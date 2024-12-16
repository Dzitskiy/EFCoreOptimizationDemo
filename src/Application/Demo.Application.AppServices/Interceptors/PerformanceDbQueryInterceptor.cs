using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Demo.Application.AppServices.Interceptors;

public class PerformanceDbQueryInterceptor : DbCommandInterceptor
{
    private readonly ILogger<PerformanceDbQueryInterceptor> _logger;

    public PerformanceDbQueryInterceptor(ILogger<PerformanceDbQueryInterceptor> logger)
    {
        _logger = logger;
    }

    public override async ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var reader = await base.ReaderExecutedAsync(command, eventData, result, cancellationToken);

        await RunPlan(command);

        return reader;
    }
        
    private async Task RunPlan(DbCommand command)
    {
        if (command?.Connection == null)
        {
            return;
        }

        try
        {
            var planCommandText = command.CommandText;

            foreach (DbParameter parameter in command.Parameters)
            {
                var value = parameter.Value;
                if (value is Array)
                {
                    var elementType = value.GetType().GetElementType();

                    var array = elementType == typeof(string)
                        ? (value as IEnumerable<string>).Select(x => $"'{x}'").ToArray()
                        : (value as IEnumerable<int>).Select(x => x.ToString()).ToArray();

                    var strArray = string.Join(',', array);
                    planCommandText = planCommandText.Replace(parameter.ParameterName, $"array[{strArray}]");
                    continue;
                }

                var parameterValue = value is string
                    ? "'" + value + "'"
                    : value?.ToString() ?? "";

                planCommandText = planCommandText.Replace(parameter.ParameterName, parameterValue);
            }

            planCommandText = "explain (summary on) " + planCommandText;

            await using var planConnection = new NpgsqlConnection(command.Connection.ConnectionString);
            var planCommand = planConnection.CreateCommand();
            planCommand.CommandText = planCommandText;

            await planConnection.OpenAsync();
            var planReader = await planCommand.ExecuteReaderAsync();

            var planResultBuilder = new StringBuilder();
            while (await planReader.ReadAsync()) planResultBuilder.Append(planReader[0] + "\r\n");

            _logger.LogInformation("   ---   План выполнения запроса   ---   \r\n" + planResultBuilder);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "В процессе выполнения плана запроса произошла ошибка.");
        }
    }
}
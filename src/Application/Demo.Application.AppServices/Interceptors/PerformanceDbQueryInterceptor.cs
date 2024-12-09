using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Text;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Demo.Application.AppServices.Interceptors
{
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

            var planCommandText = command.CommandText;

            foreach (DbParameter parameter in command.Parameters)
            {
                var parameterValue = parameter.Value is string
                    ? "'" + parameter.Value + "'"
                    : parameter.Value?.ToString() ?? "";

                planCommandText = planCommandText.Replace(parameter.ParameterName, parameterValue);
            }

            planCommandText = "explain " + planCommandText;

            await using var planConnection = new NpgsqlConnection(command.Connection.ConnectionString);
            var planCommand = planConnection.CreateCommand();
            planCommand.CommandText = planCommandText;

            await planConnection.OpenAsync();
            var planReader = await planCommand.ExecuteReaderAsync();

            var planResultBuilder = new StringBuilder();
            while (await planReader.ReadAsync()) planResultBuilder.Append(planReader[0] + "\r\n");

            _logger.LogInformation("   ---   План выполнения запроса   ---   \r\n" + planResultBuilder);
        }
    }
}

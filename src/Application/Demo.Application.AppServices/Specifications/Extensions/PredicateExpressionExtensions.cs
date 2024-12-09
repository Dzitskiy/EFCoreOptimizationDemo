using System.Linq.Expressions;

namespace Demo.Application.AppServices.Specifications.Extensions
{
    /// <summary>
    /// Набор расширений для предикатов.
    /// </summary>
    public static class PredicateExpressionExtensions
    {
        /// <summary>
        /// Выполняет композицию выражений.
        /// </summary>
        /// <param name="left">Первое выражение.</param>
        /// <param name="right">Правое выражение.</param>
        /// <param name="compose">Операция композиции.</param>
        /// <typeparam name="T">Тип делегата.</typeparam>
        /// <returns>Скомпонованное выражение.</returns>
        public static Expression<T> Compose<T>(this Expression<T> left, Expression<T> right,
            Func<Expression, Expression, Expression> compose)
        {
            var rightBody = ParameterRebinderExpressionVisitor.RebindParameters(left, right);
            return Expression.Lambda<T>(compose(left.Body, rightBody), left.Parameters);
        }

        /// <summary>
        /// Выполняет логическую операцию "И" над предикатами.
        /// </summary>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.AndAlso);
        }

        /// <summary>
        /// Выполняет логическую операцию "ИЛИ" над предикатами.
        /// </summary>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return left.Compose(right, Expression.OrElse);
        }

        /// <summary>
        /// Выполняет отрицание предиката.
        /// </summary>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.Not(expression.Body), 
                expression.Parameters);
        }
    }
}
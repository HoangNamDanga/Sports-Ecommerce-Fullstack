using System.Linq.Expressions;

namespace WebSport24hNews.HoangNam.Core.Extensions
{
    public static class DynamicSorting
    {

        //goi phan trang
        public static Expression<Func<TEntity, object>> GetPropertyGetter<TEntity>(this string property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity));
            Expression nestedProperty = GetNestedProperty(parameterExpression, property);
            UnaryExpression body = Expression.Convert(nestedProperty, typeof(object));
            return Expression.Lambda<Func<TEntity, object>>(body, new ParameterExpression[1] { parameterExpression });
        }

        private static Expression GetNestedProperty(ParameterExpression param, string propertyPath)
        {
            Expression expression = param;
            string[] array = propertyPath.Split('.');
            foreach (string propertyOrFieldName in array)
            {
                expression = Expression.PropertyOrField(expression, propertyOrFieldName);
            }

            return expression;
        }
    }
}

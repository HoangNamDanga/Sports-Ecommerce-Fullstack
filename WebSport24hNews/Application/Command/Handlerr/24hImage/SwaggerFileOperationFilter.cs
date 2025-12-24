using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;

namespace WebSport24hNews.Application.Command.Handlerr._24hImage
{

    //class custom upload ảnh
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = context.MethodInfo.GetParameters();

            // Lấy DTO type (giả sử chỉ có 1 tham số kiểu class chứa IFormFile)
            var dtoParameter = parameters.FirstOrDefault(p =>
                p.ParameterType.GetProperties().Any(prop => prop.PropertyType == typeof(IFormFile)));

            if (dtoParameter == null) return;

            var dtoType = dtoParameter.ParameterType;

            // Tạo schema properties cho tất cả các property trong DTO
            var properties = new Dictionary<string, OpenApiSchema>();

            foreach (var prop in dtoType.GetProperties())
            {
                if (prop.PropertyType == typeof(IFormFile))
                {
                    // File upload
                    properties.Add(prop.Name, new OpenApiSchema
                    {
                        Type = "string",
                        Format = "binary"
                    });
                }
                else
                {
                    // Các field khác, map sang string (hoặc kiểu khác nếu muốn phức tạp hơn)
                    properties.Add(prop.Name, new OpenApiSchema
                    {
                        Type = MapClrTypeToOpenApiType(prop.PropertyType),
                        Nullable = IsNullable(prop)
                    });
                }
            }

            operation.Parameters.Clear();

            operation.RequestBody = new OpenApiRequestBody
            {
                Content =
            {
                ["multipart/form-data"] = new OpenApiMediaType
                {
                    Schema = new OpenApiSchema
                    {
                        Type = "object",
                        Properties = properties,
                        Required = properties.Keys.ToHashSet()
                    }
                }
            }
            };
        }

        private bool IsNullable(System.Reflection.PropertyInfo prop)
        {
            var nullable = Nullable.GetUnderlyingType(prop.PropertyType) != null;
            var requiredAttr = prop.GetCustomAttributes(typeof(RequiredAttribute), false).Any();
            return nullable || !requiredAttr;
        }

        private string MapClrTypeToOpenApiType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;
            if (type == typeof(string)) return "string";
            if (type == typeof(int) || type == typeof(long) || type == typeof(short)) return "integer";
            if (type == typeof(float) || type == typeof(double) || type == typeof(decimal)) return "number";
            if (type == typeof(bool)) return "boolean";
            if (type == typeof(DateTime)) return "string"; // date-time format có thể thêm nếu cần
            return "string"; // default
        }
    }
}


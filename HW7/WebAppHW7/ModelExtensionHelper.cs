using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppMVC
{
    public static class HtmlContentExtensions
    {
        public static IHtmlContent CustomEditor(this IHtmlHelper helper) =>
            new FormContent(helper.ViewData.Model! ?? helper.ViewData.ModelMetadata.ModelType
                .GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>()));

        private class FormContent : IHtmlContent
        {
            private readonly string resultContent;

            void IHtmlContent.WriteTo(TextWriter writer, HtmlEncoder encoder) =>
                writer.WriteLine(resultContent);

            public FormContent(object model) =>
                resultContent = SetContent(model.GetType().GetProperties(), model);

            private static string SetContent(IEnumerable<PropertyInfo> propertyInfos, object model) =>
                propertyInfos
                    .Select(x =>
                        SetHeader(x) +
                        "<div class=\"editor-field\">" +
                        SetBody(x, model) +
                        "</div>")
                    .Aggregate(string.Concat);

            private static string SetHeader(PropertyInfo property) =>
                $"<div class=\"editor-label\"><label for=\"{property.Name}\">" +
                $"{((DisplayAttribute) property.GetCustomAttribute(typeof(DisplayAttribute)))?.Name ?? FromCamelCase(property.Name)}" +
                $"</label></div>";

            private static string FromCamelCase(string str) =>
                str.Skip(1).Aggregate(str[0].ToString(),
                    (current, t) => current + (char.IsUpper(t) ? $" {char.ToLower(t)}" : t));

            private static string SetBody(PropertyInfo property, object model) =>
                SetInput(property) + SetSpan(property, model);

            private static string SetInput(PropertyInfo property) =>
                property.PropertyType.IsAssignableTo(typeof(Enum))
                    ? "<select class=\"form-group\">"
                      + $"<option selected>{property.Name}</option>"
                      + property.PropertyType
                          .GetFields()
                          .Where(m => m.Name != "value__")
                          .Select(field => $"<option value=\"{field.Name}\">{field.Name}</option>")
                          .Aggregate(string.Concat)
                      + "</select>"
                    : IsNumber(property.PropertyType)
                        ? $"<input class=\"text-box single-line\" type=\"number\" name=\"{property.Name}\">"
                        : $"<input class=\"text-box single-line\" type=\"text\" name=\"{property.Name}\">";

            private static string SetSpan(PropertyInfo property, object model)
            {
                var result =
                    $"<span class=\"field-validation-error\" data-valmsg-for=\"{property.Name}\" data-valmsg-replace=\"true\">";
                var attribute = (ValidationAttribute) property.GetCustomAttribute(typeof(ValidationAttribute));
                result += !attribute?.IsValid(property.GetValue(model))! ?? false
                    ? attribute.ErrorMessage! ?? attribute.FormatErrorMessage(property.Name)
                    : string.Empty;
                result += $"</span>";
                return result;
            }

            private static readonly Type[] NumberTypes =
            {
                typeof(int), typeof(int?),
                typeof(uint), typeof(uint?),
                typeof(short), typeof(short?),
                typeof(ushort), typeof(ushort?),
                typeof(long), typeof(long?),
                typeof(ulong), typeof(ulong?),
                typeof(nint), typeof(nint?),
                typeof(byte), typeof(byte?),
                typeof(float), typeof(float?),
                typeof(double), typeof(double?),
                typeof(decimal), typeof(decimal?)
            };

            private static bool IsNumber(Type type) => NumberTypes.Any(type.IsAssignableTo);

        }
    }
}
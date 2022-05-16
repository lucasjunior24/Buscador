using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Buscador.Extensions
{
    public static class EnumHelper
    {
        public static string GetDescription<TEnum>(this TEnum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

        public static SelectList CriarListaDeEnum<TEnum>()
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { Id = e, Name = e.GetDescription() };
            return new SelectList(values, "Id", "Name", 1);
        }

        public static SelectList CriarListaDeEnumComExcecao<TEnum>(this TEnum valor)
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum)) select new { Id = e, Name = e.GetDescription() };
            return new SelectList(values.Where(x => !x.Id.Equals(valor)), "Id", "Name", 1);
        }

        public static T ParseEnum<T>(string value) => (T)Enum.Parse(typeof(T), value, true);

        public static string GetDisplayName(this Enum val)
        {
            return val.GetType()
                      .GetMember(val.ToString())
                      .FirstOrDefault()
                      ?.GetCustomAttribute<DisplayAttribute>(false)
                      ?.Name
                      ?? val.ToString();
        }
    }
}

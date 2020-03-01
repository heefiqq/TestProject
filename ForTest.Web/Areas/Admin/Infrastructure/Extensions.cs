using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace ForTest.Web.Admin.Infrastructure
{
    public static class Extensions
    {
        public static string UrlDate(this DateTime? val)
        {
            return val.HasValue ? val.Value.ToString("dd.MM.yyyy") : null;
        }

        public static IEnumerable<SelectListItem> ToLocalisedSelectItem<TEnum>(this TEnum obj)
        {
            var typeE = typeof(TEnum);
            var underlyingType = Nullable.GetUnderlyingType(typeE);

            if (underlyingType != null)
            {
                typeE = underlyingType;
            }

            var temp = Enum.GetValues(typeE)
                    .Cast<TEnum>()
                    .Select(x => new SelectListItem
                    {
                        Value = (x).ToString(),
                        Text = GetEnumDisplayName(x),
                        Selected = x.Equals(obj),
                    })
                    .ToList();
            return temp;
        }

        public static string ToLocalised<TEnum>(this TEnum obj)
        {
            return GetEnumDisplayName(obj);
        }

        private static string GetEnumDisplayName<TEnum>(TEnum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DisplayNameAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            var attr = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0
                ? attributes[0].DisplayName
                : (attr.Length > 0 ? attr[0].Description : value.ToString());
        }
    }
}
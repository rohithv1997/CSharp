using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;

namespace ReleaseCompanion
{
    static class Extensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return (CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month)).Substring(0, 3);
        }

        public static string ToCSV(this List<int> list)
        {
            string result = string.Empty;
            foreach (int i in list)
            {
                result += (i.ToString() + ", ");
            }
            return result.TrimEnd().TrimEnd(',');
        }

        public static string ToCSV(this List<string> list)
        {
            string result = string.Empty;
            foreach (var i in list)
            {
                result += (i + ", ");
            }
            return result.TrimEnd().TrimEnd(',');
        }

        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}

using System;
using System.Text;

namespace Hubert.Utility.Lite.Extension
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static string DefaultIfNullOrEmpty(this string str, string defaultStr)
        {
            return IsNullOrEmpty(str) ? defaultStr : str;
        }

        public static bool Equals(this string str1, string str2)
        {
            if (str1 == null) return str2 == null;

            return str1.Equals(str2);
        }

        public static bool EqualsIgnoreCase(this string str1, string str2)
        {
            if (str1 == null) return str2 == null;

            return str1.Equals(str2,StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool Eq(this string input, string toCompare, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if (input == null)
            {
                return toCompare == null;
            }
            return input.Equals(toCompare, comparison);
        }

        public static int CnLength(this string str) { return Encoding.Default.GetBytes(str).Length; }

        public static bool ToBoolean(this string val)
        {
            if (string.IsNullOrEmpty(val)) return false;
            return val == Boolean.TrueString;
        }

        public static int ToInt(this string val,int defaultValue =0)
        {
            int intValue;
            if (int.TryParse(val, out intValue))
            {
                return intValue;
            }
            return defaultValue;
        }

        public static Guid? ToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            Guid id;
            if (Guid.TryParse(str, out id))
            {
                return id;
            }
            return null;
        }

        public static decimal ToDecimal(this string val)
        {
            decimal intValue;
            if (decimal.TryParse(val, out intValue))
            {
                return intValue;
            }
            return 0;
        }

        public static double ToDouble(this string val)
        {
            double result;
            if (double.TryParse(val, out result))
            {
                return result;
            }
            return 0;
        }

        public static float ToFloat(this string val)
        {
            float result;
            if (float.TryParse(val, out result))
            {
                return result;
            }
            return 0;
        }

        public static DateTime ToDateTime(this string val)
        {
            DateTime result;
            if (DateTime.TryParse(val, out result))
            {
                return result;
            }
            return DateTime.MinValue;
        }

        //public static T If<T>(this T t, Predicate<T> predicate, Action<T> action) where T : class
        //{
        //    if (t == null) throw new ArgumentNullException();
        //    if (predicate(t)) action(t);
        //    return t;
        //}

        //public static T If<T>(this T t, Predicate<T> predicate, Action<T> action, Action<T> action2) where T : class
        //{
        //    if (t == null) throw new ArgumentNullException();
        //    if (predicate(t))
        //        action(t);
        //    else
        //        action2(t);

        //    return t;
        //}


        #region 格式化字符串

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public static string FormatWith(this string format, object args0)
        {
            return string.Format(format, args0);
        }

        #endregion

        #region FormatWith

        /// <summary>
        /// Formats a string with two literal placeholders.
        /// string s = "{0} ought to be enough for {1}.";
        ///string param0 = "64K";
        ///string param1 = "everybody";
        ///string expected = "64K ought to be enough for everybody.";
        ///Assert.AreEqual(expected, s.FormatWith(param0, param1),
        /// </summary>
        /// <param name="text">The extension text</param>
        /// <param name="args">args</param>
        /// <returns>The formatted string</returns>
        public static string FormatWith(this string text, params object[] args)
        {
            return string.Format(text, args);
        }

        #endregion

    }
}

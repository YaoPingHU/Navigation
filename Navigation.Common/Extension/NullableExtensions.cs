﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubert.Utility.Lite.Extension
{
    public static class NullableExtensions
    {
        public static T To<T>(this T? value) where T : struct
        {
            return To(value, default(T));
        }

        public static T To<T>(this T? value, T defaultValue) where T : struct
        {
            return value ?? defaultValue;
        }
    }
}

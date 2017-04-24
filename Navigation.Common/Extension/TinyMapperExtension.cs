using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;

namespace Navigation.Common.Extension
{
    public static class TinyMapperExtension
    {

        public static TNew MapperTo<T, TNew>(this T soure) where T : class
        {
            return TinyMapper.Map<T, TNew>(soure);
        }

        public static List<TNew> MapperTo<T, TNew>(this List<T> soure) where T : class
        {
            return TinyMapper.Map<List<T>, List<TNew>>(soure);
        }


    }
}

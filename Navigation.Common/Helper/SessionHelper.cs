using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Hubert.Utility.Lite.Helper;
using Newtonsoft.Json;

namespace Navigation.Common.Helper
{
    /// <summary>
    /// SessionHelper 帮助类
    /// </summary>
    public static class SessionHelper
    {

        #region 删除会话

        /// <summary>
        /// 删除会话
        /// </summary>
        /// <param name="strSessionName"></param>
        public static void Remove(string strSessionName)
        {
            HttpContext.Current.Session.Remove(strSessionName);
        }

        #endregion

        #region 增加会话

        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="obj"> </param>
        public static void Add(string strSessionName, object obj)
        {
            HttpContext.Current.Session[strSessionName] = obj;
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="obj"> </param>
        /// <param name="isSerialization">是否要序列化</param>
        public  static void Add(string strSessionName, object obj, bool isSerialization = false)
        {

            if (isSerialization)
                HttpContext.Current.Session[strSessionName] = JsonConvert.SerializeObject(obj);
            else
                HttpContext.Current.Session[strSessionName] = obj;

            HttpContext.Current.Session.Timeout = 20;
        }


        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="obj"> </param>
        /// <param name="isSerialization">是否要序列化</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Add(string strSessionName, object obj, bool isSerialization = false, int iExpires = 20 )
        {
            if (isSerialization)
                HttpContext.Current.Session[strSessionName] = JsonConvert.SerializeObject(obj);
            else
                HttpContext.Current.Session[strSessionName] = obj;

            HttpContext.Current.Session.Timeout = iExpires;
        }


        #endregion

        #region 获取会话

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static string Get(string strSessionName)
        {
            return CheckSessionExist(strSessionName) ? string.Empty : HttpContext.Current.Session[strSessionName].ToString();
        }

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="isDeserialization"></param>
        /// <returns>Session对象值</returns>
        public static T Get<T>(string strSessionName)
        {
            if (CheckSessionExist(strSessionName)) return default(T);
            var obj = Get(strSessionName);
            try
            {
                return JsonConvert.DeserializeObject<T>(obj);
            }
            catch
            {
                return default(T);
            }

            
        }

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="defaultValue"></param>
        /// <param name="isDeserialization"></param>
        /// <returns>Session对象值</returns>
        public static T Get<T>(string strSessionName, T defaultValue)
        {
            if (CheckSessionExist(strSessionName)) return defaultValue;
            var obj = Get(strSessionName);
            try
            {
                return JsonConvert.DeserializeObject<T>(obj);
            }
            catch
            {
                return default(T);
            }
        }

        public static bool CheckSessionExist(string strSessionName)
        {
            return HttpContext.Current.Session[strSessionName] == null;
        }


        #endregion


    }
}

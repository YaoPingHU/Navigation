using System;
using System.Text.RegularExpressions;

namespace Hubert.Utility.Lite.Helper
{
    /// <summary>
    /// ValidateHelper 帮助类
    /// </summary>
    public class ValidateHelper
    {
        
        #region 验是否是数字

        /// <summary>
        /// 验是否是数字
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsNum(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([+-]?)\\d*\\.?\\d+$");
        }

        #endregion

        #region 验是否是整数

        /// <summary>
        /// 整数
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIntege(string strIn)
        {
            return Regex.IsMatch(strIn, @"^-?[1-9]\\d*$");
        }

        #endregion

        #region 验证Email地址

        /// <summary>
        /// 验证Email地址 
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^((?'name'.+?)\s*<)?(?'email'(?>[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+\x20*|""(?'user'(?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*""\x20*)*(?'angle'<))?(?'user'(?!\.)(?>\.?[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+)+|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*"")@(?'domain'((?!-)[a-zA-Z\d\-]+(?<!-)\.)+[a-zA-Z]{2,}|\[(((?(?<!\[)\.)(25[0-5]|2[0-4]\d|[01]?\d?\d)){4}|[a-zA-Z\d\-]*[a-zA-Z\d]:((?=[\x01-\x7f])[^\\\[\]]|\\[\x01-\x7f])+)\])(?'angle')(?(name)>)$");
        }

        #endregion

        #region 验证是否是中英数下划线

        /// <summary>
        /// 验证是否是中英数下划线
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsNormalInput(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\u4E00-\u9FFF]|[0-9]|[A-Za-z]|[.]|[:]|[：]|[——]|[_]|[(]|[)]|[-{0,1}]|[,]|[，]|[ ]|[。])+$");
        }
        #endregion

        #region 验证是否是日期

        /// <summary>
        /// 验证是否是日期
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsDate(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\\d{4}(\\-|\\/|\.)\\d{1,2}\\1\\d{1,2}$");
        }
        #endregion

        #region 验证是否是中文

        /// <summary>
        /// 验证是否是中文
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsChinese(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$");
        }
        #endregion

        #region 验证是邮编

        /// <summary>
        /// 验证是邮编
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsZipCode(string strIn)
        {
            return Regex.IsMatch(strIn, @"^\\d{6}$");
        }
        #endregion

        #region 验证是图片

        /// <summary>
        /// 验证是图片
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsPicture(string strIn)
        {
            return Regex.IsMatch(strIn, @"(.*)\\.(jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$");
        }
        #endregion

        #region 验证是否为小数

        /// <summary>
        /// 验证是否为小数
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsDecimal(string strIn)
        {
            return Regex.IsMatch(strIn, @"[0].d{1,2}|[1]");
        }

        #endregion

        #region 验证是否是电话号码

        /// <summary>
        /// 验证是否是电话号码
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsTelNo(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$");
        }
        #endregion

        #region 验证是否是IP

        /// <summary>
        /// 验证是否是IP
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsIpV4(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)\\.(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)$");
        }
        #endregion

        #region 验证是否是 URL

        /// <summary>
        /// 验证是否是 URL
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsUrl(string strIn)
        {
            return Regex.IsMatch(strIn, "^http[s]?:\\/\\/([\\w-]+\\.)+[\\w-]+([\\w-./?%&=]*)?$");
        }
        #endregion

        #region 验证是否是手机

        /// <summary>
        /// 验证是否是手机
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsMobile(string strIn)
        {
            return Regex.IsMatch(strIn, "^(14|13|15|18)[0-9]{9}$");
        }
        #endregion

        #region 验证是否是电话

        /// <summary>
        /// 验证是否是手机
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsPhone(string strIn)
        {
            return Regex.IsMatch(strIn, "^(14|13|15|18)[0-9]{9}$") || Regex.IsMatch(strIn, "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$");
        }
        #endregion

        #region 身份证验证

        /// <summary>
        /// 验证身份证号码
        /// </summary>
        /// <param name="id">身份证号码</param>
        /// <returns>验证成功为True，否则为False</returns>
        public static bool CheckIdCard(string id)
        {
            switch (id.Length)
            {
                case 18:
                    {
                        bool check = CheckIdCard18(id);
                        return check;
                    }
                case 15:
                    {
                        bool check = CheckIdCard15(id);
                        return check;
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// 验证15位身份证号
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIdCard18(string id)
        {
            long n;
            if (long.TryParse(id.Remove(17), out  n) == false || n < Math.Pow(10, 16)
                || long.TryParse(id.Replace('x', '0').Replace('X', '0'), out  n) == false)
            {
                return false; //数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2)) == -1)
            {
                return false; //省份验证
            }
            string birth = id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time;



            if (DateTime.TryParse(birth, out  time) == false)
            {
                return false; //生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] ai = id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString());
            }
            int y;
            Math.DivRem(sum, 11, out  y);
            if (arrVarifyCode[y] != id.Substring(17, 1).ToLower())
            {
                return false; //校验码验证
            }
            return true; //符合GB11643-1999标准
        }

        /// <summary>
        /// 验证18位身份证号
        /// </summary>
        /// <param name="id">身份证号</param>
        /// <returns>验证成功为True，否则为False</returns>
        private static bool CheckIdCard15(string id)
        {
            long n;
            if (long.TryParse(id, out  n) == false || n < Math.Pow(10, 14))
            {
                return false; //数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2)) == -1)
            {
                return false; //省份验证
            }
            string birth = id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out  time) == false)
            {
                return false; //生日验证
            }
            return true; //符合15位身份证标准
        }



        #endregion
    }
}

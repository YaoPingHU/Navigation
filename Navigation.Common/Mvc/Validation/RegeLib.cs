using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Navigation.Common.Mvc.Validation
{
    public static class RegexLib
    {

        #region 验证是否是中英数下划线

        /// <summary>
        /// 标准用户的正则表达式 英文名 英文开头 数字 2-11 字符, 中文名 中文开头 英文 数字 1-11 字符
        /// </summary>
        public const string IsNormalInput = "^[a-z][A-Za-z0-9]{2,11}$|^[\u4e00-\u9fa5][\u4e00-\u9fa5A-Za-z0-9]{1,11}$";
        //  public const string IsNormalInput = "^([\u4E00-\u9fa5]|[0-9]|[A-Za-z]|[.]|[:]|[&]|[：]|[#]|[_]|[+]|[.]|[(]|[)]|[-{0,1}]|[,]|[，]||[“]|[ ]|[。])+$";
        public const string IsNormalInputErrorMsg = "只能输入中文英文数字!";
        public const string IsNormalInputErrorMsgEn = "only enter Chinese English numbers!";

        public const string IsEngAndNum = "^([0-9]|[A-Za-z])+$";
        public const string IsEngAndNumErrorMsg = "只能输入英文和数字!";
        public const string IsEngAndNumErrorMsgEn = "Only English and numbers can be entered!";

        #endregion

        #region 密码验证 标准密码的正则表示式 6-12 字符

        /// <summary>
        /// 标准密码的正则表示式 6-12 字符
        /// </summary>
        public const string Password = @"^\S{6,12}$";
        public const string PasswordErrorMsg = "密码必须是6-12 字符!";
        public const string PasswordErrorMsgEn = "The password must be 6-12 characters!";

        #endregion

        #region 标准 Email 的正则表达式

        /// <summary>
        /// 标准 Email 的正则表达式
        /// </summary>
        public const string Email = @"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$";
        public const string EmailErrorMsg = "请输入正确的邮箱格式!";
        public const string EmailErrorMsgEn = "Please enter the correct mailbox format!";

        #endregion

        #region QQ号码

        /// <summary>
        /// 标准 Oicq 的正则表示式  QQ号码
        /// 5 - 10 位数字
        /// </summary>
        public const string Oicq = @"^[0-9]{5,12}$";
        public const string OicqErrorMsg = "请输入正确QQ号码!";
        public const string OicqErrorMsgEn = "Please enter the correct QQ number!";

        #endregion

        #region 手机号码正则表达式

        /// <summary>
        /// 手机号码正则表达式
        /// </summary>
        //public const string ChineseMobile = @"^(130|131|132|133|134|135|136|137|138|139|153|156|158|159)\d{8}$";
        public const string ChineseMobile = @"^0?(13|15|18|14)[0-9]{9}$";
        public const string ChineseMobileErrorMsg = "手机号码为11位数字！";
        public const string ChineseMobileErrorMsgEn = "The phone number is 11 digits！";
        #endregion

        #region 电话号码

        /// <summary>
        /// 日期
        /// </summary>
        public const string Date = @"^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$";
        public const string DateErrorMsg = "日期不对！";
        public const string DateErrorMsgEn = "The date is incorrect！";

        public const string DateTime = @"^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)\s+([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$";
        public const string DateTimeErrorMsg = "日期不对！";
        public const string DateTimeErrorMsgEn = "The date is incorrect！！";

        #endregion

        #region 电话号码

        /// <summary>
        /// 电话号码
        /// </summary>
        public const string TelNo = @"^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";
        public const string TelNoErrorMsg = "电话号码不对！";
        public const string TelNoErrorMsgEn = "The phone number is incorrect！";

        #endregion

        #region URL

        /// <summary>
        /// URL
        /// </summary>
        public const string Url = @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$";
        public const string UrlErrorMsg = "URL地址不正确！";
        public const string UrlErrorMsgEn = "The URL address is not correct！";

        #endregion

        #region Num

        /// <summary>
        /// Date
        /// </summary>
        public const string Num = @"^([+-]?)\\d*\\.?\\d+$";
        public const string NumErrorMsg = "请输入数字！";
        public const string NumErrorMsgEn = "Please enter the number！";

        #endregion

        #region Integer

        /// <summary>
        /// Date
        /// </summary>
        public const string Int = @"^[0-9]\d*$";
        public const string IntErrorMsg = "请输入整数！";
        public const string IntErrorMsgEn = "Please enter an integer！";

        #endregion

        #region Decimal

        /// <summary>
        /// Decimal
        /// </summary>
        public const string Decimal = @"[0].d{1,2}|[1]";
        public const string DecimalErrorMsg = "请输入带小数的数字！";
        public const string DecimalErrorMsgEn = "Please enter a number with a decimal！";

        #endregion

        #region Money

        public const string Money = @"^([0-9]+|[0-9]{1,3}(,[0-9]{3})*)(.[0-9]{1,2})?$";
        public const string MoneyErrorMsg = "请输入正确的金额！";
        public const string MoneyErrorMsgEn = "Please enter the correct amount！";

        #endregion

        #region Chinese

        /// <summary>
        /// Chinese
        /// </summary>
        public const string Chinese = @"^[\u4e00-\u9fa5]+$";
        public const string ChineseErrorMsg = "只能输入中文！";
        public const string ChineseErrorMsgEn = "only enter Chinese！";

        #endregion

        #region ZIPCode

        /// <summary>
        /// Date
        /// </summary>
        public const string ZipCode = @"^\\d{6}$";
        public const string ZipCodeErrorMsg = "邮编输入错误！";
        public const string ZipCodeErrorMsgEn = "Incorrect postal code entry！";

        #endregion

        #region Picture

        /// <summary>
        /// Date
        /// </summary>
        public const string Picture = @"(.*)\\.(jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
        public const string PictureErrorMsg = "只能是图片文件！";
        public const string PictureErrorMsgEn = "only be a picture file！";

        #endregion


        /// <summary>
        /// 使用 , 分割的 ID 字符串
        /// </summary>
        public const string IdStrings = @"([\d+][,]?)+";

        internal static Regex InvalidXmlChar = new Regex("[\x00-\x08|\x0b-\x0c|\x0e-\x1f]+", RegexOptions.Compiled);


    }
}

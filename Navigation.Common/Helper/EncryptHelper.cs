using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.ComponentModel;

namespace Hubert.Utility.Lite.Helper
{
    /// <summary>
    /// 加密解密类
    /// </summary>
    public static class EncryptHelper
    {
        #region 可逆加密 & 解密算法

        /// <summary>
        /// Md5Pwd 加密
        /// </summary>
        /// <param name="orzPwd"></param>
        /// <returns></returns>
        public static string Md5Pwd(string orzPwd)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(orzPwd)), 4, 8);
        }

        public static string Md5(string orzPwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(orzPwd);
            byte[] md5Data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5Data.Length - 1; i++)
            {
                str += md5Data[i].ToString("x").PadLeft(2, '0');
            }
            return str;
        }

        public static string GetMd5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = md5.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToUpper());
            }
            return s.ToString();
        }

        #region 对称 可逆加密解密算法  DES 64位

        //默认密钥向量
        private static readonly byte[] DesKeys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        #region EncodeDES 对称加密 DES 64位

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8个字符(不足自动空格来加，超出则自动截取8位)，64位</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        public static string EncodeDes(string encryptString, string encryptKey = "HubertHu")
        {
            try
            {
                encryptKey = encryptKey.PadRight(8, ' ');
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIv = DesKeys;//也可以作为参数传递进来，然后再GetBytes （8个字符）
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCsp = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCsp.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }

        }

        #endregion

        #region DecodeDES 对称解密 DES 64位
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位(不足自动空格来加，超出则自动截取8位),和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string DecodeDes(string decryptString, string decryptKey = "HubertHu")
        {
            try
            {
                decryptKey = decryptKey.PadRight(8, ' ');
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIv = DesKeys;//也可以作为参数传递进来，然后再GetBytes （8个字符）
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider dcsp = new DESCryptoServiceProvider();

                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }

        }
        #endregion

        #endregion

        #region 对称 可逆加密解密算法 AES(用于替代DES的算法)

        //默认密钥向量
        private static readonly byte[] AesKeys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79, 0x53, 0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };

        #region AES加密
        /// <summary>
        /// AES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为32个字符(不足自动空格来加，超出则自动截取32位)</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        public static string EncodeAes(string encryptString, string encryptKey = "HubertHu")
        {
            try
            {
                encryptKey = encryptKey.PadRight(32, ' ');

                RijndaelManaged rijndaelProvider = new RijndaelManaged
                                                       {
                                                           Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
                                                           IV = AesKeys
                                                       };
                ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

                byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
                byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Convert.ToBase64String(encryptedData);
            }
            catch
            {
                return encryptString;
            }

        }
        #endregion

        #region AES解密
        /// <summary>
        /// AES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为32位(不足自动空格来加，超出则自动截取32位),和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string DecodeAes(string decryptString, string decryptKey = "HubertHu")
        {
            try
            {
                decryptKey = decryptKey.PadRight(32, ' ');

                RijndaelManaged rijndaelProvider = new RijndaelManaged
                                                       {Key = Encoding.UTF8.GetBytes(decryptKey), IV = AesKeys};
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return decryptString;
            }

        }
        #endregion

        #endregion

        #region 生成纯字母和数字的加密解密DES算法
        #region "加密"
        /// <summary>
        /// DES加密字符串 生成纯字母和数字
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8个字符(不足自动空格来加，超出则自动截取8位)，64位</param>
        /// <returns>加密成功返回加密后的字符串,失败返回源串</returns>
        public static string EncodeDesEx(string encryptString, string encryptKey = "HubertHu")
        {
            try
            {
                encryptKey = encryptKey.PadRight(8, ' ');

                byte[] keys = Encoding.UTF8.GetBytes(encryptKey);
                byte[] iVs = Encoding.UTF8.GetBytes(encryptKey);
                byte[] data = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                ICryptoTransform encrypt = des.CreateEncryptor(keys, iVs);
                byte[] result = encrypt.TransformFinalBlock(data, 0, data.Length);
                encrypt.Dispose();
                des.Clear();
                string tmpstr = BitConverter.ToString(result).Replace("-", "");
                return tmpstr;
            }
            catch
            {
                return encryptString;
            }



        }
        #endregion
        #region "解密"
        /// <summary>
        /// DES解密字符串 生成纯字母和数字
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位(不足自动空格来加，超出则自动截取8位),和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返源串</returns>
        public static string DecodeDesEx(string decryptString, string decryptKey = "HubertHu")
        {
            try
            {
                if (string.IsNullOrEmpty(decryptString))
                {
                    return "";
                }
                string tmpStr = "";
                for (int n = 0; n < decryptString.Length; n += 2)
                {
                    tmpStr += decryptString.Substring(n, 2);
                    if (n >= decryptString.Length - 2) break;
                    tmpStr += "-";
                }
                string[] datas = tmpStr.Split('-');
                byte[] values = new byte[datas.Length];
                Int32Converter i32Converter = new Int32Converter();
                for (int i = 0; i < datas.Length; i++)
                {
                    var convertFromInvariantString = i32Converter.ConvertFromInvariantString("0x" + datas[i]);
                    if (convertFromInvariantString != null)
                        values[i] = Convert.ToByte(convertFromInvariantString.ToString());
                }

                decryptKey = decryptKey.PadRight(8, ' ');

                byte[] keys = Encoding.UTF8.GetBytes(decryptKey);
                byte[] iVs = Encoding.UTF8.GetBytes(decryptKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                ICryptoTransform encrypt = des.CreateDecryptor(keys, iVs);
                byte[] result = encrypt.TransformFinalBlock(values, 0, values.Length);
                return Encoding.UTF8.GetString(result);
            }
            catch
            {
                return decryptString;
            }


        }
        #endregion
        #endregion

        #endregion

        public static string CmtsMd5Str(string convertString)
        {
            var md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(convertString)), 4, 8).Replace("-", "").ToLower();
        }
    }
}

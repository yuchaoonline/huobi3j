using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ADeeWu.HuoBi3J.Libary.Security
{
    public class DESEncrypt
    {
        // Fields
        private static string _Key = "d*^hh8yt*{}K}}}(Uf@@83hlI~<pwd?lfe?.<Dfge%>-";
        private static SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();

        // Methods
        public DESEncrypt()
        {
        }

        public DESEncrypt(string key)
        {
            _Key = key;
        }

        public static string Decrypto(string Source)
        {
            return Decrypto(Source, _Key);
        }

        public static string Decrypto(string Source, string key)
        {
            return pri_Decrypto(Source, key);
        }

        public static string Encrypto(string Source)
        {
            return pri_Encrypto(Source, _Key);
        }

        public static string Encrypto(string Source, string key)
        {
            return pri_Encrypto(Source, key);
        }

        private static byte[] GetLegalIV()
        {
            string sTemp = "E4hUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            mobjCryptoService.GenerateIV();
            int IVLength = mobjCryptoService.IV.Length;
            if (sTemp.Length > IVLength)
            {
                sTemp = sTemp.Substring(0, IVLength);
            }
            else if (sTemp.Length < IVLength)
            {
                sTemp = sTemp.PadRight(IVLength, ' ');
            }
            return Encoding.ASCII.GetBytes(sTemp);
        }

        private static byte[] GetLegalKey()
        {
            return GetLegalKey(_Key);
        }

        private static byte[] GetLegalKey(string key)
        {
            string sTemp = "1016" + key;
            mobjCryptoService.GenerateKey();
            int KeyLength = mobjCryptoService.Key.Length;
            if (sTemp.Length > KeyLength)
            {
                sTemp = sTemp.Substring(0, KeyLength);
            }
            else if (sTemp.Length < KeyLength)
            {
                sTemp = sTemp.PadRight(KeyLength, ' ');
            }
            return Encoding.ASCII.GetBytes(sTemp);
        }

        private static string pri_Decrypto(string Source, string key)
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKey(key);
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        private static string pri_Encrypto(string Source, string key)
        {
            byte[] bytIn = Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKey(key);
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            return Convert.ToBase64String(ms.ToArray());
        }

        // Properties
        public static string Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }

    }



    /// <summary>
    /// MD5加密类,注意经MD5加密过的信息是不能转换回原始数据的
    /// ,请不要在用户敏感的信息中使用此加密技术,比如用户的密码,
    /// 请尽量使用对称加密
    /// </summary>
    public class MD5Encrypt
    {
        private MD5 md5;
        public MD5Encrypt()
        {
            md5 = new MD5CryptoServiceProvider();
        }
        /// <summary>
        /// 从字符串中获取散列值
        /// </summary>
        /// <param name="str">要计算散列值的字符串</param>
        /// <returns></returns>
        public string GetMD5FromString(string str)
        {
            byte[] toCompute = Encoding.Unicode.GetBytes(str);
            byte[] hashed = md5.ComputeHash(toCompute, 0, toCompute.Length);
            return Encoding.ASCII.GetString(hashed);
        }
        /// <summary>
        /// 根据文件来计算散列值
        /// </summary>
        /// <param name="filePath">要计算散列值的文件路径</param>
        /// <returns></returns>
        public string GetMD5FromFile(string filePath)
        {
            bool isExist = File.Exists(filePath);
            if (isExist)//如果文件存在
            {
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream, Encoding.Unicode);
                string str = reader.ReadToEnd();
                byte[] toHash = Encoding.Unicode.GetBytes(str);
                byte[] hashed = md5.ComputeHash(toHash, 0, toHash.Length);
                stream.Close();
                return Encoding.ASCII.GetString(hashed);
            }
            else//文件不存在
            {
                throw new FileNotFoundException("指定的文件没有找到");
            }
        }
    }

}

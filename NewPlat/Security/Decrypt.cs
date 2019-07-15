using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewPlat.Security
{
    class Decrypt
    {
        /// <summary>
        /// 获取密码值
        /// </summary>
        /// <param name="strsalt">盐</param>
        /// <param name="strpassword">要验证明文密码</param>
        /// <param name="interactions">迭代次数</param>
        /// <returns>计算出的哈希值</returns>
        public static string Gethash(string strsalt, string strpassword, int interactions, int length)
        {
            byte[] salt = Encoding.Default.GetBytes(strsalt);
            byte[] password = Encoding.Default.GetBytes(strpassword);

            using (var hmac = new HMACSHA256())
            {
                var df = new Pbkdf2(hmac, password, salt, interactions);
                byte[] byt = df.getBytes(length);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < byt.Length; i++)
                {
                    sb.Append(byt[i].ToString("x2"));
                }
                return Convert.ToString(sb.ToString().ToUpper());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //biz bir password vereceğiz ve oda out ile dışarıya vereceğimiz 2 tane parametreyi gönderecek.
        public static void CreatePasswordHash(string password , out byte[] passwordHash ,out byte[] passwordSalt) //ona verdiğimiz passwordun hash ini oluşturacak aynı samanda saltınıda oluşturacak
        {//out dışarıya verilecek veri gibi

            //salt ve hash değerini vermemize yarıyor bu kod
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //hmac
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Encoding.UTF8.GetBytes(password) passwordun byte değerini veriyor

            }
        }

        //password hash i doğrulama metodu
        public static bool VerifyPasswordHash(string password , byte[] passwordHash, byte[] passwordSalt)//password kullanıcının girdiği parola
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //computed (hesaplanan) hash

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

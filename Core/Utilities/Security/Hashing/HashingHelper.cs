using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{

    public class HashingHelper
    {
        //out kullanarak bu fonksiyonun bu değerleri döndürebilmesini sağladık.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //hash dediğimiz gelen password vs şeyleri şifreleme demek. Salt ilede biz gelen 
            //password üzerine ekleme yaparak daha güvenli olmasını sağlıyoruz.

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //hazır fonksiyon  .net // her kullanıcı için değişir. o an kullandığı algoritma.
                passwordSalt = hmac.Key;
                //fonksiyon byte tipinde parametre  istediği için stringi Endcoding ile byte a dönüştürüyoruz.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //şifreleme yapılırken kullanılan salt ı  şifre çözülürken direk using içerisinde veriyoruzç
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //parolayı tekrar hash liyoruz çünkü hashlanmiş parolayla karşılaştırıcaz onaylamak için.
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));


                //burada iki tane hash karşılaştırılıyor tam olarak aynı çıkarsa demek ki şifre doğru.
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

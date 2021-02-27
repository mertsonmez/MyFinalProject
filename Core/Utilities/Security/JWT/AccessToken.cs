using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Erişim anahtarı demek AccessToken
    public class AccessToken
    {
        public string Token { get; set; } //Token jeton demek
        public DateTime Expiration { get; set; } //Bitiş zamanı
    }
}

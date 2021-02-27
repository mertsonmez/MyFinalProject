using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {

        //kullanıcı adı parola bir Credential dır.

        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature); // securty anahtarını kullan Algoritma olarak da SecurityAlgorithms.HmacSha512Signature kullan !!
            //anahtar olarak securityKey i kullan şifreleme olarak da Güvenlik algoritmalarından HMACSHA512 yi kullan diyoruz
        }

    }
}

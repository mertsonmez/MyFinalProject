using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //SecurityKeyHelper 
        //herşeyi bir byte array formatında veriyor olmamız gerekiyor

        //Microsoft.IdendityModel.Tokens ı projemize ekliyoruz Nuget Package Managerdan ekliyoruz!!

        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //keyler symetric ve asymetric olarak ayrılıyor ARAŞTIR !!

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }



    }
}

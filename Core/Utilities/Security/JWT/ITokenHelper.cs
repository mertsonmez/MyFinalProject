using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

        //eğer veriler(username password gibi) doğruysa ilgili kullanıcı için veritabanına gidicek
        //claimlerini buluşturacak
        //oradan sonra bir token üretecek ve bilgileri girişe vericek !
    }
}

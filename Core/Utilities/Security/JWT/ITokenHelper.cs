using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanıcı uygulamadan şifresini vs girdiğinde eğer doğruysa bu çalışacaka ve token oluşturup 
        //kullanıcıya vericek.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}

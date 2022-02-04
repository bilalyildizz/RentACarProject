using System;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        //verilen token için bitiş vakti.
        public DateTime Expiration { get; set; }
    }
}

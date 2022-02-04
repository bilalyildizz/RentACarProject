namespace Core.Utilities.Security.JWT
{
    // bu sınıfı web apı içerisidndeeki appseting kısından okuduklarımız nesneye atayabilmek için oluşturduk.
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

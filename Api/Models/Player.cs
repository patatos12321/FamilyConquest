using FamilyConquest.Repositories;
using LiteDB;

namespace FamilyConquest.Models
{
    [CollectionName(DbCollectionNames.Player)]
    public class Player(string username, string hashedPassword) : IDocument
    {
        [BsonId]
        public int Id { get; set; }
        public string Username { get; set; } = username;
        private string HashedPassword { get; set; } = hashedPassword;
        private string TempToken { get; set; } = GenerateAuthToken();
        private DateTime TokenExpiration { get; set; }
        public bool IsValidPassword(string hashedPassword) => hashedPassword == HashedPassword;
        public bool IsValidToken(string token) => TempToken == token && TokenExpiration > DateTime.Now;
        public string RefreshAuthToken()
        {
            TokenExpiration = DateTime.Now.AddDays(1);
            return TempToken = GenerateAuthToken();
        }

        private static string GenerateAuthToken()
        {
            return "MyTokenIs" + Guid.NewGuid();
        }
    }
}

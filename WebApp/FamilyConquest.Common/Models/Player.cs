using FamilyConquest.Common.Repositories;
using LiteDB;

namespace FamilyConquest.Common.Models
{
    [CollectionName(DbCollectionNames.Player)]
    public class Player : IDocument
    {
        public Player()
        {
            Username = string.Empty;
            HashedPassword = string.Empty;
        }
        public Player(string username, string hashedPassword)
        {
            Username = username;
            HashedPassword = hashedPassword;
        }

        [BsonId]
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        private string TempToken { get; set; } = GenerateAuthToken();
        private DateTime TokenExpiration { get; set; }
        public bool IsBot { get; set; } = false;
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

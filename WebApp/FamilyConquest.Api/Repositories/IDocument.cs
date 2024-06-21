using LiteDB;

namespace FamilyConquest.Repositories
{
    public interface IDocument
    {
        [BsonId]
        public int Id { get; set; }
    }
}

using LiteDB;

namespace FamilyConquest.Common.Repositories
{
    public interface IDocument
    {
        [BsonId]
        public int Id { get; set; }
    }
}

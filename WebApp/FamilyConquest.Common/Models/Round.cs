using FamilyConquest.Common.Repositories;
using LiteDB;

namespace FamilyConquest.Common.Models
{
    public class Round
    {
        public Round()
        {
            
        }

        public int Nb { get; set; } = 1;
        [BsonRef(DbCollectionNames.Player)]
        public int WinnerId { get; set; }
    }
}

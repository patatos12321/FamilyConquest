using FamilyConquest.Common.Repositories;
using LiteDB;

namespace FamilyConquest.Common.Models
{
    [CollectionName(DbCollectionNames.Challenge)]
    public class Challenge : IDocument
    {
        public Challenge()
        {
            
        }

        [BsonId]
        public int Id { get; set; }
        [BsonRef(DbCollectionNames.Player)]
        public int ChallengerId { get; set; }
        [BsonRef(DbCollectionNames.Player)]
        public int ChallengeeId { get; set; }
        public bool Finished { get; set; } = false;
        public List<Round> Rounds { get; set; } = [];
        public int NbRounds { get; set; } = 8;

        public bool IsFinished => Rounds.Count == NbRounds;
        public bool IsBotFight => ChallengeeId == 0;
    }
}

using FamilyConquest.Common.Models.Cards.Shared;
using FamilyConquest.Common.Repositories;
using LiteDB;

namespace FamilyConquest.Common.Models
{
    [CollectionName(DbCollectionNames.Challenge)]
    public class Challenge : IDocument
    {
        [BsonId]
        public int Id { get; set; }
        [BsonRef(DbCollectionNames.Player)]
        public Player Challenger { get; set; } = null!;
        [BsonRef(DbCollectionNames.Player)]
        public Player Challengee { get; set; } = null!;
        public bool Finished { get; set; } = false;
        public List<Round> Rounds { get; set; } = [];
        public int NbRounds { get; set; } = 8;
        public ChallengeState ChallengeState { get; set; } = ChallengeState.Drafting;

        public bool IsFinished => Rounds.Count == NbRounds && Rounds.FirstOrDefault(r => r.Nb == NbRounds)?.Winner != null;
        public bool IsBotFight => Challengee == null;
    }
}

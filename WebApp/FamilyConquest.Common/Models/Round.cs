using FamilyConquest.Common.Models.Cards;
using FamilyConquest.Common.Repositories;
using LiteDB;

namespace FamilyConquest.Common.Models
{
    public class Round
    {
        public const int NbDraftPicks = 2;

        public int Nb { get; set; } = 1;
        public bool Finished { get; set; } = false;

        [BsonRef(DbCollectionNames.Player)]
        public Player? Winner { get; set; }
        public Dictionary<int, List<ICard>> ProposedCardsPerPlayerId { get; set; } = [];
        public Dictionary<int, List<ICard>> PickedCardsPerPlayerId { get; set; } = [];
        public Dictionary<int, List<ICard>> RemovedCardsPerPlayerId { get; set; } = [];
        public Dictionary<int, Deck> DecksPerPlayerId { get; set; } = [];
    }
}

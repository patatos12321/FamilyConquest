using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class Doby : ICard
    {

        public CardIds CardId => CardIds.Doby;

        public string Name => "Doby";

        public int Power => 0;

        public string PhotoName => Name;

        public Tribes[] Tribes => [Shared.Tribes.Animal];

        public Rarity Rarity => Rarity.Rare;
    }
}

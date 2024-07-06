using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class Rat: ICard
    {

        public CardIds CardId => CardIds.Rat;

        public string Name => "Rat";

        public int Power => 1;

        public string PhotoName => Name;

        public Tribes[] Tribes => [Shared.Tribes.Animal];

        public Rarity Rarity => Rarity.Starter;
    }
}

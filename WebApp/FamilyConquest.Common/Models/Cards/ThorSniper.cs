using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class ThorSniper: ICard
    {

        public CardIds CardId => CardIds.ThorSniper;

        public string Name => "ThorSniper";

        public int Power => 0;

        public string PhotoName => Name;

        public Tribes[] Tribes => [Shared.Tribes.Animal];

        public Rarity Rarity => Rarity.Rare;
    }
}

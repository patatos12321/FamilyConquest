using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class Brutus: ICard
    {

        public CardIds CardId => CardIds.Brutus;

        public string Name => "Brutus";

        public int Power => 4;

        public string PhotoName => Name;

        public Tribes[] Tribes => [Shared.Tribes.Animal];

        public Rarity Rarity => Rarity.Common;
    }
}

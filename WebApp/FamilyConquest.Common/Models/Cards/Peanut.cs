using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class Peanut: ICard
    {

        public CardIds CardId => CardIds.Peanut;

        public string Name => "Peanut";

        public int Power => 3;

        public string PhotoName => Name;

        public Tribes[] Tribes => [Shared.Tribes.Animal];

        public Rarity Rarity => Rarity.Starter;
    }
}

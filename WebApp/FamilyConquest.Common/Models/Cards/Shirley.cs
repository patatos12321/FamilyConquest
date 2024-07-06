using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class Shirley: ICard
    {

        public CardIds CardId => CardIds.Shirley;

        public string Name => "Shirley";

        public int Power => 2;

        public string PhotoName => Name;

        public Tribes[] Tribes => [Shared.Tribes.Animal];

        public Rarity Rarity => Rarity.Starter;
    }
}

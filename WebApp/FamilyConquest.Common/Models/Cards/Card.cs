using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public class Card(CardIds cardId, string name, int power, string photoName, Tribes[] tribes, Rarity rarity)
    {
        public CardIds CardId { get; init; } = cardId;
        public string Name { get; private set; } = name;
        public int Power { get; private set; } = power;
        public string PhotoName { get; private set; } = photoName;
        public Tribes[] Tribes { get; private set; } = tribes;
        public Rarity Rarity { get; private set; } = rarity;
    }
}

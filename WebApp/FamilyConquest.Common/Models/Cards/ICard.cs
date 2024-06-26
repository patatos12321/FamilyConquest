using FamilyConquest.Common.Models.Cards.Shared;

namespace FamilyConquest.Common.Models.Cards
{
    public interface ICard
    {
        CardIds CardId { get; }
        string Name { get; }
        int Power { get; }
        string PhotoName { get; }
        Tribes[] Tribes { get; }
        Rarity Rarity { get; }
    }
}

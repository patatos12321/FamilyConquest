using FamilyConquest.Common.Models.Cards;

namespace FamilyConquest.Common.Models
{
    public class Deck: List<ICard>
    {
        public static Deck StarterDeck => [new Rat(), new Rat(), new Rat(), new Shirley(), new Peanut()];   
    }
}

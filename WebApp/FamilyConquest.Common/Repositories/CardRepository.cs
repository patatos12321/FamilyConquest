using FamilyConquest.Common.Models.Cards;
using FamilyConquest.Common.Models.Cards.Shared;
using LiteDB;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace FamilyConquest.Common.Repositories
{
    public class CardRepository()
    {
        public CardList GetStarterDeck()
        {

        }

        public CardList LoadAllUniqueCards() {
            var potentialCards = Directory.GetFiles("", "*.json", new EnumerationOptions() { RecurseSubdirectories = true });
            foreach (var potentialCard in potentialCards)
            {
                if (Enum.TryParse<CardIds>)
                {

                }
            }
        }
    }
}

namespace FamilyConquest.Repositories
{
    public static class DbCollectionNames
    {
        public const string Player = "players";
        public const string Challenge = "challenges";
        //Round may be embedded inside challenges
        public const string Round = "rounds";
        //I think matches and matchEvents will be embedded inside the round
    }
}

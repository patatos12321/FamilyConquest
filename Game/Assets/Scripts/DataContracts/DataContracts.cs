namespace DataContracts
{
    public class Challenge
    {
        public int Id { get; set; }
        public int ChallengerId { get; set; }
        public int ChallengeeId { get; set; }
    }

    public class Player
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
    }
}
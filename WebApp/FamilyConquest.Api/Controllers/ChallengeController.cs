using FamilyConquest.Common.Models;
using FamilyConquest.Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FamilyConquest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController(ILogger<ChallengeController> logger, IRepository<Challenge> challengeRepository, IRepository<Player> playerRepository) : ControllerBase
    {

        [HttpPut]
        public IActionResult ChallengeCpu([FromHeader] string authToken, [FromBody] int challengeeId)
        {
            var connectedPlayer = GetPlayer(authToken);
            if (connectedPlayer == null) { return Unauthorized(); }

            var challengee = GetPlayer(challengeeId);
            if (challengee == null) { return BadRequest(); }

            var existingPendingChallenges = challengeRepository.GetAll().Where(c => c.Challenger.Id == connectedPlayer.Id && !c.IsFinished);
            if (existingPendingChallenges.Any()) { return BadRequest(); }

            var challenge = new Challenge
            {
                Challenger = connectedPlayer,
                Challengee = challengee
            };
            challenge.PrepareNewRound();

            challengeRepository.Save(challenge);
            return Ok(challenge);
        }

        [HttpGet]
        public IActionResult ListPendingChallenges([FromHeader] string authToken)
        {
            var player = GetPlayer(authToken);
            if (player == null) { return Unauthorized(); }
            return Ok(challengeRepository.GetAll().Where(c => c.Challenger.Id == player.Id || c.Challengee.Id == player.Id && !c.IsFinished));
        }

        private Player? GetPlayer(string authToken) => playerRepository.GetAll().FirstOrDefault(p => p.IsValidToken(authToken));

        private Player? GetPlayer(int id) => playerRepository.GetAll().FirstOrDefault(p => p.Id == id);
    }
}

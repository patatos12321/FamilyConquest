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
            var player = GetPlayer(authToken);
            if (player == null) { return Unauthorized(); }

            var existingPendingChallenges = challengeRepository.GetAll().Where(c => c.ChallengerId == player.Id && !c.Finished);
            if (existingPendingChallenges.Any()) { return BadRequest(); }

            var challenge = new Challenge
            {
                ChallengerId = player.Id,
                ChallengeeId = challengeeId,
                Finished = false,
            };

            challengeRepository.Save(challenge);
            return Ok(challenge);
        }

        [HttpGet]
        public IActionResult ListPendingChallenges([FromHeader] string authToken)
        {
            var player = GetPlayer(authToken);
            if (player == null) { return Unauthorized(); }
            return Ok(challengeRepository.GetAll().Where(c => c.ChallengerId == player.Id || c.ChallengeeId == player.Id && !c.Finished));
        }

        private Player? GetPlayer(string authToken)
        {
            return playerRepository.GetAll().FirstOrDefault(p => p.IsValidToken(authToken));
        }
    }
}

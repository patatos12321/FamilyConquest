using FamilyConquest.Models;
using FamilyConquest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FamilyConquest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController(ILogger<PlayerController> logger, GenericRepository<Player> repository) : ControllerBase
    {

        [HttpPost(Name = "Register")]
        public IActionResult Register(string username, string hashedPassword)
        {
            var existingPlayers = repository.GetAll();
            if (existingPlayers.Any(e => e.Username == username))
            {
                logger.LogInformation("Someone tried to recreate the '{username}' user", username);
                return BadRequest();
            }
            repository.Save(new Player(username, hashedPassword));
            logger.LogInformation("Saved a new user '{username}'", username);
            return Ok();
        }

        [HttpPost(Name = "Login")]
        public IActionResult Login(string username, string hashedPassword)
        {
            var existingPlayers = repository.GetAll();
            var loggedPlayer = existingPlayers.FirstOrDefault(p => p.Username == username && p.IsValidPassword(hashedPassword));
            if (loggedPlayer == null)
            {
                logger.LogWarning("Unsuccessful login for '{username}'", username);
                return BadRequest();
            }
            return Ok(new LoggedPlayer(loggedPlayer.Id, loggedPlayer.RefreshAuthToken()));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }
    }

    public class LoggedPlayer(int Id, string authToken)
    {
        public int Id = Id;
        public string AuthToken = authToken;
    }
}

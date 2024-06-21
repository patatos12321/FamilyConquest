using FamilyConquest.Models;
using FamilyConquest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FamilyConquest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController(ILogger<PlayerController> logger, IRepository<Player> repository) : ControllerBase
    {

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisteringPlayer rp)
        {
            var existingPlayers = repository.GetAll();
            if (existingPlayers.Any(e => e.Username == rp.Username))
            {
                logger.LogInformation("Someone tried to recreate the '{username}' user", rp.Username);
                return BadRequest();
            }
            repository.Save(new Player(rp.Username, rp.HashedPassword));
            logger.LogInformation("Saved a new user '{username}'", rp.Username);
            return Ok();
        }

        [HttpPost("Login")]
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

        //This does Player/Test1
        [HttpGet("Test1")]
        public IActionResult Test1(string username, string hashedPassword)
        { return Ok(); }

        //This does /Test2
        [HttpGet("/Test2")]
        public IActionResult Test2(string username, string hashedPassword)
        { return Ok(); }
    }

    public class LoggedPlayer(int Id, string authToken)
    {
        public int Id = Id;
        public string AuthToken = authToken;
    }
    public class RegisteringPlayer(string username, string hashedPassword)
    {
        public string Username = username;
        public string HashedPassword = hashedPassword;
    }
}

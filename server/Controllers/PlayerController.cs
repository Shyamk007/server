using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace PlayerController;

using DAL;
using BOL;

[ApiController]
[Route("api/[controller]")]

public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [EnableCors()]
    public IEnumerable<Player> GetAllPlayers()
    {
        List<Player> players = PlayerDataAccess.GetAllPlayers();
        return players;
    }


    [HttpPost]
    [EnableCors()]
    public IActionResult InsertNewPlayer(Player player){
        PlayerDataAccess.SaveNewPlayer(player);
        return Ok(new {message = "User Created"});
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]

    public ActionResult<Player> DeleteOnePlayer(int id){
        PlayerDataAccess.DeletePlayerById(id);
        return Ok(new {message = "User deleted"});
    }
}
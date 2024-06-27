using Microsoft.AspNetCore.Mvc;

namespace CometeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FolderController : ControllerBase
{
    public FolderController()
    {

    }
    
    [HttpGet("")]
    public IActionResult index()
    {
        string response = "Récupère tous les dossiers d'un utilisateur";
        return Ok(response);
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Deck.Api.Controllers
{
    /// <summary>
    /// Deck manage controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
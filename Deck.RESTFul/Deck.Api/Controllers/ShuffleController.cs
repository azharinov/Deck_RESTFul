using Deck.Api.Models;
using Deck.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;
using System.Linq;
using System.Threading.Tasks;

namespace Deck.Api.Controllers
{
    /// <summary>
    /// Контроллер тасования колод.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShuffleController : MainController
    {
        public ShuffleController(Services services, ResponseMapper mapper, ILinksService linksService) 
            : base(services, mapper, linksService) { }

        [HttpPost("deck", Name = "shuffle-deck")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ShuffleDeck([FromBody] ShuffleRequest request)
        {
            var decks = await Services.DeckService.Find(request.DeckName);

            if (!decks.Any())
            {
                return NotFound(string.Format(Resource.DeckNotFound, request.DeckName));
            }

            if(decks.Count() > 1)
            {
                return BadRequest(string.Format(Resource.MultiplyDeckNames, request.DeckName));
            }

            var deck = decks.First();

            deck = await Services.ShuffleService.Shuffle(deck);
            await Services.DeckService.Update(deck);

            var response = Mapper.MapToDeckHeader(deck);

            await LinksService.AddLinksAsync(response);

            return Ok(response);
        }
    }
}
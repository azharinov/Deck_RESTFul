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
    /// Контроллер управления колодами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : MainController
    {
        public DeckController(Services services, ResponseMapper mapper, ILinksService linksService)
            : base(services, mapper, linksService) { }

        [HttpGet(Name = "get-decks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDecks()
        {
            var decks = await Services.DeckService.FindAll();

            var response = decks.Select(d => Mapper.MapToDeckHeader(d)).ToArray();
            
            foreach(var r in response)
            {
                await LinksService.AddLinksAsync(r);
            }

            return Ok(response);
        }

        [HttpGet("{deckName}", Name = "get-deck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDeck([FromRoute] string deckName)
        {
            var decks = await Services.DeckService.Find(deckName);

            if (!decks.Any())
            {
                return NotFound(string.Format(Resource.DeckNotFound, deckName));
            }

            if(decks.Count() > 1)
            {
                return BadRequest(string.Format(Resource.MultiplyDeckNames, deckName));
            }

            var response = Mapper.MapToDeck(decks.First());
            await LinksService.AddLinksAsync(response);

            return Ok(response);
        }

        [HttpPost(Name = "create-deck")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateDeck([FromBody] CreateDeckRequest request)
        {
            var decks = await Services.DeckService.Find(request.DeckName);
            if (decks.Any())
            {
                return BadRequest(string.Format(Resource.DeckAlreadyExists, request.DeckName));
            }

            await Services.DeckService.Create(request.DeckName);

            decks = await Services.DeckService.Find(request.DeckName);

            var response = Mapper.MapToDeck(decks.First());
            await LinksService.AddLinksAsync(response);

            return CreatedAtAction(nameof(CreateDeck), response);
        }

        [HttpDelete("{deckName}", Name = "delete-deck")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteDeck([FromRoute] string deckName)
        {
            await Services.DeckService.Delete(deckName);

            return NoContent();
        }
    }
}
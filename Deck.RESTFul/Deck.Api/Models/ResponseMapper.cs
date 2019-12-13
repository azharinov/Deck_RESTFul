using Deck.Logic.Interfaces.Entities;
using System.Linq;

namespace Deck.Api.Models
{
    public class ResponseMapper
    {
        public DeckHeaderResponse MapToDeckHeader(IDeck deck)
        {
            return new DeckHeaderResponse
            {
                DeckName = deck.Name
            };
        }

        public DeckResponse MapToDeck(IDeck deck)
        {
            return new DeckResponse
            {
                DeckName = deck.Name,
                Cards = deck.Cards().Select(c => c.Present()).ToArray()
            };
        }
    }
}

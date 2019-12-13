using RiskFirst.Hateoas.Models;
using System.Collections.Generic;

namespace Deck.Api.Models
{
    public class DeckResponse: ILinkContainer
    {
        public string DeckName { get; set; }

        public string[] Cards { get; set; }

        public Dictionary<string, Link> Links { get; set; } = new Dictionary<string, Link>();

        public void AddLink(string id, Link link)
        {
            Links.Add(id, link);
        }
    }
}

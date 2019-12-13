using Deck.Logic.Entities;
using Deck.Logic.Interfaces.Entities;
using Deck.Logic.Interfaces.Services;
using Deck.Logic.Interfaces.Storages;
using Deck.Logic.Settings;
using Deck.Logic.Storages;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deck.Logic.Services
{
    /// <summary>
    /// Сервис по управлению колодами.
    /// </summary>
    public class DeckService : IDeckService<IDeck>
    {
        /// <summary>
        /// Хранилище колод.
        /// </summary>
        private readonly IDeckStorage<Guid, DeckDTO> _storage;

        /// <summary>
        /// Настройки для сервиса.
        /// </summary>
        private readonly IOptionsMonitor<DeckSettings> _settings;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        /// <param name="storage">Хранилище колод.</param>
        public DeckService(IDeckStorage<Guid, DeckDTO> storage, IOptionsMonitor<DeckSettings> settings)
        {
            _storage = storage;
            _settings = settings;
        }

        /// <summary>
        /// Найти все колоды.
        /// </summary>
        public async Task<IEnumerable<IDeck>> FindAll()
        {
            var decks = new List<IDeck>();

            var dtos = await _storage.GetAll();
            if (dtos.Any())
            {
                decks.AddRange(dtos.Select(d => MapDeckFromDTO(d)));
            }

            return decks;
        }

        /// <summary>
        /// Создать колоду.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        public async Task<Guid> Create(string name)
        {
            var deck = DeckEntity.GenerateDeck(name, _settings.CurrentValue.Size);

            var dto = MapDeckToDTO(Guid.NewGuid(), deck);
            await _storage.Add(dto);
            return dto.Id;
        }

        /// <summary>
        /// Удалить колоду.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        public async Task Delete(string name)
        {
            var dtos = await _storage.Find(name);
            if (dtos.Any())
            {
                var dto = dtos.First();
                await _storage.Delete(dto);
            }
        }

        /// <summary>
        /// Найти колоду.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        public async Task<IEnumerable<IDeck>> Find(string name)
        {
            var decks = new List<IDeck>();

            var dtos = await _storage.Find(name);
            if (dtos.Any())
            {
                decks.AddRange(dtos.Select(d => MapDeckFromDTO(d)));
            }

            return decks;
        }

        /// <summary>
        /// Обновить колоду.
        /// </summary>
        /// <param name="deck">Обновленная колода.</param>
        public async Task Update(IDeck deck)
        {
            var dtos = await _storage.Find(deck.Name);

            if (dtos.Any())
            {
                var dto = dtos.First();
                var newDto = MapDeckToDTO(dto.Id, deck);
                await _storage.Update(newDto);
            }
        }

        #region Вспомогательные методы для конвертации.

        private DeckDTO MapDeckToDTO(Guid id, IDeck deck)
        {
            var cards = deck.Cards().Select(c => MapCardToDTO(c, id));

            return new DeckDTO(id, deck.Name, cards);
        }

        private CardDTO MapCardToDTO(ICard card, Guid deckId)
        {
            var id = Guid.NewGuid();

            return new CardDTO(id, card.Rank, card.Suit, deckId);
        }

        private IDeck MapDeckFromDTO(DeckDTO deck)
        {
            return new DeckEntity(deck.Name, deck.Cards.Select(
                    c => MapCardFromDTO(c)).ToList());
        }

        private ICard MapCardFromDTO(CardDTO card)
        {
            return new CommonCard(card.Suit, card.Rank);
        }

        #endregion
    }
}

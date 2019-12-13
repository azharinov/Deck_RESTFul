using Deck.Logic.Interfaces.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deck.Logic.Storages
{
    /// <summary>
    /// Заглушка для хранилища колод карт.
    /// </summary>
    public class FakeDeckStorage : IDeckStorage<Guid, DeckDTO>
    {
        private static List<DeckDTO> _decks = new List<DeckDTO>();

        /// <summary>
        /// Добавить колоду в хранилище.
        /// </summary>
        /// <param name="item">Колода для добавления.</param>
        public async Task Add(DeckDTO item)
        {
            _decks.Add(item);
        }

        /// <summary>
        /// Удалить колоду из хранилища.
        /// </summary>
        /// <param name="item">Удаляемая колода.</param>
        public async Task Delete(DeckDTO item)
        {
            _decks.Remove(item);
        }

        /// <summary>
        /// Найти колоду по имени.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        /// <returns></returns>
        public async Task<IEnumerable<DeckDTO>> Find(string name)
        {
            return _decks.Where(d => d.Name.Equals(name));
        }

        /// <summary>
        /// Получить все колоды из хранилища.
        /// </summary>
        public async Task<IEnumerable<DeckDTO>> GetAll()
        {
            return _decks;
        }

        /// <summary>
        /// Обновить сущность.
        /// </summary>
        /// <param name="item">Идентификатор.</param>
        public async Task Update(DeckDTO item)
        {
            _decks.Remove(_decks.First(d => d.Name.Equals(item.Name)));
            _decks.Add(item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deck.Logic.Interfaces.Services
{
    /// <summary>
    /// Контракт сервиса по управлениюю колодами.
    /// </summary>
    /// <typeparam name="T">Тип колоды.</typeparam>
    public interface IDeckService<T>
    {
        /// <summary>
        /// Найти все колоды.
        /// </summary>
        Task<IEnumerable<T>> FindAll();

        /// <summary>
        /// Создать колоду.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        Task<Guid> Create(string name);

        /// <summary>
        /// Найти колоды по имени.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        Task<IEnumerable<T>> Find(string name);

        /// <summary>
        /// Удалить колоду по имени.
        /// </summary>
        /// <param name="name">Имя колоды.</param>
        Task Delete(string name);

        /// <summary>
        /// Изменить колоду.
        /// </summary>
        /// <param name="item">Обновленная колода.</param>
        Task Update(T item);
    }
}

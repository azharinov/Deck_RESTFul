using System.Collections.Generic;
using System.Threading.Tasks;

namespace Deck.Logic.Interfaces.Storages
{
    /// <summary>
    /// Контракт хранилища колод карт.
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора.</typeparam>
    /// <typeparam name="TItem">Тип хранимых сущностей.</typeparam>
    public interface IDeckStorage<TId, TItem>
    {
        /// <summary>
        /// Получить все сущности.
        /// </summary>
        Task<IEnumerable<TItem>> GetAll();

        /// <summary>
        /// Добавить сущность в хранилище.
        /// </summary>
        /// <param name="item">Добавляемая сущность.</param>
        Task Add(TItem item);

        /// <summary>
        /// Удалить сущность из хранилища.
        /// </summary>
        /// <param name="item">Удаляемая сущность.</param>
        Task Delete(TItem item);

        /// <summary>
        /// Найти сущности по имени.
        /// </summary>
        /// <param name="name">Имя сущности.</param>
        Task<IEnumerable<TItem>> Find(string name);

        /// <summary>
        /// Обновить сущность.
        /// </summary>
        /// <param name="item">Идентификатор.</param>
        Task Update(TItem item);
    }
}

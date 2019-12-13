namespace Deck.Logic.Settings
{
    /// <summary>
    /// Настройки для сервиса тасования.
    /// </summary>
    public class ShuffleSettings
    {
        /// <summary>
        /// Выбранный алгоритм.
        /// </summary>
        public string ShuffleAlgorithm { get; set; }

        /// <summary>
        /// Количество перетасовок.
        /// </summary>
        public int ShuffleCount { get; set; }
    }
}

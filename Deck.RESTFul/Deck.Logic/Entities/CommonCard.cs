using Deck.Logic.Interfaces.Entities;
using System;

namespace Deck.Logic.Entities
{
    /// <summary>
    /// Бизнес-сущность обычной игровой карты.
    /// </summary>
    public class CommonCard : ICard
    {
        /// <summary>
        /// Масть карты.
        /// </summary>
        public string Suit { get; private set; }

        /// <summary>
        /// Ранг карты.
        /// </summary>
        public string Rank { get; private set; }

        private CommonCard() { }

        public CommonCard(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Возвращает строковое представление карты.
        /// </summary>
        public string Present()
        {
            return $"{Rank} {Suit}";
        }


        private static string[] _ranks = new string[]
        {
            "Двойка", "Тройка", "Четверка", "Пятерка", "Шестерка", "Семерка", "Восьмерка", "Девятка", "Десятка", "Валет", "Дама", "Король", "Туз"
        };
        private static string[] _suites = new string[]
        {
            "Червей", "Бубей", "Треф", "Пик"
        };

        /// <summary>
        /// Заглушка для генерации рандомной карты.
        /// </summary>
        public static CommonCard GenerateCard()
        {
            var rnd = new Random();

            string rank = _ranks[rnd.Next(13)];
            string suit = _suites[rnd.Next(4)];

            return new CommonCard(suit, rank);
        }
    }
}

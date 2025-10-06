using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models
{
    public abstract class Card : IPlayable
    {
        public string Name { get; }
        public int Cost { get; }

        protected Card(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public abstract void Play(Player owner, Player opponent, GameLogger logger);
    }
}
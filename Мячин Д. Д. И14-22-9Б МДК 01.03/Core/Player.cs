using System;
using System.Collections.Generic;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models;

#nullable enable

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core
{
    public class Player
    {
        public string Name { get; }
        public int Health { get; private set; } = 20;
        public int Mana { get; private set; }
        public int MaxMana { get; private set; }

        public Queue<Card> Deck { get; } = new();
        public Stack<Card> Discard { get; } = new();
        public List<Card> Hand { get; } = new();
        public List<CreatureCard> Battlefield { get; } = new();

        public Player(string name)
        {
            Name = name;
        }

        public void Draw(int count = 1, GameLogger? logger = null)
        {
            for (int i = 0; i < count; i++)
            {
                if (Deck.Count == 0)
                {
                    logger?.Log($"{Name} не может добрать карту — колода пуста!");
                    return; // просто пропускаем добор
                }
                var card = Deck.Dequeue();
                Hand.Add(card);
                logger?.Log($"{Name} добирает карту: {card.Name}");
            }
        }

        public void StartTurn()
        {
            MaxMana = Math.Min(10, MaxMana + 1);
            Mana = MaxMana;
        }

        public void PlayCard(int index, Player opponent, GameLogger logger)
        {
            if (index < 0 || index >= Hand.Count)
                throw new InvalidActionException($"{Name}: неверный индекс карты.");

            var card = Hand[index];

            if (card.Cost > Mana)
                throw new InvalidActionException($"{Name}: недостаточно маны ({Mana}/{card.Cost}).");

            Mana -= card.Cost;
            card.Play(this, opponent, logger);
            Hand.RemoveAt(index);

            if (card is not CreatureCard)
                Discard.Push(card);
        }

        public void TakeDamage(int amount) => Health -= amount;
        public void Heal(int amount) => Health += amount;
    }
}

#nullable restore
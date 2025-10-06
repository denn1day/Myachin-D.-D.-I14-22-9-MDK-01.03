using System;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03
{
    internal class Program
    {
        static void Main()
        {
            using var logger = new GameLogger("Logs/game.log");

            var alice = new Player("Alice");
            var bob = new Player("Bob");

            for (int i = 1; i <= 5; i++)
            {
                alice.Deck.Enqueue(new CreatureCard($"Wolf_{i}", 1, 2, 2));
                bob.Deck.Enqueue(new CreatureCard($"Goblin_{i}", 1, 1, 1));
            }

            alice.Deck.Enqueue(new SpellCard("Fireball", 2, (owner, opponent, log) =>
            {
                opponent.TakeDamage(3);
                log.Log($"{owner.Name} использует Fireball! {opponent.Name} получает 3 урона.");
            }));

            bob.Deck.Enqueue(new SpellCard("Heal", 2, (owner, opponent, log) =>
            {
                owner.Heal(3);
                log.Log($"{owner.Name} использует Heal и восстанавливает 3 HP.");
            }));

            var game = new Game(alice, bob, logger);
            game.Start();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
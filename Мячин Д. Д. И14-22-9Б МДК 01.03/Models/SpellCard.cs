using System;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models
{
    public class SpellCard : Card
    {
        private readonly Action<Player, Player, GameLogger> _effect;

        public SpellCard(string name, int cost, Action<Player, Player, GameLogger> effect)
            : base(name, cost)
        {
            _effect = effect;
        }

        public override void Play(Player owner, Player opponent, GameLogger logger)
        {
            _effect.Invoke(owner, opponent, logger);
        }
    }
}
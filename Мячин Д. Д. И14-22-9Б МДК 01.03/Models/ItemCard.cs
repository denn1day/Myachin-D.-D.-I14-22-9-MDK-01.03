using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models
{
    public class ItemCard : Card
    {
        public Action<Player, Player, GameLogger> Effect { get; }

        public ItemCard(string name, int cost, Action<Player, Player, GameLogger> effect)
            : base(name, cost)
        {
            Effect = effect;
        }

        public override void Play(Player owner, Player opponent, GameLogger logger)
        {
            logger.Log($"{owner.Name} использует предмет {Name}");
            Effect?.Invoke(owner, opponent, logger);
        }
    }
}
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models
{
    public class CreatureCard : Card
    {
        public int Attack { get; }
        public int Health { get; private set; }

        public CreatureCard(string name, int cost, int attack, int health)
            : base(name, cost)
        {
            Attack = attack;
            Health = health;
        }

        public override void Play(Player owner, Player opponent, GameLogger logger)
        {
            owner.Battlefield.Add(this);
            logger.Log($"{owner.Name} ставит {Name} на поле (АТК {Attack}, HP {Health})");
        }

        public void TakeDamage(int amount) => Health -= amount;
    }
}
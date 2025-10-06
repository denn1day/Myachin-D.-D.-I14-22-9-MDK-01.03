using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models
{
    public interface IPlayable
    {
        void Play(Player owner, Player opponent, GameLogger logger);
    }
}
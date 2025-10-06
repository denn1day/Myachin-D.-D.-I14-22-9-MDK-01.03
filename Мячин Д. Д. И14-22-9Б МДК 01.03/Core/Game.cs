using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core
{
    public class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly GameLogger _logger;

        public Game(Player p1, Player p2, GameLogger logger)
        {
            _player1 = p1;
            _player2 = p2;
            _logger = logger;
        }

        public void Start()
        {
            _logger.Log("Игра начинается!");

            _player1.Draw(3, _logger);
            _player2.Draw(3, _logger);

            int turn = 1;
            while (CanContinue(_player1, _player2))
            {
                _logger.Log($"--- Ход {turn} ---");
                TakeTurn(_player1, _player2);
                TakeTurn(_player2, _player1);
                turn++;
            }

            // Определяем победителя
            if (_player1.Health > _player2.Health)
                _logger.Log($"{_player1.Name} выиграл!");
            else if (_player2.Health > _player1.Health)
                _logger.Log($"{_player2.Name} выиграл!");
            else
                _logger.Log("Игра закончилась ничьей!");
        }

        // Проверка, можно ли продолжать игру
        private bool CanContinue(Player p1, Player p2)
        {
            bool p1HasMoves = p1.Hand.Count > 0 || p1.Deck.Count > 0;
            bool p2HasMoves = p2.Hand.Count > 0 || p2.Deck.Count > 0;

            return (p1.Health > 0 && p2.Health > 0) && (p1HasMoves || p2HasMoves);
        }

        private void TakeTurn(Player active, Player opponent)
        {
            active.StartTurn();
            _logger.Log($"{active.Name} начинает ход (HP: {active.Health}, Mana: {active.Mana})");

            // Добор карты с логированием
            active.Draw(1, _logger);

            // Играем все карты, если хватает маны
            for (int i = active.Hand.Count - 1; i >= 0; i--)
            {
                if (active.Hand[i].Cost <= active.Mana)
                {
                    try
                    {
                        active.PlayCard(i, opponent, _logger);
                    }
                    catch (InvalidActionException ex)
                    {
                        _logger.Log($"Ошибка: {ex.Message}");
                    }
                }
            }
        }
    }
}
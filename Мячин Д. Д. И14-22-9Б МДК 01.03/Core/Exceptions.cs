using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core;
using Мячин_Д.Д.И14_22_9Б_МДК_01._03.Models;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core
{
    // Исключение для пустой колоды
    public class DeckEmptyException : Exception
    {
        public DeckEmptyException(string message) : base(message) { }
    }

    // Исключение для некорректного действия игрока
    public class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message) { }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мячин_Д.Д.И14_22_9Б_МДК_01._03.Core
{
    public class GameLogger : IDisposable
    {
        private readonly StreamWriter _writer;

        public GameLogger(string relativeFilePath)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.Combine(baseDir, relativeFilePath);

            string? directory = Path.GetDirectoryName(fullPath);
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _writer = new StreamWriter(fullPath, true) { AutoFlush = true };
            Log($"=== Новая сессия {DateTime.Now} ===");
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
            _writer.WriteLine(message);
        }

        public void Dispose()
        {
            Log($"=== Конец сессии ===");
            _writer.Dispose();
        }
    }
}
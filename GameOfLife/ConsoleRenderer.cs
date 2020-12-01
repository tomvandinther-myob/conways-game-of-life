using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class ConsoleRenderer : IRenderer
    {
        private const char AliveChar = '▓';
        private const char DeadChar = ' ';
        
        public ConsoleRenderer()
        {
            // Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void Render(CellDictionary simulationOutput)
        {
            var rowList = new List<List<char>>();
            
            foreach (var cell in simulationOutput)
            {
                var (x, y) = (cell.X, cell.Y);
                
                if ((rowList.Count - 1) < y)
                {
                    var rowDeficit = y - (rowList.Count -1);
                    rowList.AddRange(Enumerable.Range(1, rowDeficit).Select(i => new List<char>()));
                }
                
                if ((rowList[y].Count -1)< x)
                {
                    var columnDeficit = x - (rowList[y].Count -1);
                    rowList[y].AddRange(Enumerable.Repeat(DeadChar, columnDeficit));
                }

                rowList[y][x] = AliveChar;
            }
            
            var stringBuilder = new StringBuilder();
            
            foreach (var row in rowList)
            {
                stringBuilder.Append(row.ToArray());
                stringBuilder.Append('\n');
            }

            stringBuilder.Length--;
            
            Write(stringBuilder.ToString());
        }
        
        private static void Write(string output)
        {
            Console.Clear();
            Console.Write(output);
        }
    }
}
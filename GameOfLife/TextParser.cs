using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    public class TextParser : IStateParser
    {
        public HashSet<Coordinate> InitialState => ParseFromFile();
        private readonly string _filePath;
        private readonly HashSet<char> _tokenChars;

        public TextParser(string filePath, HashSet<char> tokenChars)
        {
            _filePath = filePath;
            _tokenChars = tokenChars;
        }

        public HashSet<Coordinate> ParseFromFile()
        {
            var lines = File.ReadAllLines(_filePath);
            return ParseFromString(lines);
        }
        
        public HashSet<Coordinate> ParseFromString(string[] lines)
        {
            var coordinateSet = new HashSet<Coordinate>();
            

            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];

                for (var x = 0; x < line.Length; x++)
                {
                    var token = line[x];
                    if (_tokenChars.Contains(token))
                    {
                        coordinateSet.Add(new Coordinate(x, y));
                    }
                }
            }

            return coordinateSet;
        }
    }
}
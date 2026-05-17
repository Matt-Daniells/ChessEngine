using Board;
using Board.Pieces;

namespace ChessEngine
{
    public class Game
    {
        public BoardGen Board { get; }

        public Game(BoardGen board, string Colour)
        {
            Board = board;
            string colour = Colour;
            
            ConsoleKeyInfo KeyPress = Console.ReadKey();

            while (KeyPress.Key != ConsoleKey.Escape)
            {
                //Logic
                KeyPress = Console.ReadKey();
            }
        }

        public void Notation(string notation)
        {
            // Not yet implemented
        }
    }
}
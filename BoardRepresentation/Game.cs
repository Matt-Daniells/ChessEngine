using Board;
using Board.Pieces;

namespace ChessEngine
{
    public enum GameState
    {
        GAMEOVER,
        WHITEMOVE,
        BLACKMOVE,
        STARTUP
    }
    public class Game
    {
        public BoardGen Board { get; }

    

        public Game(BoardGen board, string Colour)
        {
            Board = board;
            string colour = Colour;
            GameState gamestate;

            if (colour=="White") {gamestate = GameState.WHITEMOVE;}
            else {gamestate = GameState.BLACKMOVE;}
        
            while (gamestate != GameState.GAMEOVER)
            {   
                
                Console.WriteLine($"{colour} to move: ");
                string? move = Console.ReadLine();
                
                // Requires physically typing esc to exit, needs work to allow esc key without consuming move input
                if (string.IsNullOrWhiteSpace(move))
                {
                    continue;
                }

                if (move.Equals("Esc", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Notation(move);

                bool whiteTurn = colour == "White";
                colour = whiteTurn ? "Black" : "White";
                gamestate = whiteTurn ? GameState.BLACKMOVE : GameState.WHITEMOVE;
            }
        }

        public void Notation(string? notation)
        {
            Console.WriteLine(notation);
        }
    }
}
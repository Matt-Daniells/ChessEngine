namespace Board
{
    // tracks the current game state for turn order and end of game
    public enum GameState
    {
        GAMEOVER,
        WHITEMOVE,
        BLACKMOVE
    }

    public class Game
    {
        public BoardGen Board { get; }

    

        // create a game using the provided board and the player color to move first
        public Game(BoardGen board, string Colour)
        {
            GameState gamestate;
            Board = board ?? throw new System.ArgumentNullException(nameof(board));
            String colour = Colour;

            if (colour=="White") {gamestate = GameState.WHITEMOVE;}
            else {gamestate = GameState.BLACKMOVE;}
        
            while (gamestate != GameState.GAMEOVER)
            {   
                // read a move from the console and switch turns
                Console.WriteLine($"{colour} to move: ");
                string? move = Console.ReadLine();
                
                // requires physically typing esc to exit, needs work to allow esc key without consuming move input
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

        // handle algebraic notation or move text - not yet implemented
        public static void Notation(string? notation)
        {
            Console.WriteLine(notation);
        }
    }
}
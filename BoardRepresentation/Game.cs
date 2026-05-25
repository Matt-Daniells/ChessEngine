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

        // read a line of move input, cancel when esc is pressed
        private static string? ReadMoveInput(CancellationToken token)
        {
            var sb = new System.Text.StringBuilder();
            while (true)
            {
                if (token.IsCancellationRequested) return null;
                
                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape) return null;
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        return sb.ToString();
                    }
                    if (key.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Length--;
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {
                        sb.Append(key.KeyChar);
                        Console.Write(key.KeyChar);
                    }
                }
                System.Threading.Thread.Sleep(10);
            }
        }

        // create a game using the provided board and the player color to move first
        public Game(BoardGen board, string colour)
        {
            Board = board ?? throw new System.ArgumentNullException(nameof(board));
            GameState gamestate = (colour=="White") ? GameState.WHITEMOVE : GameState.BLACKMOVE;

            using var cts = new CancellationTokenSource();
        
            while (gamestate != GameState.GAMEOVER)
            {   
                // read a move from the console and switch turns
                Console.WriteLine($"{colour} to move: ");
                string? move = ReadMoveInput(cts.Token);
                
                if (move is null)
                    break;

                if (string.IsNullOrWhiteSpace(move))
                    continue;
                
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
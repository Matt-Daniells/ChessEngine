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
            var string_builder = new System.Text.StringBuilder();
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
                        return string_builder.ToString();
                    }
                    if (key.Key == ConsoleKey.Backspace && string_builder.Length > 0)
                    {
                        string_builder.Length--;
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {
                        string_builder.Append(key.KeyChar);
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
                
                EvaluateNotation(move);

                bool whiteTurn = colour == "White";
                colour = whiteTurn ? "Black" : "White";
                gamestate = whiteTurn ? GameState.BLACKMOVE : GameState.WHITEMOVE;
            }
        }

        // handle algebraic notation or move text - uses long algebraic notation (for now)
        public void EvaluateNotation(string notation)
        {
            /* List<Char> Pieces = ['P', 'N', 'B', 'R', 'Q', 'K'];

            // get list of possible rank values given a custom board size 
            IEnumerable<int> enumerable_ranks = Enumerable.Range(1, Board.Size);
            List<int> rank_vals = enumerable_ranks.ToList();

            // get list of possible file values given a custom board size 
            IEnumerable<int> enumerable_files = Enumerable.Range('a', Board.Size);
            List<int> file_vals = enumerable_files.ToList();

            

            string[] isolated_positions = notation.Split('x', '+', '=');

            if (isolated_positions[0].Length == 2) {isolated_positions[0].Insert(0, "P");}
            Console.WriteLine(isolated_positions[0].Length.ToString());

            foreach (object o in isolated_positions)
            {
                Console.WriteLine(o);
            } */

        }
    }
}
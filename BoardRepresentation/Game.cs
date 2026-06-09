namespace Board;

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
        var stringBuilder = new System.Text.StringBuilder();
        while (true)
        {
            if (token.IsCancellationRequested)
            {
                return null;
            }

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return null;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return stringBuilder.ToString();
                }
                if (key.Key == ConsoleKey.Backspace && stringBuilder.Length > 0)
                {
                    stringBuilder.Length--;
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    _ = stringBuilder.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            Thread.Sleep(10);
        }
    }

    // create a game using the provided board and the player color to move first
    public Game(BoardGen board, string colour)
    {
        Board = board ?? throw new ArgumentNullException(nameof(board));
        GameState gameState = (colour == "White") ? GameState.WHITEMOVE : GameState.BLACKMOVE;

        using var cts = new CancellationTokenSource();

        while (gameState != GameState.GAMEOVER)
        {
            // read a move from the console and switch turns
            Console.WriteLine($"{colour} to move: ");
            string? move = ReadMoveInput(cts.Token);

            if (move is null)
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(move))
            {
                continue;
            }

            var tryMove = new Move(board, move);

            bool whiteTurn = colour == "White";
            colour = whiteTurn ? "Black" : "White";
            gameState = whiteTurn ? GameState.BLACKMOVE : GameState.WHITEMOVE;
        }
    }
}

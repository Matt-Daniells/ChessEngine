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
    public GameState GameState { get; set; }

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

    // only called within Game constructor while GameOver is not an option
    private string GetColourString() => GameState == GameState.WHITEMOVE ? "White" : "Black";
    private GameState FlipSides() => GameState == GameState.WHITEMOVE ? GameState.BLACKMOVE : GameState.WHITEMOVE;

    public Game(BoardGen board, string colour)
    {
        Board = board ?? throw new ArgumentNullException(nameof(board));
        GameState = (colour == "White") ? GameState.WHITEMOVE : GameState.BLACKMOVE;
        GameLoop();
    }

    public void GameLoop()
    {
        using var cts = new CancellationTokenSource();
        while (GameState != GameState.GAMEOVER)
        {
            string? move = GetAndParseMove(cts);
            if (string.IsNullOrWhiteSpace(move))
            {
                if (move is null) { break; }
                Console.WriteLine("You must enter a valid move.");
                continue;
            }

            try
            {
                //need to work on this to validate the move was successful
                var _ = new Move(Board, move);
            }

            catch (Exception)
            {
                Console.WriteLine("Move failed. Please check your notation and try again");
            }
            GameState = FlipSides();
        }
    }

    public string? GetAndParseMove(CancellationTokenSource cts)
    {
        Console.WriteLine($"{GetColourString()} to move: ");
        string? move = ReadMoveInput(cts.Token);
        return move;
    }
}

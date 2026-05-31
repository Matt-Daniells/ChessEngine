namespace Board
{
    public class Move
    {
        public BoardGen Board { get; }

        public Move(BoardGen board, string move_input)
        {
            Board = board ?? throw new System.ArgumentNullException(nameof(board));
            
        }
    }
}
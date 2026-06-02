namespace Board
{
    public class Move
    {
        public BoardGen board { get; }
        public string notation {get;}

        public Move(BoardGen Board, string Notation)
        {
            board = Board ?? throw new ArgumentNullException(nameof(board));
            notation = Notation ?? throw new ArgumentNullException(nameof(notation));
            SplitNotation();
        }

        private List<string> SplitNotation()
        {
            char[] splitters = ['x','+','='];
            List<string> chunks = [.. notation.Split(splitters)];

            foreach (char c in notation)
            {
                if (splitters.Contains(c)) {chunks.Add(c.ToString());}
            }

            return chunks;
        }

        private bool Castling()
        {
            return notation[0] == 'O';
        }

        private string CastlingDirection()
        {
            string side = SplitNotation().Count > 2 ? "Queen" : "King";
            return side;
        }
    }
}
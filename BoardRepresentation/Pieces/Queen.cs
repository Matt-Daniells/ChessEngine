namespace Board.Pieces
{
    public class Queen
    {
        static string _UNICODE = "\u2655";
        // returns the unicode symbol for the piece
        public static char Unicode
        {
            get {return Convert.ToChar(_UNICODE); }
        }
    }
}
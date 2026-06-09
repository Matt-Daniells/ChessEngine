namespace Board.Pieces;

public class Queen(string colour) : Piece(colour, PieceType.Queen)
{
    private const char WhiteUnicode = '\u2655';
    private const char BlackUnicode = '\u265B';

    public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
}

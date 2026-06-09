namespace Board.Pieces;

public class Rook(string colour) : Piece(colour, PieceType.Rook)
{
    private const char WhiteUnicode = '\u2656';

    private const char BlackUnicode = '\u265C';

    public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;

}

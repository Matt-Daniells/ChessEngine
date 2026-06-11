namespace Board.Pieces;

public class Pawn(string colour) : Piece(colour, PieceType.Pawn)
{
    private const char WhiteUnicode = '\u2659';
    private const char BlackUnicode = '\u265F';

    public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
}

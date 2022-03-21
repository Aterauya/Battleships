namespace Battleships.Common
{
    public class BoardCell
    {
        public BoardCell(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public bool Hit { get; set; } = false;
        public bool HasBattleship { get { return BattleshipIdentifier.HasValue; } }
        public Guid? BattleshipIdentifier { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}

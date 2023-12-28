namespace SquadLeader.Map;

public enum Direction{
    North,
    NorthWest,
    NorthEast,
    South,
    SouthWest,
    SouthEast
}

public class Location {
    private (char, int) locCoords;
    private Dictionary<Direction, Location> adjDict = new();  
    public Location((char, int) locCoordsIn, (double, double) absLocationIn) {
        this.locCoords = locCoordsIn;
        this.AbsLocation = absLocationIn;
    }
    public (double, double) AbsLocation { get; }
}
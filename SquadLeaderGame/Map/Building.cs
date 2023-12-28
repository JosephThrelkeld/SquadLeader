namespace SquadLeader.Map;

public class Building {
    public Building(List<(double, double)> verticesIn) {
        Vertices = verticesIn;
    }
    public List<(double, double)> Vertices { get; } = [];
    public List<Location> GetLocations(List<Location> locations) { throw new NotImplementedException(); } 
}   
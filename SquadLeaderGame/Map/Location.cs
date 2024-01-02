using System.Data.Common;
using System.Text.Json.Serialization;

namespace SquadLeader.Map;

public enum Direction{
    North,
    NorthWest,
    NorthEast,
    South,
    SouthWest,
    SouthEast
}

public sealed class Location {
    // override object.Equals
    public override bool Equals(object obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //
        
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        // TODO: write your implementation of Equals() here
        Location castedObj = (Location) obj;
        Console.WriteLine(this.LocCoords.Equals(castedObj.LocCoords));
        Console.WriteLine(this.LocCoords);
        Console.WriteLine(castedObj.LocCoords);
        return this.LocCoords.Equals(castedObj.LocCoords) &
               this.AbsLocation.Equals(castedObj.AbsLocation);
    }
    
    // override object.GetHashCode
    public override int GetHashCode() { return base.GetHashCode();}
        
    
    private Dictionary<Direction, Location> adjDict = new();
    [JsonConstructor]
    public Location((char, int) locCoords, (double, double) absLocation) {
        this.LocCoords = locCoords;
        this.AbsLocation = absLocation;

    }
    [JsonInclude]
    public (char, int) LocCoords { get; }
    [JsonInclude]
    public (double, double) AbsLocation { get; }
    [JsonIgnore]
    public string LocCoordString => $"{LocCoords.Item1}{LocCoords.Item2}";
}
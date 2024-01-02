namespace SquadLeader.Map;
using System.Text.Json.Serialization;

public sealed class TerrainElement {
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
        
        TerrainElement castedObj = (TerrainElement) obj;

        return this.Vertices.SequenceEqual(castedObj.Vertices) &&
               this.Locations.SequenceEqual(castedObj.Locations);   

    }
    // override object.GetHashCode
    public override int GetHashCode() { return base.GetHashCode(); }
    [JsonConstructor]
    public TerrainElement(List<(double, double)> vertices, List<Location> locations, char buildingType) {
        Vertices = vertices;
        Locations = locations;
        BuildingType = buildingType;
    }
    [JsonInclude]
    public List<(double, double)> Vertices { get; } = [];
    [JsonInclude]
    public List<Location> Locations { get; } = [];
    //Building : B, Forest : F, Road : R
    public char BuildingType { get; }
}
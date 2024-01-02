namespace SquadLeader.Map;
using GamePiece;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text.Json;

public sealed class GameMap {
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
        GameMap castedObj = (GameMap) obj;

        //Console.WriteLine(this.Locations.SequenceEqual(castedObj.Locations));
        //Console.WriteLine(this.TerrainElements.SequenceEqual(castedObj.TerrainElements));
        //Console.WriteLine(this.GamePieces.SequenceEqual(castedObj.GamePieces));

        return this.Locations.SequenceEqual(castedObj.Locations) &&
               this.TerrainElements.SequenceEqual(castedObj.TerrainElements) &&
               this.SquadPieces.SequenceEqual(castedObj.SquadPieces);
    }
    // override object.GetHashCode
    public override int GetHashCode() { return base.GetHashCode(); }
    [JsonConstructor]
    public GameMap(List<TerrainElement> terrainElements, List<SquadPiece> squadPieces, List<Location> locations) {
        TerrainElements = terrainElements;
        SquadPieces = squadPieces;
        Locations = locations;
    }
    [JsonInclude]
    public List<TerrainElement> TerrainElements { get; } = [];
    [JsonInclude]
    public List<SquadPiece> SquadPieces { get; } = [];
    [JsonInclude]
    public List<Location> Locations { get; } = [];
    private static int RadiusOfHexCircle = 20;
    public void SaveGameMap(string name) {
        var options = new JsonSerializerOptions { IncludeFields = true };
        string mapJsonString = JsonSerializer.Serialize(this, options);
        File.WriteAllText(name, mapJsonString);
    }
    public static GameMap LoadGameMap(string name) {
        var options = new JsonSerializerOptions { IncludeFields = true };
        string jsonString = File.ReadAllText(name);
        return JsonSerializer.Deserialize<GameMap>(jsonString, options);
    }
}
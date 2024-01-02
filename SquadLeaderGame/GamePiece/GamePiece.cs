namespace SquadLeader.GamePiece;
using System.Text.Json.Serialization;
public abstract class GamePiece {
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
        GamePiece castedObj = (GamePiece) obj;
        return this.Name.Equals(castedObj.Name);
    }
    
    // override object.GetHashCode
    public override int GetHashCode() { return base.GetHashCode(); }
    [JsonConstructor]
    public GamePiece(string name) {
        Name = name;
    }
    public string Name { get; }
}
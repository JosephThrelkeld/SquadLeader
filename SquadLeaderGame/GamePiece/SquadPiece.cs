namespace SquadLeader.GamePiece;
using System.Text.Json.Serialization;
using SquadLeader.Map;

public sealed class SquadPiece {
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
        SquadPiece castedObj = (SquadPiece) obj;
        return this.Firepower == castedObj.Firepower &&
               this.Range == castedObj.Range &&
               this.Morale == castedObj.Morale &&
               this.IsBroken == castedObj.IsBroken;
    }
    public override int GetHashCode() { return base.GetHashCode(); }
    [JsonConstructor]
    public SquadPiece(int firepower, int range, int morale) {
        Firepower = firepower;
        Range = range;
        Morale = morale;
    }
    public List<Location> GetPossibleMoves() { throw new NotImplementedException(); }
    public int Firepower { get; }
    public int Range { get; }
    public int Morale { get; }
    public bool IsBroken { get; set;}
    
}
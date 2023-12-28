namespace UnitTestSquadLeader;
using SquadLeader.Map;

[TestClass]
public class TestBuilding
{
    [TestMethod]
    public void TestLocation()
    {   
        var locations = new List<Location>
        {
            new(('H', 2), (30, 30)),
            new(('B', 5), (20, 10)),
        };

        var expectedLocations = new List<Location>
        {
            new(('B', 5), (20, 10)),
        };

        var testBuilding = new Building([(0,0), (25,0), (25,15), (0,15)]);

        var locationsInBuilding = testBuilding.GetLocations(locations);

        CollectionAssert.AreEquivalent(expectedLocations,locationsInBuilding);
    }
}
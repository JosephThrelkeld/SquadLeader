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

[TestClass]
public class TestGeometricCalculator {
    [TestMethod]
    public void TestIntersect()
    {
        (double, double) point1 = (1.93,2.705);
        (double, double) point2 = (4.26,2.25);
        (double, double) point3 = (2.67,1.75);
        (double, double) point4 = (3.6,3.6);

        (double, double) point5 = (1.5,2.5);
        (double, double) point6 = (2.5,3.5);
        (double, double) point7 = (2,3);
        (double, double) point8 = (3,4);

        //General tests
        Assert.IsTrue(GeometricCalculator.Intersects(point1,point2,point3,point4));
        Assert.IsFalse(GeometricCalculator.Intersects(point1,point3,point2,point4));
        Assert.IsFalse(GeometricCalculator.Intersects(point1,point4,point2,point3));

        //Colinear tests
        Assert.IsTrue(GeometricCalculator.Intersects(point5,point6,point7,point8));
        Assert.IsFalse(GeometricCalculator.Intersects(point5,point7,point6,point8));
    }
}
namespace UnitTestSquadLeader;
using SquadLeader.Map;
using SquadLeader.GamePiece;
using System.Runtime.InteropServices;

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

[TestClass]
public class TestMap {
    [TestMethod]
    public void TestEqualsOverload() {
        List<Location> locations = [new Location(('A', 1), (20,20)), new Location(('A', 2), (40,60))];
        List<TerrainElement> terrainElements = [new TerrainElement([(0,0), (0,30), (30,30), (30,0)], [locations[0]], 'B'),];
        GameMap testMap = new GameMap(terrainElements,[new SquadPiece("test")],locations);
        List<Location> locations1 = [new Location(('A', 1), (20,20)), new Location(('A', 2), (40,60))];
        List<TerrainElement> terrainElements1 = [new TerrainElement([(0,0), (0,30), (30,30), (30,0)], [locations[0]], 'B'),];
        GameMap testMap1 = new GameMap(terrainElements1,[new SquadPiece("test")],locations1);
        Assert.IsTrue(testMap.Equals(testMap1));
    }
    [TestMethod]
    public void TestSaveAndLoad() {
        List<Location> locations = [new Location(('A', 1), (20,20)), new Location(('A', 2), (40,60))];
        List<TerrainElement> terrainElements = [new TerrainElement([(0,0), (0,30), (30,30), (30,0)], [locations[0]], 'B'),];
        GameMap testMap = new GameMap(terrainElements,[],locations);
        testMap.SaveGameMap("testGame");
        GameMap loadedMap = GameMap.LoadGameMap("testGame");
        Console.WriteLine(loadedMap.Locations.Count);
        Console.WriteLine(testMap.Locations.Count);

        Assert.IsTrue(File.Exists("testGame"));
        Assert.IsTrue(testMap.Equals(loadedMap));
    }
}
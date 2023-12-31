using System.Runtime.InteropServices;

namespace SquadLeader.Map;

public class GeometricCalculator {
    //Using technique where intersecting two line segments comprised of points: p1, q1; and p2, q2, 
    //have differing orientations of sets of points (counter-clockwise, clockwise, colinear)
    //between (p1,q1,p2) and (p1,q1,p2). The same applies to (p2,q2,p1) and (p2,q2,q1)
    //Special cases where all points are colinear are handled using intersection of x- and y-projections.

    //Taken from: https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/

    private const double Epsilon = 1e-10;
    public static bool Intersects((double, double) lineSeg1Point1, (double, double) lineSeg1Point2, (double, double) lineSeg2Point1, (double, double) lineSeg2Point2) { 
        int or1 = Orientation(lineSeg1Point1,lineSeg1Point2,lineSeg2Point1);
        int or2 = Orientation(lineSeg1Point1,lineSeg1Point2,lineSeg2Point2);
        int or3 = Orientation(lineSeg2Point1,lineSeg2Point2,lineSeg1Point1);
        int or4 = Orientation(lineSeg2Point1,lineSeg2Point2,lineSeg1Point2);
          
        
        if ((or1 != or2 && or3 != or4) ||
            (or1 == 0 && OnSegment(lineSeg1Point1,lineSeg1Point2,lineSeg2Point1)) ||
            (or2 == 0 && OnSegment(lineSeg1Point1,lineSeg1Point2,lineSeg2Point2)) ||
            (or3 == 0 && OnSegment(lineSeg2Point1,lineSeg2Point2,lineSeg1Point1)) ||
            (or4 == 0 && OnSegment(lineSeg2Point1,lineSeg2Point2,lineSeg1Point2))) return true;

        return false;
    }
    private static bool OnSegment((double, double) lineSeg1Point1, (double, double) lineSeg1Point2, (double, double) point) {
        double a = (lineSeg1Point1.Item2 - lineSeg1Point2.Item2) / (lineSeg1Point1.Item1 - lineSeg1Point2.Item1); 
        double b = lineSeg1Point1.Item2 - a * lineSeg1Point1.Item1;

        return Math.Abs(point.Item2 - (a * point.Item1 + b)) < Epsilon &&
               Math.Max(lineSeg1Point1.Item1,lineSeg1Point2.Item1) - point.Item1 >= 0 && Math.Min(lineSeg1Point1.Item1,lineSeg1Point2.Item1) - point.Item1 <= 0 &&
               Math.Max(lineSeg1Point1.Item2,lineSeg1Point2.Item2) - point.Item2 >= 0 && Math.Min(lineSeg1Point1.Item2,lineSeg1Point2.Item2) - point.Item2 <= 0;
    }
    private static int Orientation((double, double) point1, (double, double) point2, (double, double) point3) {
        double val = (point2.Item2 - point1.Item2) * (point3.Item1 - point2.Item1) -
                     (point2.Item1 - point1.Item1) * (point3.Item2 - point2.Item2);

        
        if (Math.Abs(val) < Epsilon) return 0;

        return val>0? 1 : 2;
    }
}

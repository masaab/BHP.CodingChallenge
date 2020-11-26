using PolygonIntersection.Models;
using System.Collections.Generic;

namespace PolygonIntersection
{
    public class PolygonOperation
    {
        public List<Coordinates> PolygonA;
        public List<Coordinates> PolygonB;
        public List<Coordinates> IntersectResultCollection;

        public PolygonOperation(List<Coordinates> polygonA, List<Coordinates> polygonB)
        {
            PolygonA = polygonA;
            PolygonB = polygonB;
            IntersectResultCollection = new List<Coordinates>();
        }

        public void StartProcess()
        {
            //Compare PolygonA cordinate Pair with each pair of PolygonB
            //Store: The Interaction points in the IntersectResultCollection
            for (int i = 0; i < PolygonA.Count-1; i++)
            {
                for (int j = 0; j < PolygonB.Count - 1; j++)
                {
                    GetIntersectionPoint(new Coordinates(PolygonA[i].x, PolygonA[i].y),
                        new Coordinates(PolygonA[i + 1].x, PolygonA[i + 1].y),
                        new Coordinates(PolygonB[j].x, PolygonB[j].y),
                        new Coordinates(PolygonB[j+1].x, PolygonB[j+1].y));
                }
            }
        }

        public Coordinates GetIntersectionPoint(Coordinates A, Coordinates B, Coordinates C, Coordinates D)
        {
            // Line AB represented as a1x + b1y = c1  
            //Finding the Slope and Y intersect
            double a1 = B.y - A.y;
            double b1 = A.x - B.x;
            double c1 = a1 * (A.x) + b1 * (A.y);

            // Line CD represented as a2x + b2y = c2  
            //Finding the Slope and Y intersect
            double a2 = D.y - C.y;
            double b2 = C.x - D.x;
            double c2 = a2 * (C.x) + b2 * (C.y);

            double result = a1 * b2 - a2 * b1;

            if (result == 0)
            {
                // The lines are parallel. This is simplified  
                // by returning a pair of FLT_MAX  
                return  new Coordinates(double.MaxValue, double.MaxValue);
            }
            else
            {
                double x = (b2 * c1 - b1 * c2) / result;
                double y = (a1 * c2 - a2 * c1) / result;
                IntersectResultCollection.Add(new Coordinates(x, y));
                return new Coordinates(x, y);
            }
        }
    }
}

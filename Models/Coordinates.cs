using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonIntersection.Models
{
    public class Coordinates:IEquatable<Coordinates>
    {
        public double x { get; }
        public double y { get; }
        public Coordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coordinates other)
        {
            if (other == null)
                return false;

            if (this.x == other.x && this.y == other.y)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Coordinates coordinateObj = obj as Coordinates;
            if (coordinateObj == null)
                return false;
            else
                return Equals(coordinateObj);
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() + this.y.GetHashCode();
        }

        public static bool operator ==(Coordinates coordinateA, Coordinates coordinateB)
        {
            if (((object)coordinateA) == null || ((object)coordinateB) == null)
                return Object.Equals(coordinateA, coordinateB);

            return coordinateA.Equals(coordinateB);
        }

        public static bool operator !=(Coordinates coordinateA, Coordinates coordinateB)
        {
            if (((object)coordinateA) == null || ((object)coordinateB) == null)
                return !Object.Equals(coordinateA, coordinateB);

            return !(coordinateA.Equals(coordinateB));
        }
    }
}

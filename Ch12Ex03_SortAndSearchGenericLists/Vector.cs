using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex03_SortAndSearchGenericLists
{
    public class Vector
    {
        public double? R = null;
        public double? Theta = null;

        public double? ThetaRadians
        {
            get { return (Theta * Math.PI / 180); } //convert degrees to radians
        }

        public Vector(double? r, double? theta)
        {
            //normalize
            if (r < 0)
            {
                r = -r;
                theta += 180;
            }
            theta = theta % 360;

            //assign fields
            R = r;
            Theta = theta;
        }

        public static Vector operator +(Vector op1, Vector op2)
        {
            try
            {
                //get (x, y) coordinates for new vector
                double newX = op1.R.Value * Math.Sin(op1.ThetaRadians.Value) + op2.R.Value * Math.Sin(op2.ThetaRadians.Value);
                double newY = op1.R.Value * Math.Cos(op1.ThetaRadians.Value) + op2.R.Value * Math.Cos(op2.ThetaRadians.Value);

                //convert to (r, theta)
                double newR = Math.Sqrt(newX * newX + newY * newY);
                double newTheta = Math.Atan2(newX, newY) * 180.0 / Math.PI;

                //return result
                return new Vector(newR, newTheta);
            }
            catch
            {
                return new Vector(null, null); //return null vector
            }
        }

        public static Vector operator-(Vector op1)
        {
            return new Vector(-op1.R, op1.Theta);
        }

        public static Vector operator-(Vector op1, Vector op2)
        {
            return op1 + (-op2);
        }

        public override string ToString()
        {
            //get string representation of coordinates
            string rString = R.HasValue ? R.ToString() : "null";
            string thetaString = Theta.HasValue ? Theta.ToString() : "null";
            //return (r, theta) string
            return string.Format($"({rString}, {thetaString})");
        }
    }
}

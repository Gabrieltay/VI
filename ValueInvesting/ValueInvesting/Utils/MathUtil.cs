using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueInvesting.Models;

namespace ValueInvesting.Utils
{
   public static class MathUtil
    {
        public static List<Point> GenerateLinearBestFit( List<Point> aPoints, out double aGradient, out double aIntercept )
        {
            int numPoints = aPoints.Count;
            double meanX = aPoints.Average( point => point.X );
            double meanY = aPoints.Average( point => point.Y );

            double sumXSquared = aPoints.Sum( point => point.X * point.X );
            double sumXY = aPoints.Sum( point => point.X * point.Y );

            aGradient = ( sumXY / numPoints - meanX * meanY ) / ( sumXSquared / numPoints - meanX * meanX );
            aIntercept = ( aGradient * meanX - meanY );

            double a1 = aGradient;
            double b1 = aIntercept;

            return aPoints.Select( point => new Point() { X = point.X, Y = a1 * point.X - b1 } ).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex03_SortAndSearchGenericLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Vectors route = new Vectors()
            {
                new Vector(2.0, 90.0),
                new Vector(1.0, 180.0),
                new Vector(0.5, 45.0),
                new Vector(2.5, 315.0),
            };

            Console.WriteLine(route.Sum());

            Comparison<Vector> sorter = new Comparison<Vector>(VectorDelegates.Compare);
            route.Sort(sorter);
            ////could simplify code by using a method group instead of lines 23 and 24...
            //route.Sort(VectorDelegates.Compare);
            Console.WriteLine(route.Sum());

            Predicate<Vector> searcher = new Predicate<Vector>(VectorDelegates.TopRightQuadrant);
            //need to initialize an new Vectors collection using IEnumerable<Vector>.
            //using route.FindAll(searcher) would return a List<Vector> instance instead.
            Vectors topRightQuadrantRoute = new Vectors(route.FindAll(searcher));
            ////could simplify code by using a method group instead of lines 29 and 32...
            //Vectors topRightQuadrantRoute = new Vectors(route.FindAll(VectorDelegates.TopRightQuadrant));
            Console.WriteLine(topRightQuadrantRoute.Sum());

            Console.ReadKey();
        }
    }
}

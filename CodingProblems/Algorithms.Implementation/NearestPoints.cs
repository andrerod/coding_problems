using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementation
{
    
    public class NearestPoints
    {

        /// <summary>
        /// For given 'center' point returns a subset of 'm' stored points that are
        /// closer to the center than others.
        /// 
        /// E.g. Stored: (0, 1) (0, 2) (0, 3) (0, 4) (0, 5)
        /// 
        /// Find(new Point(0, 0), 3) -> (0, 1), (0, 2), (0, 3)
        /// 
        /// Seems like we can do this in two ways
        /// 
        ///     Quick select - as we do quick sort on distance from center point,
        ///         stop is pivot index == m, then everything on left is closest m
        ///         complexity will be n log n
        ///     
        ///     Max - Heap - reprocess the points into a max - heap with bounded size of m
        ///         Since everything in heap is smaller than max value, this will also ensure we
        ///         get m closet points. complexity will be n log m
        /// </summary>
        /// <param name="point"></param>
        /// <param name="k"></param>
        public static List<int[]> Find(List<int[]> points, int[] centerPoint, int m)
        {
            PriorityQueue<int[]> maxHeap = new PriorityQueue<int[]>((i, j) =>
                //since this is a max heap, we want to compare j against i
                //and we are comparing distance (sqrt(x^2 + y^2)) from the point
                (System.Math.Pow(j[0] - centerPoint[0], 2) + System.Math.Pow(j[1] - centerPoint[1], 2))
                    .CompareTo(System.Math.Pow(i[0] - centerPoint[0], 2) + System.Math.Pow(i[1] - centerPoint[1], 2))
            );

            foreach(int[] point in points) {
                maxHeap.Add(point);
                if (maxHeap.Storage.Count > m)
                {
                    maxHeap.ExtractRoot();
                }
            }

            List<int[]> result = new List<int[]>();
            while(maxHeap.Storage.Count > 0)
            {
                result.Add(maxHeap.ExtractRoot());
            }
            return result;
        }
    }

}

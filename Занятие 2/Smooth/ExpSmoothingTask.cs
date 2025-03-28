using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            var value = 0.0;
            var isChecked = false;

            foreach (var point in data)
            {
                var item = new DataPoint(point);

                if (isChecked)
                {
                    item = point.WithExpSmoothedY(value + alpha * (point.OriginalY - value));
                }
                else
                {
                    item = point.WithExpSmoothedY(point.OriginalY);
                    isChecked = true; 
                }

                yield return item;
                value = item.ExpSmoothedY;
            }
        }
    }
}
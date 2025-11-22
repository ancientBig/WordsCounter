namespace TS.TechnicalTest;

public class DeepestPitAnswer
{
    public static int Solution(int[] points)
    {
        if (points == null || points.Length < 3)
        {
            // We use three dimension
            return -1;
        }

        int maxDepth = 0;

        for (int i = 0; i < points.Length; i++)
        {
            // Find the left boundary (a "hill" or higher point)
            if(points[i] <= 0)
            {
                continue;
            }
            int leftMax = points[i];

            // If is Increasing immediately, skip as this is a rising edge
            if (i + 1 < points.Length && points[i + 1] > leftMax)
            {
                continue;
            }

            int rightMax = 0;
            List<int> pointsInRange = [];
            bool crossGround = false;

            // Find the next high point
            for (int r = i; r < points.Length; r++)
            {
                pointsInRange.Add(points[r]);
                if (points[r] > 0 && r != i && points[r]> rightMax && points[r] != rightMax)
                {
                    rightMax = points[r];
                    if (crossGround)
                    {
                        break;
                    }
                }
                if (points[r] == 0)
                {
                    crossGround = true;
                }
            }

            int lowestArea = pointsInRange.Min();

            // Calculate the potential depth at the current area
            int currentDepth = Math.Min((leftMax-(lowestArea)),(rightMax-(lowestArea)));

            // Update the maximum depth found so far
            maxDepth = Math.Max(maxDepth, currentDepth);
        }

        return maxDepth;
    }
}

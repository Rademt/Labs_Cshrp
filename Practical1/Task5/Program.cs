namespace Task5
{
    public class Program
    {
        public static double GetAverage(int[] marks)
        {
            int sum = 0;
            foreach (int m in marks) sum += m;
            return (double)sum / marks.Length;
        }

        public static int GetMin(int[] marks)
        {
            int min = marks[0];
            foreach (int m in marks) if (m < min) min = m;
            return min;
        }

        public static int GetMax(int[] marks)
        {
            int max = marks[0];
            foreach (int m in marks) if (m > max) max = m;
            return max;
        }

        public static void PrintGroupStatistics(int[][] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine($"Група {i + 1}: " +
                    $"Середній = {GetAverage(groups[i]):F1}, " +
                    $"Мінімальний = {GetMin(groups[i])}, " +
                    $"Максимальний = {GetMax(groups[i])}");
            }
        }

        public static void Main()
        {
            int[][] groups = new int[][]
            {
            new int[] { 31, 64, 53, 97, 86 },
            new int[] { 76, 83, 99, 100, 57 },
            new int[] { 89, 93, 74, 46, 81 }
            };

            PrintGroupStatistics(groups);
        }
    }
}

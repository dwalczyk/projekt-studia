public class Projekt
{
    public static void Main(string[] args)
    {
        var arr = LoadFromFile("C:/Users/bodac/Desktop/dane5s.txt");
        
        var x = 469;
        var n = arr.Length;
        var index = InterpolationSearch(arr, 0, n - 1, x);
        
        if (index != -1) {
            Console.WriteLine("Element {" + x + "} znajduje sie w indeksie: " + index);
        }
        else {
            Console.WriteLine("Element nie znaleziony.");
        }
    }

    private static int InterpolationSearch(int[] arr, int lo, int hi, int x)
    {
        if (lo <= hi && x >= arr[lo] && x <= arr[hi]) {

            var position = lo + (((hi - lo) / (arr[hi] - arr[lo])) * (x - arr[lo]));

            if (arr[position] == x) {
                return position;
            }
    
            if (arr[position] < x) {
                return InterpolationSearch(arr, position + 1, hi, x);
            }
                                           
            if (arr[position] > x) {
                return InterpolationSearch(arr, lo, position - 1, x);
            }
        }
        
        return -1;
    }

    private static int[] LoadFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        List<int> numbers = new List<int>();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            if (!string.IsNullOrEmpty(line))
            {
                string[] stringNumbers = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < stringNumbers.Length; j++)
                {
                    if (!int.TryParse(stringNumbers[j], out int num))
                    {
                        throw new OperationCanceledException(stringNumbers[j] + " was not a number.");
                    }
                    numbers.Add(num);
                }
            }
        }
        int[] array = numbers.ToArray();

        return array;
    }
}
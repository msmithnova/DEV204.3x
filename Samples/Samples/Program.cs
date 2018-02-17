using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calculate power
            int numBase = 2;
            int exp = 16;
            int result = Power(numBase, exp);
            Console.WriteLine($"Result is {result}");

            // Calculate cylinder volume
            double radius = 5.5;
            double height = 3.4;
            double dblResult = CylinderVolume(radius, height);
            Console.WriteLine($"Result is {dblResult}");

            // Bubble Sort, 
            BubbleSortTest();
            SortTest(100, 100, BubbleSort, true);
            Console.WriteLine("Testing BubbleSort with 10000 ints.");
            SortTest(10000, 10000, BubbleSort, false);
            Console.WriteLine();

            // Bubble Sort Enhanced - Last item is sorted after each loop so check one less item each loop
            // Should be about 33% faster, so much better but still O(n^2)
            SortTest(100, 100, BubbleSortEnh, true);
            Console.WriteLine("Testing BubbleSortEnh with 10000 ints.");
            SortTest(10000, 10000, BubbleSortEnh, false);
            Console.WriteLine();

            // Bubble Sort Enhanced 2 - This is about twice as fast as Bubble Sort Enhanced
            // and three times as fast as Bubble Sort.
            // Goes through the array only once forward. If it finds a number that needs to be
            // swapped it does so and then works backward through the array with that number until
            // it doesnt need to be swapped any more. Then continues forward in the array where it
            // left off before it started going backwards.
            SortTest(100, 100, BubbleSortEnh2, true);
            Console.WriteLine("Testing BubbleSortEnh2 with 10000 ints.");
            SortTest(10000, 10000, BubbleSortEnh2, false);
            Console.WriteLine();
        }

        // Calculate power using base and exponent
        static int Power(int numBase, int exp)
        {
            int result = 1;
            while (exp > 0)
            {
                result = result * numBase;
                exp--;
            }
            return result;
        }

        // Calculates volume of cylinder using radius and height
        static double CylinderVolume(double radius, double height)
        {
            return Math.PI * radius * radius * height;
        }

        // Classic Bubble Sort
        static void BubbleSort(int[] nums)
        {
            // Use this to know when to stop the sorting routine
            bool swapped;

            // Here we use a do loop but could have used for or while loops as well.
            do
            {
                // set swapped to false so that we can ensure at least one pass on the array
                swapped = false;

                // This loop will iterate over the array from beginning to end
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    // here we use the i for the position in the array
                    // So i is the first value to compare and i + 1 compares the adjacent value
                    // Once i is incremented at the end of this loop, we compare the next two sets of values, etc.
                    if (nums[i] > nums[i + 1])
                    {
                        // swap routine.  Could be a separate method as well but is used inline for simplicity here
                        // temp is used to hold the right value in the comparison so we  don't lose it.  That value will be replaced in the next step
                        int temp = nums[i + 1];

                        // Here we replace the right value with the larger value that was on the left.   See why we needed the temp variable above?
                        nums[i + 1] = nums[i];

                        // Now we assign the value that is in temp, the smaller value, to the location that was just vacated by the larger number
                        nums[i] = temp;

                        // Indicate that we did a swap, which means we need to continue to check the remaining values.
                        swapped = true;
                    }
                }
            } while (swapped == true);
        }

        // Outputs array to console
        static void OutputIntArray(int[] nums)
        {
            Console.Write("{0}", nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                Console.Write(", {0}", nums[i]);
            }
            Console.WriteLine();
        }

        // Basic test of Bubble Sort
        static void BubbleSortTest()
        {
            // declare an array of integers that are not sorted
            int[] nums = { 5, 10, 3, 2, 4 };

            // Output the unsorted array to the console
            Console.WriteLine("Before: 5, 10, 3, 2, 4");

            BubbleSort(nums);

            // output the sorted array to the console

            Console.Write("After: ");
            OutputIntArray(nums);
        }

        // Helper method to test validity and timing of algorithm
        // Choose the array lenth to test and the max int to generate random numbers from
        // Pass in the algorithm to test. The print parameter if true will print out the before and
        // after arrays for visual inspection. If print is false it will time the algorithm which
        // is good for longer arrays when you know the algorithm is working.
        static void SortTest(int arrayLength, int maxInt, Action<int[]> sortMethod, bool print)
        {
            // Create random array of arrayLength with ints from [0, maxInt)
            Random rand = new Random();
            int[] nums = new int[arrayLength];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(maxInt);
            }
            // If print is true output array before and after running algorithm
            if (print)
            {
                Console.Write("Before: ");
                OutputIntArray(nums);

                sortMethod(nums);

                Console.Write("After: ");
                OutputIntArray(nums);
            }
            // If print is false, time the algorithm instead and output timing
            else
            {
                long milliSeconds = TimeMethod(nums, sortMethod);
                Console.WriteLine("Code ran in {0} milliseconds", milliSeconds);
            }
        }

        // Same as BubbleSort except it adds a sorted variable so it can skip already sorted items
        // at the end of the array.
        static void BubbleSortEnh(int[] nums)
        {
            bool swapped;
            int sorted = 1;
            do
            {
                swapped = false;
                for (int i = 0; i < nums.Length - sorted; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        int temp = nums[i + 1];
                        nums[i + 1] = nums[i];
                        nums[i] = temp;
                        swapped = true;
                    }
                }
                sorted++;
            } while (swapped == true);
        }

        // Similar to BubbleSort but it goes through the array only once forward. When it finds a
        // number to swap it continues swapping it backwards through the array only as far as needed.
        // It then continues going forward from where it left off.
        static void BubbleSortEnh2(int[] nums)
        {
            bool swapped = false;
            // Go through aray looking for a number that needs to be swapped
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // If we found a number that needs to be swapped then swap it
                if (nums[i] > nums[i + 1])
                {
                    int temp = nums[i + 1];
                    nums[i + 1] = nums[i];
                    nums[i] = temp;
                    swapped = true;
                }
                // If we swapped a number above continue swapping it up the array as far as needed
                if (swapped)
                {
                    // Move backwards through the array as far as needed
                    for (int j = i; j > 0; j--)
                    {
                        // If number needs to be swapped, swap it and continue
                        if (nums[j] < nums[j - 1])
                        {
                            int temp = nums[j - 1];
                            nums[j - 1] = nums[j];
                            nums[j] = temp;
                        }
                        // Else the number is where it needs to be, break out of inner for loop
                        // and continue forward through the array in outer for loop.
                        else break;
                    }
                    swapped = false;
                }
            }
        }

        // Simple timing method to time algorithm with array passed in.
        static long TimeMethod(int[] nums,  Action<int[]> method) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            method(nums);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}

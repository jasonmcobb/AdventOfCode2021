using AdventOfCode2021.Constants;

namespace AdventOfCode2021.DayOne;

public class DayOne
{
    private readonly int[] _inputDataSet = InputConstants.DayOneInputDataSet;
    
    public void Solutions()
    {
        Console.WriteLine("Advent of Code Day One:: ");
        Console.WriteLine($"Part One Solution :{ProblemLogicPartOne().ToString()}");
        Console.WriteLine($"Part Two Solution :{ProblemLogicPartTwo().ToString()}");
    }
    
    private int ProblemLogicPartOne()
    {
        /*
         * Problem Statement Summary:
         * Loop over the list, increase counter every time the current number is larger than the previous.
         * I.E.
         * Array:
         * 1, First Number, No comparison
         * 2, Increase
         * 4, Increase
         * 3, Decrease
         * 2, Decrease
         * 6  Increase
         *
         * Response would be 3
         */
        
        var holderOne = 0;
        var count = 0;
        var notFirstLoop = false;
        
        foreach (var item in _inputDataSet)
        {
            if (notFirstLoop)
            {
                if (item > holderOne)
                {
                    count++;
                }
            }
            else
            {
                notFirstLoop = true;
            }
            
            holderOne = item;
        }
        
        return count;
    }
    
    private int ProblemLogicPartTwo()
    {
        /*
         * Problem Statement:
         * Considering every single measurement isn't as useful as you expected: there's just too much noise in the data.
         *
         * Instead, consider sums of a three-measurement sliding window. Again considering the above example:
         *
         * 199  A      
         * 200  A B    
         * 208  A B C  
         * 210    B C D
         * 200  E   C D
         * 207  E F   D
         * 240  E F G  
         * 269    F G H
         * 260      G H
         * 263        H
         * Start by comparing the first and second three-measurement windows.
         * The measurements in the first window are marked A (199, 200, 208);
         * their sum is 199 + 200 + 208 = 607. The second window is marked B (200, 208, 210); its sum is 618.
         * The sum of measurements in the second window is larger than the sum of the first, so this first comparison increased.
         *
         * Your goal now is to count the number of times the sum of measurements in this sliding window increases from the previous sum.
         * So, compare A with B, then compare B with C, then C with D, and so on.
         * Stop when there aren't enough measurements left to create a new three-measurement sum.
         *
         * In the above example, the sum of each three-measurement window is as follows:
         *
         * A: 607 (N/A - no previous sum)
         * B: 618 (increased)
         * C: 618 (no change)
         * D: 617 (decreased)
         * E: 647 (increased)
         * F: 716 (increased)
         * G: 769 (increased)
         * H: 792 (increased)
         * In this example, there are 5 sums that are larger than the previous sum.
         *
         * Consider sums of a three-measurement sliding window. How many sums are larger than the previous sum?
         */

        var count = 0;
        var arrayLength = _inputDataSet.Length;

        for (var i = 3; i < arrayLength; i++)
        {
            if (i >= arrayLength - 2)
            {
                continue;
            }
            
            var currentSum = _inputDataSet[i] + _inputDataSet[i + 1] + _inputDataSet[i + 2];
            var previousSum = _inputDataSet[i - 1] + _inputDataSet[i] + _inputDataSet[i + 1];
            
            if (currentSum > previousSum)
            {
                count++;
            }
        }

        return count;
    }
}
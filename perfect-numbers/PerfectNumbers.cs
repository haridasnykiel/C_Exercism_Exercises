using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification {
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers {
    public static Classification Classify (int number) {
        // Note that this loop runs  
        // till square root 

        if(number <= 0) {
            throw new ArgumentOutOfRangeException();
        }

        var squareRootOfNumber = Math.Sqrt (number);// square root of number.
        List<int> divisors = new List<int> ();

        for (int i = 1; i <= squareRootOfNumber; i++) {
            if (number % i == 0) {
                if (number / i == i) {
                    divisors.Add (i); 
                }
                else {
                    divisors.Add (i);
                    if ((number / i) != number)
                        divisors.Add (number / i);
                }
            }
        }

        var sum = divisors.Sum ();

        if (sum == number) {
            return Classification.Perfect;
        } else if (sum < number) {
            return Classification.Deficient;
        } else {
            return Classification.Abundant;
        }
    }
}
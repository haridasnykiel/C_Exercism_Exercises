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

        if (number <= 0) {
            throw new ArgumentOutOfRangeException ();
        }
        
        int sum = 0;

        for (int i = 1; i <= number / 2; i++) {
            if(number % i == 0) {
                sum += i;
            }
        }

        return sum == number ? Classification.Perfect : sum < number ? Classification.Deficient : Classification.Abundant;
    }
}
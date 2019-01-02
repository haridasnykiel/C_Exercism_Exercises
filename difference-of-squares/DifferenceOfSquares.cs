using System;
using System.Collections.Generic;
using System.Linq;

public static class DifferenceOfSquares {
    public static int CalculateSquareOfSum (int max) {
        var ints = GetListOfInt (max);
        var sum = ints.Sum ();
        return (int) Math.Pow (sum, 2);
    }

    public static int CalculateSumOfSquares (int max) {
        var ints = GetListOfInt (max);
        for (int i = 0; i < ints.Length; i++) {
            ints[i] = (int) Math.Pow (ints[i], 2);
        }
        return ints.Sum ();
    }

    public static int CalculateDifferenceOfSquares (int max) {
        var squareOfSum = CalculateSquareOfSum (max);
        var sumOfSquare = CalculateSumOfSquares (max);
        return squareOfSum > sumOfSquare 
            ? squareOfSum - sumOfSquare 
            : sumOfSquare - squareOfSum;
    }

    private static int[] GetListOfInt (int max) {
        var intArr = new List<int> ();
        for (int i = 0; i < max; i++) {
            intArr.Add (i + 1);
        }
        return intArr.ToArray ();
    }
}
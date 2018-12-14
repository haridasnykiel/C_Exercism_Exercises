using System;
using System.Linq;

public static class Hamming {
    public static int Distance (string firstStrand, string secondStrand) {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException ("The strands are not of equal length.");

        var first = firstStrand.ToCharArray ();
        var second = secondStrand.ToCharArray ();
        var count = 0;
        for (int i = 0; i < firstStrand.Length; i++) {
            if(first[i] != second[i])
                count++;
        }
        return count;
    }
}
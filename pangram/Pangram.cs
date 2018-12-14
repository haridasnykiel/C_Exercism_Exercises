using System;

public static class Pangram {
    public static bool IsPangram (string input) {
        int min = 97;
        int max = 123;
        int count = 0;
        input = input.ToLower ();
        for (int i = min; i < max; i++) {
            var character = (char) i;
            if (input.Contains (character)) { count++; }
        }
        return count == (max - min);
    }
}
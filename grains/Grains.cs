using System;

public static class Grains {
    public static ulong Square (int n) {

        if (n <= 0 || n > 64) {
            throw new ArgumentOutOfRangeException ();
        }

        ulong numberOfGrains = 0;
        for (int i = 0; i < n; i++) {
            if (i == 0)
                numberOfGrains = 1;
            else
                numberOfGrains += numberOfGrains;
        }
        return numberOfGrains;
    }

    public static ulong Total () {
        ulong total = 0;
        for (int i = 1; i <= 64; i++)
        {
            total += Square(i);
        }
        return total;
    }

}
using System;
using System.Diagnostics;

public static class RealNumberExtension {
    public static double Expreal (this int realNumber, RationalNumber r) {
        var quotient = (double) r._numerator / (double) r._denominator;
        return Math.Pow (realNumber, quotient);
    }
}

public struct RationalNumber {

    public int _numerator;
    public int _denominator;

    public RationalNumber (int numerator, int denominator) {
        _numerator = denominator < 0 ? -1 * numerator : numerator;
        _denominator = denominator < 0 ? Math.Abs (denominator) : denominator;
        CalculateGCD ();
    }

    private void CalculateGCD () {
        var gcd = Reduce (denominator: Math.Abs (_denominator), numerator: Math.Abs (_numerator));
        _numerator = _numerator / gcd;
        _denominator = _denominator / gcd;
    }

    private int Reduce (int denominator, int numerator) {
        if (denominator > numerator) {
            return GCD (denominator, numerator);
        } else {
            return GCD (numerator, denominator);
        }
    }

    private int GCD (int dividend, int divisor) {
        while (divisor != 0) {
            var temp = divisor;
            divisor = dividend % divisor;
            dividend = temp;
        }
        return Math.Abs (dividend);
    }

    public RationalNumber Add (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._denominator + this._denominator * r._numerator,
            _denominator = this._denominator * r._denominator);
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) => r1.Add(r2);

    public RationalNumber Sub (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._denominator - this._denominator * r._numerator,
            this._denominator * r._denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) => r1.Sub(r2);

    public RationalNumber Mul (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._numerator,
            Math.Abs (this._denominator * r._denominator)
        );
    }

    public static RationalNumber operator * (RationalNumber r1, RationalNumber r2) => r1.Mul (r2);

    public RationalNumber Div (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._denominator,
            this._denominator * r._numerator);
    }

    public static RationalNumber operator / (RationalNumber r1, RationalNumber r2) => r1.Div (r2);

    public RationalNumber Abs () {
        return new RationalNumber (
            this._numerator < 0 ? this._numerator * -1 : this._numerator,
            this._denominator < 0 ? this._denominator * -1 : this._denominator);
    }

    public RationalNumber Reduce() => this;

    public RationalNumber Exprational (int power) {
        return new RationalNumber (
            Convert.ToInt32 (Math.Pow (this._numerator, power)),
            Convert.ToInt32 (Math.Pow (this._denominator, power))
        );
    }
}
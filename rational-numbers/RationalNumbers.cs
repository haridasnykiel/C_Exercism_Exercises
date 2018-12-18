using System;
using System.Diagnostics;

public static class RealNumberExtension {
    public static double Expreal (this int realNumber, RationalNumber r) {
        throw new NotImplementedException ("You need to implement this extension method.");
    }
}

public struct RationalNumber {

    int _numerator;
    int _denominator;

    public RationalNumber (int numerator, int denominator) {
        _numerator = denominator < 0 ? -1 * numerator : numerator;
        _denominator = denominator < 0 ? Math.Abs (denominator) : denominator;
        CalculateGCD();
    }

    private void CalculateGCD () {
        var gcd = Reduce (a: Math.Abs (_denominator), b: Math.Abs (_numerator));
        _numerator = _numerator / gcd;
        _denominator = _denominator / gcd;
    }

    private int Reduce (int a, int b) {
        if (a > b) {
            return GCD (a, b);
        } else {
            return GCD (b, a);
        }
    }

    private int GCD (int a, int b) {
        while (b != 0) {
            var t = b;
            b = a % b;
            a = t;
        }
        return Math.Abs (a);
    }

    public RationalNumber Add (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._denominator + this._denominator * r._numerator,
            _denominator = this._denominator * r._denominator);
    }

    public static RationalNumber operator + (RationalNumber r1, RationalNumber r2) {
        return r1.Add (r2);
    }

    public RationalNumber Sub (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._denominator - this._denominator * r._numerator,
            this._denominator * r._denominator);
    }

    public static RationalNumber operator - (RationalNumber r1, RationalNumber r2) {
        return r1.Sub (r2);
    }

    public RationalNumber Mul (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._numerator,
            Math.Abs (this._denominator * r._denominator)
        );
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => r1.Mul(r2);

    public RationalNumber Div (RationalNumber r) {
        return new RationalNumber (
            this._numerator * r._denominator,
            this._denominator * r._numerator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => r1.Div(r2);

    public RationalNumber Abs () {
        return new RationalNumber (
            this._numerator < 0 ? this._numerator * -1 : this._numerator,
            this._denominator < 0 ? this._denominator * -1 : this._denominator);
    }

    public RationalNumber Reduce () {
        throw new NotImplementedException ("You need to implement this function.");
    }

    public RationalNumber Exprational (int power) {
        return new RationalNumber(
            Convert.ToInt32(Math.Pow(this._numerator, power)), 
            Convert.ToInt32(Math.Pow(this._denominator, power))
        );
    }

    public double Expreal (int baseNumber) {
        throw new NotImplementedException ("You need to implement this function.");
    }
}
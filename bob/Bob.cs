using System;
using System.Linq;
using System.Text;

public static class Bob {
    public static string Response (string statement) {

        statement = statement.TrimEnd ();

        var allCharacters = statement.Where (c => !char.IsWhiteSpace (c));
        var countLowerCaseCharacters = statement.Where (c => char.IsLower (c)).Count ();
        var countUpperCaseCharacters = statement.Where (c => char.IsUpper (c)).Count ();

        if (allCharacters.Count () == 0)
            return "Fine. Be that way!";
        else if (statement[statement.Length - 1] == '?' && countLowerCaseCharacters >= countUpperCaseCharacters)
            return "Sure.";
        else if (countLowerCaseCharacters == 0 && statement[statement.Length - 1] == '?')
            return "Calm down, I know what I'm doing!";
        else if (countLowerCaseCharacters == 0 && countUpperCaseCharacters > 0)
            return "Whoa, chill out!";

        return "Whatever.";

    }
}
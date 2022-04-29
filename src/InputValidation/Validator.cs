using System.Text.RegularExpressions;

namespace InputValidation;

public class Validator : IValidator
{
    /// <summary>
    /// laver en Regex som tjekker indhold i email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public bool IsValidEmail(string email)
    {
        //må var store og små bogstaver, symboler og maks 64 tegn. ->
        //efter @ skal der var være ->
        //efter tekst/tal/- skal der være et '.' ->
        //efter '.' skal der være tekst.
        string pattern = @"^[a-zA-Z0-9.!#$%&'*+=?^-{64}]+@[a-zA-Z0-9-]+[.][a-zA-Z]+$";

        //laver et regex objekt med regex mønster
        var regex = new Regex(pattern);

        //hvis den matcher mønster returner 
        return regex.IsMatch(email);
    }
}

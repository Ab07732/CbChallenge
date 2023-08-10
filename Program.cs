using CbChallenge.Validation;



public class Program
{
    private static void Main(string[] args)
    {
        new Validator().Validate();
        Console.WriteLine("Success! The integration imported the data correctly.");
    }
}
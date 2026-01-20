using EMV.Card;

class Program
{
    static void Main(string[] args)
    {
        var card = new EmvCard(
        "1234567812345678",
        DateTime.Now.AddYears(2),
        30.00m,
        "2011"
        );

        Console.WriteLine(card.GetMaskedPan());
        Console.WriteLine(card.IsExpired() ? "Expired" : "Valid");
        Console.WriteLine(card.RequiresPin(25.00m) ? "PIN needed" : "No PIN needed");
    }
}
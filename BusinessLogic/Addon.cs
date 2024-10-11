namespace BusinessLogic;

public class Addon
{
    public string Code { get; set; }
    public double Price { get; set; }
    public int SlotsCount { get; set; }
    public List<Keyword>? Keywords { get; set; }

    public Addon(string code, double price, int slotsCount, List<Keyword>? keywords)
    {
        Code = code;
        Price = price;
        SlotsCount = slotsCount;
        Keywords = keywords;
    }
    
    public Addon(string code, double price, int slotsCount)
    {
        Code = code;
        Price = price;
        SlotsCount = slotsCount;
    }
}

/*
public enum Keyword
{
    Heavygun,
    Twinlinked,
    Addon
}
*/
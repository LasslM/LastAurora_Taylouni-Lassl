namespace BusinessLogic;

public class Trailer
{
    public String Code { get; set; }
    public double Price { get; set; }
    public int SlotsCount { get; set; }
    public Addon? Addon { get; set; }
    public List<ISlot>? Slots { get; set; }

    public Trailer(string code, double price, int slotsCount)
    {
        Code = code;
        Price = price;
        SlotsCount = slotsCount;
    }
    
    //public List<Keyword> Keywords { get; set; }
}

public enum KeywordTrailer
{
    Chain_drive,
    Armor,
    Tesla_Weaponry,
    Heavy_Weaponry,
    Vulcan_armor,
}
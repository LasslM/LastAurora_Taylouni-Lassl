namespace BusinessLogic;

public class Truck
{
    public String Code { get; set; }
    public int Velocity { get; set; }
    public double Price { get; set; }
    public int Traction { get; set; }
    public int SlotsCount { get; set; } = 4;
    public List<Keyword> Keywords { get; set; }
    public IAddon? Addon { get; set; }
    public List<ISlot> Slots { get; private set; }

    public Truck(string code, int velocity, double price, int traction, List<Keyword> keywords)
    {
        Code = code;
        Velocity = velocity;
        Price = price;
        Traction = traction;
        Keywords = keywords;
        Slots = new List<ISlot>();
    }
    
    public Task AddSlot(ISlot slot)
    {
        if (Slots.Count < SlotsCount)
        {
            Slots.Add(slot);
        }

        return Task.CompletedTask;
    }
    
    public async Task MoveAsync()
    {
        await Task.Delay(Velocity * 1000);
    }
}

public enum Keyword
{
    Chain_drive,
    Armor,
    Tesla_Weaponry,
    Heavy_Weaponry,
    Vulcan_armor,
}
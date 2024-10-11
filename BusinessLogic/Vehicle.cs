namespace BusinessLogic;

public class Vehicle
{
    public String Code { get; set; }
    public double Price { get; set; }
    public int SlotsCount { get; set; } = 4;
    public List<Keyword> Keywords { get; set; }
    public Addon? Addon { get; set; }
    public List<ISlot> Slots { get; private set; } = new List<ISlot>();
    
    public Task AddSlot(ISlot slot)
    {
        if (Slots.Count < SlotsCount)
        {
            Slots.Add(slot);
        }

        return Task.CompletedTask;
    }
}

public enum Keyword
{
    
    Chain_drive,
    Armor,
    Tesla_Weaponry,
    Heavy_Weaponry,
    Vulcan_armor,
    Heavygun,
    Twinlinked,
    Addon
}
namespace BusinessLogic;

public class Vehicle
{
    public String Code { get; set; }
    public double Price { get; set; }
    public int SlotsCount { get; set; } = 4;

    private List<Keyword> _keywords = new List<Keyword>();

    public List<Keyword> Keywords
    {
        get
        {
            var keywords = new List<Keyword>();
            //Keywords from HeadTruck, TailTruck and Trailers
            keywords.AddRange(_keywords);
            keywords.AddRange(Slots.SelectMany(trailer => trailer.Keywords));
            if (Addon != null)
            {
                keywords.AddRange(Addon.Keywords);
            }
            
            keywords = keywords.Distinct().ToList();
            if (keywords.Count == 0) return new List<Keyword>();
            return keywords;
        }
    }
    

    public Addon? Addon { get; set; }
    public List<ASlot> Slots { get; private set; } = new List<ASlot>();
    
    public Task AddSlot(ASlot slot)
    {
        if (Slots.Count < SlotsCount)
        {
            Slots.Add(slot);
            return Task.CompletedTask;
        }
        else
        {
            throw new Exception("No free slots");
        }
    }
    
    public void AddKeyword(Keyword keyword)
    {
        _keywords.Add(keyword);
    }
    
    public void RemoveKeyword(Keyword keyword)
    {
        _keywords.Remove(keyword);
    }
    
    public void AddKeywords(List<Keyword> keywords)
    {
        _keywords.AddRange(keywords);
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
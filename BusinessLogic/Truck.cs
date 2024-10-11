namespace BusinessLogic;

public class Truck : Vehicle
{
    public int Velocity { get; set; }
    public int Traction { get; set; }

    public Truck(string code, int velocity, double price, int traction, List<Keyword> keywords)
    {
        Code = code;
        Velocity = velocity;
        Price = price;
        Traction = traction;
        Keywords = keywords;
    }
    
    
    public async Task MoveAsync()
    {
        await Task.Delay(Velocity * 1000);
    }
}

/*
public enum KeywordTruck
{
    Chain_drive,
    Armor,
    Tesla_Weaponry,
    Heavy_Weaponry,
    Vulcan_armor
}
*/
namespace BusinessLogic;

public class Machinery : ISlot
{
    public EState State { get; set; } = EState.Active;
}
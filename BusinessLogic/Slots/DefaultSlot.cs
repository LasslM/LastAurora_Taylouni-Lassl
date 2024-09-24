namespace BusinessLogic;

public class DefaultSlot : ISlot
{
    public EState State { get; set; } = EState.Active;
}
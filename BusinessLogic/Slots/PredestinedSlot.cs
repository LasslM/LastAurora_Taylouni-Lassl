namespace BusinessLogic;

public class PredestinedSlot : ISlot
{
    public EState State { get; set; } = EState.Active;
}
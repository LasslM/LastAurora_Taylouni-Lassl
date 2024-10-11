namespace BusinessLogic;

public interface ISlot
{
    public EState State { get; set; }
    
}


public enum EState
{
    Active,
    Damaged,
    Broken,
}
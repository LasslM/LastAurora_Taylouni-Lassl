namespace BusinessLogic;

public abstract class ASlot
{
    private EState _state = EState.Active;
    public EState State
    {
        get { return _state; }
        set
        {
            if (value == EState.Broken)
            {
                Keywords = new List<Keyword>();
            }

            _state = value;
        }
    }

    public List<Keyword> Keywords { get; set; } = new List<Keyword>();
    
    
}


public enum EState
{
    Active,
    Damaged,
    Broken,
}
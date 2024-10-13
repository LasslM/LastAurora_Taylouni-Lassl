namespace BusinessLogic;

public class PredestinedSlot<T>  : ASlot where T : ICargo
{
    public T? Cargo { get; set; }
}
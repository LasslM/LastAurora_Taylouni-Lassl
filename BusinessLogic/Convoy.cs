using System.Drawing;

namespace BusinessLogic;

public class Convoy
{
    public Truck HeadTruck { get; private set; }
    public Truck? TailTruck { get; private set; }
    public List<Trailer> Trailers { get; set; }

    public int Traction
    {
        get
        {
            if (TailTruck != null) return HeadTruck.Traction + TailTruck.Traction;
            return HeadTruck.Traction;
        }
    }

    public int Velocity
    {
        get
        {
            if(HeadTruck.Velocity > TailTruck.Velocity) { return HeadTruck.Velocity; }
            return TailTruck.Velocity;
        }
    }

    public Convoy(Truck headTruck)
    {
        HeadTruck = headTruck;
    }
    
    public void AddTailTruck(Truck truck)
    {
        TailTruck = truck;
    }
}
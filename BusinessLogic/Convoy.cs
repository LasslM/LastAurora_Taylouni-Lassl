using System.Drawing;

namespace BusinessLogic;

public class Convoy
{
    public Truck HeadTruck { get; private set; }
    public Truck? TailTruck { get; private set; }
   
    private List<Trailer> _trailers = new List<Trailer>();
    public List<Trailer> Trailers
    {
        get => _trailers;
        set
        {
            // Ensure the list contains no more than 5 items
            if (value.Count <= 5)
            {
                _trailers = value;
            }
            else
            {
                _trailers = value.Take(5).ToList(); // Take only the first 5 items
            }
        }
    }
    
   

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
    public void AddTrailer(Trailer trailer)
    {
        if (_trailers.Count < Traction)
        {
            _trailers.Add(trailer);
        }
        else
        {
            Console.WriteLine("Number of Trailers exceeds Traction");
        }
    }
    public void AddTrailers(List<Trailer> trailers)
    {
        foreach (var trailer in trailers)
        {
            if (_trailers.Count < Traction)
            {
                _trailers.Add(trailer);
            }
            else
            {
                throw new Exception("Number of Trailers exceeds Traction");
            }
        }
    }
}


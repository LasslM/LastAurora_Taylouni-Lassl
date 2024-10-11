using System.Drawing;

namespace BusinessLogic;

public class Convoy
{
    public Truck HeadTruck { get; private set; }
    public Truck? TailTruck { get; private set; }
    public List<Trailer> Trailers { get; private set; } = new List<Trailer>();

    public List<Keyword> Keywords
    {
        get
        {   
            var keywords = new List<Keyword>();
            //Keywords from HeadTruck, TailTruck and Trailers
            keywords.AddRange(HeadTruck.Keywords);
            keywords.AddRange(Trailers.SelectMany(trailer => trailer.Keywords));
            keywords.AddRange(TailTruck.Keywords);
            
            //Keywords from Addons
            keywords.AddRange(HeadTruck.Addon.Keywords);
            keywords.AddRange(Trailers.SelectMany(trailer => trailer.Addon.Keywords));
            keywords.AddRange(TailTruck.Addon.Keywords);
            
            keywords = keywords.Distinct().ToList();
            return keywords;
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
        if (Trailers.Count <= Traction)
        {
            Trailers.Add(trailer);
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
            if (Trailers.Count <= Traction)
            {
                Trailers.Add(trailer);
            }
            else
            {
                throw new Exception("Number of Trailers exceeds Traction");
            }
        }
    }
}


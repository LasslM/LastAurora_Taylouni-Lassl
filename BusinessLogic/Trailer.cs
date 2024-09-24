﻿namespace BusinessLogic;

public class Trailer
{
    public String Code { get; set; }
    public double Price { get; set; }
    public int SlotsCount { get; set; }

    public Trailer(string code, double price, int slotsCount)
    {
        Code = code;
        Price = price;
        SlotsCount = slotsCount;
    }
    //public List<Keyword> Keywords { get; set; }
    //public IAddon? Addon { get; set; }
}
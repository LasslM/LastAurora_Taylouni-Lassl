﻿namespace BusinessLogic;

public class Trailer : Vehicle
{
    public Trailer(string code, double price, int slotsCount)
    {
        Code = code;
        Price = price;
        SlotsCount = slotsCount;
    }
}

/*
public enum KeywordTrailer
{
    Chain_drive,
    Armor,
    Tesla_Weaponry,
    Heavy_Weaponry,
    Vulcan_armor,
}
*/
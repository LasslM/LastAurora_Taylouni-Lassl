using BusinessLogic;

namespace UnitTest;

public class Tests
{
    public Convoy Convoy { get; set; }
    [SetUp]
    public void Setup()
    {
        Truck _headTruck = new Truck(
            "Tesla Tank",
            3,
            10_000,
            3, 
            new List<Keyword>() { Keyword.Chain_drive , Keyword.Tesla_Weaponry});
        
        Convoy = new Convoy(_headTruck);
        
        Truck _tailTruck = new Truck(
            "Railgun Tank",
            4,
            140_000,
            3, 
            new List<Keyword>() { Keyword.Armor });
        
        Convoy.AddTailTruck(_tailTruck);
        
        #region Trailers

        Trailer _trailer1 = new Trailer(
            "Medical Wagon",
            15_000,
            4);
        
        Trailer _trailer2 = new Trailer(
            "Reinforced Fuelagon",
            10_000,
            4);

        Trailer _trailer3 = new Trailer(
            "Wagon",
            5_000,
            3);
        
        Convoy.AddTrailers(new List<Trailer> { _trailer1, _trailer2, _trailer3 });
        #endregion
    }
    
    [Test]
    public void HeadTailAssessment()
    {
        Assert.AreEqual(Convoy.HeadTruck.Code, "Tesla Tank");
        Assert.AreEqual(Convoy.TailTruck.Code, "Railgun Tank");
    }

    [Test]
    public void ConvoyVelocity()
    {
        Assert.AreEqual(Convoy.Velocity, 4);
    }
    
    [Test]
    public void ConvoyTraction()
    {
        Assert.AreEqual(Convoy.Traction, 6);
    }
    
    [Test]
    public void ConvoyTrailersCount()
    {
        Assert.AreEqual(Convoy.Trailers.Count, 3);
    }

    [Test]
    public void ConvoyTrailers() // Ermitteln Sie wieviel Anhänger noch zum Konvoi hinzugefügt werden können. 
    {
        Assert.AreEqual(Convoy.Traction - Convoy.Trailers.Count, 3);
    }
}
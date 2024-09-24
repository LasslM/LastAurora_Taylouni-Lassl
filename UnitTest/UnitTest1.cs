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
}
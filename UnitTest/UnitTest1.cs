using System.ComponentModel;
using BusinessLogic;

namespace UnitTest;

public class Tests
{
    public Convoy Convoy { get; set; }
    [SetUp]
    public void Setup()
    {
        # region Setup Trucks and Convoy
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
        # endregion
        
        #region Setup Trailers

        Trailer _trailer1 = new Trailer(
            "Medical Wagon",
            15_000,
            4);
        
        Trailer _trailer2 = new Trailer(
            "Reinforced Fuelwagon",
            10_000,
            4);

        Trailer _trailer3 = new Trailer(
            "Wagon",
            5_000,
            3);
        
        Trailer _trailer4 = new Trailer(
            "Reinforced Wagon",
            7_000,
            4);
        
        Convoy.AddTrailers(new List<Trailer> { _trailer1, _trailer2, _trailer3 });
        #endregion
        
        #region Setup Addons

        Addon _addon1 = new Addon(
            "Heavygun Addon",
            35_000,
            1,
            new List<Keyword>() {Keyword.Heavygun, Keyword.Heavygun}
            );
        
        Addon _addon2 = new Addon(
            "Small Storageaddon",
            1_000,
            2,
            new List<Keyword>() {Keyword.Addon}
        );
        
        Addon _addon3 = new Addon(
            "Armoraddon",
            2000,
            3,
            new List<Keyword>() {Keyword.Addon}
        );
        
        Addon _addon4 = new Addon(
            "Nuclearreactor Addon",
            25_000,
            1,
            new List<Keyword>() {Keyword.Addon});

        Addon _addon5 = new Addon(
            "Storage Addon",
            30_000,
            1,
            new List<Keyword>() {Keyword.Addon});
        
        Convoy.HeadTruck.Addon = _addon1;
        Convoy.Trailers[0].Addon = _addon2;
        Convoy.Trailers[1].Addon = _addon3;
        Convoy.Trailers[2].Addon = _addon4;
        Convoy.TailTruck.Addon = _addon5;

        #endregion

        #region Slots
        
        
        DefaultSlot _slot1 = new DefaultSlot();
        DefaultSlot _slot2 = new DefaultSlot();
        PredestinedSlot<Crew> _slot3 = new PredestinedSlot<Crew>();
        Machinery _slot4 = new Machinery();
        
        Convoy.HeadTruck.AddSlot(_slot1);
        Convoy.HeadTruck.AddSlot(_slot2);
        Convoy.HeadTruck.AddSlot(_slot3);
        Convoy.HeadTruck.AddSlot(_slot4);

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
    public void ConvoyRemainingTrailersCount()
    {
        Assert.AreEqual(Convoy.remainingTrailers, 3);
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
    
    /*
    b) Legen Sie einen Konvoi mit 3 Zugmaschinen an. Beim Hinzufügen der 3ten Zugmaschinen
    muss eine Exception geworfen werden. Fügen Sie zu jeder Konvoikomponente, ein Addon hinzu.
    Probieren Sie nun zu einer der Komponenten noch ein Addon hinzuzufügen. Werfen Sie eine
    entsprechende Exception die das verhindert. Fügen Sie eine Methode hinzu die das alte Addon
    gegen ein neues austauscht.
    */
    
    [Test]
    public void ConvoyAddons() // Ermitteln Sie wieviel Anhänger noch zum Konvoi hinzugefügt werden können. 
    {
        Assert.AreEqual(Convoy.HeadTruck.Addon.Code, "Heavygun Addon");
        Assert.AreEqual(Convoy.Trailers[0].Addon.Code, "Small Storageaddon");
        Assert.AreEqual(Convoy.Trailers[1].Addon.Code, "Armoraddon");
        Assert.AreEqual(Convoy.Trailers[2].Addon.Code, "Nuclearreactor Addon");
        Assert.AreEqual(Convoy.TailTruck.Addon.Code, "Storage Addon");
    }
    
    [Test]
    public void ConvoyContainsKeyword() // Gesamtwert des Konvois berechnen
    {
        Assert.AreEqual(Convoy.ContainsKeyword(Keyword.Chain_drive), true);
        Assert.AreEqual(Convoy.ContainsKeyword(Keyword.Twinlinked), false);
    }
    
    [Test]
    public void ConvoyTotalKeywords() // Gesamtwert des Konvois berechnen
    {
        Assert.AreEqual(
            Convoy.Keywords.Order(),
            new List<Keyword>() {Keyword.Chain_drive, Keyword.Tesla_Weaponry,  Keyword.Heavygun, Keyword.Armor, Keyword.Addon }.Order()
            );
    }
    
    [Test]
    public void ConvoyAddMoreSlotsThanPermmited() // Gesamtwert des Konvois berechnen
    {
        try
        {
            Convoy.HeadTruck.AddSlot(new DefaultSlot());
            Assert.Fail();
        }
        catch (Exception e)
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public void ConvoyAddAmmunitionSlotToCrewSlot() // Gesamtwert des Konvois berechnen
    {
        try
        {
            Convoy.HeadTruck.Slots[2] = new PredestinedSlot<Ammunition>();
            Assert.Fail();
        }
        catch (Exception e)
        {
            Assert.Pass();
        }
        
    }
    
    
}
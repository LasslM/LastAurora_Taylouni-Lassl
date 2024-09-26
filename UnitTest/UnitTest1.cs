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
            new List<KeywordTruck>() { KeywordTruck.Chain_drive , KeywordTruck.Tesla_Weaponry});
        
        Convoy = new Convoy(_headTruck);
        
        Truck _tailTruck = new Truck(
            "Railgun Tank",
            4,
            140_000,
            3, 
            new List<KeywordTruck>() { KeywordTruck.Armor });
        
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
            new List<KeywordAddon>() {KeywordAddon.Heavygun, KeywordAddon.Heavygun}
            );
        
        Addon _addon2 = new Addon(
            "Small Storageaddon",
            1_000,
            2,
            new List<KeywordAddon>() {KeywordAddon.Addon}
        );
        
        Addon _addon3 = new Addon(
            "Armoraddon",
            2000,
            3,
            new List<KeywordAddon>() {KeywordAddon.Addon}
        );
        
        Addon _addon4 = new Addon(
            "Nuclearreactor Addon",
            25_000,
            1);

        #endregion
    }
    
    /*
    a) Anlegen eines Konvois mit 2 Zugmaschinen und 2 Anhängern. Prüfen Sie welche der Zugmaschinen
    die Fordere und welche die Hintere ist. Fragen Sie die Geschwindigkeit des Konvois ab.
    Fragen Sie die Zugkraft des Konvois ab. Ermitteln Sie wieviel Anhänger noch zum Konvoi hinzugefügt
    werden können. Wieviel Anhänger hat der Konvoi. Überlegen Sie sich eine sinnvolle Fassade für
    den Konvoi.
    */
    
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
    
    /*
    b) Legen Sie einen Konvoi mit 3 Zugmaschinen an. Beim Hinzufügen der 3ten Zugmaschinen
    muss eine Exception geworfen werden. Fügen Sie zu jeder Konvoikomponente, ein Addon hinzu.
    Probieren Sie nun zu einer der Komponenten noch ein Addon hinzuzufügen. Werfen Sie eine
    entsprechende Exception die das verhindert. Fügen Sie eine Methode hinzu die das alte Addon
    gegen ein neues austauscht.
    */
    
    
}
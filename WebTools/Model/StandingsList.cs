/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class StandingsList
{
    private DriverStanding[] driverStandingField;


    private ConstructorStanding[] constructorStandingField;

    private ushort seasonField;

    private byte roundField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConstructorStanding")]
    public ConstructorStanding[] ConstructorStanding
    {
        get
        {
            return this.constructorStandingField;
        }
        set
        {
            this.constructorStandingField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("DriverStanding")]
    public DriverStanding[] DriverStanding
    {
        get
        {
            return this.driverStandingField;
        }
        set
        {
            this.driverStandingField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort season
    {
        get
        {
            return this.seasonField;
        }
        set
        {
            this.seasonField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte round
    {
        get
        {
            return this.roundField;
        }
        set
        {
            this.roundField = value;
        }
    }
}
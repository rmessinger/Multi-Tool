/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class RaceTable
{
    private Race raceField;

    private ushort seasonField;

    private byte roundField;

    /// <remarks/>
    public Race Race
    {
        get
        {
            return this.raceField;
        }
        set
        {
            this.raceField = value;
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
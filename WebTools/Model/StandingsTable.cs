/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class StandingsTable
{

    private StandingsList standingsListField;

    private ushort seasonField;

    private byte roundField;

    /// <remarks/>
    public StandingsList StandingsList
    {
        get
        {
            return this.standingsListField;
        }
        set
        {
            this.standingsListField = value;
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
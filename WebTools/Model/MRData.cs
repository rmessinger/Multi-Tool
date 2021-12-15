// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
public partial class MRData
{

    private Driver[] driverTableField;

    private RaceTable[] raceTableField;

    private StandingsTable[] standingsTableField;

    private StatusTable[] statusTableField;

    private string seriesField;

    private string urlField;

    private byte limitField;

    private byte offsetField;

    private ushort totalField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Driver", IsNullable = true)]
    public Driver[] DriverTable
    {
        get
        {
            return this.driverTableField;
        }
        set
        {
            this.driverTableField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("RaceTable", IsNullable = true)]
    public RaceTable[] RaceTable
    {
        get
        {
            return this.raceTableField;
        }
        set
        {
            this.raceTableField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("RaceTable", IsNullable = true)]
    public StandingsTable[] StandingsTable
    {
        get
        {
            return this.standingsTableField;
        }
        set
        {
            this.standingsTableField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string series
    {
        get
        {
            return this.seriesField;
        }
        set
        {
            this.seriesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string url
    {
        get
        {
            return this.urlField;
        }
        set
        {
            this.urlField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte limit
    {
        get
        {
            return this.limitField;
        }
        set
        {
            this.limitField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte offset
    {
        get
        {
            return this.offsetField;
        }
        set
        {
            this.offsetField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort total
    {
        get
        {
            return this.totalField;
        }
        set
        {
            this.totalField = value;
        }
    }
}
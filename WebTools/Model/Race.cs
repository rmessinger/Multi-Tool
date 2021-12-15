
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class Race
{
    private string raceNameField;

    private Circuit circuitField;

    private System.DateTime dateField;

    private System.DateTime timeField;

    private RaceResult[] resultsListField;

    private ushort seasonField;

    private byte roundField;

    private string urlField;

    /// <remarks/>
    public string RaceName
    {
        get
        {
            return this.raceNameField;
        }
        set
        {
            this.raceNameField = value;
        }
    }

    /// <remarks/>
    public Circuit Circuit
    {
        get
        {
            return this.circuitField;
        }
        set
        {
            this.circuitField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime Date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
    public System.DateTime Time
    {
        get
        {
            return this.timeField;
        }
        set
        {
            this.timeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Result", IsNullable = false)]
    public RaceResult[] ResultsList
    {
        get
        {
            return this.resultsListField;
        }
        set
        {
            this.resultsListField = value;
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
}

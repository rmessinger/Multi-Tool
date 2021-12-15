/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class FastestLap
{

    private string timeField;

    private FastestLapAverageSpeed averageSpeedField;

    private byte rankField;

    private byte lapField;

    /// <remarks/>
    public string Time
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
    public FastestLapAverageSpeed AverageSpeed
    {
        get
        {
            return this.averageSpeedField;
        }
        set
        {
            this.averageSpeedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte rank
    {
        get
        {
            return this.rankField;
        }
        set
        {
            this.rankField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte lap
    {
        get
        {
            return this.lapField;
        }
        set
        {
            this.lapField = value;
        }
    }
}
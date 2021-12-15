
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class PitStop
{
    private string driverIdField;

    private byte stopField;

    private byte lapField;

    private System.DateTime timeField;

    private decimal durationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string driverId
    {
        get
        {
            return this.driverIdField;
        }
        set
        {
            this.driverIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte stop
    {
        get
        {
            return this.stopField;
        }
        set
        {
            this.stopField = value;
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "time")]
    public System.DateTime time
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal duration
    {
        get
        {
            return this.durationField;
        }
        set
        {
            this.durationField = value;
        }
    }
}
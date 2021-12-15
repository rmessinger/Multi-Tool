
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class LapTiming
{
    private string driverIdField;

    private byte lapField;

    private byte positionField;

    private string timeField;

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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte position
    {
        get
        {
            return this.positionField;
        }
        set
        {
            this.positionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string time
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
}

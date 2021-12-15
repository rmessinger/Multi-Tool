/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class Circuit
{

    private string circuitNameField;

    private CircuitLocation locationField;

    private string circuitIdField;

    private string urlField;

    /// <remarks/>
    public string CircuitName
    {
        get
        {
            return this.circuitNameField;
        }
        set
        {
            this.circuitNameField = value;
        }
    }

    /// <remarks/>
    public CircuitLocation Location
    {
        get
        {
            return this.locationField;
        }
        set
        {
            this.locationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string circuitId
    {
        get
        {
            return this.circuitIdField;
        }
        set
        {
            this.circuitIdField = value;
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
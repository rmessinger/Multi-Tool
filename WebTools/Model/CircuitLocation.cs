/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class CircuitLocation
{

    private string localityField;

    private string countryField;

    private decimal latField;

    private decimal longField;

    /// <remarks/>
    public string Locality
    {
        get
        {
            return this.localityField;
        }
        set
        {
            this.localityField = value;
        }
    }

    /// <remarks/>
    public string Country
    {
        get
        {
            return this.countryField;
        }
        set
        {
            this.countryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal lat
    {
        get
        {
            return this.latField;
        }
        set
        {
            this.latField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal @long
    {
        get
        {
            return this.longField;
        }
        set
        {
            this.longField = value;
        }
    }
}

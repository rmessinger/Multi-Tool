/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class QualifyingResult
{

    private Driver driverField;

    private Constructor constructorField;

    private string q1Field;

    private byte numberField;

    private byte positionField;

    /// <remarks/>
    public Driver Driver
    {
        get
        {
            return this.driverField;
        }
        set
        {
            this.driverField = value;
        }
    }

    /// <remarks/>
    public Constructor Constructor
    {
        get
        {
            return this.constructorField;
        }
        set
        {
            this.constructorField = value;
        }
    }

    /// <remarks/>
    public string Q1
    {
        get
        {
            return this.q1Field;
        }
        set
        {
            this.q1Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte number
    {
        get
        {
            return this.numberField;
        }
        set
        {
            this.numberField = value;
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
}
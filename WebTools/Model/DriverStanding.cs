
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class DriverStanding
{
    private Driver driverField;

    private Constructor constructorField;

    private byte positionField;

    private byte positionTextField;

    private byte pointsField;

    private byte winsField;

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
    public byte positionText
    {
        get
        {
            return this.positionTextField;
        }
        set
        {
            this.positionTextField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte points
    {
        get
        {
            return this.pointsField;
        }
        set
        {
            this.pointsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte wins
    {
        get
        {
            return this.winsField;
        }
        set
        {
            this.winsField = value;
        }
    }
}
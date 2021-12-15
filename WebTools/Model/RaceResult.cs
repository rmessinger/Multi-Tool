
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class RaceResult
{

    private Driver driverField;

    private Constructor constructorField;

    private byte gridField;

    private byte lapsField;

    private Status statusField;

    private Time timeField;

    private FastestLap fastestLapField;

    private byte numberField;

    private byte positionField;

    private string positionTextField;

    private byte pointsField;

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
    public byte Grid
    {
        get
        {
            return this.gridField;
        }
        set
        {
            this.gridField = value;
        }
    }

    /// <remarks/>
    public byte Laps
    {
        get
        {
            return this.lapsField;
        }
        set
        {
            this.lapsField = value;
        }
    }

    /// <remarks/>
    public Status Status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    /// <remarks/>
    public Time Time
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
    public FastestLap FastestLap
    {
        get
        {
            return this.fastestLapField;
        }
        set
        {
            this.fastestLapField = value;
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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string positionText
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
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class Lap
{

    private LapTiming[] timingField;

    private byte numberField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Timing")]
    public LapTiming[] Timing
    {
        get
        {
            return this.timingField;
        }
        set
        {
            this.timingField = value;
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
}
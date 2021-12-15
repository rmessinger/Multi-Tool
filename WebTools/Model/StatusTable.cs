/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class StatusTable
{

    private Status[] statusField;

    private ushort seasonField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Status")]
    public Status[] Status
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
}

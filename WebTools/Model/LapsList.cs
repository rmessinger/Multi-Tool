/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class LapsList
{

    private Lap lapField;

    /// <remarks/>
    public Lap Lap
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
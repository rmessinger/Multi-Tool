/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
public partial class Driver
{
    private byte permanentNumberField;

    private bool permanentNumberFieldSpecified;

    private string givenNameField;

    private string familyNameField;

    private System.DateTime dateOfBirthField;

    private string nationalityField;

    private string driverIdField;

    private string urlField;

    private string codeField;

    /// <remarks/>
    public byte PermanentNumber
    {
        get
        {
            return this.permanentNumberField;
        }
        set
        {
            this.permanentNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PermanentNumberSpecified
    {
        get
        {
            return this.permanentNumberFieldSpecified;
        }
        set
        {
            this.permanentNumberFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string GivenName
    {
        get
        {
            return this.givenNameField;
        }
        set
        {
            this.givenNameField = value;
        }
    }

    /// <remarks/>
    public string FamilyName
    {
        get
        {
            return this.familyNameField;
        }
        set
        {
            this.familyNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime DateOfBirth
    {
        get
        {
            return this.dateOfBirthField;
        }
        set
        {
            this.dateOfBirthField = value;
        }
    }

    /// <remarks/>
    public string Nationality
    {
        get
        {
            return this.nationalityField;
        }
        set
        {
            this.nationalityField = value;
        }
    }

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

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}
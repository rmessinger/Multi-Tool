using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTools.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
    [System.Xml.Serialization.XmlRootAttribute("MRData", Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
    public partial class ConstructorResponse : Response
    {
        Constructor[] constructorTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Constructor", IsNullable = false)]
        public Constructor[] ConstructorTable
        {
            get
            {
                return this.constructorTableField;
            }
            set
            {
                this.constructorTableField = value;
            }
        }
    }
}

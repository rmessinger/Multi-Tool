using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebTools.Interfaces;

namespace WebTools.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
    [System.Xml.Serialization.XmlRootAttribute("MRData", Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
    public class SeasonsResponse : Response
    {
        private Season[] seasonTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Season", IsNullable = true)]
        public Season[] SeasonTable
        {
            get
            {
                return this.seasonTableField;
            }
            set
            {
                this.seasonTableField = value;
            }
        }
    }
}

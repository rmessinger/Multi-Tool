using System;
using System.Collections.Generic;
using System.Text;

namespace WebTools.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
    [System.Xml.Serialization.XmlRootAttribute("MRData", Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
    public partial class RaceResponse : Response
    {
        private RaceTable[] raceTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RaceTable", IsNullable = true)]
        public RaceTable[] RaceTable
        {
            get
            {
                return this.RaceTable;
            }
            set
            {
                this.raceTableField = value;
            }
        }
    }
}

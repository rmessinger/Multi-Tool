using System;
using System.Collections.Generic;
using System.Text;

namespace WebTools.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
    [System.Xml.Serialization.XmlRootAttribute("MRData", Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
    public partial class StandingsResponse : Response
    {
        private StandingsTable[] standingsTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("StandingsTable", IsNullable = true)]
        public StandingsTable[] StandingsTable
        {
            get
            {
                return this.standingsTableField;
            }
            set
            {
                this.standingsTableField = value;
            }
        }
    }
}

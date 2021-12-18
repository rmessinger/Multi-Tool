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
    public partial class StandingsResponse : Response
    {
        private StandingsList[] standingsTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("StandingsTable", IsNullable = true)]
        public StandingsList[] StandingsTable
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

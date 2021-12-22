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
    public partial class RaceResponse : Response
    {
        private Race[] raceTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Race", IsNullable = true)]
        public Race[] RaceTable
        {
            get
            {
                return this.raceTableField;
            }
            set
            {
                this.raceTableField = value;
            }
        }

        public override object[] GetTable()
        {
            return this.RaceTable;
        }

        public override void AppendToTable(object[] newItems)
        {
            this.raceTableField = this.raceTableField.Concat((Race[])newItems).ToArray();
        }
    }
}

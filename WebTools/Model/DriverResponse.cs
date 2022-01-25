using System.Linq;
using WebTools.Interfaces;
using WebTools.Model;

namespace WebTools.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
    [System.Xml.Serialization.XmlRootAttribute("MRData", Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
    public partial class DriverResponse : Response
    {
        private Driver[] driverTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Driver", IsNullable = true)]
        public Driver[] DriverTable
        {
            get
            {
                return this.driverTableField;
            }
            set
            {
                this.driverTableField = value;
            }
        }

        public override object[] GetTable(ResponseType subResponse)
        {
            return this.DriverTable;
        }

        public override void AppendToTable(object[] newItems)
        {
            this.driverTableField = this.driverTableField.Concat((Driver[])newItems).ToArray();
        }
    }
}
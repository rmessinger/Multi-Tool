﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebTools.Model
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://ergast.com/mrd/1.4")]
    [System.Xml.Serialization.XmlRootAttribute("MRData", Namespace = "http://ergast.com/mrd/1.4", IsNullable = false)]
    public partial class StatusResponse : Response
    {
        private StatusTable[] statusTableField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("StatusTable", IsNullable = true)]
        public StatusTable[] StatusTable
        {
            get
            {
                return this.statusTableField;
            }
            set
            {
                this.statusTableField = value;
            }
        }
    }
}
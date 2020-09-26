using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FE.Model.Local
{
    public class HosOrderItem : ToXElement
    {
        /// <remarks/>
        public decimal ORDER_NO
        {
            get;
            set;
        }
        /// <remarks/>
        public decimal ORDER_SUB_NO
        {
            get;
            set;
        }
        /// <remarks/>
        public int REPEAT_INDICATOR
        {
            get;
            set;
        }
        /// <remarks/>
        public string ORDER_CLASS
        {
            get;
            set;
        }
        /// <remarks/>
        public string ORDER_TEXT
        {
            get;
            set;
        }
        /// <remarks/>
        public string DOSAGE
        {
            get;
            set;
        }
        /// <remarks/>
        public string ADMINISTRATION
        {
            get;
            set;
        }
        /// <remarks/>
        public DateTime START_DATE_TIME
        {
            get;
            set;
        }
        /// <remarks/>
        public DateTime? STOP_DATE_TIME
        {
            get;
            set;
        }
        /// <remarks/>
        public string DURATION
        {
            get;
            set;
        }
        /// <remarks/>
        public string FREQUENCY
        {
            get;
            set;
        }
        /// <remarks/>
        public string FREQ_DETAIL
        {
            get;
            set;
        }
        /// <remarks/>
        public DateTime? PERFORM_SCHEDULE
        {
            get;
            set;
        }
        /// <remarks/>
        public string PERFORM_RESULT
        {
            get;
            set;
        }
        /// <remarks/>
        public string ORDERING_DEPT
        {
            get;
            set;
        }
        /// <remarks/>
        public string DOCTOR
        {
            get;
            set;
        }
        /// <remarks/>
        public string STOP_DOCTOR
        {
            get;
            set;
        }
        /// <remarks/>
        public string NURSE
        {
            get;
            set;
        }
        /// <remarks/>
        public string STOP_NURSE
        {
            get;
            set;
        }
        /// <remarks/>
        public int ORDER_STATUS
        {
            get;
            set;
        }
        /// <remarks/>
        public int DRUG_BILLING_ATTR
        {
            get;
            set;
        }
        /// <remarks/>
        public int BILLING_ATTR
        {
            get;
            set;
        }
        /// <remarks/>
        public DateTime? LAST_PERFORM_DATE_TIME
        {
            get;
            set;
        }
    }


    public class HosOrderHead : ToXElement
    {
        /// <remarks/>
        public int jzlsh
        {
            get;

            set;
        }

        /// <remarks/>
        public string mzzyhm
        {
            get;
            set;
        }

        /// <remarks/>
        public string brxm
        {
            get;
            set;
        }

        /// <remarks/>
        public int brxb
        {
            get;
            set;
        }

        /// <remarks/>
        public int brnl
        {
            get;
            set;
        }

        /// <remarks/>
        public string nldw
        {
            get;
            set;
        } = "岁";

        /// <remarks/>
        public string lxdh
        {
            get;
            set;
        }

        /// <remarks/>
        public string jtdz
        {
            get;
            set;
        }
    }


}

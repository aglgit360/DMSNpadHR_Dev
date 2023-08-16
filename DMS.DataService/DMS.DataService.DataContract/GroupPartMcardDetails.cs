using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DMS.DataService.DataContract
{
    [DataContract]
    public class GroupPartMcardDetails
    {
        [DataMember]
        public List<po_part_refcur> PartDetails { get; set; }
    }
    [DataContract]
    public class po_part_refcur
    {
        [DataMember]
        public string PART_NUM { get; set; }
        [DataMember]
        public string PART_DESC { get; set; }
        [DataMember]
        public string MRP_1 { get; set; }
        [DataMember]
        public string stock { get; set; }
    }

    [DataContract]
    public class LabourRateDetails
    {
        [DataMember]
        public List<po_labor_refcur> LaborDetails { get; set; }
    }

    [DataContract]
    public class CheckCNGVehicle //Added on 19 Dec 2022
    {
        [DataMember]
        public string PO_CNG_MSG { get; set; }
    }

    [DataContract]
    public class CNGTestingdueDate  //Added on 19 Dec 2022
    {
        [DataMember]
        public string PO_TESTING_DUE { get; set; }

        [DataMember]
        public string PO_MSG { get; set; } //Added on 22 Dec 2022
    }

    [DataContract]
    public class po_labor_refcur
    {
        [DataMember]
        public string opr_cd { get; set; }
        [DataMember]
        public string frm_hrs { get; set; }
        [DataMember]
        public string fixed_amt { get; set; }
    }
}

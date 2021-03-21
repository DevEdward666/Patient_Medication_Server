using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static WEB_API.Interface.ITableFilter;

namespace WEB_API.Models.RadStudyTable
{
    public class RadStudyTableFilter
    {

        public int page { get; set; }
        public int limit { get; set; }
        public mdlSort sort { get; set; }
        public searchModel search { get; set; }
        public class searchModel
        {
            [Required]
            public DateTime studyfrom { get; set; }
            [Required]
            public DateTime studyto { get; set; }
            [Required]
            public string hospitalno { get; set; }
            [Required]
            public string patrefno { get; set; }
            [Required]
            public string patientname { get; set; }
            [Required]
            public string accessionno { get; set; }
            [Required]
            public string urgency { get; set; }
            [Required]
            public string modality { get; set; }
            [Required]
            public string doctor { get; set; }
            [Required]
            public string resulttag { get; set; }
            [Required]
            public string procdesc { get; set; }
        }
    }


}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_API.Interface
{
    public static class ITableFilter
    {
        public class mdlFilter
        {
            public List<mdlColumn> search { get; set; }
            public mdlSort sort { get; set; }
            public string begin { get; set; }
            public int limit { get; set; }
            public int page { get; set; }
        }

        public class mdlColumn
        {
            public string key { get; set; }
            public string title { get; set; }
            public string value { get; set; }
            public string field { get; set; }
        }

        public class mdlSort
        {
            [Required]
            public string key { get; set; }

            [Required]
            public string direction { get; set; }
        }

        public class mdlTableData
        {
            public object data { get; set; }
            public int totalFiltered { get; set; }
            public int currentPage { get; set; }
            public int pageCount { get; set; }
        }
    }
}
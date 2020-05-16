using DataLayer.Entities.Common;
using DataLayer.SSOT;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Keywords:BaseEntity<int>
    {
        public string Keyword { get; set; }

        public KeywordTypeSSOT Type { get; set; }

        public bool IsActive { get; set; }

    }
}

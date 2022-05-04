namespace NKSLK.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_ROLE
    {
        public int ID { get; set; }

        public int? ID_ACCOUNT { get; set; }

        public int? ID_ROLE { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual ROLE ROLE { get; set; }
    }
}

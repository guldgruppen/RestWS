namespace WCFServiceWebRole1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Temperatur")]
    public partial class Temperatur
    {
        public int Id { get; set; }

        [Required]
        public string Data { get; set; }

        public DateTime Timestamp { get; set; }

        public int Location { get; set; }

        public int Status { get; set; }

        public virtual Location Location1 { get; set; }

        public virtual Status Status1 { get; set; }
    }
}

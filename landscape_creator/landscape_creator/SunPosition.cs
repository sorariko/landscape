namespace landscape_creator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SunPosition")]
    public partial class SunPosition
    {
        [Key]
        public int IDPosition { get; set; }

        public int Azimuth { get; set; }

        public int HeightAboveHorizon { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

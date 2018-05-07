namespace landscape_creator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlantVariety")]
    public partial class PlantVariety
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlantVariety()
        {
            LandingRadius = new HashSet<LandingRadius>();
        }

        public int ID { get; set; }

        [Required]
        public string FullName { get; set; }

        public int AverageHeight { get; set; }

        public int? LifeTime { get; set; }

        public int Sunlight { get; set; }

        public int GenusID { get; set; }

        public int LifeFormID { get; set; }

        public int AverageWidth { get; set; }

        public int TimeToAdult { get; set; }

        public virtual Genus Genus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LandingRadius> LandingRadius { get; set; }

        public virtual LifeForm LifeForm { get; set; }
    }
}

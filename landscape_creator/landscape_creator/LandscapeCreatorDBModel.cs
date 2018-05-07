namespace landscape_creator
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class LandscapeCreatorDBModel : DbContext
	{
		public LandscapeCreatorDBModel()
			: base("name=LandscapeCreatorDBConfig")
		{
		}

		public virtual DbSet<Genus> Genus { get; set; }
		public virtual DbSet<LandingRadius> LandingRadius { get; set; }
		public virtual DbSet<LifeForm> LifeForm { get; set; }
		public virtual DbSet<PlantVariety> PlantVariety { get; set; }
		public virtual DbSet<SunPosition> SunPosition { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Genus>()
				.HasMany(e => e.PlantVariety)
				.WithRequired(e => e.Genus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<LifeForm>()
				.HasMany(e => e.LandingRadius)
				.WithRequired(e => e.LifeForm)
				.HasForeignKey(e => e.IDForm)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<LifeForm>()
				.HasMany(e => e.PlantVariety)
				.WithRequired(e => e.LifeForm)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PlantVariety>()
				.HasMany(e => e.LandingRadius)
				.WithRequired(e => e.PlantVariety)
				.HasForeignKey(e => e.IDPlant)
				.WillCascadeOnDelete(false);
		}
	}
}

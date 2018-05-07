namespace landscape_creator
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class PlantsDBModel : DbContext
	{
		public PlantsDBModel()
			: base("name=PlantsDBConfig")
		{
		}

		public virtual DbSet<Genus> Genus { get; set; }
		public virtual DbSet<LandingRadius> LandingRadius { get; set; }
		public virtual DbSet<LifeForm> LifeForm { get; set; }
		public virtual DbSet<Plant> Plant { get; set; }
		public virtual DbSet<SunPosition> SunPosition { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Genus>()
				.HasMany(e => e.Plant)
				.WithRequired(e => e.Genus)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<LifeForm>()
				.HasMany(e => e.LandingRadius)
				.WithRequired(e => e.LifeForm)
				.HasForeignKey(e => e.IDForm)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<LifeForm>()
				.HasMany(e => e.Plant)
				.WithRequired(e => e.LifeForm)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Plant>()
				.HasMany(e => e.LandingRadius)
				.WithRequired(e => e.Plant)
				.HasForeignKey(e => e.IDPlant)
				.WillCascadeOnDelete(false);
		}
	}
}

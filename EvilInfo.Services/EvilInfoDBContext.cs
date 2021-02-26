using EvilInfo.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace EvilInfo.Services
{
	public partial class EvilInfoDBContext : DbContext
	{
		public EvilInfoDBContext()
		{
		}

		public EvilInfoDBContext(DbContextOptions<EvilInfoDBContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Countries> Countries { get; set; }
		public virtual DbSet<EvilnessFactors> EvilnessFactors { get; set; }
		public virtual DbSet<Jobapplications> Jobapplications { get; set; }
		public virtual DbSet<Joboffers> Joboffers { get; set; }
		public virtual DbSet<Logins> Logins { get; set; }
		public virtual DbSet<Roles> Roles { get; set; }
		public virtual DbSet<Towns> Towns { get; set; }
		public virtual DbSet<Users> Users { get; set; }
		public virtual DbSet<VillainUsers> VillainUsers { get; set; }
		public virtual DbSet<VillainuserUsers> VillainuserUsers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseMySQL("Server=127.0.0.1;Database=evilinfo; uID=test; pwd=123456; persistsecurityinfo=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Countries>(entity =>
			{
				entity.ToTable("countries");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<EvilnessFactors>(entity =>
			{
				entity.ToTable("evilness_factors");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(20);
			});

			modelBuilder.Entity<Jobapplications>(entity =>
			{
				entity.HasKey(e => new { e.UserId, e.JobOfferId })
					.HasName("PRIMARY");

				entity.ToTable("jobapplications");

				entity.HasIndex(e => e.JobOfferId)
					.HasName("FK_JobOffersJobApplications");

				entity.HasOne(d => d.JobOffer)
					.WithMany(p => p.Jobapplications)
					.HasForeignKey(d => d.JobOfferId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_JobOffersJobApplications");

				entity.HasOne(d => d.User)
					.WithMany(p => p.Jobapplications)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsersJobApplications");
			});

			modelBuilder.Entity<Joboffers>(entity =>
			{
				entity.ToTable("joboffers");

				entity.HasIndex(e => e.UserId)
					.HasName("FK_UsersJobOffers");

				entity.Property(e => e.JobOfferStatus).HasColumnType("bit(1)");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(d => d.User)
					.WithMany(p => p.Joboffers)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsersJobOffers");
			});

			modelBuilder.Entity<Logins>(entity =>
			{
				entity.ToTable("logins");

				entity.Property(e => e.Password)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Username)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Roles>(entity =>
			{
				entity.ToTable("roles");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<Towns>(entity =>
			{
				entity.ToTable("towns");

				entity.HasIndex(e => e.CountryId)
					.HasName("FK_CountriesTowns");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(d => d.Country)
					.WithMany(p => p.Towns)
					.HasForeignKey(d => d.CountryId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_CountriesTowns");
			});

			modelBuilder.Entity<Users>(entity =>
			{
				entity.ToTable("users");

				entity.HasIndex(e => e.CountryId)
					.HasName("FK_CountriesUsers");

				entity.HasIndex(e => e.RoleId)
					.HasName("FK_RolesUsers");

				entity.HasIndex(e => e.TownId)
					.HasName("FK_TownsUsers");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(d => d.Country)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.CountryId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_CountriesUsers");

				entity.HasOne(d => d.IdNavigation)
					.WithOne(p => p.Users)
					.HasForeignKey<Users>(d => d.Id)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_LoginsUsers");

				entity.HasOne(d => d.Role)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.RoleId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_RolesUsers");

				entity.HasOne(d => d.Town)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.TownId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_TownsUsers");
			});

			modelBuilder.Entity<VillainUsers>(entity =>
			{
				entity.HasKey(e => e.UserId)
					.HasName("PRIMARY");

				entity.ToTable("villain_users");

				entity.HasIndex(e => e.EvilnessFactorId)
					.HasName("FK_EvilnessFactorsVillainUsers");

				entity.HasOne(d => d.EvilnessFactor)
					.WithMany(p => p.VillainUsers)
					.HasForeignKey(d => d.EvilnessFactorId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_EvilnessFactorsVillainUsers");

				entity.HasOne(d => d.User)
					.WithOne(p => p.VillainUsers)
					.HasForeignKey<VillainUsers>(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsersVillainUsers");
			});

			modelBuilder.Entity<VillainuserUsers>(entity =>
			{
				entity.HasKey(e => new { e.MinionId, e.VillainId })
					.HasName("PRIMARY");

				entity.ToTable("villainuser_users");

				entity.HasIndex(e => e.VillainId)
					.HasName("FK_VillainUsersVillainUserUsers");

				entity.HasOne(d => d.Minion)
					.WithMany(p => p.VillainuserUsers)
					.HasForeignKey(d => d.MinionId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_UsersVillainUserUsers");

				entity.HasOne(d => d.Villain)
					.WithMany(p => p.VillainuserUsers)
					.HasForeignKey(d => d.VillainId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_VillainUsersVillainUserUsers");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}

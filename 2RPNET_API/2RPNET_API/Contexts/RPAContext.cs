using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _2RPNET_API.Domains;

#nullable disable

namespace _2RPNET_API.Contexts
{
    public partial class RPAContext : DbContext
    {
        public RPAContext()
        {
        }

        public RPAContext(DbContextOptions<RPAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assistant> Assistants { get; set; }
        public virtual DbSet<AssistantProcedure> AssistantProcedures { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<EmailVerification> EmailVerifications { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LibrarySkin> LibrarySkins { get; set; }
        public virtual DbSet<LibraryTrophy> LibraryTrophies { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Run> Runs { get; set; }
        public virtual DbSet<Skin> Skins { get; set; }
        public virtual DbSet<StatusQuest> StatusQuests { get; set; }
        public virtual DbSet<Trophy> Trophies { get; set; }
        public virtual DbSet<UserName> UserNames { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NOTE0113I2\\SQLEXPRESS; Initial Catalog=DOISRP; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Assistant>(entity =>
            {
                entity.HasKey(e => e.IdAssistant)
                    .HasName("PK__Assistan__72DCFF80238CEF87");

                entity.ToTable("Assistant");

                entity.Property(e => e.AlterationDate).HasColumnType("datetime");

                entity.Property(e => e.AssistantDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AssistantName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Assistants)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Assistant__IdEmp__571DF1D5");
            });

            modelBuilder.Entity<AssistantProcedure>(entity =>
            {
                entity.HasKey(e => e.IdAssistantProcedure)
                    .HasName("PK__Assistan__11A21508183FC8A3");

                entity.ToTable("AssistantProcedure");

                entity.Property(e => e.ProcedureDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedureName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAssistantNavigation)
                    .WithMany(p => p.AssistantProcedures)
                    .HasForeignKey(d => d.IdAssistant)
                    .HasConstraintName("FK__Assistant__IdAss__59FA5E80");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("PK__Comment__57C9AD58F3836DE0");

                entity.ToTable("Comment");

                entity.Property(e => e.CommentDescription).IsUnicode(false);

                entity.Property(e => e.DataComment).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdPlayer)
                    .HasConstraintName("FK__Comment__IdPlaye__4E88ABD4");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdPost)
                    .HasConstraintName("FK__Comment__IdPost__4D94879B");
            });

            modelBuilder.Entity<Corporation>(entity =>
            {
                entity.HasKey(e => e.IdCorporation)
                    .HasName("PK__Corporat__2BAEF03D8B38C4BC");

                entity.ToTable("Corporation");

                entity.HasIndex(e => e.Phone, "UQ__Corporat__5C7E359E3C440FF5")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Corporat__A9D1053413A7FA35")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Corporat__AA57D6B43BEE74BE")
                    .IsUnique();

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.CorporateName).IsUnicode(false);

                entity.Property(e => e.CorporatePhoto).HasColumnType("text");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NameFantasy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EmailVerification>(entity =>
            {
                entity.HasKey(e => e.IdEmailVerification)
                    .HasName("PK__EmailVer__E64B141629CF872F");

                entity.ToTable("EmailVerification");

                entity.HasIndex(e => e.Username, "UQ__EmailVer__536C85E4168A81DB")
                    .IsUnique();

                entity.Property(e => e.Cryptography)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gateway)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAssistantNavigation)
                    .WithMany(p => p.EmailVerifications)
                    .HasForeignKey(d => d.IdAssistant)
                    .HasConstraintName("FK__EmailVeri__IdAss__60A75C0F");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__Employee__51C8DD7AC9D26BA4");

                entity.ToTable("Employee");

                entity.HasOne(d => d.IdCorporationNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdCorporation)
                    .HasConstraintName("FK__Employee__IdCorp__33D4B598");

                entity.HasOne(d => d.IdRolesNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdRoles)
                    .HasConstraintName("FK__Employee__IdRole__34C8D9D1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Employee__IdUser__32E0915F");
            });

            modelBuilder.Entity<LibrarySkin>(entity =>
            {
                entity.HasKey(e => e.IdLibrarySkins)
                    .HasName("PK__LibraryS__AEA1FBE6C168F00C");

                entity.Property(e => e.UnlockData).HasColumnType("datetime");

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.LibrarySkins)
                    .HasForeignKey(d => d.IdPlayer)
                    .HasConstraintName("FK__LibrarySk__IdPla__4316F928");

                entity.HasOne(d => d.IdSkinNavigation)
                    .WithMany(p => p.LibrarySkins)
                    .HasForeignKey(d => d.IdSkin)
                    .HasConstraintName("FK__LibrarySk__IdSki__440B1D61");
            });

            modelBuilder.Entity<LibraryTrophy>(entity =>
            {
                entity.HasKey(e => e.IdLibraryTrophy)
                    .HasName("PK__LibraryT__06B3A1345AB53C48");

                entity.ToTable("LibraryTrophy");

                entity.Property(e => e.UnlockData).HasColumnType("datetime");

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.LibraryTrophies)
                    .HasForeignKey(d => d.IdPlayer)
                    .HasConstraintName("FK__LibraryTr__IdPla__534D60F1");

                entity.HasOne(d => d.IdTrophyNavigation)
                    .WithMany(p => p.LibraryTrophies)
                    .HasForeignKey(d => d.IdTrophy)
                    .HasConstraintName("FK__LibraryTr__IdTro__5441852A");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => e.IdLikes)
                    .HasName("PK__Likes__3FDC4886C3CA226B");

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdPlayer)
                    .HasConstraintName("FK__Likes__IdPlayer__4AB81AF0");

                entity.HasOne(d => d.IdPostNavigation)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.IdPost)
                    .HasConstraintName("FK__Likes__IdPost__49C3F6B7");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer)
                    .HasName("PK__Player__0A2C3D9232321B13");

                entity.ToTable("Player");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Player__IdEmploy__37A5467C");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__Post__F8DCBD4D93D1189D");

                entity.ToTable("Post");

                entity.Property(e => e.DataPost).HasColumnType("datetime");

                entity.Property(e => e.PostDescription).IsUnicode(false);

                entity.Property(e => e.PostImage)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdPlayer)
                    .HasConstraintName("FK__Post__IdPlayer__46E78A0C");
            });

            modelBuilder.Entity<Quest>(entity =>
            {
                entity.HasKey(e => e.IdQuest)
                    .HasName("PK__Quest__CDB9F57BD1029E6E");

                entity.ToTable("Quest");

                entity.Property(e => e.DateHour).HasColumnType("datetime");

                entity.Property(e => e.DescriptionQuest)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK__Quest__IdEmploye__3C69FB99");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Quests)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__Quest__IdStatus__3D5E1FD2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRoles)
                    .HasName("PK__Roles__DC54C77C5FE1EB03");

                entity.Property(e => e.TitleRoles)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Run>(entity =>
            {
                entity.HasKey(e => e.IdRun)
                    .HasName("PK__Run__2A49CE1F894BCE0E");

                entity.ToTable("Run");

                entity.Property(e => e.RunDate).HasColumnType("datetime");

                entity.Property(e => e.RunDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAssistantNavigation)
                    .WithMany(p => p.Runs)
                    .HasForeignKey(d => d.IdAssistant)
                    .HasConstraintName("FK__Run__IdAssistant__5CD6CB2B");
            });

            modelBuilder.Entity<Skin>(entity =>
            {
                entity.HasKey(e => e.IdSkin)
                    .HasName("PK__Skin__A6FFA88BC5B82267");

                entity.ToTable("Skin");

                entity.HasIndex(e => e.SkinImages, "UQ__Skin__AF3CD33B6A71BD7F")
                    .IsUnique();

                entity.Property(e => e.SkinDescription).IsUnicode(false);

                entity.Property(e => e.SkinImages)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusQuest>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__StatusQu__B450643ACBD7847B");

                entity.ToTable("StatusQuest");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trophy>(entity =>
            {
                entity.HasKey(e => e.IdTrophy)
                    .HasName("PK__Trophy__E3A7B71B16DA39AC");

                entity.ToTable("Trophy");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TrophyDescription).IsUnicode(false);

                entity.Property(e => e.TrophyImage).HasColumnType("text");
            });

            modelBuilder.Entity<UserName>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__UserName__B7C92638F84623EC");

                entity.ToTable("UserName");

                entity.HasIndex(e => e.Phone, "UQ__UserName__5C7E359EFFB1B5C7")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UserName__A9D105346C6C5A65")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__UserName__C1F897314FA1D263")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PhotoUser).IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.UserName1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.UserNames)
                    .HasForeignKey(d => d.IdUserType)
                    .HasConstraintName("FK__UserName__IdUser__29572725");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IdUserType)
                    .HasName("PK__UserType__047ED66D0DA7AAC5");

                entity.ToTable("UserType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

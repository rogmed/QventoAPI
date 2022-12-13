using Microsoft.EntityFrameworkCore;

namespace QventoAPI.Data;

public partial class QventodbContext : DbContext
{
    private string? _connectionString;
    public QventodbContext()
    {
        this._connectionString = Environment.GetEnvironmentVariable("connectionString");
    }

    public QventodbContext(DbContextOptions<QventodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<Qvento> Qventos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasKey(e => new { e.QventoId, e.UserId }).HasName("PK__Invitati__33D78D18293894D8");

            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Qvento).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.QventoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__Qvent__7C4F7684");

            entity.HasOne(d => d.User).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__UserI__7D439ABD");
        });

        modelBuilder.Entity<Qvento>(entity =>
        {
            entity.HasKey(e => e.QventoId).HasName("PK__Qventos__E2AF01DC08C5B5D3");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateOfQvento).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Qventos)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Qventos__Created__797309D9");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C1417DD11");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TempToken)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

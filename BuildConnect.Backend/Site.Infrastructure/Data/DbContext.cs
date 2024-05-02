using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Site.Application.Common.Interface;
using Site.Domain.Common;
using Site.Domain.Entity;
using System.Linq.Expressions;

namespace Site.Infrastructure.Data;

public class SiteAppDbContext : DbContext, IApplicationDbContext
{
    public SiteAppDbContext(DbContextOptions<SiteAppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType).HasQueryFilter(GetIsNotDeletedExpression(entityType.ClrType));
            }
        }

        //builder.Entity<User>()
        //.HasOne(u => u.Role)
        //.WithMany()
        //.HasForeignKey(u => u.Role);
    }

    public DbSet<SiteModel> Sites { get; set; }
    // public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<MaterialReport> MaterialReports { get; set; }
    public DbSet<StaffOnSite> StaffOnSites { get; set; }
    public DbSet<LabourForce> LabourForces { get; set; }
    public DbSet<DailyReport> DailyReports { get; set; }
    public DbSet<SiteUser> SiteUsers { get; set; }
    public DbSet<EquipmentReport> EquipmentReports { get; set; }
    public DbSet<Folder> Folders { get; set; }
    public DbSet<FileModel> FileModels { get; set; }
    public DbSet<FileDetail> FileDetails { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<UserChat> UserChats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Lookup> Lookups { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Inspection> Inspections { get; set; }
    public DbSet<ManPowerCost> ManPowerCosts { get; set; }
    public DbSet<WorkItem> WorkItems { get; set; }
    public DbSet<MaterialCost> MaterialCosts { get; set; }
    public DbSet<EquipmentCost> EquipmentCosts { get; set; }
    public DbSet<RFI> RFIs { get; set; }
    public DbSet<RFIChat> RFIChats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    // public DbSet<ActivityLog> ActivityLogs { get; set; }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker
        .Entries()
        .Where(e => e.Entity is BaseModel && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseModel)entityEntry.Entity).UpdatedAt = DateTime.UtcNow; // changed to UtcNow

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseModel)entityEntry.Entity).CreatedAt = DateTime.UtcNow; // changed to UtcNow
            }
        }



        return await base.SaveChangesAsync(cancellationToken);
    }
    private static LambdaExpression GetIsNotDeletedExpression(Type type)
    {
        var parameter = Expression.Parameter(type, "e");
        var body = Expression.Equal(Expression.Property(parameter, nameof(BaseModel.DeletedAt)), Expression.Constant(null));
        return Expression.Lambda(body, parameter);
    }

    public IDbContextTransaction BeginTransaction()
    {
        return this.Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await this.Database.BeginTransactionAsync(cancellationToken);
    }
}

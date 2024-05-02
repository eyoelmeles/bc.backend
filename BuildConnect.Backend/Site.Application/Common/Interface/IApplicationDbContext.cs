using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Site.Domain.Entity;

namespace Site.Application.Common.Interface;

public interface IApplicationDbContext
{
    DbSet<SiteModel> Sites { get; set; }
    // DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Material> Materials { get; set; }
    DbSet<MaterialReport> MaterialReports { get; set; }
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
    // public DbSet<ActivityLog> ActivityLogs { get; set; }

    public DbSet<ChatMessage> ChatMessages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    IDbContextTransaction BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
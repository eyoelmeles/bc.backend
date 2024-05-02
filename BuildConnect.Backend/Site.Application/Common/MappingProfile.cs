using AutoMapper;
using Site.Application.Features.StaffOnSiteFeature.Command;
using Site.Domain.Entity;

namespace Site.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SiteModel, SiteDTO>();
        CreateMap<RFI, RFIDTO>();
        // CreateMap<Role, RoleDto>();
        CreateMap<User, UserDTO>();
        CreateMap<Material, MaterialDTO>();
        CreateMap<MaterialReport, MaterialReportDTO>();
        CreateMap<StaffOnSite, StaffOnSiteDTO>();
        CreateMap<LabourForce, LabourForceDTO>();
        CreateMap<DailyReport, DailyReportDTO>();
        CreateMap<CreateStaffOnSiteCommand, StaffOnSiteDTO>();
        CreateMap<EquipmentReport, EquipmentReportDTO>();
        CreateMap<Folder, FolderDto>();
        CreateMap<Lookup, LookupDTO>();
        CreateMap<Schedule, ScheduleDTO>();
        CreateMap<Inspection, InspectionDTO>();
        CreateMap<ManPowerCost, ManPowerCostDTO>();
        CreateMap<MaterialCost, MaterialCostDTO>();
        CreateMap<EquipmentCost, EquipmentCostDTO>();
        CreateMap<WorkItem, WorkItemDTO>();
        CreateMap<FileDetail, FileDetailDTO>();
        // CreateMap<ActivityLog, ActivityLogDTO>();
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;
using System;

namespace Site.Application.Features.DailyReportFeature.Command;

//public class CreateDailyReportCommandCommandHandler : IRequestHandler<CreateDailyReportCommand, Guid>
//{

//    private readonly IApplicationDbContext _context;
//    private readonly IMapper _mapper;

//    public CreateDailyReportCommandCommandHandler(IApplicationDbContext context, IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }
//    public async Task<Guid> Handle(CreateDailyReportCommand request, CancellationToken cancellationToken)
//    {   
//        // Create Daily Report
//        var dailyReport = new DailyReport
//        {
//            Date = request.Date.ToUniversalTime(),
//            WorkHour = request.WorkHour,
//            InterruptedHour = request.InterruptedHour,
//            Weather = request.Weather,
//        };

//        _context.DailyReports.Add(dailyReport);
//        await _context.SaveChangesAsync(cancellationToken);

//        // Create Staff On Site
//        foreach (var staffCommand in request.StaffOnSites)
//        {
//            var staffOnSite = new StaffOnSite
//            {
//                Position = staffCommand.Position,
//                Count = staffCommand.Count,
//                DailyReportId = dailyReport.Id,
//            };

//            _context.StaffOnSites.Add(staffOnSite);
//        }

//        foreach (var labourCommand in request.LabourForces)
//        {
//            var labourForce = new LabourForce
//            {
//                Position = labourCommand.Position,
//                Count = labourCommand.Count,
//                DailyReportId = dailyReport.Id,
//            };

//            _context.LabourForces.Add(labourForce);
//        }

//        foreach (var materialCommand in request.MaterialReports)
//        {
//            var materialReport = new MaterialReport
//            {
//                Name = materialCommand.Name,
//                Quantity = materialCommand.Quantity,
//                DailyReportId = dailyReport.Id,
//            };

//            _context.MaterialReports.Add(materialReport);
//        }

//        foreach (var equipmentCommand in request.EquipmentReports)
//        {
//            var equipmentReport = new EquipmentReport
//            {
//                Name = equipmentCommand.Name,
//                WorkHour = equipmentCommand.WorkHour,
//                EdleHour = equipmentCommand.EdleHour,
//                DailyReportId = dailyReport.Id,
//            };

//            _context.EquipmentReports.Add(equipmentReport);
//        }


//        await _context.SaveChangesAsync(cancellationToken);

//        var staffOnSites = await _context.StaffOnSites
//            .Where(s => s.DailyReportId == dailyReport.Id)
//            .ToListAsync(cancellationToken);

//        // Map to DTOs
//        var staffOnSiteDtos = _mapper.Map<List<StaffOnSiteDTO>>(staffOnSites);

//        var labourForces = await _context.LabourForces
//            .Where(s => s.DailyReportId == dailyReport.Id)
//            .ToListAsync(cancellationToken);

//        // Map to DTOs
//        var labourForceDtos = _mapper.Map<List<LabourForceDTO>>(labourForces);

//        var materialsReport = await _context.MaterialReports
//            .Where(s => s.DailyReportId == dailyReport.Id)
//            .ToListAsync(cancellationToken);

//        // Map to DTOs
//        var materialReportDtos = _mapper.Map<List<MaterialReportDTO>>(materialsReport);

//        var equipmensReport = await _context.EquipmentReports
//            .Where(s => s.DailyReportId == dailyReport.Id)
//            .ToListAsync(cancellationToken);

//        // Map to DTOs
//        var equipmentReportDtos = _mapper.Map<List<EquipmentReportDTO>>(equipmensReport);


//        // Map to DTO
//        var dailyReportDto = _mapper.Map<DailyReportDTO>(dailyReport);
//        dailyReportDto.StaffsOnSite = staffOnSiteDtos;
//        dailyReportDto.LabourForces = labourForceDtos;
//        dailyReportDto.MaterialsReport = materialReportDtos;
//        dailyReportDto.EquipmentReport = equipmentReportDtos;

//        return dailyReport.Id;
//    }
//}

public class CreateDailyReportCommandHandler : IRequestHandler<CreateDailyReportCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IFileService _fileService;

    public CreateDailyReportCommandHandler(IApplicationDbContext dbContext, IFileService fileService)
    {
        _dbContext = dbContext;
        _fileService = fileService;
    }

    public async Task<Guid> Handle(CreateDailyReportCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _dbContext.BeginTransactionAsync(cancellationToken);

        try
        {
            var dailyReport = new DailyReport
            {
                Date = request.Date,
                WorkHour = request.WorkHour,
                InterruptedHour = request.InterruptedHour,
                Weather = request.Weather,
                SiteId = request.SiteId,
                CreatedById = request.CreatedById,
                ApprovedById = request.ApprovedById
            };

            _dbContext.DailyReports.Add(dailyReport);

            foreach (var staff in request.StaffOnSites)
            {
                var staffOnSite = new StaffOnSite
                {
                    Position = staff.Position,
                    Count = staff.Count,
                    DailyReportId = dailyReport.Id
                };
                _dbContext.StaffOnSites.Add(staffOnSite);
            }

            foreach (var material in request.MaterialReports)
            {
                var fileName = await SaveImageAsync(material.Image);
                var materialReport = new MaterialReport
                {
                    Name = material.Name,
                    Quantity = material.Quantity,
                    Image = fileName,
                    DailyReportId = dailyReport.Id
                };
                _dbContext.MaterialReports.Add(materialReport);
            }

            foreach (var equipment in request.EquipmentReports)
            {
                var fileName = await SaveImageAsync(equipment.Image);
                var equipmentReport = new EquipmentReport
                {
                    Name = equipment.Name,
                    WorkHour = equipment.WorkHour,
                    EdleHour = equipment.EdleHour,
                    Image = fileName,
                    DailyReportId = dailyReport.Id
                };
                _dbContext.EquipmentReports.Add(equipmentReport);
            }

            foreach (var labour in request.LabourForces)
            {
                var labourForce = new LabourForce
                {
                    Position = labour.Position,
                    Count = labour.Count,
                    DailyReportId = dailyReport.Id
                };
                _dbContext.LabourForces.Add(labourForce);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return dailyReport.Id;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new Exception($"Error occurred while creating the daily report: {ex.Message}", ex);
        }
    }

    private async Task<string?> SaveImageAsync(IFormFile? imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
            return null;

        byte[] fileBytes;
        using (var memoryStream = new MemoryStream())
        {
            await imageFile.CopyToAsync(memoryStream);
            fileBytes = memoryStream.ToArray();
        }

        var format = Image.DetectFormat(fileBytes);
        if (format == null)
        {
            throw new Exception("Invalid image format.");
        }

        var fileExtension = format.FileExtensions.FirstOrDefault();
        var fileName = await _fileService.SaveFileAsync(fileBytes, fileExtension, "DailyReportAttachments");

        return fileName;
    }
}


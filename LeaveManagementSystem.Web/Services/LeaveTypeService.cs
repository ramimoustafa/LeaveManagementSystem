﻿using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services;

public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
{
 

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypesAsync()
    {
        // var data = Select * FROM LeaveTypes
        var data = await _context.LeaveTypes.ToListAsync();
        // convert the datamodel into a view model
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    public async Task<bool> CheckIfLeaveTypeNameExist(string name)
    {
        var lowercaseName = name.ToLower();

        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowercaseName = leaveTypeEdit.Name.ToLower();

        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName) && q.Id != leaveTypeEdit.Id);
    }





}

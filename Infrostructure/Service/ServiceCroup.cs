using System.Net;
using Domain;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext context)
{
    public async Task<Response<Group>> CreateAsync(Group group)
    {
        await context.Groups.AddAsync(group);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group not created") 
            : new Response<Group>(group);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var group = await context.Groups.FindAsync(id);

        if (group == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Group not found");
        }

        context.Remove(group);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Group not deleted") 
            : new Response<string>("Group deleted successfully");
    }

    public async Task<Response<List<Group>>> GetAllAsync()
    {
        var groups = await context.Groups.ToListAsync();
        return new Response<List<Group>>(groups);
    }

    public async Task<Response<Group>> GetByIdAsync(int id)
    {
        var group = await context.Groups.FindAsync(id);
        
        return group == null 
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group not found") 
            : new Response<Group>(group);
    }

    public async Task<Response<Group>> UpdateAsync(Group group)
    {
        context.Groups.Update(group);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group not updated") 
            : new Response<Group>(group);
    }
}

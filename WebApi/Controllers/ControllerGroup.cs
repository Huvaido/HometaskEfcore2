using Domain;
using Domain;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class GroupController(GroupService group)
{
    [HttpGet("/api/products")]
    public async Task<Response<List<Group>>> GetAllAsync()
    {
        var result = await group.GetAllAsync();
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Group>> GetByIdAsync(int id)
    {
        var result = await group.GetByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<Response<Group>> CreateAsync(Group group1)
    {
        var result = await group.CreateAsync(group1);
        return result;
    }

    [HttpPut]
    public async Task<Response<Group>> UpdateAsync(Group group1)
    {
        var result = await group.UpdateAsync(group1);
        return result;
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await group.DeleteAsync(id);
        return result;
    }
}
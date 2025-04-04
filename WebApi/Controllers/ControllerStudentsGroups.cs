
using Domain;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class StudentGroupController(StudentGroupService studentGroupService)
{
    [HttpGet("/api/products")]
    public async Task<Response<List<StudentGroup>>> GetAllAsync()
    {
        var result = await studentGroupService.GetAllAsync();
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<StudentGroup>> GetByIdAsync(int id)
    {
        var result = await studentGroupService.GetByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<Response<StudentGroup>> CreateAsync(StudentGroup studentGroup)
    {
        var result = await studentGroupService.CreateAsync(studentGroup);
        return result;
    }

    [HttpPut]
    public async Task<Response<StudentGroup>> UpdateAsync(StudentGroup studentGroup)
    {
        var result = await studentGroupService.UpdateAsync(studentGroup);
        return result;
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await studentGroupService.DeleteAsync(id);
        return result;
    }
}
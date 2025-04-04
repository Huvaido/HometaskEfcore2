using Domain;
using Domain;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CourseController(CourseService course)
{
    [HttpGet("/api/products")]
    public async Task<Response<List<Course>>> GetAllAsync()
    {
        var result = await course.GetAllAsync();
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Course>> GetByIdAsync(int id)
    {
        var result = await course.GetByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<Response<Course>> CreateAsync(Course course1)
    {
        var result = await course.CreateAsync(course1);
        return result;
    }

    [HttpPut]
    public async Task<Response<Course>> UpdateAsync(Course course2)
    {
        var result = await course.UpdateAsync(course2);
        return result;
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await course.DeleteAsync(id);
        return result;
    }
}
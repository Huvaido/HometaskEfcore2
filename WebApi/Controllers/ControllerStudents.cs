
using Domain;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class StudentController(StudentService studentService)
{
    [HttpGet("/api/products")]
    public async Task<Response<List<Student>>> GetAllAsync()
    {
        var result = await studentService.GetAllAsync();
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Student>> GetByIdAsync(int id)
    {
        var result = await studentService.GetByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<Response<Student>> CreateAsync(Student student)
    {
        var result = await studentService.CreateAsync(student);
        return result;
    }

    [HttpPut]
    public async Task<Response<Student>> UpdateAsync(Student student)
    {
        var result = await studentService.UpdateAsync(student);
        return result;
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await studentService.DeleteAsync(id);
        return result;
    }
}
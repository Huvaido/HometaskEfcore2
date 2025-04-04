using System.Net;
using Domain;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(DataContext context)
{
    public async Task<Response<Course>> CreateAsync(Course course)
    {
        await context.Courses.AddAsync(course);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course not created") 
            : new Response<Course>(course);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var course = await context.Courses.FindAsync(id);

        if (course == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Course not found");
        }

        context.Remove(course);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Course not deleted") 
            : new Response<string>("Course deleted successfully");
    }

    public async Task<Response<List<Course>>> GetAllAsync()
    {
        var courses = await context.Courses.ToListAsync();
        return new Response<List<Course>>(courses);
    }

    public async Task<Response<Course>> GetByIdAsync(int id)
    {
        var course = await context.Courses.FindAsync(id);
        
        return course == null 
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course not found") 
            : new Response<Course>(course);
    }

    public async Task<Response<Course>> UpdateAsync(Course course)
    {
        context.Courses.Update(course);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course not updated") 
            : new Response<Course>(course);
    }
}

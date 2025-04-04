using System.Net;
using Domain;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;


public class AdressService(DataContext context)
{
    public async Task<Response<Adress>> CreateAsync(Adress adress)
    {
        await context.Adresses.AddAsync(adress);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Adress>(HttpStatusCode.BadRequest, "Adress not created") 
            : new Response<Adress>(adress);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var adress = await context.Adresses.FindAsync(id);

        if (adress == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Adress not found");
        }

        context.Remove(adress);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Adress not deleted") 
            : new Response<string>("Adress deleted successfully");
    }

    public async Task<Response<List<Adress>>> GetAllAsync()
    {
        var adresses = await context.Adresses.ToListAsync();
        return new Response<List<Adress>>(adresses);
    }

    public async Task<Response<Adress>> GetByIdAsync(int id)
    {
        var adress = await context.Adresses.FindAsync(id);
        
        return adress == null 
            ? new Response<Adress>(HttpStatusCode.BadRequest, "Adress not found") 
            : new Response<Adress>(adress);
    }

    public async Task<Response<Adress>> UpdateAsync(Adress adress)
    {
        context.Adresses.Update(adress);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Adress>(HttpStatusCode.BadRequest, "Adress not updated") 
            : new Response<Adress>(adress);
    }
}

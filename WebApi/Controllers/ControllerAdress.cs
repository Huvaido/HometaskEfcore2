using Domain;
using Domain;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class AdressController(AdressService adressService)
{
    [HttpGet("/api/products")]
    public async Task<Response<List<Adress>>> GetAllAsync()
    {
        var result = await adressService.GetAllAsync();
        return result;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Adress>> GetByIdAsync(int id)
    {
        var result = await adressService.GetByIdAsync(id);
        return result;
    }

    [HttpPost]
    public async Task<Response<Adress>> CreateAsync(Adress adress)
    {
        var result = await adressService.CreateAsync(adress);
        return result;
    }

    [HttpPut]
    public async Task<Response<Adress>> UpdateAsync(Adress adress)
    {
        var result = await adressService.UpdateAsync(adress);
        return result;
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var result = await adressService.DeleteAsync(id);
        return result;
    }
}
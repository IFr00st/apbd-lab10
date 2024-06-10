using lab09.DTOs;
using lab09.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab09.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;
    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientsData(string? clientLastName = null)
    {
        var patients = await _dbService.GetPatientByName(clientLastName);
        return Ok(patients.Select(e => new GetPatientsDTO()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Birthdate = e.Birthdate
            
        }).ToList());
        
    }
}
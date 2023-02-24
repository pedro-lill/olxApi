using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace olxApi.Controllers;

[ApiController]
[Route("[controller]")]

/// <summary>
/// User Controller
/// </summary>
public class userController : ControllerBase
    {
        private OlxContext _context;
        private IMapper _mapper;
        public userController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Create a new User
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult addUser(
        [FromBody] CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetriveUserById), 
                new { id = user._id }, 
                user);
        }
    
    /// <summary>
    /// Update a User
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id,
        [FromBody] UpdateUserDto anuncioDto)
    {
        var anuncio = _context.Users.FirstOrDefault(anuncio =>
            anuncio._id == id);
        if (anuncio == null)
        {
            return NotFound();
        }
        _mapper.Map(anuncioDto, anuncio);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Get all Users
    /// </summary>
    [HttpGet]
    public IEnumerable <ReadUserDto> GetAllUsers(
            [FromQuery] int skip=0, [FromQuery] int take =30)
        {
            return _mapper.Map<List<ReadUserDto>>(
                _context.Users.Skip(skip).Take(take));
        } 

    /// <summary>
    /// Get a User by id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult RetriveUserById(int id)
    {
        var anuncio = _context.Users.FirstOrDefault(anuncio => anuncio._id == id);
        if (anuncio == null)
        {
            return NotFound();
        }
        var anuncioDto = _mapper.Map<ReadUserDto>(anuncio);
        return Ok(anuncioDto);
    }

    /// <summary>
    /// Partially update a User
    /// </summary>
    [HttpPatch("{id}")]
    public IActionResult PartialUserUpdate(int id,
        JsonPatchDocument<UpdateUserDto> patchDoc)
    {
        var anuncio = _context.Users.FirstOrDefault(anuncio =>
        anuncio._id == id);
        if (anuncio == null)
            return NotFound();
        var anuncioToPatch = _mapper.Map<UpdateUserDto>(anuncio);

        patchDoc.ApplyTo(anuncioToPatch, ModelState);
        if (!TryValidateModel(anuncioToPatch))
            return ValidationProblem(ModelState);
        _mapper.Map(anuncioToPatch, anuncio);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Delete a User
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var anuncio = _context.Users.FirstOrDefault(anuncio =>
        anuncio._id == id);
        if (anuncio == null) 
            return NotFound();
        _context.Remove(anuncio);
        _context.SaveChanges();
        return NoContent();
    }
}

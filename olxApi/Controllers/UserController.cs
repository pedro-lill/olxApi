using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace olxApi.Controllers;

[ApiController]
[Route("[controller]")]

public class userController : ControllerBase
    {
        private OlxContext _context;
        private IMapper _mapper;
        public userController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserDto userDto)
    {
        var user = _context.ListUsers.FirstOrDefault(user =>
            user.email == userDto.email && user.password == userDto.password);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
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
            _context.ListUsers.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetriveUserById), 
                new { id = user._id }, 
                user);
        }
        
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id,
        [FromBody] UpdateUserDto anuncioDto)
    {
        var anuncio = _context.ListUsers.FirstOrDefault(anuncio =>
            anuncio._id == id);
        if (anuncio == null)
        {
            return NotFound();
        }
        _mapper.Map(anuncioDto, anuncio);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable <ReadUserDto> GetAllUsers(
            [FromQuery] int skip=0, [FromQuery] int take =30)
        {
            return _mapper.Map<List<ReadUserDto>>(
                _context.ListUsers.Skip(skip).Take(take));
        } 

    [HttpGet("{id}")]
    public IActionResult RetriveUserById(int id)
    {
        var anuncio = _context.ListUsers.FirstOrDefault(anuncio => anuncio._id == id);
        if (anuncio == null)
        {
            return NotFound();
        }
        var anuncioDto = _mapper.Map<ReadUserDto>(anuncio);
        return Ok(anuncioDto);
    }

    [HttpPatch("{id}")]
    public IActionResult PartialUserUpdate(int id,
        JsonPatchDocument<UpdateUserDto> patchDoc)
    {
        var anuncio = _context.ListUsers.FirstOrDefault(anuncio =>
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


    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var anuncio = _context.ListUsers.FirstOrDefault(anuncio =>
        anuncio._id == id);
        if (anuncio == null) 
            return NotFound();
        _context.Remove(anuncio);
        _context.SaveChanges();
        return NoContent();
    }
}

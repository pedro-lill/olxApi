using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

namespace olxApi.Controllers;

[ApiController]
[Route("user")]
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
    /// create a User (cadastrando um usuário)
    /// </summary>
    [HttpPost]
    [Route("signup")]
    public IActionResult Cadastrar(
        [FromBody] CreateUserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
        user.token = Guid.NewGuid().ToString();
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(new { token = user.token });
    }
    
    /// <summary>
    /// login
    /// </summary>
    [HttpPost("signin")]
    public IActionResult Logar([FromBody] LoginUserDto login)
    {
        var user = _context.Users.FirstOrDefault(user =>
            user.email == login.email);
        if (user == null)
        {
            return BadRequest(new { error = "User or password not found" });
        }
        if (BCrypt.Net.BCrypt.Verify(login.password, user.password))
        {
            user.token = Guid.NewGuid().ToString();
            _context.SaveChanges();
            user.password = null;
            return Ok(new { token = user.token });
        }
        return BadRequest(new { error = "User or password not Found" });
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

    //get a user by token
    [HttpGet]
    [Route("me")]
    public IActionResult RetrieveUserByToken(string token)
    {
        var user = _context.Users.FirstOrDefault(user =>
        user.token == token);
        if (user == null)
            return NotFound();
        user.state = _context.States.FirstOrDefault(state => state._id == user.state_id);
        return Ok(_mapper.Map<ReadUserDto>(user));
    }

    /// <summary>
    /// update a User or partial update with token parameter
    /// </summary>
    [HttpPut]
    [Route("me")]
    public IActionResult UpdateUser(
        [FromBody] UpdateUserDto userDto)
    {
        var user = _context.Users.FirstOrDefault(user =>
            user.token == userDto.token);
        if (user == null)
        {
            return NotFound();
        }
        //define old email if a new one is not informed
        if (userDto.email == null) userDto.email = user.email;
        _mapper.Map(userDto, user);
        user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
        _context.SaveChanges();
        return NoContent();
    }


    /// <summary>
    /// Delete a User
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(user =>
        user._id == id);
        if (user == null)
            return NotFound();
        _context.Users.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
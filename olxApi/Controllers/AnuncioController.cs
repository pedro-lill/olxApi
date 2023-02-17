using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace olxApi.Controllers;

[ApiController]
[Route("[controller]")]

public class anuncioController : ControllerBase
    {

        private OlxContext _context;
        private IMapper _mapper;
        public anuncioController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    /// <summary>
    /// Create a new Anuncio
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult addAnuncio(
        [FromBody] CreateAnuncioDto anuncioDto)
        {
            try
            {
            Anuncio anuncio = _mapper.Map<Anuncio>(anuncioDto);
            _context.ListAnuncios.Add(anuncio);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetriveAdById), 
                new { id = anuncio._id }, 
                anuncio);
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                throw;
            }
        }
        
    [HttpPut("{id}")]
    public IActionResult UpdateAnuncio(int id,
        [FromBody] UpdateAnuncioDto anuncioDto)
    {
        var anuncio = _context.ListAnuncios.FirstOrDefault(anuncio =>
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
    public IEnumerable <ReadAnuncioDto> GetAllAnuncios(
            [FromQuery] int skip=0, [FromQuery] int take =30)
        {
            return _mapper.Map<List<ReadAnuncioDto>>(
                _context.ListAnuncios.Skip(skip).Take(take));
        } 

    [HttpGet("{id}")]
    public IActionResult RetriveAdById(int id)
    {
        var anuncio = _context.ListAnuncios.FirstOrDefault(anuncio => anuncio._id == id);
        if (anuncio == null)
        {
            return NotFound();
        }
        var anuncioDto = _mapper.Map<ReadAnuncioDto>(anuncio);
        return Ok(anuncioDto);
    }

    [HttpPatch("{id}")]
    public IActionResult PartialAnuncioUpdate(int id,
        JsonPatchDocument<UpdateAnuncioDto> patchDoc)
    {
        var anuncio = _context.ListAnuncios.FirstOrDefault(anuncio =>
        anuncio._id == id);
        if (anuncio == null)
            return NotFound();
        var anuncioToPatch = _mapper.Map<UpdateAnuncioDto>(anuncio);

        patchDoc.ApplyTo(anuncioToPatch, ModelState);
        if (!TryValidateModel(anuncioToPatch))
            return ValidationProblem(ModelState);
        _mapper.Map(anuncioToPatch, anuncio);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteAnuncio(int id)
    {
        var anuncio = _context.ListAnuncios.FirstOrDefault(anuncio =>
        anuncio._id == id);
        if (anuncio == null) 
            return NotFound();
        _context.Remove(anuncio);
        _context.SaveChanges();
        return NoContent();
    }
}

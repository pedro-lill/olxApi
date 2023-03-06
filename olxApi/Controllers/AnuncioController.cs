using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;

namespace olxApi.Controllers;

/// <summary>
/// Anuncio Controller
/// </summary>
[ApiController]
[Route("ad")]

public class anuncioController : ControllerBase
    {
        private OlxContext _context;
        private IMapper _mapper;
        /// <summary>
        /// Anuncio Controller
        /// </summary>
        public anuncioController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Create a new Anuncio
    /// </summary>
    [HttpPost]
    [Route("add")]
    public IActionResult addAnuncio(
        [FromBody] CreateAnuncioDto anuncioDto)
        {
            try
            {
            Anuncio anuncio = _mapper.Map<Anuncio>(anuncioDto);
            _context.Anuncios.Add(anuncio);
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

    /// <summary>
    /// Update a Anuncio
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateAnuncio(int id,
        [FromBody] UpdateAnuncioDto anuncioDto)
    {
        var anuncio = _context.Anuncios.FirstOrDefault(anuncio =>
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
    /// Get all Anuncios
    /// </summary>
    [HttpGet]
    [Route("list")]
    public IEnumerable <ReadAnuncioDto> GetAllAnuncios(
            [FromQuery] string sort = "desc", [FromQuery] int limit =30)
        {
            return _mapper.Map<List<ReadAnuncioDto>>(
                _context.Anuncios.OrderByDescending(anuncio => anuncio._id).Take(limit));
        } 

      /// <summary>
    /// Get Anuncio by Id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult RetriveAdById(int id)
    {
        var anuncio = _context.Anuncios.FirstOrDefault(anuncio => anuncio._id == id);
        if (anuncio == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ReadAnuncioDto>(anuncio));
    }



    /// <summary>
    /// Get others ads from user_id
    /// </summary>
    [HttpGet("{id, other}")]
    public IEnumerable <ReadAnuncioDto> GetOthersAds(int id)
    {
        var anuncio = _context.Anuncios.FirstOrDefault(anuncio => anuncio._id == id);
        if (anuncio == null)
        {
            return (IEnumerable<ReadAnuncioDto>)NotFound();
        }
        return _mapper.Map<List<ReadAnuncioDto>>(
                _context.Anuncios.Where(anuncio => anuncio.user_id == anuncio.user_id));
    }

    /// <summary>
    /// Partially update a Anuncio
    /// </summary>
    [HttpPatch("{id}")]
    public IActionResult PartialAnuncioUpdate(int id,
        JsonPatchDocument<UpdateAnuncioDto> patchDoc)
    {
        var anuncio = _context.Anuncios.FirstOrDefault(anuncio =>
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

    /// <summary>
    /// Delete a Anuncio
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteAnuncio(int id)
    {
        var anuncio = _context.Anuncios.FirstOrDefault(anuncio =>
        anuncio._id == id);
        if (anuncio == null) 
            return NotFound();
        _context.Remove(anuncio);
        _context.SaveChanges();
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;

namespace olxApi.Controllers;

[ApiController]
[Route("ad")]
[Route("ads")]

public class anuncioController : ControllerBase
    {
        private OlxContext _context;
        private IMapper _mapper;
 
    public anuncioController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<ReadAnuncioDto> GetAnuncioById(int id, bool other = false)
    {
        if (other == true){
            //return other ads from the same user
            var anuncioItem = _context.Anuncios.Find(id);
            var Anuncios = _context.Anuncios.Where(
                anuncio => 
                anuncio.user_id == anuncioItem.user_id
            );
            return Ok(new {
                ads =_mapper.Map<List<ReadAnuncioDto>>(Anuncios),
                total = Anuncios.Count()
                });
        }
        var anuncioItemid = _context.Anuncios.Find(id);
        if (anuncioItemid != null)
        {
            return Ok(_mapper.Map<ReadAnuncioDto>(anuncioItemid));
        }
        return NotFound();
    }

    /// <summary>
    /// Get all Anuncios and filter by query with count
    /// </summary>
    [HttpGet]
    [Route("list")]
    public ActionResult<IEnumerable<ReadAnuncioDto>> GetAllAnuncios(
        [FromQuery] string q ="",
        [FromQuery] string cat = "",
        [FromQuery] string state ="",
        [FromQuery] string sort = "desc",
        [FromQuery] int limit =30,
        [FromQuery] int offset = 0)
        {
            var Categoria = _context.Categories.FirstOrDefault(categoria => categoria.slug == cat);
            var Estado = _context.States.FirstOrDefault(estado => estado.name == state);
            var Anuncios = _context.Anuncios
                            .Include(anuncio => anuncio.category)
                            .Include(anuncio => anuncio.images)
                            .Include(anuncio => anuncio.state)
                            .Where(
                                anuncio => 
                                anuncio.title.Contains(q) &&
                                (Categoria == null || anuncio.category_id == Categoria._id) &&                
                                (Estado == null || anuncio.state_id == Estado._id)    
                            )
                            .ToList()
                            .Skip(offset);
            if (limit < 10)
            {
                return Ok(new {
                    ads =_mapper.Map<List<ReadAnuncioDto>>(Anuncios.Take(limit)),
                    total = Anuncios.Count(),
                    });
            }
            else
                {
                return _mapper.Map<List<ReadAnuncioDto>>(Anuncios);
            }
        }

    [HttpGet("item")]
    public IActionResult GetOtherAds([FromQuery] int id, [FromQuery] bool other = false)
    {
        var anuncioItemid = _context.Anuncios.Find(id);
        if (anuncioItemid == null)            
            return NotFound();
        if (other == true){
            //return other ads from the same user
            var Anuncios = _context.Anuncios
            .Include(anuncio => anuncio.images)
            .Include(anuncio => anuncio.state)
            .Include(anuncio => anuncio.category)
            .Where(
                anuncio => 
                anuncio.user_id == anuncioItemid.user_id
            ).ToList();
            
            return Ok(new OtherDto(
                _mapper.Map<ReadAnuncioDto>(anuncioItemid),
                _mapper.Map<List<ReadAnuncioDto>>(Anuncios)
            ));
        }
        else{
            return Ok(new {
                ad = _mapper.Map<ReadAnuncioDto>(anuncioItemid),
                
            });
        }
    }

    [HttpPost]
    [Route("add")]
    public IActionResult addAnuncio([FromForm] CreateAnuncioDto anuncioDto)
        {       
        Anuncio anuncio = new Anuncio();
        var user = _context.Users.FirstOrDefault(user => user.token == anuncioDto.token);
        if (user == null)
        {
            return NotFound();
        }
        anuncio.user_id = user._id;
        anuncio.state_id = user.state_id;
        anuncio.title = anuncioDto.title;
        anuncio.desc = anuncioDto.desc;
        anuncio.price = anuncioDto.price;
        anuncio.dateCreated = DateTime.Now;
        anuncio.category_id = _context.Categories.FirstOrDefault(categoria => categoria.name == anuncioDto.cat)._id;
        anuncio.priceNeg = anuncioDto.priceNeg;
        
        _context.Anuncios.Add(anuncio);
        _context.SaveChanges();

        foreach (var image in anuncioDto.img){
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images",
                guid + Path.GetExtension(image.FileName));
                using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                Image img = new Image();
                img.url = guid + Path.GetExtension(image.FileName);
                img.anuncio_id = anuncio._id;
                img.isDefault = true;
                _context.Images.Add(img);
            }
        _context.SaveChanges();
        return Ok();
        }

    [HttpPut("{id}")]


    [HttpPost]
    [Route("teste")]
    public IActionResult Post(IFormFile file)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",
        Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }
        return Ok();
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
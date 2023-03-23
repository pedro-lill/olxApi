using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using System.Net.Mime;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;


namespace olxApi.Controllers;

[ApiController]
[Route("image")]


public class ImageController : ControllerBase
    {
        private OlxContext _context;
        private IMapper _mapper;
        public ImageController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("all")]
    public IActionResult RetriveAllImages()
    {
        var images = _context.Images.ToList();
        return Ok(images);
    }

    [HttpGet("{id}")]
    public IActionResult RetriveImageById(int id)
    {
        var image = _context.Images.FirstOrDefault(image =>
            image._id == id);
        if (image == null)
        {
            return NotFound();
        }
        return Ok(image);
    }


    public static string SaveImage(IFormFile image)
    {
        // Salva a imagem em um diretório no servidor e retorna a URL da imagem
        // Exemplo de código para salvar a imagem:
        
        var fileName = Guid.NewGuid().ToString();
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "Images", fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            image.CopyTo(stream);
        }
        return filePath;
     
    }




}
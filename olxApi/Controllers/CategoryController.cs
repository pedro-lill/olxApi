using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace olxApi.Controllers;

[ApiController]
[Route("[controller]")]

public class categoryController : ControllerBase
    {

        private OlxContext _context;
        private IMapper _mapper;
        public categoryController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    
    /// <summary>
    /// Create a new Category
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult addCategory(
        [FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
            Category category = _mapper.Map<Category>(categoryDto);
            _context.ListCategories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetriveAdById), 
                new { id = category._id }, 
                category);
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                throw;
            }
        }
        
    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id,
        [FromBody] UpdateCategoryDto categoryDto)
    {
        var category = _context.ListCategories.FirstOrDefault(category =>
            category._id == id);
        if (category == null)
        {
            return NotFound();
        }
        _mapper.Map(categoryDto, category);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public IEnumerable <ReadCategoryDto> GetAllCategories(
            [FromQuery] int skip=0, [FromQuery] int take =30)
        {
            return _mapper.Map<List<ReadCategoryDto>>(
                _context.ListCategories.Skip(skip).Take(take));
        } 

    [HttpGet("{id}")]
    public IActionResult RetriveAdById(int id)
    {
        var category = _context.ListCategories.FirstOrDefault(category => category._id == id);
        if (category == null)
        {
            return NotFound();
        }
        var categoryDto = _mapper.Map<ReadCategoryDto>(category);
        return Ok(categoryDto);
    }

    [HttpPatch("{id}")]
    public IActionResult PartialCategoryUpdate(int id,
        JsonPatchDocument<UpdateCategoryDto> patchDoc)
    {
        var category = _context.ListCategories.FirstOrDefault(category =>
        category._id == id);
        if (category == null)
            return NotFound();
        var categoryToPatch = _mapper.Map<UpdateCategoryDto>(category);

        patchDoc.ApplyTo(categoryToPatch, ModelState);
        if (!TryValidateModel(categoryToPatch))
            return ValidationProblem(ModelState);
        _mapper.Map(categoryToPatch, category);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = _context.ListCategories.FirstOrDefault(category =>
        category._id == id);
        if (category == null) 
            return NotFound();
        _context.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}

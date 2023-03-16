using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace olxApi.Controllers;

/// <summary>
/// Category Controller
/// </summary>
[ApiController]
[Route("categories")]
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
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetriveCategoryById), 
                new { id = category._id }, 
                category);
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                throw;
            }
        }
        

    /// <summary>
    /// Get all Categories
    /// </summary>
    [HttpGet]
    public IActionResult GetAllCategories(
            [FromQuery] int skip=0, [FromQuery] int take =30)
        {
            
            var categories =_mapper.Map<List<ReadCategoryDto>>(_context.Categories.Skip(skip).Take(take));
        
            return Ok(new {categories});
        
        } 

    /// <summary>
    /// Get a Category by id
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult RetriveCategoryById(int id)
    {
        var category = _context.Categories.FirstOrDefault(category => category._id == id);
        if (category == null)
        {
            return NotFound();
        }
        var categoryDto = _mapper.Map<ReadCategoryDto>(category);
        return Ok(categoryDto);
    }

    /// <summary>
    /// Partially update a Category
    /// </summary>
    [HttpPatch("{id}")]
    public IActionResult PartialCategoryUpdate(int id,
        JsonPatchDocument<UpdateCategoryDto> patchDoc)
    {
        var category = _context.Categories.FirstOrDefault(category =>
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

    /// <summary>
    /// Delete a Category
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = _context.Categories.FirstOrDefault(category =>
        category._id == id);
        if (category == null) 
            return NotFound();
        _context.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}

    
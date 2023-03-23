using Microsoft.AspNetCore.Mvc;
using olxApi.Models;
using olxApi.Data;
using olxApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Cors;

namespace olxApi.Controllers;

/// <summary>
/// State Controller
/// </summary>
[ApiController]
[Route("states")]

public class stateController : ControllerBase
    {
        private OlxContext _context;
        private IMapper _mapper;
        /// <summary>
        /// State Controller
        /// </summary>
    public stateController(OlxContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// get all states
    /// </summary>
    [HttpGet]
    public IEnumerable<ReadStateDto> GetAllStates()
    {
        return _mapper.Map<IEnumerable<ReadStateDto>>(_context.States);
    }

    /// <summary>
    /// get state by id
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ReadStateDto> GetStateById(int id)
    {
        var stateItem = _context.States.Find(id);
        if (stateItem != null)
        {
            return Ok(_mapper.Map<ReadStateDto>(stateItem));
        }
        return NotFound();
    }
    
}

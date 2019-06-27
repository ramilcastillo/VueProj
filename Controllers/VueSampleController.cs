using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace vue_sample_proj.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VueSampleController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public VueSampleController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/foodrecords
    [HttpGet]
    public async Task<ActionResult<List<VueSampleModel>>> Get()
    {
      return await _dbContext.VueSample.ToListAsync();
    }

    // GET api/foodrecords/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VueSampleModel>> Get(string id)
    {
      return await _dbContext.VueSample.FindAsync(id);
    }

    // POST api/foodrecords
    [HttpPost]
    public async Task Post(VueSampleModel model)
    {
      await _dbContext.AddAsync(model);

      await _dbContext.SaveChangesAsync();
    }

    // PUT api/foodrecords/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, VueSampleModel model)
    {
      var exists = await _dbContext.VueSample.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.VueSample.Update(model);

      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/foodrecords/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
      var entity = await _dbContext.VueSample.FindAsync(id);

      _dbContext.VueSample.Remove(entity);

      await _dbContext.SaveChangesAsync();

      return Ok();
    }
  }
}

using System.Web.Http;
using System.Threading.Tasks;
using System;

public class FruitController : ApiController
{
    private readonly FruitService _fruitService;

    public FruitController(FruitService fruitService)
    {
        _fruitService = fruitService;
    }

    [HttpGet]
    public async Task<IHttpActionResult> GetFruitByName(string name)
    {
        try
        {
            var fruit = await _fruitService.GetFruitByName(name);
            return Ok(fruit);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IHttpActionResult> AddMetadata(int fruitId, [FromBody] FruitMetadata metadata)
    {
        try
        {
            var fruit = await _fruitService.AddMetadata(fruitId, metadata.Key, metadata.Value);
            return Ok(fruit);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IHttpActionResult> RemoveMetadata(int fruitId, string key)
    {
        try
        {
            var fruit = await _fruitService.RemoveMetadata(fruitId, key);
            return Ok(fruit);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IHttpActionResult> UpdateMetadata(int fruitId, string key, [FromBody] string newValue)
    {
        try
        {
            var fruit = await _fruitService.UpdateMetadata(fruitId, key, newValue);
            return Ok(fruit);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
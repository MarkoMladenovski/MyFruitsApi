using System.Web.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;


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
            return InternalServerError(ex.Message);
        }
    }

    private IHttpActionResult InternalServerError(string message)
    {
        throw new NotImplementedException();
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
            return InternalServerError(ex.Message);
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
            return InternalServerError(ex.Message);
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
            return InternalServerError(ex.Message);
        }
    }
}

//The HTTTPClient you can put it in another wrapper for the client and enter data as a parameter and that the url as an app config variable, or on the cloud
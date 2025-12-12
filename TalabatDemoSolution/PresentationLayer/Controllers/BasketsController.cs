using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOS.BasketDtos;
using Shared.DTOS.ProductDtos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PresentationLayer.Controllers
{
    [ApiController]
    [Authorize]

    [Route("api/[controller]")]
    public class BasketsController(IServiceManager serviceManager)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> Update(BasketDTO basket)
            => Ok(await serviceManager.BasketService.UpdateAsync(basket));
        [HttpDelete]
        public async Task<ActionResult<BasketDTO>> Delete(string id)
        {
            await serviceManager.BasketService.DeleteAsync(id);
            return NoContent(); 
        }
        [HttpGet]
        public async Task<ActionResult<BasketDTO>> Get(string id)
            => Ok(await serviceManager.BasketService.GetAsync(id));
    }
}
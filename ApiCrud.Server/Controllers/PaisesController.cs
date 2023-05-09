using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ApiCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        //[Authorize]
        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var listaPaises= await Task.FromResult(new List<string> { "Francia", "Argentina", "Croasia", "Marruecos" });
            return Ok(listaPaises);
        }
           
    }
}

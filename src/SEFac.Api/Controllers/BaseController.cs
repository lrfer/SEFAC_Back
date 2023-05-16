using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SEFAC.Domain.Const;

namespace SEFac.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors(Policy.AllowAll)]
    public class ApiController : ControllerBase
    {
    }
}

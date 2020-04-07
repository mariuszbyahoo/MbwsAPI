using Mbws.Data;
using Mbws.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mbws.API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private PostsContext _ctx;

        public PostsController(PostsContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<Post[]>> GetAll()
        {
            return Ok(await _ctx.Read());
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<ActionResult<Post>> Get(Guid ID)
        {
            return Ok(await _ctx.Read(ID));
        }

        [HttpPatch]
        [Route("{ID}")]
        public ActionResult<Post> Patch(Guid ID, [FromBody] Post post)
        {
            _ctx.Update(post);
            return Ok(post);
        }

        [HttpPost]
        public ActionResult<Post> Create ([FromBody] Post post)
        {
            _ctx.Create(post);
            return Created("Uri",post);
        }

        [HttpDelete]
        [Route("{ID}")]
        public async Task<ActionResult> Delete (Guid ID)
        {
            await _ctx.Delete(ID);
            return NoContent();
        }
    }
}

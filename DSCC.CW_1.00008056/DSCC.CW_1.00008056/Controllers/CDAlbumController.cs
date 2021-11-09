using DSCC.CW_1._00008056.Model;
using DSCC.CW_1._00008056.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSCC.CW_1._00008056.Controllers
{
   //An url address from which all the values inserted into DB should come in a JSON format
    [Route("api/CDAlbum")]
    [Produces("application/json")]
    [ApiController]
    public class CDAlbumController : ControllerBase
    {

        private readonly IAlbumRepository _albumRepository;
        public CDAlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        // GET: api/<CDAlbumController>
        [HttpGet]
        public IActionResult Get()
        {
            var albums = _albumRepository.GetAlbums();
            return new OkObjectResult(albums);
        }

        // GET api/<CDAlbumController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var album = _albumRepository.GetAlbumById(id);
            return new OkObjectResult(album);

        }

        // POST api/<CDAlbumController>
        [HttpPost]
        public IActionResult Post([FromBody] Album album)
        {
            using (var scope = new TransactionScope())
            {
                _albumRepository.InsertAlbum(album);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = album.AlbumId }, album);
            }

        }

        // PUT api/<CDAlbumController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Album album)
        {
            if (album != null)
            {
                using (var scope = new TransactionScope())
                {
                    _albumRepository.UpdateAlbum(album);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<CDAlbumController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _albumRepository.DeleteAlbum(id);
            return new OkResult();
        }
    }
}

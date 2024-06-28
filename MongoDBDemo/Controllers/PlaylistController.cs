using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBDemo.Models;
using MongoDBDemo.Services;

namespace MongoDBDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistService playlistService;

        public PlaylistController(PlaylistService _playlistService)
        {
            playlistService = _playlistService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Playlist>>> Get()
        {
            return await playlistService.GetAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Playlist playlist)
        {
            await playlistService.CreateAsync(playlist);
            return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
        {
            await playlistService.AddToPlaylistAsync(id, movieId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await playlistService.DeleteAsync(id);
            return NoContent();
        }
    }
}

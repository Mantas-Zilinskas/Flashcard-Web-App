using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using FlashcardWebApp.LeaderboardAPI.Interfaces;
using FlashcardWebApp.LeaderboardAPI.Models;

namespace FlashcardWebApp.LeaderboardAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttemptController : ControllerBase
    {
        private readonly IAttemptService _attemptService;

        public AttemptController(IAttemptService service)
        {
            _attemptService = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _attemptService.GetAttempts());
        }

        [HttpDelete("DeleteAll")]
        public async Task DeleteAll()
        {
            await _attemptService.DeleteAll();
        }

        [HttpDelete("DeleteBySetName/{setName}")]
        public async Task DeleteFromSet(string setName)
        {
            await _attemptService.DeleteAttempt(setName);
        }

        [HttpPost("AddAttempt")]
        public async Task AddAttempt([FromBody] AttemptDTO attempt)
        {
            await _attemptService.AddAttempt(attempt);
        }

        [HttpGet("GetBySetName/{setName}")]
        public async Task<IActionResult> GetBySetName(string setName)
        {
            return Ok(await _attemptService.GetAttempts(setName));
        }

        [HttpGet("getStats/{setName}")]
        public async Task<IActionResult> GetStats(string setName) {
            return Ok(await _attemptService.GetStats(setName));
        }
    }
}
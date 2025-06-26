using CertificateAPI.DTOs.Training;
using CertificateAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprache;
using System.Security.Claims;

namespace CertificateAPI.Controller
{
    [ApiController]
    [Route("api/trainings")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        public TrainingController(ITrainingService trainingService) => _trainingService = trainingService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _trainingService.GetAllAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var training = await _trainingService.GetByIdAsync(id);
            return Ok(training);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainingDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var created = await _trainingService.CreateAsync(dto, Guid.Parse(userId!));
            return Ok(created);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TrainingDto dto)
        {
            var updated = await _trainingService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _trainingService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
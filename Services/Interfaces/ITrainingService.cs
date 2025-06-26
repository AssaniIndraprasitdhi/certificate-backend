using CertificateAPI.DTOs.Training;
using CertificateAPI.Models;

namespace CertificateAPI.Services.Interfaces
{
    public interface ITrainingService
    {
        Task<List<TrainingDto>> GetAllAsync();
        Task<TrainingDto> GetByIdAsync(Guid id);
        Task<TrainingDto> CreateAsync(TrainingDto dto, Guid creatorId);
        Task<TrainingDto> UpdateAsync(Guid id, TrainingDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
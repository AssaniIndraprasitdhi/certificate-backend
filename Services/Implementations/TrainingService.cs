using CertificateAPI.Data;
using CertificateAPI.DTOs.Training;
using CertificateAPI.Models;
using CertificateAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CertificateAPI.Services.Implementations
{
    public class TrainingService : ITrainingService
    {
        private readonly AppDbContext _db;
        public TrainingService(AppDbContext db) => _db = db;

        public async Task<List<TrainingDto>> GetAllAsync()
        {
            return await _db.Trainings
                .Select(t => new TrainingDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Date = t.Date,
                    Location = t.Location,
                    TrainerName = t.TrainerName
                }).ToListAsync();
        }

        public async Task<TrainingDto> GetByIdAsync(Guid id)
        {
            var t = await _db.Trainings.FindAsync(id) ?? throw new Exception("Training not found");
            return new TrainingDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Date = t.Date,
                Location = t.Location,
                TrainerName = t.TrainerName
            };
        }

        public async Task<TrainingDto> CreateAsync(TrainingDto dto, Guid creatorId)
        {
            var training = new Training
            {
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                Location = dto.Location,
                TrainerName = dto.TrainerName,
                CreateBy = creatorId
            };

            _db.Trainings.Add(training);
            await _db.SaveChangesAsync();

            dto.Id = training.Id;
            return dto;
        }

        public async Task<TrainingDto> UpdateAsync(Guid id, TrainingDto dto)
        {
            var training = await _db.Trainings.FindAsync(id) ?? throw new Exception("Training not found.");

            training.Title = dto.Title;
            training.Description = dto.Description;
            training.Date = dto.Date;
            training.Location = dto.Location;
            training.TrainerName = dto.TrainerName;

            await _db.SaveChangesAsync();
            return new TrainingDto
            {
                Id = training.Id,
                Title = training.Title,
                Description = training.Description,
                Date = training.Date,
                Location = training.Location,
                TrainerName = training.TrainerName
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var training = await _db.Trainings.FindAsync(id) ?? throw new Exception("Training not found.");
            if (training == null) return false;

            _db.Trainings.Remove(training);
            await _db.SaveChangesAsync();
            return true;
        }   
    }
}
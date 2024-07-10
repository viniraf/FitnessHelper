using FitnessHelper.Data;
using FitnessHelper.Enums;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessHelper.Repositories.Implementations;

public class TrainingRepository : ITrainingRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TrainingRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<TrainingModel>> GetAllByStatusAsync(int userId, bool trainingIsActive)
    {
        List<TrainingModel> trainings = await _applicationDbContext.Trainings
            .Where(t => t.UserId == userId && t.IsActive == trainingIsActive)
            .ToListAsync();

        return trainings;
    }

    public async Task<TrainingModel> GetByIdAsync(int userId, int id)
    {
        TrainingModel? training = await _applicationDbContext.Trainings.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == id);

       return training;
    }

    public async Task CreateAsync(TrainingModel trainingModel)
    {
        await _applicationDbContext.Trainings.AddAsync(trainingModel);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TrainingModel trainingModel)
    {
        _applicationDbContext.Trainings.Update(trainingModel);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<List<ExerciseModel>> GetAllExercisesByStatusAsync(int userId, bool exerciseIsActive)
    {
        List<ExerciseModel> exercises = await _applicationDbContext.Exercises
            .Where(e => e.UserId == userId && e.IsActive == exerciseIsActive)
            .ToListAsync();

        return exercises;
    }
}

using FitnessHelper.Data;
using FitnessHelper.Enums;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;

namespace FitnessHelper.Repositories.Implementations;

public class TrainingRepository : ITrainingRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TrainingRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public List<TrainingModel> GetAllByStatus(int userId, bool trainingIsActive)
    {
        List<TrainingModel> trainings = _applicationDbContext.Trainings.Where(t => t.UserId == userId && t.IsActive == trainingIsActive).ToList();
        return trainings;
    }

    public TrainingModel GetById(int userId, int id)
    {
        TrainingModel? training = _applicationDbContext.Trainings.FirstOrDefault(t => t.UserId == userId && t.Id == id);
       return training;
    }

    public void Create(TrainingModel trainingModel)
    {
        _applicationDbContext.Trainings.Add(trainingModel);
        _applicationDbContext.SaveChanges();
    }

    public void Update(TrainingModel trainingModel)
    {
        _applicationDbContext.Update(trainingModel);
        _applicationDbContext.SaveChanges();
    }

    public List<ExerciseModel> GetAllExercisesByStatus(int userId, bool exerciseIsActive)
    {
        List<ExerciseModel> exercises = _applicationDbContext.Exercises.Where(e => e.UserId == userId && e.IsActive == exerciseIsActive).ToList();

        return exercises;
    }
}

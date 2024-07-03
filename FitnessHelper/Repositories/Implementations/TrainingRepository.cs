using FitnessHelper.Data;
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

    public List<TrainingModel> GetAll(int userId)
    {
        List<TrainingModel> trainings = _applicationDbContext.Trainings.Where(t => t.UserId == userId).ToList();
        return trainings;
    }

    public TrainingModel GetById(int userId, int id)
    {
       var training = _applicationDbContext.Trainings.FirstOrDefault(t => t.UserId == userId && t.Id == id);
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

    public List<ExerciseModel> GetAllExercises(int userId)
    {
        var exercises = _applicationDbContext.Exercises.Where(e => e.UserId == userId).ToList();

        return exercises;
    }
}

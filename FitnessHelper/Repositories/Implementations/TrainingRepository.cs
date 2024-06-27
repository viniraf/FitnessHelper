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

    public List<TrainingModel> GetAll()
    {
        List<TrainingModel> trainings = _applicationDbContext.Trainings.ToList();
        return trainings;
    }

    public TrainingModel GetById(int id)
    {
       var training = _applicationDbContext.Trainings.FirstOrDefault(x => x.Id == id);
       return training;
    }

    public void Create(TrainingModel trainingModel)
    {
        _applicationDbContext.Trainings.Add(trainingModel);
        _applicationDbContext.SaveChanges();
    }

    public void Update()
    {
        _applicationDbContext.SaveChanges();
    }
}

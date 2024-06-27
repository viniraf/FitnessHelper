using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using FitnessHelper.Services.Interfaces;

namespace FitnessHelper.Services.Implementatios;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;

    public TrainingService(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public List<TrainingModel> GetAll()
    {
        List<TrainingModel> trainings = _trainingRepository.GetAll();

        if (trainings.Count == 0)
        {
            return new List<TrainingModel>();
        }

        return trainings;
    }

    public TrainingModel GetById(int id)
    {
        TrainingModel training = _trainingRepository.GetById(id);

        return training;
    }

    public void Create(TrainingRequestModel trainingRequestModel)
    {
        var trainingModel = new TrainingModel
        {
            Title = trainingRequestModel.Title,
            CreateDate = DateTime.Now,
            IsActive = trainingRequestModel.IsActive
        };

        _trainingRepository.Create(trainingModel);
    }

    public void Update(int id, TrainingUpdateRequestModel trainingUpdateRequestModel)
    {
        TrainingModel trainingInDb = _trainingRepository.GetById(id);

        trainingInDb.Title = trainingUpdateRequestModel.Title;
        trainingInDb.IsActive = trainingUpdateRequestModel.IsActive;

        _trainingRepository.Update();
    }
}




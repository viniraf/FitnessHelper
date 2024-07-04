using FitnessHelper.Enums;
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

    public List<TrainingModel> GetAllByStatus(int userId, bool trainingIsActive, bool exerciseIsActive)
    {
        List<TrainingModel> trainings = _trainingRepository.GetAllByStatus(userId, trainingIsActive);

        if (trainings.Count == 0)
        {
            return new List<TrainingModel>();
        }

        List<ExerciseModel> exercises = _trainingRepository.GetAllExercisesByStatus(userId, exerciseIsActive);


        Dictionary<int, List<ExerciseModel>> exercisesByTrainingId = exercises.GroupBy(e => e.TrainingId)
                                              .ToDictionary(g => g.Key, g => g.ToList());

        foreach (TrainingModel training in trainings)
        {
            if (exercisesByTrainingId.TryGetValue(training.Id, out List<ExerciseModel>? associatedExercises))
            {
                training.Exercises = associatedExercises;
            }
            else
            {
                training.Exercises = new List<ExerciseModel>();
            }
        }
        return trainings;
    }

    public TrainingModel GetById(int userId, int id)
    {
        TrainingModel training = _trainingRepository.GetById(userId, id);

        return training;
    }

    public void Create(int userId, TrainingRequestModel trainingRequestModel)
    {
        TrainingModel trainingModel = new TrainingModel
        {
            TrainingTitle = trainingRequestModel.TrainingTitle,
            CreateDate = DateOnly.FromDateTime(DateTime.Now),
            IsActive = true,
            UserId = userId,
        };

        _trainingRepository.Create(trainingModel);
    }

    public void Update(int userId, int id, TrainingUpdateRequestModel trainingUpdateRequestModel)
    {
        TrainingModel trainingInDb = _trainingRepository.GetById(userId, id);

        trainingInDb.TrainingTitle = trainingUpdateRequestModel.TrainingTitle;
        trainingInDb.IsActive = trainingUpdateRequestModel.IsActive;

        _trainingRepository.Update(trainingInDb);
    }
}




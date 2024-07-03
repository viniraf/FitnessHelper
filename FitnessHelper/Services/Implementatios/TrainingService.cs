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

    public List<TrainingModel> GetAll(int userId)
    {
        List<TrainingModel> trainings = _trainingRepository.GetAll(userId);

        if (trainings.Count == 0)
        {
            return new List<TrainingModel>();
        }

        var exercises = _trainingRepository.GetAllExercises(userId);

        // Crie um dicionário para mapear os exercícios por TrainingId
        var exercisesByTrainingId = exercises.GroupBy(e => e.TrainingId)
                                              .ToDictionary(g => g.Key, g => g.ToList());

        // Associe os exercícios aos treinamentos
        foreach (var training in trainings)
        {
            if (exercisesByTrainingId.TryGetValue(training.Id, out var associatedExercises))
            {
                training.Exercises = associatedExercises;
            }
            else
            {
                // Se não houver exercícios associados, defina a lista como vazia
                training.Exercises = new List<ExerciseModel>();
            }
        }

        // Agora a lista de treinamentos contém os exercícios associados

        return trainings;
    }

    public TrainingModel GetById(int userId, int id)
    {
        TrainingModel training = _trainingRepository.GetById(userId, id);

        return training;
    }

    public void Create(int userId, TrainingRequestModel trainingRequestModel)
    {
        var trainingModel = new TrainingModel
        {
            TrainingTitle = trainingRequestModel.TrainingTitle,
            CreateDate = DateOnly.FromDateTime(DateTime.Now),
            IsActive = trainingRequestModel.IsActive,
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




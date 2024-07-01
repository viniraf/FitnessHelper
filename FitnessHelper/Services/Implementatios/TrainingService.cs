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

        var exercises = _trainingRepository.GetAllExercises();

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

        _trainingRepository.Update(trainingInDb);
    }
}




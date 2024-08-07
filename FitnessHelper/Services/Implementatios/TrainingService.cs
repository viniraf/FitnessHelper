﻿namespace FitnessHelper.Services.Implementatios;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;

    public TrainingService(ITrainingRepository trainingRepository)
    {
        _trainingRepository = trainingRepository;
    }

    public async Task<List<TrainingModel>> GetAllByStatusAsync(int userId, bool trainingIsActive, bool exerciseIsActive)
    {
        List<TrainingModel> trainings = await _trainingRepository.GetAllByStatusAsync(userId, trainingIsActive);

        if (trainings.Count == 0)
        {
            return new List<TrainingModel>();
        }

        List<ExerciseModel> exercises = await _trainingRepository.GetAllExercisesByStatusAsync(userId, exerciseIsActive);


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

    public async Task<TrainingModel> GetByIdAsync(int userId, int id)
    {
        TrainingModel training = await _trainingRepository.GetByIdAsync(userId, id);

        return training;
    }

    public async Task CreateAsync(int userId, TrainingRequestModel trainingRequestModel)
    {
        TrainingModel trainingModel = new TrainingModel
        {
            TrainingTitle = trainingRequestModel.TrainingTitle,
            CreateDate = DateOnly.FromDateTime(DateTime.Now),
            IsActive = true,
            UserId = userId,
        };

        await _trainingRepository.CreateAsync(trainingModel);
    }

    public async Task UpdateAsync(int userId, int id, TrainingUpdateRequestModel trainingUpdateRequestModel)
    {
        TrainingModel trainingInDb = await _trainingRepository.GetByIdAsync(userId, id);

        trainingInDb.TrainingTitle = trainingUpdateRequestModel.TrainingTitle;
        trainingInDb.IsActive = trainingUpdateRequestModel.IsActive;

        await _trainingRepository.UpdateAsync(trainingInDb);
    }
}
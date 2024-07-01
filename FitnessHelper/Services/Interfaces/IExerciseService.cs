using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IExerciseService
{
    public ExerciseModel GetById(int id);

    public void AddExercise(int trainingId, ExerciseRequestModel exerciseRequestModel);

    public void UpdateExercise(int id, ExerciseRequestModel exerciseRequestModel);
}

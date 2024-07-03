using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IExerciseService
{
    public ExerciseModel GetById(int userId, int id);

    public void AddExercise(int userId, ExerciseRequestModel exerciseRequestModel);

    public void UpdateExercise(int userId, int id, ExerciseRequestModel exerciseRequestModel);
}

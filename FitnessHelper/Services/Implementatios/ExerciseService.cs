namespace FitnessHelper.Services.Implementatios;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<ExerciseModel> GetByIdAsync(int userId, int id)
    {
        ExerciseModel exercise = await _exerciseRepository.GetByIdAsync(userId, id);

        return exercise;
    }

    public async Task AddExerciseAsync(int userId, ExerciseRequestModel exerciseRequestModel)
    {
        ExerciseModel exercise = new ExerciseModel();

        exercise.ExerciseTitle = exerciseRequestModel.ExerciseTitle;
        exercise.TrainingId = exerciseRequestModel.TrainingId;
        exercise.QtySets = exerciseRequestModel.QtySets;
        exercise.QtyReps = exerciseRequestModel.QtyReps;
        exercise.IsActive = true;
        exercise.UserId = userId;

        await _exerciseRepository.AddExerciseAsync(exercise);
    }

    public async Task UpdateExerciseAsync(int userId, int id, ExerciseUpdateRequestModel exerciseUpdateRequestModel)
    {
        ExerciseModel exercise = await _exerciseRepository.GetByIdAsync(userId, id);

        exercise.ExerciseTitle = exerciseUpdateRequestModel.ExerciseTitle;
        exercise.QtySets = exerciseUpdateRequestModel.QtySets;
        exercise.QtyReps = exerciseUpdateRequestModel.QtyReps;
        exercise.IsActive = exerciseUpdateRequestModel.IsActive;

        await _exerciseRepository.UpdateExerciseAsync(exercise);
    }
}
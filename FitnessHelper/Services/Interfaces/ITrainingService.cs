namespace FitnessHelper.Services.Interfaces;

public interface ITrainingService
{
    public Task<List<TrainingModel>> GetAllByStatusAsync(int userId, bool trainingIsActive, bool exericiseIsActive);

    public Task<TrainingModel> GetByIdAsync(int userId, int id);

    public Task CreateAsync(int userId, TrainingRequestModel trainingRequestModel);

    public Task UpdateAsync(int userId, int id, TrainingUpdateRequestModel trainingUpdateRequestModel);
}
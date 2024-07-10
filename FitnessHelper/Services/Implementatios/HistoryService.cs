namespace FitnessHelper.Services.Implementatios;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public async Task AddTrainingHistoryAsync(int userId, TrainingHistoryRequestModel trainingHistoryRequest)
    {
        TrainingHistoryModel trainingHistory = new TrainingHistoryModel();
        trainingHistory.Date = trainingHistoryRequest.Date;
        trainingHistory.TrainingId = trainingHistoryRequest.TrainingId;
        trainingHistory.UserId = userId;

        await _historyRepository.AddTrainingHistoryAsync(trainingHistory);
    }

    public async Task AddWeighingHistoryAsync(int userId, WeighingHistoryRequestModel weighingHistoryRequest)
    {
        WeighingHistoryModel weighingHistory = new WeighingHistoryModel();
        weighingHistory.Date = weighingHistoryRequest.Date;
        weighingHistory.Weight = weighingHistoryRequest.Weight;
        weighingHistory.UserId = userId;

        await _historyRepository.AddWeighingHistoryAsync(weighingHistory);
    }

    public async Task<List<TrainingHistoryModel>> GetTrainingHistoriesAsync(int userId)
    {
        List<TrainingHistoryModel> trainingHistories = await _historyRepository.GetTrainingHistoriesAsync(userId);

        if (trainingHistories.Count == 0)
        {
            return new List<TrainingHistoryModel>();
        }

        return trainingHistories;
    }

    public async Task<List<WeighingHistoryModel>> GetWeighingHistoriesAsync(int userId)
    {
        List<WeighingHistoryModel> weighingHistories = await _historyRepository.GetWeighingHistoriesAsync(userId);

        if (weighingHistories.Count > 0)
        {
            return new List<WeighingHistoryModel>();
        }

        return weighingHistories;
    }
}
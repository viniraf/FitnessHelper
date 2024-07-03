using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using FitnessHelper.Services.Interfaces;

namespace FitnessHelper.Services.Implementatios;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public void AddTrainingHistory(int userId, TrainingHistoryRequestModel trainingHistoryRequest)
    {
        TrainingHistoryModel trainingHistory = new TrainingHistoryModel();
        trainingHistory.Date = trainingHistoryRequest.Date;
        trainingHistory.TrainingId = trainingHistoryRequest.TrainingId;
        trainingHistory.UserId = userId;

        _historyRepository.AddTrainingHistory(trainingHistory);
    }

    public void AddWeighingHistory(int userId, WeighingHistoryRequestModel weighingHistoryRequest)
    {
        WeighingHistoryModel weighingHistory = new WeighingHistoryModel();
        weighingHistory.Date = weighingHistoryRequest.Date;
        weighingHistory.Weight = weighingHistoryRequest.Weight;
        weighingHistory.UserId = userId;
        _historyRepository.AddWeighingHistory(weighingHistory);
    }

    public List<TrainingHistoryModel> GetTrainingHistories(int userId)
    {
        List<TrainingHistoryModel> trainingHistories = _historyRepository.GetTrainingHistories(userId);

        if (trainingHistories.Count == 0)
        {
            return new List<TrainingHistoryModel>();
        }

        return trainingHistories;
    }

    public List<WeighingHistoryModel> GetWeighingHistories(int userId)
    {
        List<WeighingHistoryModel> weighingHistories = _historyRepository.GetWeighingHistories(userId);

        if (weighingHistories.Count > 0)
        {
            return new List<WeighingHistoryModel>();
        }

        return weighingHistories;
    }
}

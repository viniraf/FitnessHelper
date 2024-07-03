using FitnessHelper.Data;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;

namespace FitnessHelper.Repositories.Implementations;

public class HistoryRepository : IHistoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public HistoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void AddTrainingHistory(TrainingHistoryModel trainingHistory)
    {
        _applicationDbContext.TrainingHistories.Add(trainingHistory);
        _applicationDbContext.SaveChanges();
    }

    public void AddWeighingHistory(WeighingHistoryModel weighingHistory)
    {
        _applicationDbContext.WeighingHistories.Add(weighingHistory);
        _applicationDbContext.SaveChanges();
    }

    public List<TrainingHistoryModel> GetTrainingHistories(int userId)
    {
        List<TrainingHistoryModel> trainingHistories = _applicationDbContext.TrainingHistories.Where(th =>  th.UserId == userId).ToList();

        return trainingHistories;
    }

    public List<WeighingHistoryModel> GetWeighingHistories(int userId)
    {
        List<WeighingHistoryModel> weighingHistories = _applicationDbContext.WeighingHistories.Where(wh =>  wh.UserId == userId).ToList();

        return weighingHistories;
    }
}

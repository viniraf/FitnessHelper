using FitnessHelper.Data;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FitnessHelper.Repositories.Implementations;

public class HistoryRepository : IHistoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public HistoryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task AddTrainingHistoryAsync(TrainingHistoryModel trainingHistory)
    {
        await _applicationDbContext.TrainingHistories.AddAsync(trainingHistory);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task AddWeighingHistoryAsync(WeighingHistoryModel weighingHistory)
    {
        await _applicationDbContext.WeighingHistories.AddAsync(weighingHistory);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<List<TrainingHistoryModel>> GetTrainingHistoriesAsync(int userId)
    {
        List<TrainingHistoryModel> trainingHistories = await _applicationDbContext.TrainingHistories
            .Where(th => th.UserId == userId)
            .Include(th => th.Training)
            .Select(th => new TrainingHistoryModel
            {
                Id = th.Id,
                Date = th.Date,
                TrainingId = th.TrainingId,
                UserId = th.UserId,
                TrainingName = th.Training.TrainingTitle
            })
            .ToListAsync();

        return trainingHistories;
    }

    public async Task<List<WeighingHistoryModel>> GetWeighingHistoriesAsync(int userId)
    {
        List<WeighingHistoryModel> weighingHistories = await _applicationDbContext.WeighingHistories
            .Where(wh =>  wh.UserId == userId)
            .ToListAsync();

        return weighingHistories;
    }
}

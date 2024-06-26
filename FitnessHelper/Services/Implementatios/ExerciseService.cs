﻿using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using FitnessHelper.Services.Interfaces;

namespace FitnessHelper.Services.Implementatios;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public ExerciseModel GetById(int id)
    {
        var exercise = _exerciseRepository.GetById(id);

        return exercise;
    }

    public void AddExercise(int trainingId, ExerciseRequestModel exerciseRequestModel)
    {
        var exercise = new ExerciseModel();
        exercise.Exercise = exerciseRequestModel.Exercise;
        exercise.TrainingId = trainingId;
        exercise.QtySets = exerciseRequestModel.QtySets;
        exercise.QtyReps = exerciseRequestModel.QtyReps;
        exercise.IsActive = true;

        _exerciseRepository.AddExercise(exercise);
    }

    public void UpdateExercise(int id, ExerciseRequestModel exerciseRequestModel)
    {
        var exercise = _exerciseRepository.GetById(id);

        exercise.Exercise = exerciseRequestModel.Exercise;
        exercise.QtySets = exerciseRequestModel.QtySets;
        exercise.QtyReps = exerciseRequestModel.QtyReps;
        exercise.IsActive = exerciseRequestModel.IsActive;

        _exerciseRepository.UpdateExercise(exercise);
    }
}

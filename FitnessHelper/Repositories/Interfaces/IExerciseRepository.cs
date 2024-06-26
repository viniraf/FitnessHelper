﻿using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface IExerciseRepository
{
    public ExerciseModel GetById(int id);

    public void AddExercise(ExerciseModel exerciseModel);

    public void UpdateExercise(ExerciseModel exerciseModel);
}

﻿namespace FitnessHelper.Models.Food;

public class FoodModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string UnitOfMeasurement { get; set; } = string.Empty;

    public double Qty { get; set; }

    public double QtyProt { get; set; }

    public double QtyCarb { get; set; }

    public double QtyFat { get; set; }

    public double QtyCal { get; set; }

    public FoodModel()
    {
        
    }
}

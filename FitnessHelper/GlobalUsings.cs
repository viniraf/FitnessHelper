global using System.ComponentModel.DataAnnotations.Schema;
global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using System.Text.Json.Serialization;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;

global using DotNetEnv;
global using Swashbuckle.AspNetCore.Annotations;
global using Swashbuckle.AspNetCore.SwaggerUI;
global using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

global using FitnessHelper.Data;
global using FitnessHelper.Dictionaries;
global using FitnessHelper.Enums;
global using FitnessHelper.Helpers.Implementations;
global using FitnessHelper.Helpers.Interfaces;
global using FitnessHelper.Models.Exercise;
global using FitnessHelper.Models.MacronutrientCalculation;
global using FitnessHelper.Models.TrainingHistory;
global using FitnessHelper.Models.Training;
global using FitnessHelper.Models.User;
global using FitnessHelper.Models.WeighingHistory;
global using FitnessHelper.Repositories.Implementations;
global using FitnessHelper.Repositories.Interfaces;
global using FitnessHelper.Services.Implementatios;
global using FitnessHelper.Services.Interfaces;
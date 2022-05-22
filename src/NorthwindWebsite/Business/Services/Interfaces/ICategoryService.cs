﻿using NorthwindWebsite.Infrastructure.Entities;

namespace NorthwindWebsite.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAll();
}
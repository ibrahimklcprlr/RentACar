using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services.Repositories;

public interface IModelRepository : IAsyncRepository<Model, Guid>, IRepository<Model, Guid>
{
}


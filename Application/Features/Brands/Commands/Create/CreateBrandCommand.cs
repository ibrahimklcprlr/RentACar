﻿using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand:IRequest<CreatedBrandResponse>,ITransactionalRequest,ICacheRemoverRequest,ILoggerRequest
{
    public string Name { get; set; }

    public string CacheKey => $"";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetBrands";


    public class CreateBrandHandle : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {

        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBussinessRules _brandBussinessRules;

        public CreateBrandHandle(IBrandRepository brandRepository, IMapper mapper, BrandBussinessRules brandBussinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBussinessRules = brandBussinessRules;
        }

        public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBussinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);
            Brand brand = _mapper.Map<Brand>(request);
            brand.Id = Guid.NewGuid();
            await _brandRepository.AddAsync(brand);
            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(brand);             return createdBrandResponse;
        }
    }
}


﻿using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBussinessRules:BaseBusinessRules
    {
        private IBrandRepository _brandRepository;

        public BrandBussinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            Brand? result = await _brandRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
            if (result!=null)
            {
                throw new BusinessException(BrandsMessages.BrandNameExist);
            }
        }
    }
}

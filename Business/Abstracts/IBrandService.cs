﻿using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBrandService
    {
        CreatedBrandResponse Add(CreateBrandRequest createBrandRequest);
        List<GetAllBrandsResponse> GetAll();
        GetBrandResponse GetById(int id);
        string Delete(int id);
    }
}

// responses and requests

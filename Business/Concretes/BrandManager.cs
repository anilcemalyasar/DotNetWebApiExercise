using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BrandManager:IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
        {
            // mapping request dto to database entity
            Brand brand = new Brand();
            brand.Name = createBrandRequest.Name;
            brand.CreatedDate = DateTime.Now;
            brand.Id = 4;
            
            _brandDal.Add(brand);

            // mapping database entity to response dto
            CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
            createdBrandResponse.Name = createBrandRequest.Name;
            createdBrandResponse.Id = brand.Id;
            createdBrandResponse.CreatedDate = brand.CreatedDate;

            return createdBrandResponse;
        }

        public string Delete(int id)
        {
            string res = _brandDal.Delete(id);
            if (res is null)
            {
                return null;
            }
            return res;
        }

        public List<GetAllBrandsResponse> GetAll()
        {
            // all these brands are database entities
            List<Brand> brands = _brandDal.GetAll();
            
            // thats why we should map them to response DTO
            List<GetAllBrandsResponse> getAllBrandsResponses = new List<GetAllBrandsResponse>();
            foreach (var brand in brands)
            {
                GetAllBrandsResponse getAllBrandsResponse = new GetAllBrandsResponse();
                getAllBrandsResponse.Id = brand.Id;
                getAllBrandsResponse.Name = brand.Name;
                getAllBrandsResponse.CreatedDate = brand.CreatedDate;

                getAllBrandsResponses.Add(getAllBrandsResponse);
            }

            // return Response DTO
            return getAllBrandsResponses;
        }

        public GetBrandResponse GetById(int id)
        {
            // get database entity from data access layer
            Brand brand = _brandDal.GetById(id);
            if (brand is null)
            {
                return null;
            }

            // map db entity to response dto
            GetBrandResponse getBrandResponse = new GetBrandResponse()
            {
                Id = brand.Id,
                Name = brand.Name,
                CreatedDate = brand.CreatedDate,
            };

            // return response dto with limited informations
            return getBrandResponse;
        }

    }
}

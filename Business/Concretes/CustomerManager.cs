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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public CreatedCustomerResponse Add(CreateCustomerRequest createCustomerRequest)
        {
            // mapping request dto to database entity
            Customer customer = new Customer();
            customer.Id = 4;
            customer.CreatedDate = DateTime.Now;
            customer.FirstName = createCustomerRequest.FirstName;
            customer.LastName = createCustomerRequest.LastName;
            customer.City = createCustomerRequest.City;

            // save database entity to database
            _customerDal.Add(customer);

            // map db entity to response dto and then return it
            CreatedCustomerResponse createdCustomerResponse = new CreatedCustomerResponse
            {
                Id = customer.Id,
                CreatedDate = customer.CreatedDate,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                City = customer.City,
            };

            return createdCustomerResponse;

        }

        public List<GetAllCustomerResponse> GetAll()
        {
            // all these customers are database entities
            List<Customer> customers = _customerDal.GetAll();

            // thats why we should map them to response DTO
            List<GetAllCustomerResponse> getAllCustomerResponses = new List<GetAllCustomerResponse>();
            foreach (var customer in customers)
            {
                GetAllCustomerResponse getAllCustomerResponse = new GetAllCustomerResponse()
                {
                    Id = customer.Id,
                    CreatedDate = customer.CreatedDate,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    City = customer.City,
                };
                getAllCustomerResponses.Add(getAllCustomerResponse);
            }

            // return from db entity mapped response dto
            return getAllCustomerResponses;
        }
    }
}

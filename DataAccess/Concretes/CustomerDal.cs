using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class CustomerDal:ICustomerDal
    {
        List<Customer> _customers;

        public CustomerDal()
        {
            _customers = new List<Customer>();
            Customer customer1 = new Customer()
            {
                Id = 1,
                CreatedDate = DateTime.Now,
                FirstName = "Anıl",
                LastName = "Yaşar",
                City = "Istanbul"
            };

            Customer customer2 = new Customer()
            {
                Id = 2,
                CreatedDate = DateTime.Now,
                FirstName = "Ece",
                LastName = "Loş",
                City = "İzmir"
            };

            Customer customer3 = new Customer()
            {
                Id = 3,
                CreatedDate = DateTime.Now,
                FirstName = "Sumru",
                LastName = "Yaşar",
                City = "İstanbul"
            };


            _customers.Add(customer1);
            _customers.Add(customer2);
            _customers.Add(customer3);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public string Delete(int id)
        {
            Customer customer = _customers.Where(c => c.Id == id).FirstOrDefault();
            if (customer == null)
            {
                return null;
            }
            _customers.Remove(customer);
            return $"Customer with Id:{id} Successfully Deleted!";
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(int id)
        {
            // LINQ methods
            return _customers.Where(c => c.Id  == id).FirstOrDefault();
        }
    }
}

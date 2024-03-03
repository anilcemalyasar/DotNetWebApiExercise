using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICustomerDal
    {
        void Add(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        string Delete(int id);
    }
}

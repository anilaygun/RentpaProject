using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _custmerDal;

        public CustomerManager(ICustomerDal custmerDal)
        {
            _custmerDal = custmerDal;
        }




        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CheckIfCompanyNameExists(customer.CompanyName));
            if (result != null)
            {
                return result;
            }
            _custmerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.Id != null)
            {
                _custmerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);

            }
            else
            {
                return new ErrorResult(Messages.CustomerIdInvalid);
            }
        }
        public IResult Update(Customer customer)
        {
            if (customer.Id != null)
            {
                _custmerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CustomerIdInvalid);
            }
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_custmerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_custmerDal.Get(c => c.Id == customerId));
        }

        private IResult CheckIfCompanyNameExists(string companyName)
        {
            var result = _custmerDal.GetAll(cu => cu.CompanyName == companyName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CompanyNameExists);
            }
            return new SuccessResult();
        }

    }
}

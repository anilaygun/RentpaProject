using Business.Abstract;
using Business.Constants;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length > 2)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            else
            {
                return new ErrorResult(Messages.UserAddException);
            }
        }

        public IResult Delete(User user)
        {
            if (user.Id != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);

            }
            else
            {
                return new ErrorResult(Messages.UserIdInvalid);
            }
        }
        public IResult Update(User user)
        {
            if (user.Id != null)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            else
            {
                return new ErrorResult(Messages.UserIdInvalid);
            }
        }
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }

    }
}

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length > 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            else
            {
                return new ErrorResult(Messages.ColorAddException);
            }
        }

        public IResult Delete(Color color)
        {
            if (color.Id != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);

            }
            else
            {
                return new ErrorResult(Messages.ColorIdInvalid);
            }
        }
        public IResult Update(Color color)
        {
            if (color.Id != null)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            else
            {
                return new ErrorResult(Messages.ColorIdInvalid);
            }
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

    }
}

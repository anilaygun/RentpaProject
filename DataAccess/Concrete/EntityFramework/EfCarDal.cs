using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentpaContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentpaContext context = new RentpaContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();

            }

        }
    }
}

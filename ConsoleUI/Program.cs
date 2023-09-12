using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


CarManager carManager = new CarManager(new EfCarDal(new RentpaContext()));

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}
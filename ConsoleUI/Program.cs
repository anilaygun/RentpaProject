using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
Console.WriteLine("----------*_TEST ZONE_*----------\n");

//CarTest();
//BrandTest();
//ColorTest();
//UserAddTest();
//CustomerTest();

//RentalTest();

static void CarTest()
{
    Console.WriteLine("----------*_CARS_*----------");
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetails();
    if (result.Success)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine("ID:{0}, {1} / {2} / {3} / {4}", car.CarId, car.BrandName, car.ColorName, car.ModelYear.Year, car.Description);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }


}

static void BrandTest()
{
    Console.WriteLine("----------*_BRANDS_*----------");
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll().Data)
    {
        Console.WriteLine(brand.Name);
    }
}
static void ColorTest()
{
    Console.WriteLine("----------*_COLORS_*----------");
    ColorManager colorManager = new ColorManager(new EfColorDal());
    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.Name);
    }
}

static void UserAddTest()
{
    Console.WriteLine("----------*_USERS_*----------");
    UserManager userManager = new UserManager(new EfUserDal());
    userManager.Add(new User { FirstName = ".", LastName = ".", Email = "corenil@dev.com", Password = "Testparola" });
    foreach (var user in userManager.GetAll().Data)
    {
        Console.WriteLine("\"ID:{0}, {1} / {2} ", user.Id, user.FirstName, user.LastName);
    }
}

static void CustomerTest()
{
    Console.WriteLine("----------*_CUSTOMER_*----------");
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    customerManager.Add(new Customer { CompanyName = "DABDUD" });
    foreach (var customer in customerManager.GetAll().Data)
    {
        Console.WriteLine("\"ID:{0}, {1}", customer.Id, customer.CompanyName);
    }
}

static void RentalTest()
{
    Console.WriteLine("----------*_RENTALS_*----------");
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    foreach (var rentDetail in rentalManager.GetRentalDetails().Data)
    {
        Console.WriteLine("ID:{0}, {1} / {2} / {3} - {4}", rentDetail.RentId, rentDetail.CarName, rentDetail.CompanyName, rentDetail.RentDate, rentDetail.ReturnDate);
    }

    //var addResult = rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = DateTime.Today, ReturnDate = new DateTime(2023, 9, 20) });
    //if (addResult.Success)
    //{
    //    foreach (var rental in rentalManager.GetAll().Data)
    //    {
    //        Console.WriteLine("ID:{0}, {1} / {2} / {3} / {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);

    //    }
    //}
    //else
    //{
    //    Console.WriteLine(addResult.Message);
    //}
}
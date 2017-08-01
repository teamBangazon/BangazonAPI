using System;
using System.Linq;
using BangazonAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BangazonAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonAPIContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonAPIContext>>()))
            {
                if(context.Customer.Any())
                {
                    return;
                }

                var customers = new Customer[]
                {
                    new Customer {
                        FirstName = "Tim",
                        LastName = "Handle"
                    },
                    new Customer {
                        FirstName = "Mitch",
                        LastName = "Delant"
                    },
                    new Customer {
                        FirstName = "Kim",
                        LastName = "Strong"
                    },
                };

                foreach (Customer i in customers)
                {
                    context.Customer.Add(i);
                }
                context.SaveChanges();

                // var producttypes = new ProductType[]
                // {
                //     new ProductType {
                //         Type = "Household Goods"
                //     },
                //     new ProductType {
                //         Type = "Electronics"
                //     },
                //     new ProductType {
                //         Type = "Musical Instruments"
                //     },
                // };

                // foreach (ProductType i in producttypes)
                // {
                //     context.ProductType.Add(i);
                // }
                // context.SaveChanges();

                // var products = new Product[]
                // {
                //     new Product {
                //         ProductTypeId = producttypes.Single(s => s.Type == "Electronics").ProductTypeId,
                //         Title = "Time Machine",
                //         Price = 800,
                //         Description = "Trust me, it works. Really, it does!",
                //         CustomerId = customers.Single(s => s.FirstName == "Tim").CustomerId,
                //     },
                //     new Product {
                //         ProductTypeId = producttypes.Single(s => s.Type == "Household Goods").ProductTypeId,
                //         Title = "Couch",
                //         Price = 125,
                //         Description = "Good couch, small rip on left side.",
                //         CustomerId = customers.Single(s => s.FirstName == "Mitch").CustomerId,
                //     },
                //     new Product {
                //         ProductTypeId = producttypes.Single(s => s.Type == "Musical Instruments").ProductTypeId,
                //         Title = "Acordian",
                //         Price = 2000,
                //         Description = "No clue why I have this, please take it off my hands!",
                //         CustomerId = customers.Single(s => s.FirstName == "Kim").CustomerId,
                //     }
                // };

                // foreach (Product i in products)
                // {
                //     context.Product.Add(i);
                // }
                // context.SaveChanges();

                var orders = new Order[]
                {
                    new Order {
                        CustomerId = customers.Single(s => s.FirstName == "Mitch").CustomerId
                    },
                    new Order {
                        CustomerId = customers.Single(s => s.FirstName == "Kim").CustomerId
                    },
                    new Order {
                        CustomerId = customers.Single(s => s.FirstName == "Tim").CustomerId
                    },
                };

                foreach (Order i in orders)
                {
                    context.Order.Add(i);
                }
                context.SaveChanges();

                var paymenttypes = new PaymentType[]
                {
                    new PaymentType {
                        Type = "Visa",
                        CustomerId = customers.Single(s => s.FirstName == "Tim").CustomerId
                    },
                    new PaymentType {
                        Type = "MasterCard",
                        CustomerId = customers.Single(s => s.FirstName == "Kim").CustomerId
                    },
                    new PaymentType {
                        Type = "American Express",
                        CustomerId = customers.Single(s => s.FirstName == "Mitch").CustomerId
                    },
                };

                foreach (PaymentType i in paymenttypes)
                {
                    context.PaymentType.Add(i);
                }
                context.SaveChanges();

                var computers = new Computer[]
                {
                    new Computer {
                        PurchasedDate = DateTime.Parse("2017-01-02")
                    },
                    new Computer {
                        PurchasedDate = DateTime.Parse("2016-01-02")
                    },
                    new Computer {
                        PurchasedDate = DateTime.Parse("2018-01-02")
                    },
                };

                foreach (Computer i in computers)
                {
                    context.Computer.Add(i);
                }
                context.SaveChanges();

                var departments = new Department[]
                {
                    new Department {
                        Name = "Customer Service",
                        ExpenseBudget = 6500
                    },
                    new Department {
                        Name = "Human Relations",
                        ExpenseBudget = 6500
                    },
                    new Department {
                        Name = "Moderators",
                        ExpenseBudget = 6500    
                    },
                };

                foreach (Department i in departments)
                {
                    context.Department.Add(i);
                }
                context.SaveChanges();

                var employees = new Employee[]
                {
                    new Employee {
                        FirstName = "Green",
                        LastName = "Thumb",
                        DepartmentId = departments.Single(s => s.Name == "Customer Service").DepartmentId
                    },
                    new Employee {
                        FirstName = "Blue",
                        LastName = "Duck",
                        DepartmentId = departments.Single(s => s.Name == "Human Relations").DepartmentId
                    },
                    new Employee {
                        FirstName = "Red",
                        LastName = "Herring",
                        DepartmentId = departments.Single(s => s.Name == "Moderators").DepartmentId,
                        Supervisor = true
                    },
                };

                foreach (Employee i in employees)
                {
                    context.Employee.Add(i);
                }
                context.SaveChanges();

                var trainingprograms = new TrainingProgram[]
                {
                    new TrainingProgram {
                        StartDate = DateTime.Parse("2017-01-02"),
                        EndDate = DateTime.Parse("2017-02-01"),
                        MaxAttendees = 15
                    },
                    new TrainingProgram {
                        StartDate = DateTime.Parse("2016-01-02"),
                        EndDate = DateTime.Parse("2016-02-01"),
                        MaxAttendees = 20
                    },
                    new TrainingProgram {
                        StartDate = DateTime.Parse("2018-01-02"),
                        EndDate = DateTime.Parse("2018-02-01"),
                        MaxAttendees = 30
                    },
                };

                foreach (TrainingProgram i in trainingprograms)
                {
                    context.TrainingProgram.Add(i);
                }
                context.SaveChanges();

            }
        }
    }
}
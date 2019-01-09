using Lcma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcma.DAL.Context
{
    public class Seeder : CreateDatabaseIfNotExists<MyAppContext>
    {
        protected override void Seed(MyAppContext context)
        {
            context.Employees.Add(new Employee
            {
                FirstName = "Ярослава",
                LastName = "Ермишина",
                MiddleName = "Филипповна",
                Email = "ermishina@mail.com"
            });
            context.Employees.Add(new Employee
            {
                FirstName = "Владилен",
                LastName = "Пашин",
                MiddleName = "Елизарович",
                Email = "pashin@mail.com"
            });
            context.Employees.Add(new Employee
            {
                FirstName = "Артем",
                LastName = "Яманов",
                MiddleName = "Прохорович ",
                Email = "yamanov@mail.com"
            });
            context.Employees.Add(new Employee
            {
                FirstName = "Оксана",
                LastName = "Лютова",
                MiddleName = "Родионовна",
                Email = "lutova@mail.com"
            });
            context.Employees.Add(new Employee
            {
                FirstName = "Адам",
                LastName = "Абабков",
                MiddleName = "Назарович",
                Email = "ababkov@mail.com"
            });

            context.SaveChanges();

            context.Projects.Add(new Project
            {
                Title = "Постройка многоэтажного дома",
                Customer = "Люди",
                Performer = "МногоЭтажДомСтрой",
                Priority = 3,
                Comment = "Построить",
                DateStart = DateTime.Today.AddYears(-1),
                DateEnd = DateTime.Today.AddYears(2),
                CreatedAt = DateTime.Today,
                UpdatedAt = DateTime.Today,
                ManagerId = context.Employees.First().Id
            });
            context.Projects.Add(new Project
            {
                Title = "Недельный субботник",
                Customer = "Домком",
                Performer = "Жильцы",
                Priority = 8,
                Comment = "Убраться на территории",
                DateStart = DateTime.Today.AddDays(-3),
                DateEnd = DateTime.Today.AddDays(4),
                CreatedAt = DateTime.Today.AddDays(-1),
                UpdatedAt = DateTime.Today.AddDays(-1),
                ManagerId = null
            });
            context.Projects.Add(new Project
            {
                Title = "Ремонт авто",
                Customer = "Клиент",
                Performer = "СТО",
                Priority = 5,
                Comment = "В кратчайшие сроки",
                DateStart = DateTime.Today.AddDays(1),
                DateEnd = DateTime.Today.AddDays(2),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ManagerId = context.Employees.ToList().Last().Id
            });

            context.SaveChanges();
        }
    }
}

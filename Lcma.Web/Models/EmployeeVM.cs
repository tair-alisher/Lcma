﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lcma.Web.Models
{
    public class EmployeeVM : VMBase
    {
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Почта")]
        public string Email { get; set; }

        public ICollection<ProjectVM> Projects { get; set; }

        public string FullName
        {
            get => $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
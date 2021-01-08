﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDatabase.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required] public string Fio { get; set; }

        public DateTime? VacationStart { get; set; }

        [Required] public Position Position { get; set; }
    }
}
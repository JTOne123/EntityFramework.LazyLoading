﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.EntityFrameworkCore.LazyLoading.Sample.Models
{
    public class Instructor : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        private LazyReference<OfficeAssignment> _officeAssignmentLazy = new LazyReference<OfficeAssignment>();
        public OfficeAssignment OfficeAssignment
        {
            get
            {
                return _officeAssignmentLazy.GetValue(this);
            }
            set
            {
                _officeAssignmentLazy.SetValue(value);
            }
        }
    }
}

﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Integratieproject1.BL.Models.Datatypes;
using Integratieproject1.BL.Models.Users;

namespace Integratieproject1.BL.Models.Projects
{
    public class Platform
    {
      [Key]
        public int PlatformId { get; set; }
    [Required]
        public string PlatformName { get; set; }
        public string Logo { get; set; }
        public Address Address { get; set; }
        public string Phonenumber { get; set; }
        public string Description { get; set; }
    
        public ICollection<Project> Projects { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

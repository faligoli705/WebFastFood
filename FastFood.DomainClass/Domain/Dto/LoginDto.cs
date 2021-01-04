using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DomainClass.Domain.Dto
{
  public  class LoginDto
    {
        public string FName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public int PasswordCustomer { get; set; }
    }
}

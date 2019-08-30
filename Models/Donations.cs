using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodAppleProj.Models {
    public class Donation {
        [Key]
        public int DonationId {get;set;}

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Amount {get;set;}

        [Required]
        public int ProjectId {get;set;}
        public Project Project {get;set;}

        [Required]
        public int DonorId {get;set;}
        public User Donor {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}
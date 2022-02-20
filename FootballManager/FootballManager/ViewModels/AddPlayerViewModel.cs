using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.ViewModels
{
    public class AddPlayerViewModel
    {
             
        [StringLength(80, MinimumLength = 5)]
        public string FullName { get; set; }

        public string ImageUrl { get; set; }
     
        [StringLength(20, MinimumLength = 5)]
        public string Position { get; set; }

        
        [Range(0, 10)]
        public byte Speed { get; set; }
       
        [Range(0, 10)]
        public byte Endurance { get; set; }
        
        [StringLength(200)]
        public string Description { get; set; }

    }
}
using FootballManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service.DTOs.Footballer
{
    public class UpdateFootballerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manager Manager{ get; set; }
    }
}

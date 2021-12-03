using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get { return CreateDate; } set { CreateDate = DateTime.Now; } }
        public DateTime UpdateDate { get; set; }
    }
}

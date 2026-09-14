using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPage.frameworks.Data.Entity
{
    public interface IEntity
    {
         long Id { get; set; }
         DateTime? CreatedDate { get; set; }
         DateTime? EditedDate { get; set; }
    }
}

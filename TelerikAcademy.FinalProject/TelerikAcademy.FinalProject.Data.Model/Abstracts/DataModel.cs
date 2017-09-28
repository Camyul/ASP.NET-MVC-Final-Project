using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelerikAcademy.FinalProject.Data.Model.Contracts;

namespace TelerikAcademy.FinalProject.Data.Model.Abstracts
{
    public abstract class DataModel : IDeletable
    {
        public DataModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }

    }
}

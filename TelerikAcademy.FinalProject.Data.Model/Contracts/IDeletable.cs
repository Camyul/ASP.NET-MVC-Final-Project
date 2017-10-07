using System;

namespace TelerikAcademy.FinalProject.Data.Model.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}

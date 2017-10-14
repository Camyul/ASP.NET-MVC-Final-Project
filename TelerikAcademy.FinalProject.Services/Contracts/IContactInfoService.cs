using System;
using TelerikAcademy.FinalProject.Data.Model;

namespace TelerikAcademy.FinalProject.Services.Contracts
{
    public interface IContactInfoService
    {
        ContactInfo GetById(Guid? id);

        // ContactInfo GetByName(string name);

        Guid Update(ContactInfo contactInfo);

        // Guid Delete(Guid? id);

        Guid Create(ContactInfo contactInfo);
    }
}

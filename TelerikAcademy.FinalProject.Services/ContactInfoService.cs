using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using TelerikAcademy.FinalProject.Data.Model;
using TelerikAcademy.FinalProject.Data.Repositories;
using TelerikAcademy.FinalProject.Data.SaveContext;
using TelerikAcademy.FinalProject.Services.Contracts;

namespace TelerikAcademy.FinalProject.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly ISaveContext context;
        private readonly IEfRepository<ContactInfo> contactInfoRepo;

        public ContactInfoService(IEfRepository<ContactInfo> contactInfoRepo, ISaveContext context)
        {
            Guard.WhenArgument(contactInfoRepo, "contactInfoRepo").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.contactInfoRepo = contactInfoRepo;
            this.context = context;
        }

        public IEnumerable<ContactInfo> GetAll()
        {
            return this.contactInfoRepo
                .All
                .Where(c => c.IsDeleted == false)
                .ToList();
        }

        public ContactInfo GetById(Guid? id)
        {
            return id.HasValue ? this.contactInfoRepo.GetById(id) : null;
        }

        public Guid Create(ContactInfo contactInfo)
        {
            this.contactInfoRepo.Add(contactInfo);
            this.context.Commit();

            return contactInfo.Id.Value;
        }

        public Guid Update(ContactInfo contactInfo)
        {

            ContactInfo ContactInfoToUpdate = this.contactInfoRepo.GetById(contactInfo.Id.Value);
            this.contactInfoRepo.Update(ContactInfoToUpdate);

            this.context.Commit();

            return contactInfo.Id.Value;
        }
    }
}

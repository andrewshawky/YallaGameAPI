using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Models.Repositories
{
    public class InvitationRepository : IModelRepositery<Invitation>
    {
        private readonly yallagameContext context;

        public InvitationRepository(yallagameContext context)
        {
            this.context = context;
        }
        public void Delete(int InvitationId)
        {
            Invitation invitation = context.Invitation.Find(InvitationId);
            context.Invitation.Remove(invitation);
        }

        public List<Invitation> getAll()
        {
            return context.Invitation.ToList();
        }

        public Invitation getById(int InvitationId)
        {
            return context.Invitation/*.Include(m=>m.Packages)*/.FirstOrDefault(t => t.InvitationId == InvitationId);
        }

        public void Insert(Invitation invitation)
        {
            context.Invitation.Add(invitation);
        }

        public bool ItemExists(int InvitationId)
        {
            return context.Invitation.Count(e => e.InvitationId == InvitationId) > 0;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Invitation item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}

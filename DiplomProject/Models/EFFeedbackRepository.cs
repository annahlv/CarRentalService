using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomProject.Models
{
    public class EFFeedbackRepository : IFeedbackRepository
    {
        private ApplicationDbContext context;

        public EFFeedbackRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Feedback> Feedback => context.Feedback;
        public void SaveFeedback(Feedback feedback)
        {
            if (feedback.Id == 0)
            {
                context.Feedback.Add(feedback);
            }
            else
            {
                Feedback dbEntry = context.Feedback
                    .FirstOrDefault(p => p.Id == feedback.Id);
                if (dbEntry != null)
                {
                    dbEntry.Email = feedback.Email;
                    dbEntry.Text = feedback.Text;
                }

            }
            context.SaveChanges();
        }

        public Feedback DeleteFeedback(int id)
        {
            Feedback dbEntry = context.Feedback
                .FirstOrDefault(p => p.Id == id);
            if (dbEntry != null)
            {
                context.Feedback.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        }
}

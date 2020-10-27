using System.Linq;

namespace DiplomProject.Models
{

    public interface IFeedbackRepository
    {
        IQueryable<Feedback> Feedback { get; }
        void SaveFeedback(Feedback feedback);
        Feedback DeleteFeedback(int id);
    }
}

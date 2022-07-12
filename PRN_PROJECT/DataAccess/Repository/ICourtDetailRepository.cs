using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICourtDetailRepository
    {
        void AddSlot(CourtDetail cd);
        void DeleteSlot(CourtDetail cd);
        void UpdateSlot(CourtDetail cd);
        List<CourtDetail> GetCourtDetails();
        CourtDetail GetSlotByCourtId(int id);
        List<CourtDetail> GetAvailableSlot(int id);
        CourtDetail GetCourtDetailByCourtDetailsID(int id);
    }
}

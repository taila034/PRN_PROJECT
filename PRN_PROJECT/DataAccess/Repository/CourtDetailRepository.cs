using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourtDetailRepository : ICourtDetailRepository
    {
        public void DeleteSlot(CourtDetail cd) => CourtDetailDAO.DeleteSlot(cd);
        public void AddSlot(CourtDetail cd) => CourtDetailDAO.AddSlot(cd);
        public void UpdateSlot(CourtDetail cd) => CourtDetailDAO.UpdateSlot(cd);
        public List<CourtDetail> GetCourtDetails() => CourtDetailDAO.GetCourtDetails();
        public CourtDetail GetSlotByCourtId(int id) => CourtDetailDAO.GetCourtDetailByCourtId(id);
    }
}

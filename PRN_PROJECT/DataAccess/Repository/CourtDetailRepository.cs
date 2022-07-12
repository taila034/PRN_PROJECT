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
        public void DeleteSlot(CourtDetail cd) => CourtDetailDAO.Instance.DeleteSlot(cd);
        public void AddSlot(CourtDetail cd) => CourtDetailDAO.Instance.AddSlot(cd);
        public void UpdateSlot(CourtDetail cd) => CourtDetailDAO.Instance.UpdateSlot(cd);
        public List<CourtDetail> GetCourtDetails() => CourtDetailDAO.Instance.GetCourtDetails();
        public CourtDetail GetSlotByCourtId(int id) => CourtDetailDAO.Instance.GetCourtDetailByCourtDetailId(id);
        public List<CourtDetail> GetAvailableSlot(int id) => CourtDetailDAO.Instance.GetAvailableSlot(id);
        public CourtDetail GetCourtDetailByCourtDetailsID(int id) => CourtDetailDAO.Instance.GetCourtDetailByCourtDetailId(id);

    }
}

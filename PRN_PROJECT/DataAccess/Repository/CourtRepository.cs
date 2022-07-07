using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CourtRepository : ICourtRepository
    {
        public void DeleteCourt(Court court) => CourtDAO.DeleteCourt(court);
        public void AddCourt(Court court) => CourtDAO.AddCourt(court);
        public void UpdateCourt(Court court) => CourtDAO.UpdateCourt(court);
        public List<Court> GetCourts() => CourtDAO.GetCourts();
        public Court GetCourtById(int id) => CourtDAO.GetCourtById(id);
    }
}

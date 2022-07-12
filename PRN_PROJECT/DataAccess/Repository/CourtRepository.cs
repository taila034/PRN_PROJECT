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
        public void DeleteCourt(Court court) => CourtDAO.Instance.DeleteCourt(court);
        public void AddCourt(Court court) => CourtDAO.Instance.AddCourt(court);
        public void UpdateCourt(Court court) => CourtDAO.Instance.UpdateCourt(court);
        public List<Court> GetCourts() => CourtDAO.Instance.GetCourts();
        public Court GetCourtById(int id) => CourtDAO.Instance.GetCourtById(id);
        public string getCategoryName(int id) => CourtDAO.Instance.getCategoryName(id);
        public List<Category> GetCategories() => CourtDAO.Instance.getCategories();
    }
}


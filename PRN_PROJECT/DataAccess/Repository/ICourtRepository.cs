using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICourtRepository
    {
        void AddCourt(Court court);
        void DeleteCourt(Court court);
        void UpdateCourt(Court court);
        List<Court> GetCourts();
        Court GetCourtById(int id);
        string getCategoryName(int id);
        List<Category> GetCategories();
    }
}

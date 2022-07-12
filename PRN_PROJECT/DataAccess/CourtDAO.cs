using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CourtDAO
    {
        private static CourtDAO instance = null;
        private static readonly object instanceLock = new object();
        private CourtDAO() { }
        public static CourtDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CourtDAO();
                    }
                    return instance;
                }
            }
        }
        public List<Court> GetCourts()
        {
            var listCourts = new List<Court>();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    listCourts = db.Courts.Include(p => p.Category).ToList();
                }
            }
            catch (Exception e) { }
            return listCourts;
        }
        public Court GetCourtById(int id)
        {
            var court = new Court();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    court = db.Courts.Find(id);
                }
            }
            catch (Exception e) { }
            return court;
        }

        public void AddCourt(Court court)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    context.Courts.Add(court);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateCourt(Court court)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    context.Entry<Court>(court).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteCourt(Court court)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    var p1 = context.Courts.SingleOrDefault(c => c.CourtId == court.CourtId);
                    context.Courts.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public string getCategoryName(int id)
        {
            var category = new Category();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    category = db.Categories.Find(id);
                }
            }
            catch (Exception e) { }
            return category.CategoryName;
        }
        public List<Category> getCategories()
        {
            var category = new List<Category>();
            {
                try
                {
                    using (var db = new SportCourtManagementDBContext())
                    {
                        category = db.Categories.ToList();
                    }
                }
                catch (Exception e) { }
                return category;
                }
            }
        }

    }


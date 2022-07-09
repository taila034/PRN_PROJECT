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
        private static SportCourtManagementDBContext instance = null;
        private static readonly object instanceLock = new object();
        public static SportCourtManagementDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SportCourtManagementDBContext();
                    }
                    return instance;
                }
            }
        }
        public static List<Court> GetCourts()
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
        public static Court GetCourtById(int id)
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

        public static void AddCourt(Court court)
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
        public static Court GetListByID(int p)
        {
            var mem = new Court();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    mem = db.Courts.SingleOrDefault(c => c.CourtId == p);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return mem;
        }
        public static void UpdateCourt(Court court)
        {
            try
            {
                if (GetListByID(court.CourtId) != null)
                {
                    using (var context = new SportCourtManagementDBContext())
                    {
                        context.Courts.Update(court);
                        context.SaveChanges();
                    }
                }
                   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteCourt(Court court)
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

    }
}

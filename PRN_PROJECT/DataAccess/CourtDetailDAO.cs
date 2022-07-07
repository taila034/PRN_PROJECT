using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CourtDetailDAO
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
        public static List<CourtDetail> GetCourtDetails()
        {
            var listCourtDetails = new List<CourtDetail>();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    listCourtDetails = db.CourtDetails.ToList();
                }
            }
            catch (Exception e) { }
            return listCourtDetails;
        }
        public static CourtDetail GetCourtDetailByCourtId(int id)
        {
            var cd = new CourtDetail();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    cd = db.CourtDetails.Find(id);
                }
            }
            catch (Exception e) { }
            return cd;
        }

        public static void AddSlot(CourtDetail cd)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    context.CourtDetails.Add(cd);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateSlot(CourtDetail cd)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    context.Entry<CourtDetail>(cd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DeleteSlot(CourtDetail cd)
        {
            try
            {
                using (var context = new SportCourtManagementDBContext())
                {
                    var p1 = context.CourtDetails.SingleOrDefault(cdetail => cdetail.CourtDetailsId == cd.CourtDetailsId);
                    context.CourtDetails.Remove(p1);
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

using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CourtDetailDAO
    {
        private static CourtDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private CourtDetailDAO() { }
        public static CourtDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CourtDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public List<CourtDetail> GetCourtDetails()
        {
            var listCourtDetails = new List<CourtDetail>();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    listCourtDetails = db.CourtDetails.Include(p => p.Court).ToList();
                }
            }
            catch (Exception e) { }
            return listCourtDetails;
        }
        public CourtDetail GetCourtDetailByCourtDetailId(int id)
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

        public void AddSlot(CourtDetail cd)
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
        public void UpdateSlot(CourtDetail cd)
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
        public void DeleteSlot(CourtDetail cd)
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
        public List<CourtDetail> GetAvailableSlot(int id)
        {
            var slotList = new List<CourtDetail>();
            try
            {
                using (var db = new SportCourtManagementDBContext())
                {
                    var items = db.CourtDetails.ToList();
                    foreach(var slot in items)
                    {
                        if(slot.CourtId == id && slot.Status)
                        {
                            slotList.Add(slot);
                        }
                    }
                    
                }
            }
            catch (Exception e) { }
            return slotList;
        }
        

    }
}

using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportBooking
{
    public partial class frmCourtDetail : Form
    {
        ICourtRepository courts = new CourtRepository();
        public Court court;
        public bool UpdateOrInsert { get; set; }    
        public frmCourtDetail()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Court members = null;



                if (UpdateOrInsert == false)
                {
                    members = new Court()
                    {
                        Status = bool.Parse(txtStatus.Text),
                        Price = decimal.Parse(txtPrice.Text),
                        CategoryId = int.Parse(TxtCategoryID.Text),
                        CourtName = txtCourseName.Text
                        //CourtId = int.Parse(TxtCourtID.Text)

                    };
                    courts.AddCourt(members);

                }
                
                if (UpdateOrInsert == true)
                {
                    var member = new Court()
                    {
                        Status = bool.Parse(txtStatus.Text),
                        Price = decimal.Parse(txtPrice.Text),
                        CategoryId = int.Parse(TxtCategoryID.Text),
                        CourtName = txtCourseName.Text,
                        CourtId = int.Parse(TxtCourtID.Text)

                    };
                    courts.UpdateCourt(member);

                }
             
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, UpdateOrInsert == false ? "Add a new Member" : "update a Member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCourtDetail_Load(object sender, EventArgs e)
        {
            TxtCourtID.Enabled = false;
            TxtCategoryID.Enabled = !UpdateOrInsert;
            if (UpdateOrInsert == true)
            {
                
                txtStatus.Text = court.Status.ToString();
                txtPrice.Text = court.Price.ToString();
                TxtCategoryID.Text = court.CategoryId.ToString();
                txtCourseName.Text = court.CourtName.ToString();
                TxtCourtID.Text = court.CourtId.ToString();

            }
           
            
        }
    }
}

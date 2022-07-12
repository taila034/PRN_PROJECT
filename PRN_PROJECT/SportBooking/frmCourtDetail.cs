using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportBooking
{
    public partial class frmCourtDetail : Form
    {
        public frmCourtDetail()
        {
            InitializeComponent();
        }
        public bool isUpdate { get; set; }
        public ICourtRepository courtRepository { get; set; }
        public Court CourtEditInfo { get; set; }

        private void frmCourtDetail_Load(object sender, EventArgs e)
        {
            var category = courtRepository.GetCategories();
            cbCategory.DataSource = category;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryId";
            if (isUpdate)
            {
                txtName.Text = CourtEditInfo.CourtName;
                var categoryName = courtRepository.getCategoryName(CourtEditInfo.CategoryId);
                cbCategory.Text = categoryName;
                cbStatus.SelectedText = CourtEditInfo.Status.ToString();
                txtPrice.Text = CourtEditInfo.Price.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var court = new Court()
                {

                    CategoryId = int.Parse(cbCategory.SelectedValue.ToString()),
                    CourtName = txtName.Text,
                    Status = Boolean.Parse(cbStatus.Text),
                    Price = decimal.Parse(txtPrice.Text)



                };
                if (!isUpdate)
                {
                    if (txtName.Text =="" || txtPrice.Text == "")
                    {
                        MessageBox.Show("All fields are required!!", "Court Management - Add court", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    else if (checkDup())
                    {

                        courtRepository.AddCourt(court);
                        MessageBox.Show("Added successfully!", "Court Management - Add a court", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Court has existed!!", "Court Management - Add a court", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    court.CourtId = CourtEditInfo.CourtId;

                    courtRepository.UpdateCourt(court);
                    MessageBox.Show("Updated successfully!", "Court Management - Update a court", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkDup()
        {
            var courtList = courtRepository.GetCourts();
            foreach (var item in courtList)
            {
                if (item.CourtName.ToUpper().Equals(txtName.Text.ToUpper()))
                {
                    return false;

                }
            }
            return true;

        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$");
            if (!regex.IsMatch(txtPrice.Text) || int.Parse(txtPrice.Text) <= 0)
            {
                MessageBox.Show("Price must be numbers and bigger than 0 ! Please enter again", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

    


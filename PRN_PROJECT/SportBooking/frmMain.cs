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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public IAccountRepository AccountRepository { get; set; }
        public ICourtRepository CourtRepository { get; set; }
        //public ICourtDetailRepository CourtDetailRepository { get; set; }
        public Order orderInfo = new Order() {};
        
        public bool isCustomer { get; set; }
        public Account AccountInfo { get; set; }
        
        BindingSource source = new BindingSource();
        public bool isAdmin { get; set; }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (isCustomer)
            {
                btnCourt.Visible = false;
                btnSlot.Visible = false;
                btnUser.Visible = false;
                btnOrder.Visible = false;
            }
            
            LoadCourtList();

        }
        
        public void LoadCourtList()
        {
            var courts = CourtRepository.GetCourts().Where(p => p.Status == true);

            try
            {
                source = new BindingSource();
                source.DataSource = courts;
                txtCourtID.DataBindings.Clear();

                txtPrice.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                txtCategory.DataBindings.Clear();

                txtCourtID.DataBindings.Add("Text", source, "CourtId");
                txtPrice.DataBindings.Add("Text", source, "Price");
                txtCourtName.DataBindings.Add("Text", source, "CourtName");
                txtCategory.DataBindings.Add("Text", source, "Category.CategoryName");

                dgvCourtList.DataSource = null;
                dgvCourtList.DataSource = source;
                dgvCourtList.Columns[3].Visible = false;
                dgvCourtList.Columns[5].Visible = false;
                dgvCourtList.Columns[6].Visible = false;
                dgvCourtList.Columns[7].Visible = false;
                dgvCourtList.Columns[8].Visible = false;

                if (courts.Count() == 0)
                {
                    ClearText();
                    cbCategory.Enabled = false;

                }
                else
                {

                    cbCategory.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load court list");
            }
        }
        private void ClearText()
        {
            txtCourtID.Text = string.Empty;
            txtCourtName.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtCategory.Text = String.Empty;

        }
        public void FindCourtList()
        {
            var courts = CourtRepository.GetCourts().Where(c => c.Category.CategoryName.Equals(cbCategory.SelectedItem) && c.Status == true);
            try
            {
                source = new BindingSource();
                source.DataSource = courts;
                txtCourtID.DataBindings.Clear();

                txtPrice.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                txtCategory.DataBindings.Clear();

                txtCourtID.DataBindings.Add("Text", source, "CourtId");
                txtPrice.DataBindings.Add("Text", source, "Price");
                txtCourtName.DataBindings.Add("Text", source, "CourtName");
                txtCategory.DataBindings.Add("Text", source, "Category.CategoryName");

                dgvCourtList.DataSource = null;
                dgvCourtList.DataSource = source;
                dgvCourtList.Columns[3].Visible = false;
                dgvCourtList.Columns[5].Visible = false;
                dgvCourtList.Columns[6].Visible = false;
                dgvCourtList.Columns[7].Visible = false;
                dgvCourtList.Columns[8].Visible = false;

                if (courts.Count() == 0)
                {
                    ClearText();
                    MessageBox.Show("No court found!! Court maybe under maintenance", "Court Management - Search court", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {

                    cbCategory.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load court list");
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindCourtList();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            frmUserDetail frmUserDetail = new frmUserDetail()
            {
                Text = "Update Information",
                AccountEditInfo = AccountInfo,
                AccountRepository = AccountRepository,
                isUpdate = true
            };
            frmUserDetail.ShowDialog();
        }

        private void btnCourt_Click(object sender, EventArgs e)
        {
            frmCourtManagement frmCourtManagement = new frmCourtManagement();
            frmCourtManagement.ShowDialog();
        }

        private void btnSlot_Click(object sender, EventArgs e)
        {
            frmSlotManagement frmSlotManagement = new frmSlotManagement();
            frmSlotManagement.ShowDialog();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUserManagement frmUserManagement = new frmUserManagement
            {
                AccountRepository = AccountRepository
            };
            frmUserManagement.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrderManagement frmOrderManagement = new frmOrderManagement();
            frmOrderManagement.ShowDialog();
        }

        private void dgvCourtList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmBooking frm = new frmBooking()
            {
                CourtInfo = CourtRepository.GetCourtById(int.Parse(txtCourtID.Text)),
                orderInfo = orderInfo,
                CourtRepository = CourtRepository,
                AccountInfo = AccountInfo
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCourtList();
                orderInfo.OrderId = frm.orderInfo.OrderId;
                orderInfo.Status = frm.orderInfo.Status;
                orderInfo.TotalPrice = frm.orderInfo.TotalPrice;
            }
            
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            if (orderInfo.OrderId == 0 || orderInfo.Status.Equals("Confirmed"))
            {
                MessageBox.Show("There is nothing in your cart");
            }
            else
            {
                frmOrderDetail frm = new frmOrderDetail()
                {
                    orderInfo = orderInfo,

                };
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadCourtList();
                    orderInfo = frm.orderInfo;
                    //set status to checkout
                }
                else
                {
                    orderInfo = frm.orderInfo;
                }



            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            
            frmOrderManagement frm = new frmOrderManagement()
            {
                isAdmin = isAdmin,
                isCustomer = isCustomer,
                AccountInfo = AccountInfo
            };
            frm.ShowDialog();
        }
    }
}

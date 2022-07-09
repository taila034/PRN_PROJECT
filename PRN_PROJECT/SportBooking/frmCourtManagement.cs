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
    public partial class frmCourtManagement : Form
    {
        
        BindingSource source;
        ICourtRepository court = new CourtRepository();
        public frmCourtManagement()
        {
            InitializeComponent();
        }

        private void frmCourtManagement_Load(object sender, EventArgs e)
        {
            loadListMember();
        }
        private void clearText()
        {
            txtStatus.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtCategory.Text = String.Empty;
            txtSportName.Text = String.Empty;
            txtCourtName.Text = String.Empty;
            TxtCourtId.Text = String.Empty;
        }

        public void loadListMember()                       // Từ dữ liệu Car đổ cào DATAGRIDVIEW
        {

           
            var member = court.GetCourts();
            try
            {
                source = new BindingSource(); // là cột column trong Datagridview 
                source.DataSource = member; /// Thêm dữ liệu car vào BindingSource

                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtSportName.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                TxtCourtId.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                /// Tạo tên cho các cột trong DATAGRIDVIEW
                txtPrice.DataBindings.Add("Text", source, "Price"); 
                txtStatus.DataBindings.Add("Text", source, "Status");
                txtCategory.DataBindings.Add("Text", source, "CategoryId");
                txtSportName.DataBindings.Add("Text", source, "Category.CategoryName");
                txtCourtName.DataBindings.Add("Text", source, "CourtName");
                TxtCourtId.DataBindings.Add("Text", source, "CourtId");
                // lÀM TRỐNG DATAGRIDVIEW và sau đó chèn dữ liệu car vào bảng DgvCarList

                dgvSlotList.DataSource = null;
                dgvSlotList.DataSource = source;
                dgvSlotList.Columns[3].Visible = false;
                dgvSlotList.Columns[6].Visible = false;
                dgvSlotList.Columns[7].Visible = false;
                dgvSlotList.Columns[8].Visible = false;
                /// Nếu ko có dữ liệu Car thì sẽ ẩn nút DELETE
                if (member.Count() == 0)
                {
                    clearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Court List");
            }

        }
        private Court GetsCourtObjects()
        {
            Court mem = null;
            try
            {
                
                mem   = new Court()
                {
                    Status = bool.Parse(txtStatus.Text),
                    Price =decimal.Parse(txtPrice.Text),
                    CategoryId=int.Parse(txtCategory.Text),
                     CourtName=txtCourtName.Text,
                       CourtId=int.Parse(TxtCourtId.Text)
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Court!!!");

            }
            return mem;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCourtDetail detail = new frmCourtDetail()
            {
                Text = "Create",
                court = GetsCourtObjects(),
                UpdateOrInsert = false
            };
            if (detail.ShowDialog() == DialogResult.OK)
            {
                loadListMember();
            }
        }

        private void dgvSlotList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCourtDetail detailCourt = new frmCourtDetail()
            {
                Text = "Update",
                court = GetsCourtObjects(),
                UpdateOrInsert=true
            };
            if (detailCourt.ShowDialog() == DialogResult.OK)
            {
                loadListMember();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                var member = GetsCourtObjects();
                court.DeleteCourt(member);
                loadListMember();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a car");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
    }


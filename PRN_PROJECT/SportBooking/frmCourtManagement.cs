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
        public frmCourtManagement()
        {
            InitializeComponent();
        }
        public ICourtRepository courtRepository = new CourtRepository();
        BindingSource source = new BindingSource();

        private void frmCourtManagement_Load(object sender, EventArgs e)
        {
            LoadCourtList();
        }
        private void LoadCourtList()
        {
            bool flag = true;
            var courtList = courtRepository.GetCourts().Where(c => c.Status == flag);
            try
            {
                source = new BindingSource();
                source.DataSource = courtList;
                txtCourtID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                txtCategory.DataBindings.Clear();

                txtCourtID.DataBindings.Add("Text", source, "CourtId");
                txtPrice.DataBindings.Add("Text", source, "Price");
                txtCourtName.DataBindings.Add("Text", source, "CourtName");
                txtCategory.DataBindings.Add("Text", source, "Category.CategoryName");
                txtStatus.DataBindings.Add("Text", source, "Status");

                dgvCourtList.DataSource = null;
                dgvCourtList.DataSource = source;
                dgvCourtList.Columns[3].Visible = false;
                dgvCourtList.Columns[5].Visible = false;
                dgvCourtList.Columns[6].Visible = false;
                dgvCourtList.Columns[7].Visible = false;
                dgvCourtList.Columns[8].Visible = false;


                if (courtList.Count() == 0)
                {
                    ClearText();
                    
                    btnDelete.Enabled = false;

                }
                else
                {
                    
                    btnDelete.Enabled = true;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load court list");
            }
        }
        private void ClearText()
        {
            txtCourtID.Text = String.Empty;
            txtCourtName.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtCategory.Text = String.Empty;
            txtStatus.Text = String.Empty;

        }
        public void FindCourtList()
        {
            bool flag = true;
            var courts = courtRepository.GetCourts().Where(c => c.Category.CategoryName.Equals(cbCategory.SelectedItem) && c.Status == flag);
            try
            {
                source = new BindingSource();
                source.DataSource = courts;
                txtCourtID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                txtCategory.DataBindings.Clear();

                txtCourtID.DataBindings.Add("Text", source, "CourtId");
                txtPrice.DataBindings.Add("Text", source, "Price");
                txtCourtName.DataBindings.Add("Text", source, "CourtName");
                txtCategory.DataBindings.Add("Text", source, "Category.CategoryName");
                txtStatus.DataBindings.Add("Text", source, "Status");

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
                    MessageBox.Show("No court found!!", "Court Management - Search court", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDelete.Enabled = false;

                }
                else
                {

                    btnDelete.Enabled = true;


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

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCourtDetail frm = new frmCourtDetail()
            {
                Text = "Add new court",
                isUpdate = false,
                courtRepository = courtRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {

                LoadCourtList();
                source.Position = source.Count - 1;

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Do you want to delete this court ?", "Court Management - Delete Court", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var court = courtRepository.GetCourtById(int.Parse(txtCourtID.Text));
                    court.Status = false;
                    courtRepository.UpdateCourt(court);
                    MessageBox.Show("Deleted successfully!", "Slot Management - Delete a slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourtList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a slot");
                }
            }
        }

        private void dgvCourtList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCourtDetail frm = new frmCourtDetail()
            {
                Text = "Update court",
                isUpdate = true,
                CourtEditInfo = courtRepository.GetCourtById(int.Parse(txtCourtID.Text)),
                courtRepository = courtRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCourtList();
                source.Position = source.Count - 1;
            }
        }
    }
    }


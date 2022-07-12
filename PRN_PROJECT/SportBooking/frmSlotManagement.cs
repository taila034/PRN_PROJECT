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
    public partial class frmSlotManagement : Form
    {
        public frmSlotManagement()
        {
            InitializeComponent();
        }
        public ICourtDetailRepository courtDetailRepository = new CourtDetailRepository();
        BindingSource source = new BindingSource();
        private void frmSlotManagement_Load(object sender, EventArgs e)
        {
            LoadSlotList();
        }
        private void LoadSlotList()
        {
            bool flag = true;
            var slotList = courtDetailRepository.GetCourtDetails().Where(c => c.Status == flag);
            try
            {
                source = new BindingSource();
                source.DataSource = slotList;
                txtCourtName.DataBindings.Clear();
                txtCDID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtSlot.DataBindings.Clear();
                txtCategory.DataBindings.Clear();

                txtStatus.DataBindings.Add("Text", source, "Status");
                txtPrice.DataBindings.Add("Text", source, "Court.Price");
                txtCourtName.DataBindings.Add("Text", source, "Court.CourtName");
                txtCategory.DataBindings.Add("Text", source, "Court.CategoryId");
                txtSlot.DataBindings.Add("Text", source, "Slot");
                txtCDID.DataBindings.Add("Text", source, "CourtDetailsId");

                dgvSlotList.DataSource = null;
                dgvSlotList.DataSource = source;
               
                dgvSlotList.Columns[5].Visible = false;
                dgvSlotList.Columns[6].Visible = false;
                dgvSlotList.Columns[7].Visible = false;

                if (slotList.Count() == 0)
                {
                    ClearText();
                    btnSearch.Enabled = false;
                    btnDelete.Enabled = false;

                }
                else
                {
                    btnSearch.Enabled = true;
                    btnDelete.Enabled = true;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load slot list");
            }
        }
        private void ClearText()
        {
            txtStatus.Text = String.Empty;
            txtCourtName.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtCategory.Text = String.Empty;
            txtSlot.Text = String.Empty;
            txtCDID.Text = String.Empty;

        }
        private void FindSlotList()
        {
            bool flag = true;
            var slots = courtDetailRepository.GetCourtDetails().Where(c => c.Court.CourtName.ToUpper().Contains(txtSearch.Text.ToUpper()) && c.Status == flag);
            try
            {
                source = new BindingSource();
                source.DataSource = slots;
                txtCourtName.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtSlot.DataBindings.Clear();
                txtCategory.DataBindings.Clear();
                txtCDID.DataBindings.Clear();

                txtStatus.DataBindings.Add("Text", source, "Status");
                txtPrice.DataBindings.Add("Text", source, "Court.Price");
                txtCourtName.DataBindings.Add("Text", source, "Court.CourtName");
                txtCategory.DataBindings.Add("Text", source, "Court.CategoryId");
                txtSlot.DataBindings.Add("Text", source, "Slot");
                txtCDID.DataBindings.Add("Text", source, "CourtDetailsId");

                dgvSlotList.DataSource = null;
                dgvSlotList.DataSource = source;

                dgvSlotList.Columns[5].Visible = false;
                dgvSlotList.Columns[6].Visible = false;
                dgvSlotList.Columns[7].Visible = false;

                if (slots.Count() == 0)
                {
                    ClearText();
                    MessageBox.Show("No slot found!! Pls add slot to this court", "Slot Management - Search slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSearch.Enabled = false;
                    btnDelete.Enabled = false;

                }
                else
                {
                    btnSearch.Enabled = true;
                    btnDelete.Enabled = true;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load slot list");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindSlotList();
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Do you want to delete this slot ?", "Slot Management - Delete Slot", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var slot = courtDetailRepository.GetCourtDetailByCourtDetailsID(int.Parse(txtCDID.Text));
                    slot.Status = false;
                    courtDetailRepository.UpdateSlot(slot);
                    MessageBox.Show("Deleted successfully!", "Slot Management - Delete a slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSlotList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a slot");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSlotDetail frm = new frmSlotDetail
            {
                Text = "Add slot",
                isUpdate = false,
                courtDetailRepository = courtDetailRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {

                LoadSlotList();
                source.Position = source.Count - 1;

            }
        }

        private void dgvSlotList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmSlotDetail frm = new frmSlotDetail()
            {
                Text = "Update slot",
                isUpdate = true,
                SlotEditInfo = courtDetailRepository.GetCourtDetailByCourtDetailsID(int.Parse(txtCDID.Text)),
                courtDetailRepository = courtDetailRepository
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadSlotList();
                source.Position = source.Count - 1;
            }
        }
    }

    }


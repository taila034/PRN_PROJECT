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
    public partial class frmSlotDetail : Form
    {
        public frmSlotDetail()
        {
            InitializeComponent();
        }
        public bool isUpdate { get; set; }
        public ICourtDetailRepository courtDetailRepository { get; set; }
        public ICourtRepository courtRepository = new CourtRepository();
        public CourtDetail SlotEditInfo { get; set; }

        private void frmSlotDetail_Load(object sender, EventArgs e)
        {
            var courtList = courtRepository.GetCourts();
            cbCourtID.DataSource = courtList;
            cbCourtID.DisplayMember = "CourtName";
            cbCourtID.ValueMember = "CourtId";
            if (isUpdate)
            {
                cbCourtID.Enabled = false;
                mskStart.Text = SlotEditInfo.StartAt.ToString();
                mskEnd.Text = SlotEditInfo.EndAt.ToString();
                cbStatus.SelectedText = SlotEditInfo.Status.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var slot = new CourtDetail()
                {

                    CourtId = int.Parse(cbCourtID.SelectedValue.ToString()),
                    StartAt = TimeSpan.Parse(mskStart.Text),
                    EndAt = TimeSpan.Parse(mskEnd.Text),
                    Status = Boolean.Parse(cbStatus.Text),
                    Slot =  $"{mskStart.Text}-{mskEnd.Text}",


                };
                if (!isUpdate)
                {
                    if (checkDup())
                    {

                        courtDetailRepository.AddSlot(slot);
                        MessageBox.Show("Added successfully!", "Slot Management - Add a slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Slot of the court has existed!!", "Slot Management - Add slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    slot.CourtDetailsId = SlotEditInfo.CourtDetailsId;

                    courtDetailRepository.UpdateSlot(slot);
                    MessageBox.Show("Updated successfully!", "Slot Management - Update a slot", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool checkDup()
        {
            var courtDetailList = courtDetailRepository.GetCourtDetails();
            foreach(var item in courtDetailList)
            {
                if(item.CourtId == int.Parse(cbCourtID.SelectedValue.ToString()) && item.StartAt == TimeSpan.Parse(mskStart.Text) && item.EndAt == TimeSpan.Parse(mskEnd.Text)){
                    return false;
                    
                }
            }
            return true;
            
        }
    }
    
}

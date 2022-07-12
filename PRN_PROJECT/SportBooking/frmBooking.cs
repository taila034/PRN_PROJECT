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
    public partial class frmBooking : Form
    {
        public frmBooking()
        {
            InitializeComponent();
        }
        public Court CourtInfo { get; set; }
        public ICourtDetailRepository CourtDetailRepository = new CourtDetailRepository();
        public IOrderRepository orderRepository = new OrderRepository();
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public Account AccountInfo { get; set; }
        public Order orderInfo { get; set; }
        public ICourtRepository CourtRepository { get; set; }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            monthCalendar1.MinDate = DateTime.Today;
            txtCourtName.Text = CourtInfo.CourtName;
            var name = CourtRepository.getCategoryName(CourtInfo.CategoryId);
            txtSportName.Text = name;
            txtPrice.Text = CourtInfo.Price.ToString();
            List<CourtDetail> slots = new List<CourtDetail>();
            slots = CourtDetailRepository.GetAvailableSlot(CourtInfo.CourtId);
            
            cbSlot.DataSource = slots;
            cbSlot.DisplayMember = "Slot";
            cbSlot.ValueMember = "CourtDetailsId";
            

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //var orderInfo = new Order()
            if (!checkSlotDup() && orderInfo.Status != "Confirmed")
            {
                MessageBox.Show("Slot and court has been booked!", "Booking service - Add an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (orderInfo.OrderId == 0 || orderInfo.Status.Equals("Confirmed"))// checkout thanh cong tao order moi
            {
                orderInfo = new Order()
                {
                    OrderDate = DateTime.Today,
                    Status = "Pending",
                    AccountId = AccountInfo.AccountId,
                    CreatedDate = DateTime.Today,
                    TotalPrice = (decimal)CourtInfo.Price
                };

                orderRepository.AddNew(orderInfo);

                var orderDetailInfo = new OrderDetail()
                {
                    OrderId = orderInfo.OrderId,
                    CourtDetailsId = (int)cbSlot.SelectedValue,
                    OrderDate = monthCalendar1.SelectionRange.Start.Date
                };
                orderDetailRepository.AddOrderDetail(orderDetailInfo);
                MessageBox.Show("Added successfully!", "Booking service - Add an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //if (!checkSlotDup())
            //{
            //    MessageBox.Show("Slot and court has been booked!", "Booking service - Add an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            else
            {
                var orderDetailInfo = new OrderDetail()
                {
                    OrderId = orderInfo.OrderId,
                    CourtDetailsId = (int)cbSlot.SelectedValue,
                    OrderDate = monthCalendar1.SelectionRange.Start.Date
                };
                orderDetailRepository.AddOrderDetail(orderDetailInfo);
                orderInfo.TotalPrice += (decimal)CourtInfo.Price;
                MessageBox.Show("Added successfully!", "Booking service - Add an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        private bool checkSlotDup()
        {
            var orderDetailList =orderDetailRepository.GetOrderDetailList();
            foreach(var item in orderDetailList)
            {
                if((item.OrderId == orderInfo.OrderId && item.CourtDetailsId == (int)cbSlot.SelectedValue) || (item.OrderId != orderInfo.OrderId && item.CourtDetailsId == (int)cbSlot.SelectedValue && item.OrderDate == monthCalendar1.SelectionRange.Start.Date)){
                    return false;
                }
            }
            return true;
        }

    }
}

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
    public partial class frmOrderDetail : Form
    {
        public frmOrderDetail()
        {
            InitializeComponent();
        }
        public Order orderInfo { get; set; }
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public ICourtRepository courtRepository = new CourtRepository();
        public ICourtDetailRepository courtDetailRepository = new CourtDetailRepository();
        public IOrderRepository orderRepository = new OrderRepository();
        BindingSource source = new BindingSource();
        public bool isAdmin { get; set; }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            
   
            var orderDetailList = orderDetailRepository.GetOrderDetailByOrderID(orderInfo.OrderId);
            try
            {
                source = new BindingSource();

                source.DataSource = orderDetailList;

                txtOrderID.DataBindings.Clear();
                txtOrderDetailsID.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                txtSlot.DataBindings.Clear();
                txtCourtDetailsID.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtOrderDetailsID.DataBindings.Add("Text", source, "OrderDetailID");
                txtCourtDetailsID.DataBindings.Add("Text", source, "CourtDetailsId");


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                if (isAdmin)
                {
                    btnCheckout.Visible = false;
                    
                    btnDelete.Visible = false;
                }

               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load cart list");
            }
            }
        
        private void ClearText()
        {
            txtOrderID.Text = string.Empty;
            txtCourtName.Text = String.Empty;
            txtOrderDetailsID.Text = String.Empty;
            txtSlot.Text = String.Empty;
            txtCourtDetailsID.Text = String.Empty;
       

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          var courtDetail=  courtDetailRepository.GetCourtDetailByCourtDetailsID(int.Parse(txtCourtDetailsID.Text));
            var court = courtRepository.GetCourtById(courtDetail.CourtId);
            txtSlot.Text = courtDetail.Slot;
            txtCourtName.Text = court.CourtName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Do you want to delete this order detail ?", "Order Management - Delete Order Detail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    var orderDetail = orderDetailRepository.GetOrderDetailByID(int.Parse(txtOrderDetailsID.Text));
                    var courtDetail = courtDetailRepository.GetCourtDetailByCourtDetailsID(int.Parse(txtCourtDetailsID.Text));
                    var court = courtRepository.GetCourtById(courtDetail.CourtId);
                    orderDetailRepository.RemoveOrderDetail(orderDetail.OrderDetailId);
                    MessageBox.Show("Deleted successfully!", "Order Management - Delete an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrder();

                    orderInfo.TotalPrice -= (decimal)court.Price;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete this order because of some related data", "Order Management - Delete an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Your total price is {orderInfo.TotalPrice}");
            var order = orderRepository.GetOrderByID(orderInfo.OrderId);
            order.Status = "Confirmed";
            orderRepository.Update(order);
            orderInfo.Status = "Confirmed";
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
        private void LoadOrder()
        {
            var orderDetailList = orderDetailRepository.GetOrderDetailByOrderID(orderInfo.OrderId);
            try
            {
                source = new BindingSource();

                source.DataSource = orderDetailList;

                txtOrderID.DataBindings.Clear();
                txtOrderDetailsID.DataBindings.Clear();
                txtCourtName.DataBindings.Clear();
                txtSlot.DataBindings.Clear();
                txtCourtDetailsID.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtOrderDetailsID.DataBindings.Add("Text", source, "OrderDetailID");
                txtCourtDetailsID.DataBindings.Add("Text", source, "CourtDetailsId");


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = source;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                if (isAdmin)
                {
                    btnCheckout.Visible = false;
                   
                    btnDelete.Visible = false;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load cart list");
            }
        }

       
    }
    }


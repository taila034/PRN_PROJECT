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
    public partial class frmOrderManagement : Form
    {
        public frmOrderManagement()
        {
            InitializeComponent();
        }
        public Order orderInfo { get; set; }
        public IOrderRepository orderRepository = new OrderRepository();
        BindingSource source = new BindingSource();
        public bool isAdmin { get; set; }
        public bool isCustomer { get; set; }
        public Account AccountInfo { get; set; }

        private void frmOrderManagement_Load(object sender, EventArgs e)
        {
            
            if (isCustomer)
            {
                LoadOrderListForCustomer();
                btnDelete.Visible = false;
            }
            else
            {
                LoadOrderList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Do you want to change the status to CONFIRMED for this order ?", "Order Management - Update Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {

                    var order = orderRepository.GetOrderByID(int.Parse(txtOrderID.Text));
                    order.Status = "Confirmed";
                    orderRepository.Update(order);
                    MessageBox.Show("Updated successfully!", "Order Management - Update an order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrderList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Update an order");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();


        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindOrderList();
        }

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            orderInfo.OrderId = int.Parse(txtOrderID.Text);
            frmOrderDetail frm = new frmOrderDetail()
            {
                orderInfo = orderInfo,
                isAdmin = isAdmin
            };

        }
        private void LoadOrderList()
        {
            var orderList = orderRepository.GetOrderList();
            try
            {
                source = new BindingSource();
                source.DataSource = orderList;
                txtOrderID.DataBindings.Clear();
                txtAccountID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtDate.DataBindings.Clear();
                if (orderList.Count() == 0)
                {
                    ClearText();
                    cbStatus.Enabled = false;
                    MessageBox.Show("No order found!!", "Order Management - Search order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    cbStatus.Enabled = true;



                    txtStatus.DataBindings.Add("Text", source, "Status");
                    txtPrice.DataBindings.Add("Text", source, "TotalPrice");
                    txtOrderID.DataBindings.Add("Text", source, "OrderId");
                    txtDate.DataBindings.Add("Text", source, "OrderDate");
                    txtAccountID.DataBindings.Add("Text", source, "AccountId");


                    dgvOrder.DataSource = null;
                    dgvOrder.DataSource = source;

                    dgvOrder.Columns[4].Visible = false;
                    dgvOrder.Columns[6].Visible = false;
                    dgvOrder.Columns[7].Visible = false;



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
            txtOrderID.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtAccountID.Text = String.Empty;
            txtDate.Text = String.Empty;


        }
        public void FindOrderList()
        {
            var orderList = orderRepository.GetOrderList();//.Where(c => c.Status.Equals(cbStatus.SelectedItem));
            var filterList = new List<Order>();
            foreach(var item in orderList)
            {
                if(item.Status.Equals(cbStatus.SelectedItem))
                    filterList.Add(item);
            }
            try
            {
                source = new BindingSource();
                source.DataSource = filterList;
                txtOrderID.DataBindings.Clear();
                txtAccountID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtDate.DataBindings.Clear();
                if (filterList == null)
                {
                    ClearText();
                    cbStatus.Enabled = false;
                    
                    MessageBox.Show("No order found!!", "Order Management - Search order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    cbStatus.Enabled = true;
                    




                    txtPrice.DataBindings.Add("Text", source, "TotalPrice");
                    txtOrderID.DataBindings.Add("Text", source, "OrderId");
                    txtDate.DataBindings.Add("Text", source, "OrderDate");
                    txtAccountID.DataBindings.Add("Text", source, "AccountId");
                    txtStatus.DataBindings.Add("Text", source, "Status");


                    dgvOrder.DataSource = null;
                    dgvOrder.DataSource = source;

                    dgvOrder.Columns[4].Visible = false;
                    dgvOrder.Columns[6].Visible = false;
                    dgvOrder.Columns[7].Visible = false;
                }


               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }
        private void LoadOrderListForCustomer()
        {
            var orderList = orderRepository.GetOrderList().Where(c => c.AccountId == AccountInfo.AccountId);
            try
            {
                source = new BindingSource();
                source.DataSource = orderList;
                txtOrderID.DataBindings.Clear();
                txtAccountID.DataBindings.Clear();
                txtStatus.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtDate.DataBindings.Clear();

                if (orderList.Count() == 0)
                {
                    ClearText();
                    cbStatus.Enabled = false;
                    MessageBox.Show("No order found!!", "Order Management - Search order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    cbStatus.Enabled = true;



                    txtStatus.DataBindings.Add("Text", source, "Status");
                    txtPrice.DataBindings.Add("Text", source, "TotalPrice");
                    txtOrderID.DataBindings.Add("Text", source, "OrderId");
                    txtDate.DataBindings.Add("Text", source, "OrderDate");
                    txtAccountID.DataBindings.Add("Text", source, "AccountId");


                    dgvOrder.DataSource = null;
                    dgvOrder.DataSource = source;

                    dgvOrder.Columns[4].Visible = false;
                    dgvOrder.Columns[6].Visible = false;
                    dgvOrder.Columns[7].Visible = false;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }
    }
}
    


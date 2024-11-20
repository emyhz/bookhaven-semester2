using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenDesktop.UserControls
{
    public partial class OrderList : UserControl
    {
        private int id;
        public OrderList()
        {
            InitializeComponent();

        }

        public int OrderId
        {
            get { return id; }
            set { id = value; lblOrderNo.Text = "Order #" + value; }
        }


    }
}

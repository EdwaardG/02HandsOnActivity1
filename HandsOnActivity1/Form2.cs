using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandsOnActivity1
{
    public partial class CashierWindowQueueForm : Form
    {
        public CashierWindowQueueForm()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            


        }
        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }
        private int _ticks;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _ticks++;
                lblTime.Text = _ticks.ToString();
                if (_ticks == 10)
                {
                    DisplayCashierQueue(CashierClass.CashierQueue.Dequeue());
                    DisplayCashierQueue(CashierClass.CashierQueue);
                    timer1.Stop();
                    _ticks = 0;
                }
            }
            catch(System.InvalidOperationException ex)
            {
                timer1.Stop();
                MessageBox.Show("Theres nothing in the Queue right now.", "Message");
                _ticks = 0;
            }
        } 

        private void CashierWindowQueueForm_Load(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer1.Stop();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}

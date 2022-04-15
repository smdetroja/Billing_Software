using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Umiya_bag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Green;
            radioButton2.ForeColor = Color.Red;

            cmb_items.Items.Clear();
            cmb_items.Items.Add("American Tourist");
            cmb_items.Items.Add("Skybags");
            cmb_items.Items.Add("VIP");
            
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Red;
            radioButton2.ForeColor = Color.Green;

            cmb_items.Items.Clear();
            cmb_items.Items.Add("Sun Bag");
            cmb_items.Items.Add("Astron Bag");
            cmb_items.Items.Add("Sunrise Bag");
            
        }

        private void cmb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_items.SelectedItem.ToString() == "American Tourist")
            { txt_price.Text = "1000"; }
            else if (cmb_items.SelectedItem.ToString() == "Skybags")
            { txt_price.Text = "1500"; }
            else if (cmb_items.SelectedItem.ToString() == "VIP")
            { txt_price.Text = "2000"; }
            else if (cmb_items.SelectedItem.ToString() == "Sun Bag")
            { txt_price.Text = "500"; }
            else if (cmb_items.SelectedItem.ToString() == "Astron Bag")
            { txt_price.Text = "750"; }
            else if (cmb_items.SelectedItem.ToString() == "Sunrise Bag")
            { txt_price.Text = "1000"; }
            else
            { txt_price.Text = "0"; }


            txt_total.Text = "";
            txt_qty.Text = "";
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            if (txt_qty.Text.Length>0)
            {
                txt_total.Text = (Convert.ToDouble(txt_qty.Text) * Convert.ToDouble(txt_price.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] arr = new string[4];
            arr[0] = cmb_items.SelectedItem.ToString();
            arr[1] = txt_price.Text;
            arr[2] = txt_qty.Text;
            arr[3] = txt_total.Text;

            ListViewItem lvi = new ListViewItem(arr);           
            listView1.Items.Add(lvi);


            txt_sub.Text = (Convert.ToDouble(txt_sub.Text) + Convert.ToDouble(txt_total.Text)).ToString();

        }

        private void button5_Click(object sender, EventArgs e)        {
          
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count ; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        txt_sub.Text = (Convert.ToDouble(txt_sub.Text) - Convert.ToDouble(listView1.Items[i].SubItems[3].Text)).ToString();
                        listView1.Items[i].Remove();


                    }
                }
            }
        }




        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text.Length > 0)
            {
                txt_net.Text = (Convert.ToDouble(txt_sub.Text) - Convert.ToDouble(txt_discount.Text)).ToString();
            }
        }

        private void txt_paid_TextChanged(object sender, EventArgs e)
        {
            if (txt_discount.Text.Length > 0)
            {
                txt_balance.Text = (Convert.ToDouble(txt_net.Text) - Convert.ToDouble(txt_paid.Text)).ToString();
            }
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        

        private void txt_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_sub_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_net_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_balance_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            printDocument1.Print();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView1.Items.Count == 0 && txt_paid.Text == null)
            {
                MessageBox.Show("Add Items to generate Bill");
            }
            else {
                OleDbConnection connectionn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = D:\\study\\BVM college\\.net project\\UmiyaBag.mdb");

                connectionn.Open();
                OleDbDataAdapter com = new OleDbDataAdapter("Insert into key_detail values('" + txt_name.Text + "','" + dateTimePicker1.Text + "','" + txt_sub.Text + "', '" + txt_discount.Text + "', '" + txt_net.Text + "', '" + txt_paid.Text + "', '" + txt_balance.Text + "')", connectionn);
                com.SelectCommand.ExecuteNonQuery();

                /*for (int i = 0; i < listView1.Items.Count; i++)
                {
                    OleDbDataAdapter comm = new OleDbDataAdapter("Insert item_detail values('" + listView1.Items[i].SubItems[0].Text + "', '" + listView1.Items[i].SubItems[0].Text + "', '" + listView1.Items[i].SubItems[0].Text + "', '" + listView1.Items[i].SubItems[0].Text + "')", connectionn);
                    comm.SelectCommand.ExecuteNonQuery();
                }*/

                MessageBox.Show("Bill Generated");
                connectionn.Close();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Image img = Image.FromFile("D:\\study\\BVM college\\.net project\\Umiya_bag\\Umiya_bag\\image\\UmiyaBag Logo.png");
            Point loc = new Point(150, 20);
            e.Graphics.DrawImage(img, loc);


            Pen selPen = new Pen(Color.Black);
            e.Graphics.DrawString("Umiya Bags", new Font("Times new roman Bold", 25), Brushes.Black, 150, 300);
            e.Graphics.DrawString("Chitakhana, Opp. SBI bank, Diwan chowk, Juangadh-362001", new Font("Arial", 12), Brushes.Black, 150, 340);
            e.Graphics.DrawString("Manojbhai Detroja              Contact No. : 0285-260331", new Font("Arial", 12), Brushes.Black, 150, 360);

            e.Graphics.DrawString("Customer Name : "+ txt_name.Text, new Font("Arial", 14), Brushes.Black, 150, 390);

            // e.Graphics.DrawRectangle(selPen, 125, 125, 550, 250);
            e.Graphics.DrawString("Discount : " + txt_discount.Text + "        " + "Net Amount : " + txt_net.Text, new Font("Arial", 12), Brushes.Black, 150, 420);
            //e.Graphics.DrawString("Net Amount : " + txt_net.Text, new Font("Arial", 12), Brushes.Black, 150, 325);
            e.Graphics.DrawString("Paid Amount : " + txt_paid.Text + "        " + "Balance : " + txt_balance.Text, new Font("Arial", 12), Brushes.Black, 150, 440);
            //e.Graphics.DrawString("Balance : " + txt_balance.Text, new Font("Arial", 12), Brushes.Black, 150, 375);
            e.Graphics.DrawString("No." + "            " + "Item" + "            " + "Price"+ "            " + "Qty"+ "            " + "Total", new Font("Arial Bold", 11), new SolidBrush(Color.Black), 150, 480);
            e.Graphics.DrawLine(selPen, 150, 500, 600, 495);
            int y = 510;
            int a = 1;

            int p = 150, q = 600, r = 530;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                
                e.Graphics.DrawLine(selPen, p, r, q, r);
                r = r + 30;

                e.Graphics.DrawString(a + "         " + listView1.Items[i].SubItems[0].Text + "         " + listView1.Items[i].SubItems[1].Text + "         " +
                            listView1.Items[i].SubItems[2].Text + "         " + listView1.Items[i].SubItems[3].Text, new Font("Arial Bold", 11), new SolidBrush(Color.Black), 150, y);
                a++;
                y = y + 30;
                
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comppanel.Visible = false;
            rangepanel.Visible = false;
            valuepanel.Visible = false;
        }

        private void comppanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comppanel.Visible = true;
            opercombo.Items.Clear();
            opercombo.Text = "-select-";
            opercombo.Items.Add("Equal");
            opercombo.Items.Add("Not Equal");
            opercombo.Items.Add("Larger Than");
            opercombo.Items.Add("Smaller Than");
            opercombo.Items.Add("in Range");

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comppanel.Visible = false;
            opercombo.Items.Clear();
            opercombo.Text = "-select-";
            opercombo.Items.Add("Sum");
            opercombo.Items.Add("Avg");
            opercombo.Items.Add("Min");
            opercombo.Items.Add("Max");
            opercombo.Items.Add("Count");
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comppanel.Visible = false;
            opercombo.Items.Clear();
            opercombo.Text = "-select-";
            opercombo.Items.Add("And");
            opercombo.Items.Add("Or");
        }

        private void opercombe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oper = opercombo.SelectedItem.ToString();
            if (oper == "in Range")
            {
                rangepanel.Visible = true;
                valuepanel.Visible = false;
            }
            else
            {
                rangepanel.Visible = false;
                valuepanel.Visible = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            if (comboBox1.SelectedItem.ToString() == "Students")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("student.xml");

                XmlNodeList list = doc.GetElementsByTagName("student");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList child = list[i].ChildNodes;
                    string id = child[0].InnerText;
                    string name = child[1].InnerText;
                    string dep = child[2].InnerText;
                    string year = child[3].InnerText;

                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", "id");
                        dataGridView1.Columns.Add("name", "name");
                        dataGridView1.Columns.Add("department", "dep");
                        dataGridView1.Columns.Add("year", "year");
                    }
                    dataGridView1.Rows.Add(id, name, dep, year);   
                }
                checkedListBox2.Items.Clear();
                checkedListBox2.Items.Insert(0, "id");
                checkedListBox2.Items.Insert(0, "name");
                checkedListBox2.Items.Insert(0, "department");
                checkedListBox2.Items.Insert(0, "year");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (opercombo.SelectedItem.ToString() == "Equal")
                {

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Proj
{
    public partial class UserControl1 : UserControl
    {
        student s = new student();
        Dictionary<string, student> sdict = new Dictionary<string, student>();
        department d = new department();
        Dictionary<string, department> ddict = new Dictionary<string, department>();
        teacher t = new teacher();
        Dictionary<string, teacher> tdict = new Dictionary<string, teacher>();
        course c = new course();
        Dictionary<string, course> cdict = new Dictionary<string, course>();

       
        student std = new student();
        department departmen = new department();
        teacher teach = new teacher();
        course cour = new course();
        Dictionary<string, student> students = new Dictionary<string, student>();
        Dictionary<string, department> departments = new Dictionary<string, department>();
        Dictionary<string, teacher> teachers = new Dictionary<string, teacher>();
        Dictionary<string, course> coursess = new Dictionary<string, course>();


        public UserControl1()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel_aggregate.Visible = false;
            panel_comparison.Visible = false;
            panel_bool.Visible = false;
            t.readteacher(tdict);
            c.readcourse(cdict);
            s.readstudent(sdict);
            d.readdepartment(ddict);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string value = textBox2.Text.ToString();
            string inrange_from = textBox3.ToString();
            string inrange_to = textBox4.ToString();
          

            dataGridView1.Rows.Clear();


          

            //comparison
            if (radioButton1.Checked)
            {
                string operation = comboBox2.SelectedItem.ToString();
                string column = comboBox4.SelectedItem.ToString();
                comparsion(); 

            }

            //aggregate
            else if (radioButton2.Checked)
            {

                aggregate();
            }
            //boolean
            else if (radioButton3.Checked)
            {
               
                Boolean();

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel_comparison.Visible = true;
            panel_aggregate.Visible = false;
            panel_bool.Visible = false;

            comboBox2.Items.Clear();
            comboBox2.Text = "-select operation-";
            comboBox2.Items.Add("Equal");
            comboBox2.Items.Add("Not Equal");
            comboBox2.Items.Add("Larger Than");
            comboBox2.Items.Add("Smaller Than");
            comboBox2.Items.Add("in Range");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel_aggregate.Visible = true;
            panel_comparison.Visible = false;
            panel_bool.Visible = false;

            textBox1.Clear();
            comboBox2.Items.Clear();
            comboBox2.Text = "-select Aggregation-";
            comboBox2.Items.Add("Sum");
            comboBox2.Items.Add("Avg");
            comboBox2.Items.Add("Min");
            comboBox2.Items.Add("Max");
            comboBox2.Items.Add("Count");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel_bool.Visible = true;
            panel_aggregate.Visible = false;
            panel_comparison.Visible = false;

            comboBox2.Items.Clear();
            comboBox2.Text = "-select operation-";
            comboBox2.Items.Add("Equal");
            comboBox2.Items.Add("Not Equal");
            comboBox2.Items.Add("Larger Than");
            comboBox2.Items.Add("Smaller Than");
            comboBox2.Items.Add("in Range");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (comboBox1.SelectedItem.ToString() == "Students")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();


                for (int i = 1; i <= sdict.Count; i++)
                {


                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", "id");
                        dataGridView1.Columns.Add("name", "name");
                        dataGridView1.Columns.Add("department", "department");
                        dataGridView1.Columns.Add("year", "year");

                    }
                    dataGridView1.Rows.Add(sdict["" + i].id, sdict["" + i].name, sdict["" + i].department_id, sdict["" + i].year);

                }

                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "id");
                comboBox4.Items.Insert(0, "name");
                comboBox4.Items.Insert(0, "department");
                comboBox4.Items.Insert(0, "year");

                if (radioButton2.Checked)
                {
                    comboBox6.Items.Clear();
                    comboBox6.Items.Insert(0, "teacher id");
                    comboBox6.Items.Insert(0, "department id");
                    comboBox6.Items.Insert(0, "student id");
                }

                if (radioButton3.Checked)
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Insert(0, "department name");
                }
            }



            else if (comboBox1.SelectedItem.ToString() == "Departments")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();


                for (int i = 1; i <= ddict.Count; i++)
                {

                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", "id");
                        dataGridView1.Columns.Add("name", "name");
                        dataGridView1.Columns.Add("number of studens", "std_num");
                        dataGridView1.Columns.Add("courses", "course1 ID");
                        dataGridView1.Columns.Add("courses", "course2 ID");
                        dataGridView1.Columns.Add("courses", "course3 ID");
                        dataGridView1.Columns.Add("courses", "course4 ID");
                    }
                    dataGridView1.Rows.Add(ddict["" + i].id, ddict["" + i].name, ddict["" + i].no_of_student, ddict["" + i].course[0]
                        , ddict["" + i].course[1], ddict["" + i].course[2], ddict["" + i].course[3]);
                }
                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "id");
                comboBox4.Items.Insert(0, "name");
                comboBox4.Items.Insert(0, "number of studens");
                comboBox4.Items.Insert(0, "courses ID");

                if (radioButton2.Checked)
                {
                    comboBox6.Items.Clear();
                    comboBox6.Items.Insert(0, "teacher id");
                    comboBox6.Items.Insert(0, "department id");
                    comboBox6.Items.Insert(0, "student id");
                }


                if (radioButton3.Checked)
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Insert(0, "course 1 name");
                    comboBox5.Items.Insert(0, "course 1 duration");
                    comboBox5.Items.Insert(0, "course 1 grade");
                    comboBox5.Items.Insert(0, "course 2 name");
                    comboBox5.Items.Insert(0, "course 2 duration");
                    comboBox5.Items.Insert(0, "course 2 grade");
                    comboBox5.Items.Insert(0, "course 3 name");
                    comboBox5.Items.Insert(0, "course 3 duration");
                    comboBox5.Items.Insert(0, "course 3 grade");
                    comboBox5.Items.Insert(0, "teacher id");
                    comboBox5.Items.Insert(0, "teacher name");
                    comboBox5.Items.Insert(0, "teacher salary");
                    comboBox5.Items.Insert(0, "teacher rate");


                }
            }

            else if (comboBox1.SelectedItem.ToString() == "Courses")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                for (int i = 1; i <= cdict.Count; i++)
                {

                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", "id");
                        dataGridView1.Columns.Add("name", "name");
                        dataGridView1.Columns.Add("teacher ID", "teacher_id");
                        dataGridView1.Columns.Add("Duration", "duration");
                        dataGridView1.Columns.Add("Grade", "grade");

                    }
                    dataGridView1.Rows.Add(cdict["" + i].id, cdict["" + i].name
                        , cdict["" + i].teacher_id, cdict["" + i].duration, cdict["" + i].grade);
                }
                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "id");
                comboBox4.Items.Insert(0, "name");
                comboBox4.Items.Insert(0, "teacher ID");
                comboBox4.Items.Insert(0, "Duration");
                comboBox4.Items.Insert(0, "Grade");

                if (radioButton2.Checked)
                {
                    comboBox6.Items.Clear();
                    comboBox6.Items.Insert(0, "teacher id");
                    comboBox6.Items.Insert(0, "department id");
                    comboBox6.Items.Insert(0, "student id");
                }

                if (radioButton3.Checked)
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Insert(0, "teacher name");
                    comboBox5.Items.Insert(0, "teacher salary");
                    comboBox5.Items.Insert(0, "teacher rate");
                    comboBox5.Items.Insert(0, "department name");


                }
            }


            else if (comboBox1.SelectedItem.ToString() == "Teachers")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                for (int i = 1; i <= tdict.Count; i++)
                {

                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", "id");
                        dataGridView1.Columns.Add("name", "name");

                       dataGridView1.Columns.Add("courses", "course1 ID");
                        dataGridView1.Columns.Add("courses", "course2 id");
                        dataGridView1.Columns.Add("salary", "salary");
                        dataGridView1.Columns.Add("rate", "rate");
                    }
                    dataGridView1.Rows.Add(tdict["" + i].id, tdict["" + i].name
                        , tdict["" + i].course[0], tdict["" + i].course[1]
                        , tdict["" + i].salary, tdict["" + i].rate);
                }
                comboBox4.Items.Clear();
                comboBox4.Items.Insert(0, "id");
                comboBox4.Items.Insert(0, "name");
                comboBox4.Items.Insert(0, "salary");
                comboBox4.Items.Insert(0, "rate");
                comboBox4.Items.Insert(0, "courses");
               // comboBox4.Items.Insert(0, "courses2 ID");

                if (radioButton2.Checked)
                {
                    comboBox6.Items.Clear();
                    comboBox6.Items.Insert(0, "teacher id");
                    comboBox6.Items.Insert(0, "department id");
                    comboBox6.Items.Insert(0, "student id");
                }

                if (radioButton3.Checked)
                {
                    comboBox5.Items.Clear();
                    comboBox5.Items.Insert(0, "course name");
                    comboBox5.Items.Insert(0, "course duration");
                    comboBox5.Items.Insert(0, "course grade");



                }
            }

        }

        private void opercombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                try
                {
                    if (comboBox1.SelectedItem.ToString() == "Students" &&
                        comboBox2.SelectedItem.ToString() == "Count")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                        comboBox6.Items.Add("name equal");
                        comboBox6.Items.Add("first char in name equal ");
                        comboBox6.Items.Add("department name equal");
                        comboBox6.Items.Add("year equal");
                        comboBox6.Items.Add("year greater");
                        comboBox6.Items.Add("year smaller");
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Departments" &&
                          comboBox2.SelectedItem.ToString() == "Count")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                        comboBox6.Items.Add("name equal");
                        comboBox6.Items.Add("teacher name");
                        comboBox6.Items.Add("courses in department");
                        comboBox6.Items.Add("number of students");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Courses" &&
                        comboBox2.SelectedItem.ToString() == "Count")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                        comboBox6.Items.Add("course name");
                        comboBox6.Items.Add("teacher name");
                        comboBox6.Items.Add("duration equal");
                        comboBox6.Items.Add("duration greater");
                        comboBox6.Items.Add("duration smaller");
                        comboBox6.Items.Add("grade equal");
                        comboBox6.Items.Add("grade greater");
                        comboBox6.Items.Add("grade smaller");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Teachers" &&
                       comboBox2.SelectedItem.ToString() == "Count")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                        comboBox6.Items.Add("teacher first char");
                        comboBox6.Items.Add("teacher name");
                        comboBox6.Items.Add("salary equal");
                        comboBox6.Items.Add("salary greater");
                        comboBox6.Items.Add("salary smaller");
                        comboBox6.Items.Add("rate equal");
                        comboBox6.Items.Add("rate greater");
                        comboBox6.Items.Add("rate smaller");

                    }
                    if (comboBox1.SelectedItem.ToString() == "Students" &&
                       comboBox2.SelectedItem.ToString() == "Avg")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("years");
                        comboBox6.Items.Add("grade of all student");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Courses" &&
                        comboBox2.SelectedItem.ToString() == "Avg")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("grade");
                        comboBox6.Items.Add("duration");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Teachers" &&
                      comboBox2.SelectedItem.ToString() == "Avg")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("salary");
                        comboBox6.Items.Add("rate");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Departments" &&
                      comboBox2.SelectedItem.ToString() == "Avg")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("duration");
                        comboBox6.Items.Add("grade");

                    }
                    if (comboBox1.SelectedItem.ToString() == "Students" &&
                      comboBox2.SelectedItem.ToString() == "Sum")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Teachers" &&
                       comboBox2.SelectedItem.ToString() == "Sum")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                        comboBox6.Items.Add("salary");
                    }
                    else if (comboBox1.SelectedItem.ToString() == "Departments" &&
                      comboBox2.SelectedItem.ToString() == "Sum")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Courses" &&
                     comboBox2.SelectedItem.ToString() == "Sum")
                    {
                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("all");
                        comboBox6.Items.Add("duration");
                        comboBox6.Items.Add("grade");

                    }
                    if (comboBox1.SelectedItem.ToString() == "Students" &&
                       comboBox2.SelectedItem.ToString() == "Max")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("year");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Departments" &&
                      comboBox2.SelectedItem.ToString() == "Max")
                    {
                        MessageBox.Show("department has no max or mini");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Departments" &&
                      comboBox2.SelectedItem.ToString() == "Min")
                    {
                        MessageBox.Show("department has no max or mini");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Courses" &&
                   comboBox2.SelectedItem.ToString() == "Max")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("duration");
                        comboBox6.Items.Add("grade");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Teachers" &&
                comboBox2.SelectedItem.ToString() == "Max")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("salary");
                        comboBox6.Items.Add("rate");

                    }
                    if (comboBox1.SelectedItem.ToString() == "Students" &&
                    comboBox2.SelectedItem.ToString() == "Min")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("year");

                    }

                    else if (comboBox1.SelectedItem.ToString() == "Courses" &&
                    comboBox2.SelectedItem.ToString() == "Min")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("duration");
                        comboBox6.Items.Add("grade");

                    }
                    else if (comboBox1.SelectedItem.ToString() == "Teachers" &&
                comboBox2.SelectedItem.ToString() == "Min")
                    {

                        comboBox6.Items.Clear();
                        comboBox6.Text = "-selected-";
                        comboBox6.Items.Add("salary");
                        comboBox6.Items.Add("rate");

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("try again");
                }
            }
            string oper = comboBox2.SelectedItem.ToString();
            if (radioButton3.Checked)
            {
                if (oper == "in Range")
                {
                    panel4.Visible = true;
                    panel5.Visible = false;
                }
                else
                {
                    panel4.Visible = false;
                    panel5.Visible = true;
                }
            }
            if (radioButton1.Checked)
            {
                if (oper == "in Range")
                {
                    panel5_fromto.Visible = true;
                    panel4_value.Visible = false;
                }
                else
                {
                    panel5_fromto.Visible = false;
                    panel4_value.Visible = true;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oper = comboBox3.SelectedItem.ToString();
            if (oper == "in Range")
            {
                panel6.Visible = true;
                panel7.Visible = false;
            }
            else
            {
                panel6.Visible = false;
                panel7.Visible = true;
            }
        }

        private void panel_aggregate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void aggregate()
        {
            string ch = comboBox2.SelectedItem.ToString();
            try
            {
                if (ch.Equals("Count"))
                {
                    count();
                }
                else if (ch.Equals("Avg"))
                {
                    avg();
                }
                else if (ch.Equals("Sum"))
                {
                    sum();
                }
                else if (ch.Equals("Max"))
                {
                    max();
                }
                else if (ch.Equals("Min"))
                {
                    mini();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("try by right way plz XD");
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void count()
        {

            int counter = 0;
            if (comboBox1.SelectedItem.ToString() == "Students")
            {
               
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                    counter = sdict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "name equal")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    foreach (KeyValuePair<string, student> std in sdict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 1;
                            break;
                        }        
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                    
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "first char in name equal ")
                {
                    counter = 0;
                   char name = textBox1.Text[0];
                    foreach (KeyValuePair<string, student> std in sdict)
                    {
                      
                        if (std.Value.name.ToString()[0] == name)
                        {
                            counter = counter + 1;
                            
                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "department name equal")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    foreach (KeyValuePair<string, department> std in ddict)
                    {

                        if (std.Value.name.ToString() == name)
                        {
                            counter =  5;
                            break;
                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "year equal")
                {
                    counter = 0;
                    int name = int .Parse(textBox1.Text);
                    foreach (KeyValuePair<string, student> std in sdict)
                    {

                        if (std.Value.year == name)
                        {
                            counter = counter + 1;
                            
                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "year greater")
                {
                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, student> std in sdict)
                    {

                        if (std.Value.year > name)
                        {
                            counter = counter + 1;
                        }
                        
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "year smaller")
                {
                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, student> std in sdict)
                    {

                        if (std.Value.year < name)
                        {
                            counter = counter + 1;
                           
                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }

            }



            else if (comboBox1.SelectedItem.ToString() == "Departments")
            {
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                    counter = ddict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
               else if (comboBox6.SelectedItem.ToString() == "name equal")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    foreach (KeyValuePair<string, department> std in ddict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 1;
                            break;
                        }
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                  
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "teacher name")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 2;
                            break;
                        }
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                   
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "courses in department")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    foreach (KeyValuePair<string, department> std in ddict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 1;
                            break;
                        }
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "number of students")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    foreach (KeyValuePair<string, department> std in ddict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 5;
                            break;
                        }
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }


            }

            else if (comboBox1.SelectedItem.ToString() == "Courses")
            {
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                    counter = cdict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "course name")
                {
                    counter = 0;
                    string name = textBox1.Text.ToString();
                    foreach (KeyValuePair<string, course> std in cdict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 1;
                            break;
                        }
                    }
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "teacher name")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 2;
                            break;
                        }
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "duration equal") {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.duration == name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "duration greater")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.duration > name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "duration smaller")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.duration  < name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "grade equal")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.grade == name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "grade greater")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.grade > name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "grade smaller")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.grade < name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
            }


            else if (comboBox1.SelectedItem.ToString() == "Teachers")
            {
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }
                    counter = tdict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "teacher first char")
                {
                    counter = 0;
                    char name = textBox1.Text[0];
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.name.ToString()[0] == name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "teacher name")
                {
                    counter = 0;
                    string name = textBox1.Text;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();

                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {
                        if (std.Value.name.ToString() == name)
                        {
                            counter = 2;
                            break;
                        }
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "salary equal")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.salary == name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "salary greater")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.salary > name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "salary smaller")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.salary < name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "rate equal")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.rate == name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "rate greater")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.rate > name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "rate smaller")
                {

                    counter = 0;
                    int name = int.Parse(textBox1.Text);
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.rate < name)
                        {
                            counter = counter + 1;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("count", "count");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }

            }

        }
        public void avg()
        {
            int sum = 0;
            int num = 0;
            double avg = 0;
            if (comboBox1.SelectedItem.ToString() == "Students")
            {
                 if (comboBox6.SelectedItem.ToString() == "years")
                {

                     sum = 0;
                     num = 0;
                     avg = 0;
             
                    foreach (KeyValuePair<string, student> std in sdict)
                    {

                        sum = sum + std.Value.year;
                    }
                    num = sdict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = sum / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "grade of all student")
                {

                    sum = 0;
                     num = 0;
                    avg = 0;
                  
                    int i = 0;
                    
                    foreach (KeyValuePair<string, student> std in sdict)
                    {

                        List<string> co = new List<string>();

                        co.Add(""+i+1);
                        i = i + 1;
                        co.Add("" + i + 1);
                        i = i + 1;
                        co.Add("" + i + 1);
                        i = i + 1;
                        co.Add("" + i + 1);
                    
                        foreach (KeyValuePair<string, course> c in cdict)
                        {
                            if (co.Contains(c.Value.id))
                            {
                                sum = sum + c.Value.grade;
                            }
                        } }
                    num = sdict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = sum / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Departments")
            {
                if (comboBox6.SelectedItem.ToString() == "duration")
                {

                     sum = 0;
                   num = 0;
                   avg = 0;


                    foreach (KeyValuePair<string, course> std in cdict)
                    {
                        sum = sum + std.Value.duration;
                    }
                    num = ddict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = sum / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "grade")
                {

                    sum = 0;
                   num = 0;
                     avg = 0;


                    foreach (KeyValuePair<string, course> std in cdict)
                    {
                        sum = sum + std.Value.grade;
                    }
                    num = ddict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = sum / num;
                     string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Courses")
            {
                 if (comboBox6.SelectedItem.ToString() == "duration")
                {

                   sum = 0;
                     num = 0;
                     avg = 0;
                    

                    foreach (KeyValuePair<string,course> std in cdict)
                    {
                        sum = sum + std.Value.duration;
                    }
                    num = cdict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = sum / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
               else if (comboBox6.SelectedItem.ToString() == "grade")
                {

                   sum = 0;
                     num = 0;
                   avg = 0;


                    foreach (KeyValuePair<string, course> std in cdict)
                    {
                        sum = sum + std.Value.grade;
                    }
                    num = cdict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = sum / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Teachers")
            {
                if (comboBox6.SelectedItem.ToString() == "salary")
                {

                     double l = 0;
                   num = 0;
                    avg = 0;


                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {
                       l = l + std.Value.salary;
                    }
                    num = tdict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = l / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
                if (comboBox6.SelectedItem.ToString() == "rate")
                {

                    double l = 0;
                    num = 0;
                    avg = 0;


                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {
                        l = l + std.Value.rate;
                    }
                    num = tdict.Count;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("avg", "avg");

                    }
                    if (num != 0)
                        avg = l / num;
                    string show = "" + avg;
                    dataGridView1.Rows.Add(show);

                }
            }
        }
        public void sum()
        {
            int counter = 0;

            if (comboBox1.SelectedItem.ToString() == "Students")
            {

                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }
                    counter = sdict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }

            }
            else if (comboBox1.SelectedItem.ToString() == "Departments")
            {
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }
                    counter = ddict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Courses")
            {
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }
                    counter = cdict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "duration") {
                    counter = 0;
                    
                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                       
                            counter = counter +std.Value.duration ;

                        
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }
                else if (comboBox6.SelectedItem.ToString() == "grade")
                {
                    counter = 0;
            
                    foreach (KeyValuePair<string, course> std in cdict)
                    {


                        counter = counter + std.Value.grade;


                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }

                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);

                }

            }

        
            else if (comboBox1.SelectedItem.ToString() == "Teachers")
            {
                if (comboBox6.SelectedItem.ToString() == "all")
                {
                    counter = 0;
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }
                    counter = tdict.Count;
                    string show = "" + counter;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "salary")
                {
                    double d = 0;
                    
                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        d= d + std.Value.salary;

                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("sum", "sum");

                    }

                    string show = "" + d;
                    dataGridView1.Rows.Add(show);
                }
            }


        }
        public void max()
        {
            int max = 0;
            if (comboBox1.SelectedItem.ToString() == "Students") { 
            if (comboBox6.SelectedItem.ToString() == "year")
            {
                max = 0;
       
                foreach (KeyValuePair<string, student> std in sdict)
                {

                    if (std.Value.year > max)
                    {
                            max = std.Value.year;

                    }
                }

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                if (dataGridView1.ColumnCount == 0)
                {
                    dataGridView1.Columns.Add("max", "max");

                }

                string show = "" + max;
                dataGridView1.Rows.Add(show);
            }
        }
        
        else if (comboBox1.SelectedItem.ToString() == "Courses")
                {
                if (comboBox6.SelectedItem.ToString() == "duration")
                {
                    max = 0;

                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.duration > max)
                        {
                            max = std.Value.duration;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("max", "max");

                    }

                    string show = "" + max;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "grade")
                {
                    max = 0;

                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.grade > max)
                        {
                            max = std.Value.grade;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("max", "max");

                    }

                    string show = "" + max;
                    dataGridView1.Rows.Add(show);
                }
            }   
        else if (comboBox1.SelectedItem.ToString() == "Teachers")
        {
                if (comboBox6.SelectedItem.ToString() == "salary")
                {
                    double l = 0;

                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.salary > l)
                        {
                          l =  std.Value.salary;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("max", "max");

                    }

                    string show = "" + l;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "rate")
                {
                    double l = 0;

                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.rate > l)
                        {
                            l = std.Value.rate;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("max", "max");

                    }

                    string show = "" + l;
                    dataGridView1.Rows.Add(show);
                }

            }

        }
        public void mini()
        {
            int mini=1000000000;
            if (comboBox1.SelectedItem.ToString() == "Students")
            {
                if (comboBox6.SelectedItem.ToString() == "year")
                {
                    mini = 1000000000;

                    foreach (KeyValuePair<string, student> std in sdict)
                    {

                        if (std.Value.year < mini)
                        {
                            mini = std.Value.year;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("mini", "mini");

                    }

                    string show = "" + mini;
                    dataGridView1.Rows.Add(show);
                }
            }

            else if (comboBox1.SelectedItem.ToString() == "Courses")
            {
                if (comboBox6.SelectedItem.ToString() == "duration")
                {
                    mini = 1000000000;

                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.duration < mini)
                        {
                            mini = std.Value.duration;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("mini", "mini");

                    }

                    string show = "" + mini;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "grade")
                {
                    mini = 1000000000;

                    foreach (KeyValuePair<string, course> std in cdict)
                    {

                        if (std.Value.grade < mini)
                        {
                            mini = std.Value.grade;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("mini", "mini");

                    }

                    string show = "" + mini;
                    dataGridView1.Rows.Add(show);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Teachers")
            {
                if (comboBox6.SelectedItem.ToString() == "salary")
                {
                   
                    double l = 1000000000;

                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.salary < l)
                        {
                            l = std.Value.salary;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("max", "max");

                    }

                    string show = "" + l;
                    dataGridView1.Rows.Add(show);
                }
                else if (comboBox6.SelectedItem.ToString() == "rate")
                {
                    double l = 1000000000;

                    foreach (KeyValuePair<string, teacher> std in tdict)
                    {

                        if (std.Value.rate < l)
                        {
                            l = std.Value.rate;

                        }
                    }

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("max", "max");

                    }

                    string show = "" + l;
                    dataGridView1.Rows.Add(show);
                }

            }
        }
      

        public void comparsion()
        {
            dataGridView1.Rows.Clear();
            string table = comboBox1.SelectedItem.ToString();
            string operation = comboBox2.SelectedItem.ToString();
            string value = textBox2.Text.ToString();
            string inrange_from = textBox9.ToString();
            string inrange_to = textBox8.ToString();
            string column = comboBox4.SelectedItem.ToString();
            student std = new student();
            department departmen = new department();
            teacher teach = new teacher();
            course cour = new course();
            Dictionary<string, student> students = new Dictionary<string, student>();
            Dictionary<string, department> departments = new Dictionary<string, department>();
            Dictionary<string, teacher> teachers = new Dictionary<string, teacher>();
            Dictionary<string, course> coursess = new Dictionary<string, course>();

            try
            {

                dataGridView1.Rows.Clear();
              
                //comparison
                if (radioButton1.Checked)
                {


                    switch (operation)
                    {

                        // begaining of equalization case 
                        case "Equal":
                            {

                                dataGridView1.Rows.Clear();

                                if (comboBox1.SelectedItem.ToString() == "Students")// student equalization
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("student.xml");


                                    XmlNodeList list = doc.GetElementsByTagName("student");
                                    std.readstudent(students);
                                    switch (column) //checking columns 
                                    {
                                        case "id":

                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                if (value.Equals(students.ElementAt(i).Value.id.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (value.Equals(students.ElementAt(i).Value.name.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "department":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (value.Equals(students.ElementAt(i).Value.department_id.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "year":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (value.Equals(students.ElementAt(i).Value.year.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;
                                    }

                                } // end of student equalization 

                                ///////////////////////////////////////////////////////////////////////////////////

                                    //// teachers
                                else if (comboBox1.SelectedItem.ToString() == "Teachers")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("teachers.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("Teachers");
                                    teach.readteacher(teachers);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (value.Equals(teachers.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (value.Equals(teachers.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "courses":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (value.Equals(teachers.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }
                                                else if (value.Equals(teachers.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "salary":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (value.Equals(teachers.ElementAt(i).Value.salary.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                        case "rate":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (value.Equals(teachers.ElementAt(i).Value.rate.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                    }//end of switch case of teachers 
                                } // end of teachers in equaliztion 


                                    /////////////////////////////////////////////////////////////////////////////////////////////

                                    // begaining of   departments equaliztion
                                else if (comboBox1.SelectedItem.ToString() == "Departments")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("departments.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("department");
                                    departmen.readdepartment(departments);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (value.Equals(departments.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (value.Equals(departments.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "courses ID":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (value.Equals(departments.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[1]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[2].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[2]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[3].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "number of studens":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (value.Equals(departments.ElementAt(i).Value.no_of_student.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                    }//end of switch case for department
                                }// end of departments in equalization 

                                    //////////////////////////////////////////////////////////////////////////////////////////////////

                                    //courses equalization
                                else if (comboBox1.SelectedItem.ToString() == "Courses")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("courses.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("courses");
                                    cour.readcourse(coursess);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (value.Equals(coursess.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (value.Equals(coursess.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "teacher ID":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (value.Equals(coursess.ElementAt(i).Value.teacher_id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Duration":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (value.Equals(coursess.ElementAt(i).Value.duration.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Grade":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (value.Equals(coursess.ElementAt(i).Value.grade.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;
                                    }// end of switch case for courses 
                                }// end of courses equalization

                                break;
                            }// end of the whole equalization


                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

                        //begaining of not equal statement
                        case "Not Equal":
                            {
                                dataGridView1.Rows.Clear();

                                if (comboBox1.SelectedItem.ToString() == "Students")// student 
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("student.xml");


                                    XmlNodeList list = doc.GetElementsByTagName("student");
                                    std.readstudent(students);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                if (!value.Equals(students.ElementAt(i).Value.id.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (!value.Equals(students.ElementAt(i).Value.name.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "department":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (!value.Equals(students.ElementAt(i).Value.department_id.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "year":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (!value.Equals(students.ElementAt(i).Value.year.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;
                                    }

                                } // end of student

                                    /////////////////////////////////////////////////////////

                                    //// teachers
                                else if (comboBox1.SelectedItem.ToString() == "Teachers")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("teachers.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("Teachers");
                                    teach.readteacher(teachers);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (!value.Equals(teachers.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (!value.Equals(teachers.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "courses":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (!value.Equals(teachers.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }
                                                if (!value.Equals(teachers.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "salary":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (!value.Equals(teachers.ElementAt(i).Value.salary.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                        case "rate":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (!value.Equals(teachers.ElementAt(i).Value.rate.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                    }//end of switch case of teachers 
                                } // end of teachers 

                                    ////////////////////////////////////////////////////////////////////

                                     // begaining of   departments 

                                else if (comboBox1.SelectedItem.ToString() == "Departments")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("departments.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("department");
                                    departmen.readdepartment(departments);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (!value.Equals(departments.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (!value.Equals(departments.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "courses ID":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (!value.Equals(departments.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]);
                                                }
                                                if (!value.Equals(departments.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[1]);
                                                }
                                                if (!value.Equals(departments.ElementAt(i).Value.course[2].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[2]);
                                                }
                                                if (!value.Equals(departments.ElementAt(i).Value.course[3].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "number of studens":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (!value.Equals(departments.ElementAt(i).Value.no_of_student.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                    }//end of switch case for department
                                }// end of departments 

                                    /////////////////////////////////////////////////////////////////////////////////////

                                    //courses
                                else if (comboBox1.SelectedItem.ToString() == "Courses")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("courses.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("courses");
                                    cour.readcourse(coursess);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (!value.Equals(coursess.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (!value.Equals(coursess.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "teacher ID":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (!value.Equals(coursess.ElementAt(i).Value.teacher_id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Duration":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (!value.Equals(coursess.ElementAt(i).Value.duration.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Grade":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (!value.Equals(coursess.ElementAt(i).Value.grade.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;
                                    }// end of switch case for courses 
                                }// end of courses 

                                break;
                            }//end of not equal 


                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        //begaining of larger than statment
                        case "Larger Than":
                            {
                                dataGridView1.Rows.Clear();

                                if (comboBox1.SelectedItem.ToString() == "Students")  // student 
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("student.xml");


                                    XmlNodeList list = doc.GetElementsByTagName("student");
                                    std.readstudent(students);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(students.ElementAt(i).Value.id))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(students.ElementAt(i).Value.name.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "department":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (int.Parse(value) < int.Parse(students.ElementAt(i).Value.department_id))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "year":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (int.Parse(value) < int.Parse(students.ElementAt(i).Value.year.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;
                                    }

                                } // end of student

                                    ////////////////////////////////////////////////////////////////////////////////////////

                                    //// teachers
                                else if (comboBox1.SelectedItem.ToString() == "Teachers")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("teachers.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("Teachers");
                                    teach.readteacher(teachers);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(teachers.ElementAt(i).Value.id))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(teachers.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "courses":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(teachers.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }
                                                else if (value.Equals(teachers.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "salary":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(teachers.ElementAt(i).Value.salary.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                        case "rate":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (double.Parse(value) < double.Parse(teachers.ElementAt(i).Value.rate.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                    }//end of switch case of teachers 
                                } // end of teachers 

                                    ////////////////////////////////////////////////////////////////////////////////////////

                                else if (comboBox1.SelectedItem.ToString() == "Departments") // begaining of   departments 
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("departments.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("department");
                                    departmen.readdepartment(departments);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(departments.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(departments.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "courses ID":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(departments.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[1]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[2].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[2]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[3].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "number of studens":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(departments.ElementAt(i).Value.no_of_student.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                    }//end of switch case for department
                                }// end of departments 

                                    /////////////////////////////////////////////////////////////////////////////////////////////

                                    //courses
                                else if (comboBox1.SelectedItem.ToString() == "Courses")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("courses.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("courses");
                                    cour.readcourse(coursess);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(coursess.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(coursess.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "teacher ID":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(coursess.ElementAt(i).Value.teacher_id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Duration":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(coursess.ElementAt(i).Value.duration.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Grade":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(value) < int.Parse(coursess.ElementAt(i).Value.grade.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;
                                    }// end of switch case for courses 
                                }// end of courses 


                                break;
                            }// end of larger than statment 

                        /////////////////////////////////////////////////////////////////////////////////////

                        case "Smaller Than":
                            {
                                dataGridView1.Rows.Clear();

                                if (comboBox1.SelectedItem.ToString() == "Students")// student equalization
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("student.xml");


                                    XmlNodeList list = doc.GetElementsByTagName("student");
                                    std.readstudent(students);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(students.ElementAt(i).Value.id))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(students.ElementAt(i).Value.name.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "department":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (int.Parse(value) > int.Parse(students.ElementAt(i).Value.department_id))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "year":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (int.Parse(value) > int.Parse(students.ElementAt(i).Value.year.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;
                                    }

                                } // end of student 

                                    ///////////////////////////////////////////////////////////

                                    //// teachers
                                else if (comboBox1.SelectedItem.ToString() == "Teachers")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("teachers.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("Teachers");
                                    teach.readteacher(teachers);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(teachers.ElementAt(i).Value.id))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(teachers.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "courses":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(teachers.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }
                                                else if (value.Equals(teachers.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "salary":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(teachers.ElementAt(i).Value.salary.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                        case "rate":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (double.Parse(value) > double.Parse(teachers.ElementAt(i).Value.rate.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                    }//end of switch case of teachers 
                                } // end of teachers  

                                    /////////////////////////////////////////////////////////////

                                else if (comboBox1.SelectedItem.ToString() == "Departments") // begaining of   departments 
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("departments.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("department");
                                    departmen.readdepartment(departments);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(departments.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(departments.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "courses ID":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(departments.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[1]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[2].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[2]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[3].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "number of studens":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(departments.ElementAt(i).Value.no_of_student.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                    }//end of switch case for department
                                }// end of departments 

                                    //////////////////////////////////////////////////////////////////////////////

                                else if (comboBox1.SelectedItem.ToString() == "Courses")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("courses.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("courses");
                                    cour.readcourse(coursess);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(coursess.ElementAt(i).Value.id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(coursess.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "teacher ID":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(coursess.ElementAt(i).Value.teacher_id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Duration":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(coursess.ElementAt(i).Value.duration.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Grade":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(value) > int.Parse(coursess.ElementAt(i).Value.grade.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;
                                    }// end of switch case for courses 
                                }// end of courses 
                                break;
                            }// the end of the whole smaller than statment 


                        //////////////////////////////////////////////////////////////////////////////////////////

                        // in range statement
                        case "in Range":
                            {
                                dataGridView1.Rows.Clear();

                                if (comboBox1.SelectedItem.ToString() == "Students")  // student 
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("student.xml");


                                    XmlNodeList list = doc.GetElementsByTagName("student");
                                    std.readstudent(students);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(students.ElementAt(i).Value.id) && int.Parse(students.ElementAt(i).Value.id) < int.Parse(inrange_to))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < students.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(students.ElementAt(i).Value.name.ToString()))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "department":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (int.Parse(inrange_from) < int.Parse(students.ElementAt(i).Value.department_id) && int.Parse(students.ElementAt(i).Value.department_id) < int.Parse(inrange_to))
                                                {

                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;

                                        case "year":
                                            for (int i = 0; i < students.Count; i++)
                                            {

                                                if (int.Parse(inrange_from) < int.Parse(students.ElementAt(i).Value.year.ToString()) && int.Parse(students.ElementAt(i).Value.year.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(students.ElementAt(i).Value.id
                                                        , students.ElementAt(i).Value.name
                                                        , students.ElementAt(i).Value.department_id
                                                        , students.ElementAt(i).Value.year);
                                                }
                                            }
                                            break;
                                    }

                                } // end of student

                                    ////////////////////////////////////////////////////////////////////////////////////////

                                    //// teachers
                                else if (comboBox1.SelectedItem.ToString() == "Teachers")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("teachers.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("Teachers");
                                    teach.readteacher(teachers);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(teachers.ElementAt(i).Value.id) && int.Parse(teachers.ElementAt(i).Value.id) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(teachers.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "courses":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(teachers.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }
                                                else if (value.Equals(teachers.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;

                                        case "salary":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(teachers.ElementAt(i).Value.salary.ToString()) && int.Parse(teachers.ElementAt(i).Value.salary.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                        case "rate":
                                            for (int i = 0; i < teachers.Count; i++)
                                            {
                                                if (double.Parse(inrange_from) < double.Parse(teachers.ElementAt(i).Value.rate.ToString()) && double.Parse(teachers.ElementAt(i).Value.rate.ToString()) < double.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(teachers.ElementAt(i).Value.id
                                                        , teachers.ElementAt(i).Value.name
                                                        , teachers.ElementAt(i).Value.course[0]
                                                        , teachers.ElementAt(i).Value.course[1]
                                                        , teachers.ElementAt(i).Value.salary
                                                        , teachers.ElementAt(i).Value.rate);
                                                }

                                            }
                                            break;
                                    }//end of switch case of teachers 
                                } // end of teachers 

                                    ////////////////////////////////////////////////////////////////////////////////////////

                                else if (comboBox1.SelectedItem.ToString() == "Departments") // begaining of   departments 
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("departments.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("department");
                                    departmen.readdepartment(departments);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(departments.ElementAt(i).Value.id.ToString()) && int.Parse(departments.ElementAt(i).Value.id.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(departments.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "courses ID":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(departments.ElementAt(i).Value.course[0].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[1].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[1]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[2].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[2]);
                                                }
                                                else if (value.Equals(departments.ElementAt(i).Value.course[3].ToString()))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                        case "number of studens":
                                            for (int i = 0; i < departments.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(departments.ElementAt(i).Value.no_of_student.ToString()) && int.Parse(departments.ElementAt(i).Value.no_of_student.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(departments.ElementAt(i).Value.id
                                                        , departments.ElementAt(i).Value.name
                                                        , departments.ElementAt(i).Value.no_of_student
                                                        , departments.ElementAt(i).Value.course[0]
                                                        , departments.ElementAt(i).Value.course[1]
                                                        , departments.ElementAt(i).Value.course[2]
                                                        , departments.ElementAt(i).Value.course[3]);
                                                }
                                            }
                                            break;

                                    }//end of switch case for department
                                }// end of departments 

                                    /////////////////////////////////////////////////////////////////////////////////////////////

                                    //courses
                                else if (comboBox1.SelectedItem.ToString() == "Courses")
                                {
                                    XmlDocument doc = new XmlDocument();
                                    doc.Load("courses.xml");
                                    XmlNodeList list = doc.GetElementsByTagName("courses");
                                    cour.readcourse(coursess);
                                    switch (column)
                                    {
                                        case "id":

                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(coursess.ElementAt(i).Value.id.ToString()) && int.Parse(coursess.ElementAt(i).Value.id.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }

                                            break;

                                        case "name":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(coursess.ElementAt(i).Value.name.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "teacher ID":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                MessageBox.Show("this operation is not valid for this column !!");
                                                break;
                                                if (value.Equals(coursess.ElementAt(i).Value.teacher_id.ToString()))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Duration":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(coursess.ElementAt(i).Value.duration.ToString()) && int.Parse(coursess.ElementAt(i).Value.duration.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;

                                        case "Grade":
                                            for (int i = 0; i < coursess.Count; i++)
                                            {
                                                if (int.Parse(inrange_from) < int.Parse(coursess.ElementAt(i).Value.grade.ToString()) && int.Parse(coursess.ElementAt(i).Value.grade.ToString()) < int.Parse(inrange_to))
                                                {
                                                    dataGridView1.Rows.Add(coursess.ElementAt(i).Value.id
                                                        , coursess.ElementAt(i).Value.name
                                                        , coursess.ElementAt(i).Value.teacher_id
                                                        , coursess.ElementAt(i).Value.duration
                                                        , coursess.ElementAt(i).Value.grade);
                                                }
                                            }
                                            break;
                                    }// end of switch case for courses 
                                }

                                break;
                            }// end of the whole "in range" statment 


                    }


                }


            }
            catch (Exception)
            { MessageBox.Show("Error try again please"); }


        }
    
    public void Boolean()
        {
           
           
     try
      {
          dataGridView1.Rows.Clear();
          string selctedcolumn;
          string selctedcolumn2;
          selctedcolumn = comboBox4.SelectedItem.ToString();
          selctedcolumn2 = comboBox5.SelectedItem.ToString();
          string checkdepid = " ";
         /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //table student
          if (comboBox1.SelectedItem.ToString() == "Students")
                {


                    //OR condition
                    if (radioButton5.Checked)
                    {
                        //year or dep name
                        if (selctedcolumn == "year" && selctedcolumn2 == "department name")
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.year.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.year.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }

                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Not Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.year.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.year.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }
                            }
                        }

                        //dep or dep name
                        if (selctedcolumn == "department" && selctedcolumn2 == "department name")
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }

                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.department_id.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.department_id.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }

                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Not Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.department_id.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.department_id.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }
                            }
                        }

                        //name or dep name
                        if (selctedcolumn == "name" && selctedcolumn2 == "department name")
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.name.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.name.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }

                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Not Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.name.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.name.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }
                            }
                        }

                        //id or dep name
                        if (selctedcolumn == "id" && selctedcolumn2 == "department name")
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.id.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.id.ToString() == textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }

                                //first combo
                                if (comboBox2.SelectedItem.ToString() == "Not Equal")
                                {
                                    //second combo
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        //second condition or first condition
                                        if ((std.Value.department_id.ToString() == checkdepid) || std.Value.id.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    //second combo
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if ((std.Value.department_id.ToString() != checkdepid) || std.Value.id.ToString() != textBox7.Text)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //AND condition
                    /////////////////////////////////////
                    

                  if (comboBox2.SelectedItem.ToString() == "Equal")
                    {
                        //column year
                        if (selctedcolumn == "year" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }


                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.year.ToString() == textBox7.Text)
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }

                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }

                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }

                                   
                                }


                            }

                        }

                        //column dep_id
                        if (selctedcolumn == "department" && selctedcolumn2 == "department name" && radioButton4.Checked)
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.department_id.ToString() == textBox7.Text)
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }


                                    else  if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }


                                }

                            }
                        }

                        //column st_name
                        if (selctedcolumn == "name" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.name.ToString() == textBox7.Text)
                                {

                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }

                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }

                        //column std_id
                        if (selctedcolumn == "id" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                           foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.id.ToString() == textBox7.Text)
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }

                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }

                    }
               else if (comboBox2.SelectedItem.ToString() == "Not Equal")
                     {
                         //column year
                         if (selctedcolumn == "year" && selctedcolumn2 == "department name" && radioButton4.Checked )
                         {
                             foreach (KeyValuePair<string, department> dep in ddict)
                             {
                                 if (dep.Value.name.ToString() == textBox10.Text)
                                 {
                                     checkdepid = dep.Value.id.ToString();
                                 }
                             }
                             foreach (KeyValuePair<string, student> std in sdict)
                             {


                                 if (std.Value.year.ToString() != textBox7.Text)
                                 {
                                     if (comboBox3.SelectedItem.ToString() == "Equal")
                                     {
                                         if (std.Value.department_id.ToString() == checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }
                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                     {
                                         if (std.Value.department_id.ToString() != checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                 }

                             }

                         }


                         //column dep_id
                         if (selctedcolumn == "department" && selctedcolumn2 == "department name" && radioButton4.Checked )
                         {
                             foreach (KeyValuePair<string, department> dep in ddict)
                             {
                                 if (dep.Value.name.ToString() == textBox10.Text)
                                 {
                                     checkdepid = dep.Value.id.ToString();
                                 }
                             }
                             foreach (KeyValuePair<string, student> std in sdict)
                             {


                                 if (std.Value.department_id.ToString() != textBox7.Text)
                                 {
                                     if (comboBox3.SelectedItem.ToString() == "Equal")
                                     {
                                         if (std.Value.department_id.ToString() == checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }
                                     }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                     {
                                         if (std.Value.department_id.ToString() != checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                 }

                             }
                         }
                         //column st_name
                         if (selctedcolumn == "name" && selctedcolumn2 == "department name" && radioButton4.Checked )
                         {
                             foreach (KeyValuePair<string, department> dep in ddict)
                             {
                                 if (dep.Value.name.ToString() == textBox10.Text)
                                 {
                                     checkdepid = dep.Value.id.ToString();
                                 }
                             }
                             foreach (KeyValuePair<string, student> std in sdict)
                             {


                                 if (std.Value.name.ToString() != textBox7.Text)
                                 {
                                     if (comboBox3.SelectedItem.ToString() == "Equal")
                                     {
                                         if (std.Value.department_id.ToString() == checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }
                                     }

                                     else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                     {
                                         if (std.Value.department_id.ToString() != checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }

                                 }

                             }
                         }

                         //column std_id
                         if (selctedcolumn == "id" && selctedcolumn2 == "department name" && radioButton4.Checked )
                         {
                             foreach (KeyValuePair<string, department> dep in ddict)
                             {
                                 if (dep.Value.name.ToString() == textBox10.Text)
                                 {
                                     checkdepid = dep.Value.id.ToString();
                                 }
                             }
                             foreach (KeyValuePair<string, student> std in sdict)
                             {


                                 if (std.Value.id.ToString() != textBox7.Text)
                                 {
                                     if (comboBox3.SelectedItem.ToString() == "Equal")
                                     {
                                         if (std.Value.department_id.ToString() == checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }
                                     }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                     {
                                         if (std.Value.department_id.ToString() != checkdepid)
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                     else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                     {
                                         if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                         {
                                             dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                         }

                                     }
                                 }

                             }
                         }
                     }
               else if (comboBox2.SelectedItem.ToString() == "Larger Than")
                    {
                        //column year
                        if (selctedcolumn == "year" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.year > int.Parse(textBox7.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }

                        }


                        //column dep_id
                        if (selctedcolumn == "department" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (int.Parse(std.Value.department_id) > int.Parse(textBox7.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }

                        //column st_name
                        if (selctedcolumn == "name" && selctedcolumn2 == "department name")
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                int var=0;

                                var = string.Compare(textBox7.Text.ToString(), std.Value.name.ToString());
                                if (comboBox3.SelectedItem.ToString() == "Equal")
                                {
                                    if (var == -1 && std.Value.department_id.ToString() == checkdepid)
                                    {

                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);

                                    }
                                }
                                else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                {
                                    if (var == -1 && std.Value.department_id.ToString() != checkdepid)
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                {
                                    if (var == -1 && int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }

                                else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                {
                                    if (var == -1 && int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                            }
                        }
                        //column std_id
                        if (selctedcolumn == "id" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (int.Parse(std.Value.id.ToString()) > int.Parse(textBox7.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                }
                                else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                {
                                    if (std.Value.department_id.ToString() != checkdepid)
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                {
                                    if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                {
                                    if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }

                            }
                        }

                    }
               else if (comboBox2.SelectedItem.ToString() == "Smaller Than")
                    {
                        //column year
                        if (selctedcolumn == "year" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.year < int.Parse(textBox7.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }

                        }

                        //column dep_id
                        if (selctedcolumn == "department" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (int.Parse(std.Value.department_id) < int.Parse(textBox7.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }

                        //column st_name
                        if (selctedcolumn == "name" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                int var = 0;

                                var = string.Compare(textBox7.Text.ToString(), std.Value.name.ToString());
                                if (comboBox3.SelectedItem.ToString() == "Equal")
                                {
                                    if (var == 1 && std.Value.department_id.ToString() == checkdepid)
                                    {

                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);

                                    }
                                }
                                else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                {
                                    if (var == 1 && std.Value.department_id.ToString() != checkdepid)
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                {
                                    if (var == 1 && int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                {
                                    if (var == 1 && int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }

                            }
                        }

                        //column std_id
                        if (selctedcolumn == "id" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (int.Parse(std.Value.id.ToString()) < int.Parse(textBox7.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }
                    }
               else if (comboBox2.SelectedItem.ToString() == "in Range")
                    {
                        //column year
                        if (selctedcolumn == "year" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (std.Value.year > int.Parse(textBox6.Text) && std.Value.year < int.Parse(textBox5.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }

                        }


                        //column dep_id
                        if (selctedcolumn == "department" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (int.Parse(std.Value.department_id) > int.Parse(textBox6.Text) && int.Parse(std.Value.department_id) < int.Parse(textBox5.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }

                        //column st_name
                        if (selctedcolumn == "name" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {
                                int var_from = 0;
                                int var_to = 0;
                                var_from = string.Compare(textBox6.Text.ToString(), std.Value.name.ToString());
                                var_to = string.Compare(textBox5.Text.ToString(), std.Value.name.ToString());
                                if (comboBox3.SelectedItem.ToString() == "Equal")
                                {
                                    if (var_from == -1 && var_to == 1 && std.Value.department_id.ToString() == checkdepid)
                                    {

                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);

                                    }
                                }
                                else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                {
                                    if (var_from == -1 && var_to == 1 && std.Value.department_id.ToString() != checkdepid)
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                {
                                    if ((var_from == -1 && var_to == 1 && (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }
                                else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                {
                                    if ((var_from == -1 && var_to == 1 && (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))))
                                    {
                                        dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                    }

                                }

                            }
                        }


                        //column std_id
                        if (selctedcolumn == "id" && selctedcolumn2 == "department name" && radioButton4.Checked )
                        {
                            foreach (KeyValuePair<string, department> dep in ddict)
                            {
                                if (dep.Value.name.ToString() == textBox10.Text)
                                {
                                    checkdepid = dep.Value.id.ToString();
                                }
                            }
                            foreach (KeyValuePair<string, student> std in sdict)
                            {


                                if (int.Parse(std.Value.id.ToString()) > int.Parse(textBox6.Text) && int.Parse(std.Value.id.ToString()) < int.Parse(textBox5.Text))
                                {
                                    if (comboBox3.SelectedItem.ToString() == "Equal")
                                    {
                                        if (std.Value.department_id.ToString() == checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }
                                    }
                                    else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                                    {
                                        if (std.Value.department_id.ToString() != checkdepid)
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                       else if (comboBox3.SelectedItem.ToString() == "Larger Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) > int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                      else if (comboBox3.SelectedItem.ToString() == "Smaller Than")
                                    {
                                        if (int.Parse(std.Value.department_id.ToString()) < int.Parse(checkdepid))
                                        {
                                            dataGridView1.Rows.Add(std.Value.id, std.Value.name, std.Value.department_id, std.Value.year);
                                        }

                                    }
                                }

                            }
                        }

                    }

                }
         /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         //table courses
          if (comboBox1.SelectedItem.ToString() == "Courses")
          {

              if (comboBox2.SelectedItem.ToString() == "Equal")
              {
                  //column cour_id
                  if (selctedcolumn == "id" && selctedcolumn2 == "teacher name" && radioButton4.Checked)
                  {
                      foreach (KeyValuePair<string, teacher> tea in tdict)
                      {

                          if (tea.Value.name.ToString().Equals(textBox10.Text))
                          {
                              checkdepid = tea.Value.id.ToString();
                          }


                      }
                      foreach (KeyValuePair<string, course> cour in cdict)
                      {


                          if (cour.Value.id.ToString() == textBox7.Text)
                          {
                              if (comboBox3.SelectedItem.ToString() == "Equal")
                              {
                                  if (cour.Value.teacher_id.ToString() == checkdepid)
                                  {
                                      dataGridView1.Rows.Add(cour.Value.id, cour.Value.name, cour.Value.teacher_id, cour.Value.duration, cour.Value.grade);
                                  }
                              }

                              else if (comboBox3.SelectedItem.ToString() == "Not Equal")
                              {
                                  if (cour.Value.teacher_id.ToString() != checkdepid)
                                  {
                                      dataGridView1.Rows.Add(cour.Value.id, cour.Value.name, cour.Value.teacher_id, cour.Value.duration, cour.Value.grade);
                                  }

                              }
                          }


                      }

                  }


              }



          }



      }
     catch (Exception)
     { MessageBox.Show("Error try again please"); }

        }
    
    }

}

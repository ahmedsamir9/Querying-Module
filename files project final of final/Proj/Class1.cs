using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Proj
{
    class student
    {

        public string name, id, department_id;
        public int year;
        public Dictionary<string, student> sdict = null;
        public student() { }
        public student(string n, string i, string did, int yer)
        {
            name = n;
            id = i;
            department_id = did;
            year = yer;
        }
        public void readstudent(Dictionary<string, student> stu)
        {

            XmlDocument doc = new XmlDocument();

            doc.Load("student.xml");
            XmlNodeList list = doc.GetElementsByTagName("student");
            string sname, sid, sdepartment_id;
            int syear;
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList nodes = list[i].ChildNodes;
                sid = nodes[0].InnerText;
                sname = nodes[1].InnerText;
                sdepartment_id = nodes[2].InnerText;
                syear = int.Parse(nodes[3].InnerText);
                stu.Add(sid, new student(sname, sid, sdepartment_id, syear));
            }

        }
      

    }

    class department
    {
        public string name, id;
        public int no_of_student;
        public List<string> course;
        public department()
        {
            course = new List<string>();
        }
        department(string s, string n, int k, List<string> c)
        {
            id = s;
            name = n;
            no_of_student = k;
            course = c;
        }
        public void readdepartment(Dictionary<string, department> dep)
        {
            dep.Clear();
            department depaetment = new department();
            XmlDocument doc = new XmlDocument();
            List<string> courses = new List<string>();
            doc.Load("departments.xml");
            XmlNodeList list = doc.GetElementsByTagName("department");
            string dname, did;
            int no_ofstudent;
            for (int i = 0; i < list.Count; i++)
            {
                courses = new List<string>();
                XmlNodeList nodes = list[i].ChildNodes;
                did = nodes[0].InnerText;

                dname = nodes[1].InnerText;
                no_ofstudent = int.Parse(nodes[2].InnerText);


                XmlNodeList courselist = nodes[3].ChildNodes;
                for (int j = 0; j < courselist.Count; j++)
                {

                    courses.Add(courselist[j].InnerText);
                }

                dep.Add(did, new department(did, dname, no_ofstudent, courses));

            }

        }
    }

    class course
    {
        public string name, id, teacher_id;
        public int duration, grade;
        public course() { }

        public course(string n, string i, string tei, int dur, int gra)
        {
            name = n;
            id = i;
            teacher_id = tei;
            duration = dur;
            grade = gra;
        }
        public void readcourse(Dictionary<string, course> cour)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("courses.xml");
            XmlNodeList list = doc.GetElementsByTagName("courses");
            string cname, cid, cteacherid;
            int cgrade, cduration;
            for (int i = 0; i < list.Count; i++)
            {

                XmlNodeList nodes = list[i].ChildNodes;
                cid = nodes[0].InnerText;
                cname = nodes[1].InnerText;
                cteacherid = nodes[2].InnerText;
                cduration = int.Parse(nodes[3].InnerText);
                cgrade = int.Parse(nodes[4].InnerText);
                cour.Add(cid, new course(cname, cid, cteacherid, cduration, cgrade));
            }
        }
    }
    class teacher
    {
        public string name, id;
        public double rate, salary;
        public List<string> course;
        public teacher()
        {
            course = new List<string>();
        }
        teacher(string n, string i, double ra, double sal, List<string> c)
        {
            name = n;
            id = i;
            rate = ra;
            salary = sal;
            course = c;
        }
        public void readteacher(Dictionary<string, teacher> tea)
        {

            XmlDocument doc = new XmlDocument();
            List<string> courses = new List<string>();
            doc.Load("teachers.xml");
            XmlNodeList list = doc.GetElementsByTagName("Teachers");
            string tname, tid;
            double trate, tsalary;
            for (int i = 0; i < list.Count; i++)
            {
                courses = new List<string>();
                XmlNodeList nodes = list[i].ChildNodes;
                tid = nodes[0].InnerText;

                tname = nodes[1].InnerText;
                XmlNodeList courselist = nodes[2].ChildNodes;
                for (int j = 0; j < courselist.Count; j++)
                {

                    courses.Add(courselist[j].InnerText);
                }
                tsalary = double.Parse(nodes[3].InnerText);
                trate = double.Parse(nodes[4].InnerText);
                tea.Add(tid, new teacher(tname, tid, trate, tsalary, courses));

            }

        }

    }
}

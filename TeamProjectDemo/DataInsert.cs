using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TeamProjectDemo
{
    public partial class DataInsert : Form
    {
        public static String url = "SERVER=127.0.0.1; " +
                                  "USER=root; " +
                                  "DATABASE=rank;" +
                                  "PORT=3306; " +
                                  "PASSWORD=4245; " +
                                  "SSLMODE=NONE";

        private MySqlConnection mConnection; // DB접속
        private MySqlCommand mCommand; // 쿼리문
        private MySqlDataReader mDataReader; // 실행문

        public string gradeStr;
        public int score = 527;

        public DataInsert()
        {
            InitializeComponent();
        }

        private void DataInsert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mConnection = new MySqlConnection(url); // DB접속
                mCommand = new MySqlCommand(); // 쿼리문 생성
                mCommand.Connection = mConnection; // DB에 연결

                if (score < 100)
                {
                    gradeStr = "F";
                }
                else if (score >= 100 && score < 200)
                {
                    gradeStr = "C";
                }
                else if (score >= 200 && score < 300)
                {
                    gradeStr = "C+";
                }
                else if (score >= 300 && score < 400)
                {
                    gradeStr = "B";
                }
                else if (score >= 400 && score < 500)
                {
                    gradeStr = "B+";
                }
                else if (score >= 500 && score < 600)
                {
                    gradeStr = "A";
                }
                else
                {
                    gradeStr = "A+";
                }


                mCommand.CommandText = "INSERT INTO ranking (name, score, grade) VALUES ('" + textBox1.Text + "', " + score + ",'" + gradeStr + "')"; // 쿼리문 작성

                //mCommand.CommandText = "INSERT INTO ranking VALUES ("+ count+", '" + textBox1.Text + "', 12,'12')"; // 쿼리문 작성
                mConnection.Open(); // DB 오픈
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

                mConnection.Close(); // 사용 후 객체 닫기

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
            }

            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }
    }
}

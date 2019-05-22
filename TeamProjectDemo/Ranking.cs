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
    public partial class Ranking : Form
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

        private MySqlDataAdapter mySqlDataAdapter;

        private DataTable data_table = null;

        private float fontSize = 10;


        public Ranking()
        {
            InitializeComponent();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {
            using (Font fnt = new Font(this.label2.Font.Name, 7)) { this.label2.Font = fnt; }


            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
            mCommand.CommandText = "SELECT * FROM ranking"; // 쿼리문 작성
            mConnection.Open(); // DB 오픈
            mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행




            mySqlDataAdapter = new MySqlDataAdapter("select name AS 이름, score as 점수, grade as 학점 from ranking order by score desc limit 10", mConnection);
            DataSet DS = new DataSet();

            mConnection.Close(); // 사용 후 객체 닫기

            mySqlDataAdapter.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }
    }
}

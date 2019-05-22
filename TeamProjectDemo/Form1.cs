using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TeamProjectDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class Form1 : Form
    {
        bool right, left;
        bool jump;
        bool doubleJump=false;
        bool initialInit = false;
        int G = 20, Force;

        public Form1()
        {
            InitializeComponent();
            Init();
            View();


        }

        private void ItemInitVer1()
        {
            for (int i = 0; i < 10; i++)
            {
                if(initialInit ==false)
                soju[i] = new PictureBox();
            
                soju[i].Image = global::TeamProjectDemo.Properties.Resources.soju;
                soju[i].Location = new System.Drawing.Point(800 + i * 80, 150);
                soju[i].Name = "soju";
                soju[i].Size = new System.Drawing.Size(30, 30);
                this.Controls.Add(soju[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                if (initialInit == false)
                    book[i] = new PictureBox();
                book[i].Image = global::TeamProjectDemo.Properties.Resources.agenda;
                book[i].Location = new System.Drawing.Point(800 + i * 80, 200);
                book[i].Name = "soju";
                book[i].Size = new System.Drawing.Size(30, 30);
                this.Controls.Add(this.book[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                if (initialInit == false)
                    hotsix[i] = new PictureBox();
                hotsix[i].Image = global::TeamProjectDemo.Properties.Resources.energy_drink;
                hotsix[i].Location = new System.Drawing.Point(800 + i * 80, 250);   
                hotsix[i].Name = "soju";
                hotsix[i].Size = new System.Drawing.Size(30, 30);
                this.Controls.Add(this.hotsix[i]);
            }
            this.Controls.Add(this.screen);
        }
        private void Init()
        {

            //배경화면 설정 

           // this.screen.BackgroundImage = Image.FromFile("street.png");
            // PictureBox 배열 soju,book,hotsix 생성
            soju = new PictureBox[10];
            book = new PictureBox[10];
            hotsix = new PictureBox[10];

            //PictureBox- soju,book.hotsix 생성
            this.ItemInitVer1();
            initialInit = true;

            sy = new User(player);

            //itemList 생성
            itemList = new List<Item>();

            //itemList에 soju,hotsix,book가 담긴 Item 무명객체를 넣어줌
           for (int i = 0; i < 10; i++)
            {
                itemList.Add(new Item(soju[i]));
                itemList.Add(new Item(hotsix[i]));
                itemList.Add(new Item(book[i]));
            }
        }
        private void View()
        {
            label1.Text += sy.Hp;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
               player.Image = Image.FromFile("walk_R.gif");

            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                player.Image = Image.FromFile("walk_L.gif");
            }
            if (e.KeyCode == Keys.Escape) { this.Close(); }

            if (jump != true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    jump = true;
                    Force = G;
                    player.Image = Image.FromFile("jump.png");
                }
            }
            else
            {
                if (e.KeyCode == Keys.Up)
                {
                    Force = G;
                    doubleJump = true;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (right == true) { player.Left += 5; }
            if (left == true) { player.Left -= 5; }

            if (jump == true && doubleJump == false)
            {
                player.Top -= Force; //점프하면서 떨어짐
                Force -= 1;
            }
            if (jump == true && doubleJump == true)
            {
                player.Top -= Force; //점프하면서 떨어짐
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; //stop falling at bottom
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand.png");
                }
                jump = false;
                doubleJump = false;
            }
            else
            {
                player.Top += 5;
            }

            /*
            if (sy.JumpState == true)
            {

                if (sy.picture.Location.Y > 100)
                {
                    sy.Dy = -7;
                    sy.move();
                }
                if(sy.picture.Location.Y<=100)
                {
                    sy.JumpState = false;
                }
            }
            if (sy.JumpState == false)
            {
                if (sy.picture.Location.Y < 200)
                {
                    sy.Dy = +7;
                    sy.move();
                }
            }
            */
            Item temp;

           
            for (int i=itemList.Count-1; i>=0; i--)
            {
                temp = itemList[i];

                if (sy.checkCollision(temp))
                {
                    sy.Hp -= 1;
                    label1.Text = sy.Hp.ToString();

                    //충돌시 picture 이미지 삭제 및 itemList에서 제거
                   // temp.picture.Dispose(); 
                   temp.picture.Location = new System.Drawing.Point( 1000, 150);
                    itemList.Remove(temp);

                    if(sy.Hp == 90)
                    {
                        this.Visible = false;
                        DataInsert dataIn = new DataInsert();
                        dataIn.Show();
                    }
                }

                if (temp.picture.Location.X < 100)
                {
                    // picture 이미지 삭제 및 itemList에서 제거
                    //  temp.picture.Dispose();
                    temp.picture.Location = new System.Drawing.Point(1000, 150);
                    itemList.Remove(temp);
                }
                else
                {
                    temp.Dx = -5;
                    temp.move();

                }

            }

            if(itemList.Count==0)
            {
                for (int i = 0; i < 10; i++)
                {
                    itemList.Add(new Item(soju[i]));
                    itemList.Add(new Item(hotsix[i]));
                    itemList.Add(new Item(book[i]));
                }
                this.ItemInitVer1();
            }

        }//timer1_tick()

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("stand.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
                player.Image = Image.FromFile("stand.png");
            }
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
                
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
           
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DataInsert dataIn = new DataInsert();
            dataIn.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

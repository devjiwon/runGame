using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamProjectDemo
{
    class Sprite
    {
        protected int x; // 객체 x좌표
        protected int y; // 객제 y좌표
        protected int dx; // 단위시간당 x 이동거리 
        protected int dy; // 단위시간당 y 이동거리 
        protected int width;

        public System.Windows.Forms.PictureBox picture; 
        
   

        //생성자
        public Sprite() { }
        public Sprite(System.Windows.Forms.PictureBox picture)
        {
            this.picture = picture;
            this.x = picture.Location.X;
            this.y = picture.Location.Y;
            this.dx = 0;
            this.dy = 0;
        }

        //get/set
        public int X
        {
            get { return x; }

            set { this.x = value; }
        }
        public int Y
        {
            get { return y; }

            set { this.y = value; }
        }
        public int Dx
        {
            get { return dx; }

            set { this.dx = value; }
        }
        public int Dy
        {
            get { return dy; }

            set { this.dy = value; }
        }
        public int Width
        {
            get { return picture.Width; }

            set { this.picture.Width = value; }
        }
        public int Height
        {
            get { return picture.Height; }

            set { this.picture.Height= value; }
        }

        public void SetSize(int width, int height)
        {
            this.picture.Size = new System.Drawing.Size(width, height);
        }

        public void SetLocation(int x, int y)
        {
            this.picture.Location = new Point(x, y);
        }
        //funcitional
        
        public void move()
        {
            picture.Location = new Point(picture.Location.X + (dx), picture.Location.Y + dy);
          
        }
        public bool checkCollision(Sprite other)
        {
            Rectangle myRect = new Rectangle();
            Rectangle otherRect = new Rectangle();

            myRect.Location = new Point(this.picture.Location.X, this.picture.Location.Y);
            myRect.Size = new Size(this.picture.Width, this.picture.Height);

            otherRect.Location = new Point(other.picture.Location.X, other.picture.Location.Y);
            otherRect.Size = new Size(other.picture.Width, other.picture.Height);

            return myRect.IntersectsWith(otherRect);
        }
    }
}

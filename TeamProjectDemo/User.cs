using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace TeamProjectDemo
{
    class User : Sprite
    {
        protected int hp;
        protected int score;
        protected int deathCount;
        protected int superCount;
        protected bool jumpState;

        public User(System.Windows.Forms.PictureBox picture) : base(picture)
        {
            hp = 100;
            score = 0;
            deathCount = 0;
            superCount = 0;
            jumpState = false;
        }

        public bool JumpState {
            get
            {
               return jumpState;
            }
            set
            {
                jumpState = value;
            }
        }

        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }
        public void Jump()
        {

            dy = -1;
            while (picture.Location.Y > 100)
            {
                move();  
            }
            dy = +1;
            while (picture.Location.Y != 200)
            {
                move();            
            }




        }
    }
}

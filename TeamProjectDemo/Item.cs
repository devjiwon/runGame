using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;


namespace TeamProjectDemo
{
    class Item : Sprite
    {
        enum Items
        {
            Hotsix, Jokbo, Soju
        }
        protected int plusHp;
        Items itemName;

        public Item(System.Windows.Forms.PictureBox picture) : base(picture)
        {
            this.plusHp = 0;

            
            Random random = new Random();
            int choice;
                  
           
        }//생성자

      
       
    }
}

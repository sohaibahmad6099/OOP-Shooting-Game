using Backend.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace Backend.BL
{
    public class GameObject
    {
        private readonly IMotion Motion;
        private readonly PictureBox PB;
        private readonly ObjectType objectType;
        private readonly Form Conatiner;
        private readonly IMotion move;
        public GameObject(PictureBox pb, IMotion motion)
        {
            PB = pb;
            Motion = motion;
        }

        public GameObject(Form Conatiner, Image image, int left, int top, IMotion motion, ObjectType objectType)
        {
            this.Conatiner = Conatiner;
            PB = new PictureBox
            {
                Image = image,
                Left = left,
                Top = top,
                BackColor = Color.Transparent
            };
            Motion = motion;
            this.objectType = objectType;
            if (objectType == ObjectType.enemy)
            {
                PB.Width = 62;
                PB.Height = 92;
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (objectType == ObjectType.player)
            {
                PB.Width = 95;
                PB.Height = 105;
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (objectType == ObjectType.enemyBullet)
            {
                PB.Height = 62;
                PB.Width = 30;
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (objectType == ObjectType.playerBullet)
            {
                PB.Width = 20;
                PB.Height = 50; 
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            this.Conatiner.Controls.Add(PB);
        }
        public void Update()
        {
            PB.Location = Motion.Move(PB.Location);
        }
        public PictureBox getPictureBox()
        {
            return PB;
        }
        public PictureBox GetEnmies()
        {
            return objectType == ObjectType.enemy ? PB : null;
        }
        public ObjectType GetObjectType()
        {
            return objectType;
        }
        public int GetLeft()
        {
            return PB.Left;
        }
        public int GetTop()
        {
            return PB.Top;
        }
        public void SetLeft(int val)
        {
            PB.Left = val;
        }
        public void SetTop(int val)
        {
            PB.Top = val;
        }

    }
}

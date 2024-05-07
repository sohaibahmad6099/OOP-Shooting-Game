using Backend.BL;
using EZInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        Game game;
        GameObject player;
        GameObject enemies;
        Random rand;
        private int EnemyFireGenerationTime = 150;
        private int CurrentEnemyFireGenerationTime;
        public Form1()
        {
            InitializeComponent();
            this.game = new Game(this);
            Instance = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            System.Drawing.Point Boundary = new System.Drawing.Point(this.Width - 200, this.Height - 200);
            rand = new Random();
            player = new GameObject(this,Properties.Resources.HellSing,this.Width/2,500,new KeyBoardHandler(10,Boundary),ObjectType.player);
            this.game.AddGameObjects(player);
            for(int i=0;i<3;i++)
            {
                if(i==0)
                {
                    enemies = new GameObject(this, Properties.Resources.Enemy, rand.Next(this.Top-200, this.Left-200), rand.Next(this.Top - 200, this.Left - 200), new VerticalMotion(4,Boundary, "up"), ObjectType.enemy);
                    this.game.AddGameObjects(enemies);
                }
                else if(i==1)
                {
                    enemies = new GameObject(this, Properties.Resources.Enemy, rand.Next(this.Top - 200, this.Left - 200), rand.Next(this.Top - 200, this.Left - 200), new HorizontalMotion(4,Boundary,"left"), ObjectType.enemy);
                    this.game.AddGameObjects(enemies);
                }
                else if(i== 2)
                {
                    enemies = new GameObject(this, Properties.Resources.Enemy, rand.Next(this.Top - 200, this.Left - 200), rand.Next(this.Top - 200, this.Left - 200), new ZigZagMotion(4,Boundary, "left"), ObjectType.enemy);
                    game.AddGameObjects(enemies);
                }
            }
            this.game.EnemyFire(Properties.Resources.N);
            this.game.DeleteFire();
            this.game.DeletePlayerFire();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.game.Update();
            if (CurrentEnemyFireGenerationTime == EnemyFireGenerationTime)
            {
                this.game.EnemyFire(Properties.Resources.N);
                CurrentEnemyFireGenerationTime = 0;
            }
            if(Keyboard.IsKeyPressed(Key.Space))
            {
                this.game.PlayerFire(Properties.Resources.bullet1);
            }
            CurrentEnemyFireGenerationTime++;
            this.game.DeleteFire();
            this.game.DeletePlayerFire();
            if(player.getPictureBox().Visible == false) 
            {
                MessageBox.Show("Game Over");
                this.Close();
                this.Hide();
            }
        }
    }
}

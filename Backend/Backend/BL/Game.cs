using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Backend.BL
{
    public class Game
    {
        List<GameObject> gameObjectsList;
        Form Container;
        Collision Collision ;
        public Game(Form Conatiner)
        {
            gameObjectsList = new List<GameObject>();
            this.Container = Conatiner;
            Collision = new Collision();
        }
        public void AddGameObjects(GameObject myobject)
        {
            GameObject gameObject = myobject;
            this.Container.Controls.Add(gameObject.getPictureBox());
            gameObjectsList.Add(gameObject);
        }
        public void removeGameObjects(GameObject myobject)
        {
            GameObject gameObject = myobject;
            this.Container.Controls.Remove(gameObject.getPictureBox());
            gameObjectsList.Remove(gameObject);
        }
        public void Update()
        {
            List<GameObject> objectsToRemove = new List<GameObject>();

            foreach (GameObject go in gameObjectsList)
            {
                go.Update();
                Collision.CheckCollisionOfPlayer(gameObjectsList, this.Container, objectsToRemove);
            }
            foreach (GameObject go in gameObjectsList)
            {
                go.Update();
                Collision.CheckCollisionOfEnemy(gameObjectsList, this.Container, objectsToRemove);
            }
            foreach (GameObject objToRemove in objectsToRemove)
            {
                gameObjectsList.Remove(objToRemove);
                this.Container.Controls.Remove(objToRemove.getPictureBox());
            }
        }


        public void PlayerFire(Image Img)
        {
            int Top = 0;
            int Left=0;
            Point Boundary = new System.Drawing.Point(this.Container.Width, this.Container.Height);
            for(int i=0;i<gameObjectsList.Count;i++)
            {
                if (gameObjectsList[i].GetObjectType()==ObjectType.player)
                {
                    Top = gameObjectsList[i].GetTop();
                    Left = gameObjectsList[i].GetLeft();
                    Top -= 50;
                    Left += 40;
                    break;
                }
            }
            GameObject gameObject = new GameObject(this.Container, Img, Left, Top, new PlayerBullet(5, Boundary), ObjectType.playerBullet);
            this.Container.Controls.Add(gameObject.getPictureBox());
            gameObjectsList.Add(gameObject);
        }
        public void DeletePlayerFire()
        {
            for (int i = 0; i < gameObjectsList.Count; i++)
            {
                if (gameObjectsList[i].GetObjectType() == ObjectType.playerBullet)
                {
                    GameObject gameObject = gameObjectsList[i];
                    int Y = gameObjectsList[i].GetTop();
                    if (Y == this.Container.Top)
                    {
                        this.Container.Controls.Remove(gameObject.getPictureBox());
                        gameObjectsList.Remove(gameObject);
                    }
                }
            }
        }
        public void EnemyFire(Image Img)
        {
            Point Boundary = new System.Drawing.Point(this.Container.Width, this.Container.Height);
            for (int i=0;i<gameObjectsList.Count;i++) 
            {
                if (gameObjectsList[i].GetObjectType()==ObjectType.enemy)
                {
                    int Top = gameObjectsList[i].GetTop();
                    int Left = gameObjectsList[i].GetLeft();
                    Top += 120;
                    Left += 5;
                    GameObject gameObject = new GameObject(this.Container,Img,Left,Top,new Bullet(5,Boundary),ObjectType.enemyBullet);
                    this.Container.Controls.Add(gameObject.getPictureBox());
                    gameObjectsList.Add(gameObject);
                }
            }
        }
        public void DeleteFire()
        {
            for(int i=0; i<gameObjectsList.Count;i++)
            {
                if (gameObjectsList[i].GetObjectType()==ObjectType.enemyBullet)
                {
                    GameObject gameObject = gameObjectsList[i];
                    int Y = gameObjectsList[i].GetTop();
                    if(Y<= 0)
                    {
                        this.Container.Controls.Remove(gameObject.getPictureBox());
                        gameObjectsList.Remove(gameObject);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Linq;

namespace Backend.BL
{
    public class Collision
    {
        int count = 0;
        public void CheckCollisionOfPlayer(List<GameObject> gameObjects, Form container, List<GameObject> objectsToRemove)
        {
            Form form = container;
            foreach (GameObject obj in gameObjects.ToList())
            {
                if (obj.GetObjectType() == ObjectType.enemyBullet)
                {
                    foreach (GameObject obj2 in gameObjects.ToList())
                    {
                        if (obj2.GetObjectType() == ObjectType.player)
                        {
                            PictureBox Pb1 = obj.getPictureBox();
                            PictureBox Pb2 = obj2.getPictureBox();
                            if (Pb2.Bounds.IntersectsWith(Pb1.Bounds))
                            {
                                objectsToRemove.Add(obj);
                                objectsToRemove.Add(obj2);
                                MessageBox.Show("Game Over");
                                form.Hide();
                                form.Close();
                                
                            }
                        }
                        else if (obj2.GetObjectType() == ObjectType.playerBullet)
                        {
                            PictureBox Pb1 = obj.getPictureBox();
                            PictureBox Pb2 = obj2.getPictureBox();
                            if (Pb2.Bounds.IntersectsWith(Pb1.Bounds))
                            {
                                objectsToRemove.Add(obj);
                                objectsToRemove.Add(obj2);
                              
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void CheckCollisionOfEnemy(List<GameObject> gameObjects, Form container, List<GameObject> objectsToRemove)
        {
            Form form = container;
            foreach (GameObject obj in gameObjects.ToList())
            {
                if (obj.GetObjectType() == ObjectType.playerBullet)
                {
                    foreach (GameObject obj2 in gameObjects.ToList())
                    {
                        if (obj2.GetObjectType() == ObjectType.enemy)
                        {
                            PictureBox Pb1 = obj.getPictureBox();
                            PictureBox Pb2 = obj2.getPictureBox();
                            if (Pb2.Bounds.IntersectsWith(Pb1.Bounds))
                            {
                                objectsToRemove.Add(obj);
                                objectsToRemove.Add(obj2);
                                count++;
                                if (count == 3)
                                {
                                    MessageBox.Show("Victory");
                                    form.Hide();
                                    form.Close();
                                }
                                break ;
                            }
                        }
                        else if (obj2.GetObjectType() == ObjectType.enemy)
                        {
                            PictureBox Pb1 = obj.getPictureBox();
                            PictureBox Pb2 = obj2.getPictureBox();
                            if (Pb2.Bounds.IntersectsWith(Pb1.Bounds))
                            {
                                objectsToRemove.Add(obj);
                                objectsToRemove.Add(obj2);
                                count++;
                                if (count == 3)
                                {
                                    MessageBox.Show("Victory");
                                    form.Hide();
                                    form.Close();
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecodation_City_Car_Oyunu
{
    public partial class Form1 : Form
    {
        Random r = new Random();

        int score = 0;
        int line1Y=10;
        int line2Y=270;
        int line3Y=530;
        int car1X;
        int car2X;
        int car1Y;
        int car2Y;
        int coin1X;
        int coin1Y;
        int coin2X;
        int coin2Y;

        Image[] resimler = 
           { 
            Properties.Resources.car1,
            Properties.Resources.car2,
            Properties.Resources.car3,
            Properties.Resources.car4,
            Properties.Resources.car5,
            Properties.Resources.car6,
            Properties.Resources.car7,
            Properties.Resources.car8,
            Properties.Resources.car9,
           };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            

            car1X = r.Next(40, 220);
            car2X = r.Next(250, 400);

            car1Y = r.Next(-500, -100);
            car2Y = r.Next(-500, -100);

            coin1X = r.Next(40, 220);
            coin2X = r.Next(250, 400);

            coin1Y = r.Next(-500, -100);
            coin2Y = r.Next(-500, -100);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                player.Left -= 20;
            }
            if (e.KeyCode == Keys.Right)
            {
                player.Left += 20;
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

            line1Y += 40;
            line2Y += 40;
            line3Y += 40;

            

            label3.Location = new Point(240, line1Y);
            label4.Location = new Point(240, line2Y);
            label5.Location = new Point(240, line3Y);

            if (line1Y>700)
            {
                line1Y = -40;
                label3.Location = new Point(240, line1Y);
            }
            if (line2Y > 700)
            {
                line2Y = -40;
                label4.Location = new Point(240, line2Y);
            }
            if (line3Y > 700)
            {
                line3Y = -40;
                label5.Location = new Point(240, line3Y);
            }

            

            car1Y += 20;
            car2Y += 20;
            car1.Location = new Point(car1X, car1Y);
            car2.Location = new Point(car2X, car2Y);

            if (car1Y>700)
            {
                car1.Image = resimler[r.Next(0, 9)];
                car1X = r.Next(40, 220);
                car1Y = r.Next(-500, -100);
                car1.Location = new Point(car1X, car1Y);
            }
            if (car2Y > 700)
            {
                car2.Image = resimler[r.Next(0, 9)];
                car2X = r.Next(250, 400);
                car2Y = r.Next(-500, -100);
                car2.Location = new Point(car2X, car2Y);
            }



            coin1Y += 20;
            coin2Y += 20;

            coin1.Location = new Point(coin1X, coin1Y);
            coin2.Location = new Point(coin2X, coin2Y);

            if (coin1Y>700)
            {
                coin1X = r.Next(40, 220);
                coin1Y = r.Next(-500, -100);
                coin1.Location = new Point(coin1X, coin1Y);
            }

            if (coin2Y > 700)
            {
                coin2X = r.Next(250, 400);
                coin2Y = r.Next(-500, -100);
                coin2.Location = new Point(coin2X, coin2Y);
            }

            if (player.Bounds.IntersectsWith(label1.Bounds))
            {
                player.Left = +20;
            }

            if (player.Bounds.IntersectsWith(label1.Bounds))
            {
                player.Left = +20;
            }

            noLeft();
            noRight();
            
            if (player.Bounds.IntersectsWith(car1.Bounds))
            {
                timer1.Enabled = false;
                line_speed();
                
                timer2.Enabled = true;
                

                if (player.Left < car1.Left)
                {
                    player.Left -= 10;
                }

                else if (player.Left > car1.Left)
                {
                    player.Left += 10;
                }
                else
                {
                    player.Left += 10;
                }
                time_spin();
                
            }



            if (player.Bounds.IntersectsWith(car2.Bounds))
            {
                timer1.Enabled = false;
                line_speed();

                timer2.Enabled = true;


                if (player.Left < car2.Left)
                {
                    player.Left -= 10;
                }

                else if (player.Left > car2.Left)
                {
                    player.Left += 10;
                }
                else
                {
                    player.Left += 10;
                }
                time_spin();

            }

            if (player.Bounds.IntersectsWith(coin1.Bounds))
            {
                score++;
                scoreLbl.Text = "Score: " + score;
                coin1X = r.Next(40, 220);
                coin1Y = r.Next(-500, -100);
                coin1.Location = new Point(coin1X, coin1Y);
            }

            if (player.Bounds.IntersectsWith(coin2.Bounds))
            {
                score++;
                scoreLbl.Text = "Score: " + score;
                coin2X = r.Next(250, 400);
                coin2Y = r.Next(-500, -100);
                coin2.Location = new Point(coin2X, coin2Y);

            }

        }

        private void noLeft()
        {
            if (player.Bounds.IntersectsWith(label1.Bounds))
            {
                player.Left += 20;
            }
        }
        private void noRight()
        {
            if (player.Bounds.IntersectsWith(label2.Bounds))
            {
                player.Left -= 20;
            }
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            line_speed();
            car1Y += 20;
            car2Y += 20;
            car1.Location = new Point(car1X, car1Y);
            car2.Location = new Point(car2X, car2Y);

            if (car1Y > 700)
            {
                car1.Image = resimler[r.Next(0, 9)];
                car1X = r.Next(40, 220);
                car1Y = r.Next(-500, -100);
                car1.Location = new Point(car1X, car1Y);
            }
            if (car2Y > 700)
            {
                car2.Image = resimler[r.Next(0, 9)];
                car2X = r.Next(250, 400);
                car2Y = r.Next(-500, -100);
                car2.Location = new Point(car2X, car2Y);
            }
            

            label3.Location = new Point(240, line1Y);
            label4.Location = new Point(240, line2Y);
            label5.Location = new Point(240, line3Y);

            if (line1Y > 700)
            {
                line1Y = -40;
                label3.Location = new Point(240, line1Y);
            }
            if (line2Y > 700)
            {
                line2Y = -40;
                label4.Location = new Point(240, line2Y);
            }
            if (line3Y > 700)
            {
                line3Y = -40;
                label5.Location = new Point(240, line3Y);
            }

            
        }

        private void time_spin() 
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }
        private void line_speed()
        {
            line1Y +=0;
            line2Y +=0;
            line3Y +=0;
        }
    }



}

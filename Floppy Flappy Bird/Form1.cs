using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floppy_Flappy_Bird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8; // default pipe speed
        int gravity = 10; // default gravity speed
        int score = 0; // default score
        public Form1()
        {
            InitializeComponent();
        }
        private void endGame()
        {
            gameTimer.Stop(); // stop the main timer
            scoreText.Text += " - GG!";
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity; // link the flappy bird picture box to the gravity
            bottomPipe.Left -= pipeSpeed; // link the bottom pipes left position to the pipe speed integer, it wil lreduce the pipe speed value from the left position of the pipe picture box so it will move left with each tick
            topPipe.Left -= pipeSpeed; // same as with bottom pipe
            scoreText.Text = "Score: " + score; // show the current score

            // check if any of the pipes have left the screen

            if (bottomPipe.Left < -150)
            {
                // if the bottom pipe's location is -150 then we will reset it back to 800 and add 1 to the score
                bottomPipe.Left = 800;
                score++;
            }

            if(topPipe.Left < -180)
            {
                topPipe.Left = 950;
                score++;
            }

            // check if the bird has hit either pipe or the ground or if it's left the screen
            
            if (FlappyBird.Bounds.IntersectsWith(bottomPipe.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(topPipe.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Grand.Bounds) || FlappyBird.Top < -25)
            {
                // end the game
                endGame();
            }

            // check if the score is higher then 5 and increase the pipe speed to 15 if it is

            if (score > 5)
            { 
                pipeSpeed = 15;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // if the space key is pressed then the gravity will be set to -10
                gravity = -10;
            }

            if (e.KeyCode == Keys.Enter)
            {
               var newGame = new Form1();
               newGame.Show();
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // if the space key is released then gravity is set back to 15
                gravity = 10;
            }
        }
    }
}

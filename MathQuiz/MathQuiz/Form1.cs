using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer to generate random numbers.
        Random randomizer = new Random();

        // Integers to store numbers for the addition problem.
        int addend1;
        int addend2;

        // Integers to store numbers for the subtraction problem. 
        int minuend;
        int subtrahend;

        // Integers to store numbers for the multiplication problem.
        int multiplicand;
        int multiplier;

        // Integers to store numbers for the divison problem. 
        int dividend;
        int divisor;

        //This int variable keeps track of the remaining time. 
        int timeLeft;

        // Start the quiz by filling in all the problems and starting the timer.
        public void StartTheQuiz()
        {
            // Fill in the addition problems
            // Generate two numbers to add. 
            // Store the values
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convert the two randomly generated numbers into strings so they can be displayed in labels. 
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Makes sure 'sum' is 0 before adding values to it
            sum.Value = 0;

            // Fill in the subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Fill in the multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Fill in the divison problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        // Check the answer to see if the user got everythign right.
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value)
                )
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //If CheckTheAnswer() returns true, then the user got the answer right. Stop the timer and show a MessageBox
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
                timeLabel.BackColor = Color.Empty;
            }
            else if (timeLeft > 0)
            {
                //If CheckTheAnswer() returns false, keep counting down. Decrease the time left by one second and display the new time left by updating the Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }

            }
            else
            {
                //If the user ran out of time, stop the timer, show a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.BackColor = Color.Empty;
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void answer_CheckSound(object sender, EventArgs e)
        {

        }

        private void answer_CheckSoundAdd(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\chimes.wav");
                simpleSound.Play();
            }
        }

        private void answer_CheckSoundMinus(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\chimes.wav");
                simpleSound.Play();
            }
        }

        private void answer_CheckSoundTimes(object sender, EventArgs e)
        {
            if (multiplicand * multiplier == product.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\chimes.wav");
                simpleSound.Play();
            }
        }

        private void answer_CheckSoundDivide(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\media\chimes.wav");
                simpleSound.Play();
            }
        }
    }
}

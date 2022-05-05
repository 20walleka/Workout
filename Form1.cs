using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Workout.v1._1 
 
 NAME: Kate Walley
 DATE: August 23, 2021

 PURPOSE: This program will control
 an app that will remind the user to
 do a small workout every X number of 
 minutes. 
 */

namespace Workout.V1._1
{
    public partial class Form1 : Form
    {
        //Variable to needed for random number
        static Random num = new Random();

        public Form1()
        {
            InitializeComponent();
        }//Form1

        /* button3_Click - This method will help users learn 
           how to use the program. 
         */
        private void button3_Click(object sender, EventArgs e)
        {
            String helpInfo = "Select the time between workouts and select type of workout. Then press START and let the timer count down.";

            //Show Help Box
            MessageBox.Show(helpInfo, "Help", MessageBoxButtons.OK, MessageBoxIcon.None);
        }//button3_Click

        /* button1_Click - This method will start the count down timer.
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Program.startStop = true;
            Program.timeBetween = Int16.Parse(listBox2.SelectedItem.ToString());
            Program.workoutSelected = listBox1.SelectedItem.ToString();  
            clockTime();
        }//button1_Click

        /* clockTime - This method will set up the workoutTimer.
         */
        private void clockTime()
        {
            Program.EndTime = DateTime.Now.AddMinutes(Program.timeBetween);
            Program.workoutTimer = new Timer();
            Program.workoutTimer.Interval = 500;
            Program.workoutTimer.Enabled = true;
            Program.workoutTimer.Tick += new EventHandler(workoutTimer_Tick);
            workoutTimer_Tick(null, null);
        }//clockTime

        /* workoutTimer_Tick - This method will display the time left
           to the user, stop the time at the end and give the user their
           workout.
         */
        private void workoutTimer_Tick(Object sender, EventArgs e)
        {
            TimeSpan span = Program.EndTime.Subtract(DateTime.Now);
            label4.Text = span.ToString(@"mm\:ss");
            if(label4.Text.Equals("00:00"))
            {
               Program.workoutTimer.Stop();
               giveWorkout();
                if (Program.startStop)
                {
                    clockTime();
                }//if
            }//if
        }//workoutTimer_Tick

        /* giveWorkout - This method will give the
           user the workout at the end of the time.
         */
        private static void giveWorkout()
        {
            //Random num = new Random();
            String activity = null;

            //Generate Workout Exercises
            int number = num.Next(0,7);

            if (Program.workoutSelected.Equals("Low Intensity"))
            {
                switch(number)
                {
                    case 0:
                        activity = "5 Jumping Jacks";
                        break;
                    case 1:
                        activity = "2 Push Ups";
                        break;
                    case 2:
                        activity = "10 Seconds Plank";
                        break;
                    case 3:
                        activity = "10 Sit Ups";
                        break;
                    case 4:
                        activity = "3 Squats";
                        break;
                    case 5:
                        activity = "4 Toe Touches";
                        break;
                    case 6:
                        activity = "8 Lunges";
                        break;
                    default:
                        activity = "3 Tuck Jumps";
                        break;
                }//switch
            }else if (Program.workoutSelected.Equals("Medium Intensity"))
            {
                switch (number)
                {
                    case 0:
                        activity = "14 Jumping Jacks";
                        break;
                    case 1:
                        activity = "5 Push Ups";
                        break;
                    case 2:
                        activity = "15 Seconds Plank";
                        break;
                    case 3:
                        activity = "15 Sit Ups";
                        break;
                    case 4:
                        activity = "10 Squats";
                        break;
                    case 5:
                        activity = "6 Toe Touches";
                        break;
                    case 6:
                        activity = "12 Lunges";
                        break;
                    default:
                        activity = "5 Tuck Jumps";
                        break;
                }//switch
            }//else if
            else if (Program.workoutSelected.Equals("High Intensity"))
            {
                switch (number)
                {
                    case 0:
                        activity = "20 Jumping Jacks";
                        break;
                    case 1:
                        activity = "10 Push Ups";
                        break;
                    case 2:
                        activity = "25 Seconds Plank";
                        break;
                    case 3:
                        activity = "20 Sit Ups";
                        break;
                    case 4:
                        activity = "20 Squats";
                        break;
                    case 5:
                        activity = "10 Toe Touches";
                        break;
                    case 6:
                        activity = "20 Lunges";
                        break;
                    default:
                        activity = "10 Tuck Jumps";
                        break;
                }//switch
            }//else if
            else
            {
                switch (number)
                {
                    case 0:
                        activity = "30 Jumping Jacks";
                        break;
                    case 1:
                        activity = "15 Push Ups";
                        break;
                    case 2:
                        activity = "45 Seconds Plank";
                        break;
                    case 3:
                        activity = "40 Sit Ups";
                        break;
                    case 4:
                        activity = "30 Squats";
                        break;
                    case 5:
                        activity = "15 Toe Touches";
                        break;
                    case 6:
                        activity = "30 Lunges";
                        break;
                    default:
                        activity = "15 Tuck Jumps";
                        break;
                }//switch
            }//else

            //Show Message
            if(MessageBox.Show("Time for "+activity+ "! Would you like to continue?","Workout!",MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                Program.startStop = false;
            }//if
        }//giveWorkout

        /* Form1_Load - This method will load the 
           correct time.
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = Program.currentTime.ToString("mm:ss");
        }//Form1_Load

        /* button2_Click - This method will allow the user to
           exit when clicked.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//button2_Click
    }//Form 1
}//Workout.V1._1

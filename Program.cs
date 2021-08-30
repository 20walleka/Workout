using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workout.V1._1
{
    static class Program
    {
        //Global variables 
        public static int totalSeconds = 0;
        public static int timeBetween = 0;
        public static String workoutSelected = null;
        public static bool startStop = false;
        public static DateTime currentTime = new DateTime();
        public static DateTime EndTime = new DateTime();
        public static Timer workoutTimer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }//Main
    }//Program
}//Workout.V1._1

using Program_2_Taylor_Leavelle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Media;

namespace HW3_adv_soft_dev
{
    
    public partial class Badalarm : Form 
    {
        AlarmTime time2 = new AlarmTime("",0,0,0);

        // System.Timers.Timer timeticker;
        //System.Timers.Timer mytime = new Timer();
        Systems.Timers.Timer timer;
        


        //private void set_alarm_ticker()
       // {
         //   //System.Timers.Timer timeticker;
         //   timeticker.Interval = 1000;

       // }
        private void checktime()
        {
            if (hour == time2.Hour && minute == time2.Minute && second == time2.Second)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
            }

        }
        private void ElapsedEventHandler(object displayTimeEvent)
        {
            throw new NotImplementedException();
        }

        Time2_book[] alarms2 = new Time2_book[10];

        private int hour;
        private int minute;
        private int second;
        private string message;
        int count = 0;



        public Badalarm()
        {
            InitializeComponent();
          //  set_alarm_ticker();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new Systems.Timers.Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Elapsed += Timer_elapsed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_second_Click(object sender, EventArgs e)
        {

        }

          private void button3_Click(object sender, EventArgs e)
          {
            listBox1.Sorted = true;
            hour = Convert.ToInt32(textBox1.Text);
              minute = Convert.ToInt32(textBox2.Text);
              second = Convert.ToInt32(textBox3.Text);
              message = (textBox4.Text);
              AlarmTime time = new AlarmTime(message, hour, minute, second);
              listBox1.Items.Add(time.ToUniversalString());

            if (hour == time2.Hour && minute == time2.Minute && second == time2.Second)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
            }
           
            
            
              
          }

        private void Timer_elapsed(object sender, ElapsedEventArgs e)
        {
            get_next_alarm_and_ring();
            time2.addtime(0,0,1);
            updatealarm();
        }
        private void updatealarm()
        {
           // label_hour.Text = time2.ToString();

        }

        private void button4_Click()
        {
            throw new NotImplementedException();
        }

        public void get_next_alarm_and_ring()
        {
           //if (listBox1.TopIndex != listBox1.SelectedIndex)
              //  listBox1.TopIndex = listBox1.SelectedIndex;
            
            if (hour == time2.Hour && minute == time2.Minute && second == time2.Second)
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
            }
        }
        
        public string displayMembers(List<String> alarms)
   {
            
            var text = string.Empty;
       Array array = alarms.ToArray();
       Array.Sort(array);
       foreach (String s in alarms)
       {
           text += s.ToString() + "\r\n";
       }
       return text;
   }


        private void button4_Click(object sender, EventArgs e)
            {
            string message = "";
            hour = Convert.ToInt32(textBox1.Text);
            minute = Convert.ToInt32(textBox2.Text);
            second = Convert.ToInt32(textBox3.Text);
            time2 = new AlarmTime(message,hour, minute, second);
            label_hour.Text = time2.ToString();

                }

            private void label_hour_Click(object sender, EventArgs e)
                {

                }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

             }

        private void button5_Click(object sender, EventArgs e)
        {
            label_hour.Text = DateTime.Now.ToString("HH:mm:ss tt").ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

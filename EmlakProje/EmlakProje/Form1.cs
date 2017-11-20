using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace EmlakProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool PanelDurum = true;
        public void PanelKaydir(Panel panel, int boyut)
        {
            if (PanelDurum == false)
            {
                panel.Width -= boyut;
                PanelDurum = true;

            }
            else if (PanelDurum == true)
            {
                panel.Width += boyut;
                PanelDurum = false;
            }
        }
        List<PictureBox> pictureboxlar = new List<PictureBox>();
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureboxlar.Add(pictureBox1);
            pictureboxlar.Add(pictureBox2);
            pictureboxlar.Add(pictureBox3);
            yanPanel.Width -= 200;
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videocapturedevice in webcam)
                comboBox1.Items.Add(videocapturedevice.Name);

            //comboBox1.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PanelKaydir(yanPanel, 200);
        }

        private void IlanAraButton_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
           
                cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
                cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
                cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            
                cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();
            
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            if(fotograf==1)
                pictureBox1.Image = bit;
            if (fotograf == 2)
                pictureBox2.Image = bit;
            if (fotograf == 3)
                pictureBox3.Image = bit;
            if (fotograf == 4)
                pictureBox4.Image = bit;
            
            
        }

        private void ilanEklePanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public void fotografCek(PictureBox picturebox)
        {
            if (cam.IsRunning == true)
            {
                cam.Stop();
                picturebox.Image = picturebox.Image;
                
                
            }

        }
        public int fotograf = 1;
        private void fotografButton_Click(object sender, EventArgs e)
        {
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            pictureBox2.DoubleClick += pictureBox2_DoubleClick;
            pictureBox3.DoubleClick += pictureBox3_DoubleClick;

            if (fotograf == 1)
            {
                pictureBox1.Image = pictureBox1.Image;
            }
            if (fotograf == 2)
            {
                pictureBox2.Image = pictureBox2.Image;
            }
            if (fotograf == 3)
            {
                pictureBox3.Image = pictureBox3.Image;
            }
            if (fotograf == 4)
            {
                pictureBox4.Image = pictureBox4.Image;
                
            }
            fotograf++;
            
        }

        void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            fotografCek(pictureBox3);
        }

        void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            fotografCek(pictureBox2);
        }

        void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            fotografCek(pictureBox1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IlanVerButton_Click(object sender, EventArgs e)
        {
            if(ilanEklePanel.Visible==false)
                ilanEklePanel.Visible = true;
        }
        
        }

    }


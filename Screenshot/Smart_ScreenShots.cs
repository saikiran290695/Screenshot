using System;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Smart_ScreenShots : Form
    {
        private Services _service;
        private static int imageCount { get; set; }        
        private static string rootPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SmartScreenshots";
        public Smart_ScreenShots()
        {
            InitializeComponent();
            this.TopMost = true;

            if (!System.IO.Directory.Exists($"{rootPath}"))
                System.IO.Directory.CreateDirectory($"{rootPath}");
            _service = new Services(rootPath);            
            
            resetForm();
        }
        private void Start_Recording_Click(object sender, EventArgs e)
        {
            _service.setFolderName($"{DateTime.Now.ToString("MM-dd-yyyy-HH_mm_ss")}");
            initiateRecording();                        
        }
        private void ScreenShot(object sender, EventArgs e)
        {
            string imageName = string.IsNullOrEmpty(this.Screenshot_Name.Text) ? imageCount.ToString() : this.Screenshot_Name.Text;
            this.Hide();
            _service.ScreenShot(imageName);
            this.Show();
            this.Screenshot_Name.Text = string.Empty;
            imageCount++;
        }

        private void Stop_Recording_Click(object sender, EventArgs e)
        {            
            _service.InsertImage($"{DateTime.Now.ToString("MM-dd-yyyy-HH_mm_ss")}");
            _service.dispose();
            resetForm();
        }   
        
        private void initiateRecording()
        {
            this.Start_Recording.Enabled = false;
            this.Capture_Screen.Enabled = true;
            this.Stop_Recording.Enabled = true;
            this.Screen_shot_name.Visible = true;
            this.Screenshot_Name.Show();
        }

        private void resetForm()
        {
            this.Start_Recording.Enabled = true;
            this.Capture_Screen.Enabled = false;
            this.Stop_Recording.Enabled = false;
            this.Screen_shot_name.Visible = false;
            this.Screenshot_Name.Hide();
                     
            imageCount = 0;
        }
    }
}

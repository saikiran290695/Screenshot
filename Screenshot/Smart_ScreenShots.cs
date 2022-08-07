using System;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Smart_ScreenShots : Form
    {
        private Services _service;
        private static int imageCount { get; set; }
        public Smart_ScreenShots()
        {
            InitializeComponent();                      
            _service = new Services(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Document",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\images");
            resetForm();
        }
        private void Start_Recording_Click(object sender, EventArgs e)
        {
            initiateRecording();                        
        }
        private void ScreenShot(object sender, EventArgs e)
        {
            string imageName = string.IsNullOrEmpty(this.Screenshot_Name.Text) ? imageCount.ToString() : this.Screenshot_Name.Text;
            
            _service.ScreenShot(this, imageName);
            this.Screenshot_Name.Text = string.Empty;
            imageCount++;
        }

        private void Stop_Recording_Click(object sender, EventArgs e)
        {            
            _service.InsertImage("testData");
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

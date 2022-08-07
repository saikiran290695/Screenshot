namespace Screenshot
{
    partial class Smart_ScreenShots
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Capture_Screen = new System.Windows.Forms.Button();
            this.Start_Recording = new System.Windows.Forms.Button();
            this.Stop_Recording = new System.Windows.Forms.Button();
            this.Screenshot_Name = new System.Windows.Forms.TextBox();
            this.Screen_shot_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Capture_Screen
            // 
            this.Capture_Screen.Enabled = false;
            this.Capture_Screen.Location = new System.Drawing.Point(322, 75);
            this.Capture_Screen.Name = "Capture_Screen";
            this.Capture_Screen.Size = new System.Drawing.Size(151, 37);
            this.Capture_Screen.TabIndex = 0;
            this.Capture_Screen.Text = "Capture Screen";
            this.Capture_Screen.UseVisualStyleBackColor = true;
            this.Capture_Screen.Click += new System.EventHandler(this.ScreenShot);
            // 
            // Start_Recording
            // 
            this.Start_Recording.Location = new System.Drawing.Point(322, 32);
            this.Start_Recording.Name = "Start_Recording";
            this.Start_Recording.Size = new System.Drawing.Size(151, 37);
            this.Start_Recording.TabIndex = 1;
            this.Start_Recording.Text = "Start Recording";
            this.Start_Recording.UseVisualStyleBackColor = true;
            this.Start_Recording.Click += new System.EventHandler(this.Start_Recording_Click);
            // 
            // Stop_Recording
            // 
            this.Stop_Recording.Location = new System.Drawing.Point(322, 118);
            this.Stop_Recording.Name = "Stop_Recording";
            this.Stop_Recording.Size = new System.Drawing.Size(151, 37);
            this.Stop_Recording.TabIndex = 2;
            this.Stop_Recording.Text = "Stop Recording";
            this.Stop_Recording.UseVisualStyleBackColor = true;
            this.Stop_Recording.Click += new System.EventHandler(this.Stop_Recording_Click);
            // 
            // Screenshot_Name
            // 
            this.Screenshot_Name.Location = new System.Drawing.Point(44, 90);
            this.Screenshot_Name.Name = "Screenshot_Name";
            this.Screenshot_Name.Size = new System.Drawing.Size(202, 22);
            this.Screenshot_Name.TabIndex = 3;
            // 
            // Screen_shot_name
            // 
            this.Screen_shot_name.AutoSize = true;
            this.Screen_shot_name.Location = new System.Drawing.Point(41, 71);
            this.Screen_shot_name.Name = "Screen_shot_name";
            this.Screen_shot_name.Size = new System.Drawing.Size(121, 16);
            this.Screen_shot_name.TabIndex = 4;
            this.Screen_shot_name.Text = "Screenshot Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Smart Screen Capture";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 182);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Screen_shot_name);
            this.Controls.Add(this.Screenshot_Name);
            this.Controls.Add(this.Stop_Recording);
            this.Controls.Add(this.Start_Recording);
            this.Controls.Add(this.Capture_Screen);
            this.Name = "Form1";
            this.Text = "Smart Screenshots";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Capture_Screen;
        private System.Windows.Forms.Button Start_Recording;
        private System.Windows.Forms.Button Stop_Recording;
        private System.Windows.Forms.TextBox Screenshot_Name;
        private System.Windows.Forms.Label Screen_shot_name;
        private System.Windows.Forms.Label label1;
    }
}


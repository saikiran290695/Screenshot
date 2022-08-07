using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Screenshot
{    
    internal class Services
    {
        
        private static string folderPath { get; set; }
        private static string imageTempPath { get; set; }
        private static Dictionary<string, string> imagesPath { get; set; }

        public Services(string _folderPath, string _imageTempPath)
        {
            
            folderPath = _folderPath;
            if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);

            imageTempPath = _imageTempPath;
            if (!System.IO.Directory.Exists(imageTempPath)) System.IO.Directory.CreateDirectory(imageTempPath);            

            imagesPath = new Dictionary<string, string>();
        }        
        public void InsertImage(string documentName)
        {
            //Create Document  
            Document document = new Document();
            Section s = document.AddSection();

            foreach (string key in imagesPath.Keys)
            {
                Paragraph p = s.AddParagraph();

                p.AppendText(key);
                p.AppendBreak(BreakType.LineBreak);

                //Insert Image and Set Its Size  
                DocPicture Pic = p.AppendPicture(Image.FromFile(imagesPath[key]));
                Pic.Width = Image.FromFile(imagesPath[key]).Width / 3;
                Pic.Height = Image.FromFile(imagesPath[key]).Height / 3;
                p.AppendBreak(BreakType.LineBreak);
                                
                //Save and Launch  
                document.SaveToFile(folderPath + $"\\{documentName}.docx", FileFormat.Docx);
            };

            System.Diagnostics.Process.Start(folderPath + $"\\{documentName}.docx");
        }

        public void ScreenShot(Form1 form, string imageName)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                form.Hide();
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                form.Show();
                
                string path = $"{imageTempPath}\\{imageName}.jpg";

                bitmap.Save(@path, ImageFormat.Jpeg);
                imagesPath.Add(imageName, path);                
            }
        }

        public void dispose()
        {            
            imagesPath.Clear();
        }
    }
}

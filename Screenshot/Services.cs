using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Screenshot
{
    internal class Services
    {
        private static string folderPath { get; set; }
        private static string imageTempPath { get; set; }
        private static Dictionary<string, string> imagesPath { get; set; }
        private static string rootFolder { get; set; }
        
        public Services(string _folderPath)
        {
            folderPath = _folderPath;
            if (!System.IO.Directory.Exists(folderPath)) System.IO.Directory.CreateDirectory(folderPath);
            
            imagesPath = new Dictionary<string, string>();
        }

        public void setFolderName(string folderName)
        {
            rootFolder = folderName;
            System.IO.Directory.CreateDirectory($"{folderPath}\\{folderName}");

            imageTempPath = $"{folderPath}\\{folderName}\\Screenshots";
            System.IO.Directory.CreateDirectory(imageTempPath);
        }

        public void InsertImage(string documentName)
        {
            Document document = new Document();
            Section s = document.AddSection();

            foreach (string key in imagesPath.Keys)
            {
                Paragraph p = s.AddParagraph();

                p.AppendText($"Image - {key} \n");
                p.AppendText($"Date - {DateTime.Now.ToString()}");
                p.AppendBreak(BreakType.LineBreak);

                DocPicture Pic = p.AppendPicture(Image.FromFile(imagesPath[key]));
                Pic.Width = Image.FromFile(imagesPath[key]).Width / 4;
                Pic.Height = Image.FromFile(imagesPath[key]).Height / 4;
                p.AppendBreak(BreakType.LineBreak);     
                
                document.SaveToFile($"{folderPath}\\{rootFolder}\\{documentName}.docx", FileFormat.Docx);
            };

            System.Diagnostics.Process.Start($"{folderPath}\\{rootFolder}\\{documentName}.docx");
        }

        private static class Win32Native
        {
            public const int DESKTOPVERTRES = 0x75;
            public const int DESKTOPHORZRES = 0x76;

            [DllImport("gdi32.dll")]
            public static extern int GetDeviceCaps(IntPtr hDC, int index);
        }

        public void ScreenShot(string imageName)
        {

            int width, height;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var hDC = g.GetHdc();
                width = Win32Native.GetDeviceCaps(hDC, Win32Native.DESKTOPHORZRES);
                height = Win32Native.GetDeviceCaps(hDC, Win32Native.DESKTOPVERTRES);
                g.ReleaseHdc(hDC);
            }
            
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
                }

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
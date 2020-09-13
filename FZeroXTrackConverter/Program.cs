using FZeroX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FZeroXTrackConverter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var ofd = new OpenFileDialog();
            ofd.Title = "Open Track File To Convert";
            ofd.Filter = "*.crsd|*.crsd";

            if (ofd.ShowDialog() != DialogResult.OK || File.Exists(ofd.FileName) == false) return;

            var sfd = new SaveFileDialog();
            sfd.Title = "Save Track File To Convert";
            sfd.Filter = "*.txt|*.txt";
            sfd.ShowDialog();

            var file = new NewCourseSaveFormat();
            using (var br = new BigEndianBinaryReader(new FileStream(ofd.FileName, FileMode.Open)))
            {
                file.Read(br);
            }

            using (var sw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create)))
            {
                file.Write("FZeroX Track Converter", sw);
            }

            //using (var bw = new BinaryWriter(new FileStream(sfd.FileName, FileMode.Create)))
            //{
            //    file.Write(bw);
            //}
        }
    }
}

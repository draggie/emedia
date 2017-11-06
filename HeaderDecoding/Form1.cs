using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeaderDecoding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private FileReader fileReader;
        private FFT FFT;
        private bool FileLoaded = false;
        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg";
            openFileDialog.Title = "Select a Image File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                preview.SizeMode = PictureBoxSizeMode.Zoom;
                preview.Image = Image.FromFile(openFileDialog.FileName);
                string shortFileName = Path.GetFileName(openFileDialog.FileName);
                event_log_box.AppendText($"Loaded file {shortFileName}");
                event_log_box.AppendText(Environment.NewLine);
                file_info.Text = shortFileName;
                FileLoaded = true;
                try
                {
                    fileReader = new FileReader(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    FileLoaded = false;
                    MessageBox.Show("Specified file is invalid", "Parsing error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        private void decode_headers_Click(object sender, EventArgs e)
        {
            if (FileLoaded)
            {
                event_log_box.AppendText(fileReader.ListHeaders());
                event_log_box.AppendText(Environment.NewLine);
            }
            else
            {
                MessageBox.Show("You have to load image first.", "File not loaded!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            event_log_box.Clear();
        }

        private void load_fft_Click(object sender, EventArgs e)
        {
            if (fileReader!=null && fileReader.HasFile())
            {
                Bitmap image = new Bitmap(fileReader.GetImage(), new Size(256, 256));
                FFT = new FFT(image);
                ffft.Image = FFT.GetForwardFourierTransform();
                bfft.Image = FFT.GetBackwardFourierTransform();
            }
            else
            {
                MessageBox.Show("You have to load image first.", "File not loaded!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

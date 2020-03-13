using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QRCoder;
using System.Drawing.Imaging;
using System.IO;

namespace QRCoderDemo
{
    public partial class Form1 : Form
    {
        string qrcode_text;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string args)
        {
            qrcode_text = args;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenderQrCode();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            RenderQrCode();
        }

        private void RenderQrCode()
        {
            string level = "L";
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode_text, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {

                        pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(20, Color.Black, Color.White,
                            GetIconBitmap(), (int) 15);

                         this.pictureBoxQRCode.Size = new System.Drawing.Size(pictureBoxQRCode.Width, pictureBoxQRCode.Height);
                        //Set the SizeMode to center the image.
                        this.pictureBoxQRCode.SizeMode = PictureBoxSizeMode.CenterImage;

                        pictureBoxQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private Bitmap GetIconBitmap()
        {
            Bitmap img = null;
           
            return img;
        }

    

        private void btn_save_Click(object sender, EventArgs e)
        {

            this.Close();


        }

        public void ExportToBmp(string path)
        {

        }

        private void textBoxQRCode_TextChanged(object sender, EventArgs e)
        {
            RenderQrCode();
        }

        private void comboBoxECC_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderQrCode();
        }
    }
}

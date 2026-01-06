namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private Image? FillPb()
        {


            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
            else
            {
                MessageBox.Show("No Image Selected");
            }

            return pictureBox1.Image;
        }


        private void ConvertImageToBase64(Image? image)
        {
            if (image == null)
            {
                MessageBox.Show("No Image Selected");
                return;
            }


            try
            {

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    textBox1.Text = base64String;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ في تحويل الصورة:\n{ex.Message}",
                    "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ConvertImageToBase64(FillPb());
        }
    }
}
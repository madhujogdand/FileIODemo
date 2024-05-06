using System;
using System.IO;
using System.Windows.Forms;

namespace FileIODemo
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\.NET\FileIOProduct";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("directory exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory created");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\.NET\FileIOProduct\product.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File Exists");
                }
                else
                { 
                   File.Create(path);
                    MessageBox.Show("File created");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\.NET\FileIOProduct\pro.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtId.Text));  
                bw.Write(txtName.Text); 
                bw.Write(Convert.ToDouble(txtPrice.Text));
                bw.Close();
                fs.Close();
                MessageBox.Show("Added the data");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\.NET\FileIOProduct\pro.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtPrice.Text = br.ReadDouble().ToString(); 
                br.Close(); 
                fs.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnStramWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\.NET\FileIOProduct\sample.txt", FileMode.Create, FileAccess.Write);
               StreamWriter sw= new StreamWriter(fs);   
                sw.Write(richTextBox1.Text);
                sw.Close();
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\.NET\FileIOProduct\sample.txt", FileMode.Open, FileAccess.Read);
                StreamReader sw= new StreamReader(fs);
                richTextBox1.Text= sw.ReadToEnd();  
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using Facebook.facebooksv;
using System.IO;

namespace Facebook
{
    public partial class facebook : Form
    {
        public facebook()
        {
            InitializeComponent();
        }

        private void picFacebookButton_Click(object sender, EventArgs e)
        {
            Facebook.facebooksv.FacebookService sv = new Facebook.facebooksv.FacebookService();
            var ls = sv.DoWork();
            string newfile = getFileHost();

            newfile += "# -------- Start Jaibreak Facebook -------- \r\n";
            foreach (address add in ls)
            {
                newfile += add.line + " #facebook.shinguyen.net \r\n"; ;
            }
            newfile += "# -------- End Jaibreak Facebook   --------";
            writefile(newfile,backup);
        }
        private string backup = string.Empty;
        private string getFileHost()
        {
            TextReader tr = new StreamReader(@"C:\Windows\System32\drivers\etc\hosts");
            string line = string.Empty;
            string newfile = string.Empty;
            while ((line = tr.ReadLine()) != null)
            {
                backup += line + "\r\n #"  ;
                if (System.Text.RegularExpressions.Regex.IsMatch(line, @"facebook") || System.Text.RegularExpressions.Regex.IsMatch(line, @"fbcdn") || System.Text.RegularExpressions.Regex.IsMatch(line, @"Facebook"))
                {
                    
                }
                else
                {
                    newfile += line + "\r\n";
                }
            }
            tr.Close();
            return newfile;
        }


        private void writefile(string write,string write_backup)
        {
            try
            {
                TextWriter tw = new StreamWriter(@"C:\Windows\System32\drivers\etc\hosts");
                tw.Write(write);
                tw.Close();

                TextWriter tw_backup = new StreamWriter(@"C:\Windows\System32\drivers\etc\hosts.backup");
                tw_backup.Write(write_backup);
                tw_backup.Close();


                MessageBox.Show("Jaibreak Facebook Finish !!!");
            }
            catch (Exception e) {
                MessageBox.Show("Máy tính bạn được bảo vệ nghiêm ngặt, vui lòng click chuột phải và chọn Run administrator ");
            }
        }

        private void picFacebookButton_MouseHover(object sender, EventArgs e)
        {
            this.picFacebookButton.Image = global::Facebook.Properties.Resources.conaibanganhshinua;
        }

        private void picFacebookButton_MouseLeave(object sender, EventArgs e)
        {
            this.picFacebookButton.Image = global::Facebook.Properties.Resources.anhshideptrai;
        }

        private void facebook_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn phải đổi DNS của Google là 8.8.8.8 trước khi thực hiện Unlock Facebook");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

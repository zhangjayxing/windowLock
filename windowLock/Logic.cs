using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowLock
{
    public partial class Logic : Form
    {
        public Logic()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            string userId = txtUser.Text.Trim();
            string pwd = txtPwd.Text.Trim();

            string pwdDES= Comm.EncryptDES(pwd,"12345679");
            string sql = string.Format("select COUNT(*) from UserInfo where UserId='{0}' and Pwd='{1}'",userId,pwdDES);

            int result=Convert.ToInt32( SqlCom.selectSingle(sql));
            if (result > 0)
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("密码都不记得，你看个毛啊！！");
                
            }
        }
    }
}

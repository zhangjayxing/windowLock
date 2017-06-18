using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowLock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fbdSelect.ShowDialog()==DialogResult.OK)
            {
                txtFilePath.Text = fbdSelect.SelectedPath;
            }
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAll.Checked == true)
            {
                ckavi.Checked = true;
                ckmkv.Checked = true;
                ckmp4.Checked = true;
                ckrmvb.Checked = true;
            }
            else
            {
                ckavi.Checked = false;
                ckmkv.Checked = false;
                ckmp4.Checked = false;
                ckrmvb.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pwd = txtPWD.Text.Trim();

            string pwdDES = Comm.EncryptDES(pwd, "12345679");
            string sql = string.Format("select COUNT(*) from UserInfo where UserId='{0}' and Pwd='{1}'", "admin", pwdDES);

            int result = Convert.ToInt32(SqlCom.selectSingle(sql));
            if (result > 0)
            {
                int pathId = Convert.ToInt32(cbPath.SelectedValue);
                DataTable dt = SqlCom.QueryList(string.Format("select FileName,Path from FileInfo a inner join FilePath b on a.PathID=b.id where b.Id={0}", pathId));
                foreach (DataRow item in dt.Rows)
                {
                    string path = item["Path"].ToString() + "\\" + item["FileName"].ToString();
                    if (File.Exists(path))
                    {
                        FileInfo fi = new FileInfo(path);
                        fi.Attributes = FileAttributes.Archive;

                    }

                }
                MessageBox.Show("还原成功！");
            }
            else
            {
                MessageBox.Show("密码都不记得，你还原个毛啊！！");
                return;
            }

            

        }


        /*
        如何获取指定目录包含的文件和子目录
        1. DirectoryInfo.GetFiles()：获取目录中（不包含子目录）的文件，返回类型为FileInfo[]，支持通配符查找；
        2. DirectoryInfo.GetDirectories()：获取目录（不包含子目录）的子目录，返回类型为DirectoryInfo[]，支持通配符查找；
        3. DirectoryInfo. GetFileSystemInfos()：获取指定目录下（不包含子目录）的文件和子目录，返回类型为FileSystemInfo[]，支持通配符查找；
        如何获取指定文件的基本信息；
        FileInfo.Exists：获取指定文件是否存在；
        FileInfo.Name，FileInfo.Extensioin：获取文件的名称和扩展名；
        FileInfo.FullName：获取文件的全限定名称（完整路径）；
        FileInfo.Directory：获取文件所在目录，返回类型为DirectoryInfo；
        FileInfo.DirectoryName：获取文件所在目录的路径（完整路径）；
        FileInfo.Length：获取文件的大小（字节数）；
        FileInfo.IsReadOnly：获取文件是否只读；
        FileInfo.Attributes：获取或设置指定文件的属性，返回类型为FileAttributes枚举，可以是多个值的组合
        FileInfo.CreationTime、FileInfo.LastAccessTime、FileInfo.LastWriteTime：分别用于获取文件的创建时间、访问时间、修改时间；
        */
        private void btnDispose_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txtFilePath.Text.Trim()))
            {
                return;
            }
            else
            {
                if (!Directory.Exists(txtFilePath.Text.Trim()))//判断是否存在
                {
                    MessageBox.Show("路径不存在！");
                    return;
                }
                else
                {
                    if (ckavi.Checked == true || ckmkv.Checked == true || ckmp4.Checked == true || ckrmvb.Checked == true)
                    {
                        bool isResult = false;
                        //遍历指定文件夹中的所有文件
                        DirectoryInfo TheFolder = new DirectoryInfo(txtFilePath.Text.Trim());
                        //获取目录（不包含子目录）的子目录，返回类型为DirectoryInfo[]，支持通配符查找；
                        FileInfo[] fileInfo = TheFolder.GetFiles();
                        foreach (FileInfo item in fileInfo)
                        {
                                string Ext = item.Extension;
                                if (ckavi.Checked == true)
                                {
                                    if (Ext.ToLower().Equals(".avi"))
                                    {
                                    isResult =  CheckAttributes(item);
                                    }
                                }
                                if (ckmkv.Checked == true)
                                {
                                    if (Ext.ToLower().Equals(".mkv"))
                                    {
                                    isResult = CheckAttributes(item);
                                    }

                                }
                                if (ckmp4.Checked == true)
                                {
                                    if (Ext.ToLower().Equals(".mp4"))
                                    {
                                    isResult = CheckAttributes(item);
                                    }
                                }
                                if (ckrmvb.Checked == true)
                                {
                                    if (Ext.ToLower().Equals(".rmvb"))
                                    {
                                    isResult = CheckAttributes(item);
                                    }
                                }
                          
                        


                        }

                        MessageBox.Show("处理成功！");
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public bool CheckAttributes(FileInfo item)
        {
            string sql = string.Format("select Id from FilePath  where Path='{0}'", txtFilePath.Text.Trim());
            string pathId = SqlCom.selectSingle(sql);//路径ID
            if (pathId == null)
            {
                string sqlIns = string.Format("INSERT INTO FilePath([Path],[UpdateTime],[CheckUp]) VALUES('{0}','{1}','0')", txtFilePath.Text.Trim(), DateTime.Now);
                if (SqlCom.Add(sqlIns))
                {
                    pathId = SqlCom.selectSingle(sql);
                }

            }

            string sqlFile = string.Format("select Id from FileInfo where FileName = '{0}'", item.Name);
            string FileId = SqlCom.selectSingle(sqlFile);//文件ID
            if (FileId == null)
            {

                //string encName = Comm.EncryptString(item.Name, "abc");
                string sqlInsFile = string.Format("INSERT INTO[FileInfo]([FileName] ,[CheckFileName],[PathID] ,[Form]) VALUES('{0}', '{1}' ,'{2}' ,'{3}')", item.Name, "", pathId, item.Extension);
                if (SqlCom.Add(sqlInsFile))
                {
                    FileId = SqlCom.selectSingle(sqlFile);
                    item.Attributes = FileAttributes.Hidden;//设置文件隐藏
                    return true;
                }

            }
            else
            {
                item.Attributes = FileAttributes.Hidden;//设置文件隐藏
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt= SqlCom.QueryList("select Id,[Path] from FilePath");
            cbPath.DataSource = dt;
            cbPath.DisplayMember = "Path";
            cbPath.ValueMember = "Id";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

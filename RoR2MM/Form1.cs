using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //add this namespace also 

namespace WindowsFormsApp4
{

    public partial class Form1 : Form
    {
        static System.String currentDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        Boolean checkInstalled = false;

        public Form1()
        {

            InitializeComponent();
            checkForFolder("\\mods\\");
            checkForFolder("\\unloaded\\");

        }
        
        private void checkedListBox1_ItemCheck(object sender, EventArgs e)
        {
            if(checkedListBox1.SelectedIndex > -1)
            {
                iwanttodie(Convert.ToString(checkedListBox1.SelectedItem));
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;

            label2.Text = "";
            if (File.Exists(currentDir+ "\\Assembly-CSharp_Vanilla.dll"))
            {
                checkInstalled = true;
            }
            else
            {
                checkInstalled = false;
            }

            if (checkInstalled)
            {
                button1.ForeColor = System.Drawing.Color.Red;
                button1.Text = "Uninstall Mod";
                
            }
            else
            {
                button1.ForeColor = System.Drawing.Color.Green;
                button1.Text = "Install Mod";
            }


            var pos0 = this.PointToScreen(label1.Location);
            pos0 = pictureBox1.PointToClient(pos0);
            label1.Parent = pictureBox1;
            label1.Location = pos0;
            label1.BackColor = Color.Transparent;

            var pos1 = this.PointToScreen(label1.Location);
            pos1 = checkedListBox1.PointToClient(pos1);
            label2.Parent = checkedListBox1;
            label2.Location = pos1;
            label2.BackColor = Color.Transparent;

            string[] files = new DirectoryInfo(currentDir + "\\mods").GetFiles().Select(o => o.Name).ToArray();
            string[] unloaded = new DirectoryInfo(currentDir + "\\unloaded").GetFiles().Select(o => o.Name).ToArray();
            for (int i = 0; i < files.Length; i++)
            {
                checkedListBox1.Items.Add(files[i]);
                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
            for (int i = 0; i < unloaded.Length; i++)
            {
                checkedListBox1.Items.Add(unloaded[i]);
                checkedListBox1.SetItemCheckState(files.Length+i, CheckState.Unchecked);
            }
            if ((files.Length == 0) && (unloaded.Length == 0))
            {
                label2.Text = "No Mods found";
            }

        }

        public static void checkForFolder(string foldername)
        {
            if (!System.IO.Directory.Exists(currentDir + foldername))
            {
                System.IO.Directory.CreateDirectory(currentDir + foldername);
            }
            else
            {
                //MessageBox.Show("Directory \"{0}\" already exists.", currentDir + foldername);
                return;
            }
        }

        void iwanttodie(string fil)
        {
            string fileName = Convert.ToString(fil);
           
          // 

            if ((checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Checked))
            {
                string sourcePath =currentDir+@"\mods\";
                string targetPath = currentDir + @"\unloaded\";
                string sourceFile = System.IO.Path.Combine(currentDir + sourcePath+fileName, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                if (System.IO.Directory.Exists(sourcePath))
                {
                        System.IO.File.Move(sourcePath+fileName,targetPath+ fileName);
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
            }
            else
            {
                string targetPath = currentDir + @"\mods\";
                string sourcePath = currentDir + @"\unloaded\";
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                if (System.IO.Directory.Exists(sourcePath))
                {
                    System.IO.File.Move(sourcePath + fileName, targetPath + fileName);
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(currentDir + "\\_InstallMod.bat"))
            {
                MessageBox.Show("Could not find _InstallMod.bat");
            }
            else
            {
                if (checkInstalled)
                {
                    button1.ForeColor = System.Drawing.Color.Green;
                    button1.Text = "Uninstall Mod";


                    File.Replace(currentDir + "\\Assembly-CSharp_Vanilla.dll", currentDir + "\\Assembly-CSharp.dll", null);
                    checkInstalled = !checkInstalled;
                }
                else
                {
                    button1.ForeColor = System.Drawing.Color.Red;
                    button1.Text = "Uninstall Mod";
                    try
                    {
                        System.Diagnostics.Process.Start(currentDir + "\\_InstallMod.bat");
                    }
                    catch (Exception f)
                    {
                        MessageBox.Show("Could not find _InstallMod.bat");
                    }
                    checkInstalled = !checkInstalled;
                }
            }
        }
    }
}

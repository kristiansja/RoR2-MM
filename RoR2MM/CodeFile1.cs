/*
 * 
 * 
 * private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = Convert.ToString(checkedListBox1.SelectedItem);
            // MessageBox.Show(fileName);


            if (checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Checked)
            {
                string sourcePath = @"\\mods\\";
                string targetPath = @"\\mods\\unloaded\\";
                string sourceFile = System.IO.Path.Combine(currentDir + sourcePath, fileName);
                string destFile = System.IO.Path.Combine(currentDir + targetPath, fileName);
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
            }
            else
            {
                string targetPath = @"\\mods\\";
                string sourcePath = @"\\mods\\unloaded\\";
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    Console.WriteLine("Source path does not exist!");
                }
            }



            */
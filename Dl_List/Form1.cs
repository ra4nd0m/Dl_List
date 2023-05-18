using System.Diagnostics;
//TODO
//Statistics

namespace Dl_List
{
    public partial class Main : Form
    {
        const string configPath = "paths";
        List<DownloadObj> source = new List<DownloadObj>();
        List<DownloadObj> source_bak = new List<DownloadObj>();
        List<Path> paths = new List<Path>();
        string? currentSort;
        string? nameSort;
        string? typeSort;
        string? sizeSort;
        string? fileSort;
        string? pathSort;
        string? currentPath;
        bool filterUsed = false;
        List<DownloadObj> filtered_source = new List<DownloadObj>();
        bool FilesHidden = false;
        bool FoldersHidden = false;
        Dictionary<string, string> sizes = new Dictionary<string, string>();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            fillSource();
            sizes.Add("Bytes", "KB");
            sizes.Add("KB", "MB");
            sizes.Add("MB", "GB");
            sizes.Add("GB", "Bytes");
            dataGridView1.DataSource = source;
            //dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView2.DataSource = paths;
            sortTable(0);
        }

        private void fillSource()
        {
            source.Clear();
            paths = getPaths();
            foreach (var item in paths)
            {
                currentPath = item.path;
                string[] folders = Directory.GetDirectories(item.path, "*", SearchOption.TopDirectoryOnly);
                foreach (string folder in folders)
                {
                    string directoryName = System.IO.Path.GetFileName(folder);
                    string type = "Other";
                    switch (directoryName)
                    {
                        case "Books":
                            type = directoryName;
                            break;
                        case "Games":
                            type = directoryName;
                            break;
                        case "Music":
                            type = directoryName;
                            break;
                        case "Programs":
                            type = directoryName;
                            break;
                        case "Videos":
                            type = directoryName;
                            break;
                    }
                    if (type != "Other")
                    {
                        scanDirs(folder, type);
                        scanFiles(folder, type);
                    }
                    else
                        scanDir(folder, type);
                }
                scanFiles(item.path, "Other");
            }
            currentPath = null;
            source_bak = source;
        }
        private void scanDirs(string folder, string type)
        {
            string[] strings = Directory.GetDirectories(folder, "*", SearchOption.TopDirectoryOnly);
            foreach (string str in strings)
            {
                scanDir(str, type);
            }
        }
        private void scanDir(string folder, string type)
        {
            DirectoryInfo info = new DirectoryInfo(folder);
            //in bytes
            long totalSize = info.EnumerateFiles("*", SearchOption.AllDirectories).Sum(f => f.Length);
            //totalSize = totalSize / 1024;//kb
            //totalSize = totalSize / 1024;//mb
            DownloadObj obj = new DownloadObj(System.IO.Path.GetFileName(folder), totalSize, System.IO.Path.GetDirectoryName(folder), type, false, currentPath);
            source.Add(obj);
        }

        private void scanFiles(string folder, string type)
        {
            string[] strings = Directory.GetFiles(folder, "*", SearchOption.TopDirectoryOnly);
            foreach (var str in strings)
            {
                FileInfo fi = new FileInfo(str);
                long totalSize = fi.Length;
                // totalSize /= 1024;
                DownloadObj obj = new DownloadObj(System.IO.Path.GetFileName(str), totalSize, folder, type, true, currentPath);
                source.Add(obj);
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (source[e.RowIndex].IsFile)
                    Process.Start("explorer.exe", "/select, "+source[e.RowIndex].FullPath);
                else
                    Process.Start("explorer.exe", source[e.RowIndex].FullPath);
            }
            catch
            {
                //empty for a reason
            }
        }

        private List<Path> getPaths()
        {
            List<Path> paths = new List<Path>();
            try
            {
                using (FileStream fs = new FileStream(configPath, FileMode.Open, FileAccess.Read))
                {
                    StreamReader sr = new StreamReader(fs);
                    string? line = sr.ReadLine();
                    if (line == null)
                        throw new Exception(Name = "Config file is empty!\nAdd new paths.");
                    while (line != null)
                    {
                        paths.Add(new Path(line));
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
            return (paths);
        }

        private void addPathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string path = folderBrowserDialog1.SelectedPath;
            try
            {
                foreach (var p in paths)
                {
                    if (p.path == path)
                        throw new Exception(Name = "Duplicate found!");
                }
                paths.Add(new Path(path));
                savePaths();
                reattachPaths(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void removePathButton_Click(object sender, EventArgs e)
        {
            if (paths.Count() != 0)
            {
                int selectedRowsCount = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowsCount > 0)
                {
                    DialogResult Result = MessageBox.Show("Delete selected paths?", "Warning!", MessageBoxButtons.YesNo);
                    if (Result == DialogResult.Yes)
                    {
                        List<Path> deletedPaths = new List<Path>();
                        for (int i = 0; i < selectedRowsCount; i++)
                            deletedPaths.Add(paths[dataGridView2.SelectedRows[i].Index]);
                        foreach (var p in deletedPaths)
                            paths.Remove(p);
                        savePaths();
                        reattachPaths(true);
                    }
                }
            }
        }
        private void reattachPaths(bool refill)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = paths;
            dataGridView1.DataSource = null;
            if (refill)
                fillSource();
            dataGridView1.DataSource = source;
            //dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void savePaths()
        {
            try
            {
                StreamWriter sw = new StreamWriter(configPath, false);
                foreach (var path in paths)
                {
                    sw.WriteLine(path);
                }
                sw.Close();
            }
            catch
            {
                MessageBox.Show("Config write error!", "Error", MessageBoxButtons.OK);
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Process.Start("explorer.exe", paths[e.RowIndex].path);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            reattachPaths(true);
        }

        private void buttonHideFiles_Click(object sender, EventArgs e)
        {
            FilesHidden = !FilesHidden;
            if (FilesHidden)
            {
                buttonHideFiles.Text = "Show Files";
                source = source.Where(x => !x.IsFile).ToList();
            }
            else
            {
                buttonHideFiles.Text = "Hide Files";
                if (FoldersHidden)
                    source = source_bak.Where(x => x.IsFile).ToList();
                else
                    source = source_bak;

            }
            reattachPaths(false);
        }

        private void buttonHideFolders_Click(object sender, EventArgs e)
        {
            FoldersHidden = !FoldersHidden;
            if (FoldersHidden)
            {
                buttonHideFolders.Text = "Show Folders";
                source = source.Where(x => x.IsFile).ToList();
            }
            else
            {
                buttonHideFolders.Text = "Hide Folders";
                if (FilesHidden)
                    source = source_bak.Where(x => !x.IsFile).ToList();
                else
                    source = source_bak;
            }
            reattachPaths(false);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sortTable(e.ColumnIndex);
        }

        private void sortTable(int columnIndex)
        {
            switch (columnIndex)
            {
                case 0:
                    nameSort = (String.IsNullOrEmpty(nameSort) || nameSort == "name_desc") ? "name" : "name_desc";
                    currentSort = nameSort;
                    break;
                case 1:
                    typeSort = (typeSort == "type_desc" || String.IsNullOrEmpty(typeSort)) ? "type" : "type_desc";
                    currentSort = typeSort;
                    break;
                case 2:
                    sizeSort = (sizeSort == "size_desc" || String.IsNullOrEmpty(sizeSort)) ? "size" : "size_desc";
                    currentSort = sizeSort;
                    break;
                case 3:
                    pathSort = (pathSort == "path_desc" || String.IsNullOrEmpty(pathSort)) ? "path" : "path_desc";
                    currentSort = pathSort;
                    break;
                case 4:
                    fileSort = (fileSort == "file_desc" || String.IsNullOrEmpty(fileSort)) ? "file" : "file_desc";
                    currentSort = fileSort;
                    break;
            }
            switch (currentSort)
            {
                case "type_desc":
                    source = source.OrderByDescending(x => x.Type).ToList();
                    break;
                case "type":
                    source = source.OrderBy(x => x.Type).ToList();
                    break;
                case "name_desc":
                    source = source.OrderByDescending(x => x.Name).ToList();
                    break;
                case "size":
                    source = source.OrderBy(x => x.Size).ToList();
                    break;
                case "size_desc":
                    source = source.OrderByDescending(x => x.Size).ToList();
                    break;
                case "path":
                    source = source.OrderBy(x => x.Path).ToList();
                    break;
                case "path_desc":
                    source = source.OrderByDescending(x => x.Path).ToList();
                    break;
                case "file":
                    source = source.OrderBy(x => x.IsFile).ToList();
                    break;
                case "file_desc":
                    source = source.OrderByDescending(x => x.IsFile).ToList();
                    break;
                default:
                    source = source.OrderBy(x => x.Name).ToList();
                    break;
            }
            reattachPaths(false);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchString = textBox1.Text;
            if (filterUsed)
                source = filtered_source;
            else
                source = source_bak;
            if (!String.IsNullOrEmpty(searchString))
            {
                source = source.Where(s => s.Name.Contains(searchString)).ToList();
            }
            reattachPaths(false);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Delete selected entries?", "Warning!", MessageBoxButtons.YesNo);
            int selectedRowsCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (Result == DialogResult.Yes && selectedRowsCount > 0)
            {
                for (int i = 0; i < selectedRowsCount; i++)
                {
                    int index = dataGridView1.SelectedRows[i].Index;
                    if (source[index].IsFile)
                        File.Delete(source[index].FullPath);
                    else
                        Directory.Delete(source[index].FullPath, true);
                }
                reattachPaths(true);
            }
        }

        private void buttonSelectSize_Click(object sender, EventArgs e)
        {
            string next = sizes[DownloadObj.ShownSize];
            DownloadObj.ShownSize = next;
            buttonSelectSize.Text = next;
            reattachPaths(false);
        }

        private void buttonPathHide_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            int count = 0;
            if (selectedRowsCount > 0)
            {
                for (int i = 0; i < selectedRowsCount; i++)
                {
                    int index = dataGridView2.SelectedCells[i].RowIndex;
                    paths[index].isHidden = !paths[index].isHidden;
                }
                source = source_bak;

                foreach (var p in paths)
                {
                    if (p.isHidden)
                    {
                        source = source.Where(x => x.RootPath != p.path).ToList();
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                filterUsed = true;
                filtered_source = source;
            }
            else
            {
                filterUsed = false;
                filtered_source.Clear();
            }
            reattachPaths(false);
        }
    }
}
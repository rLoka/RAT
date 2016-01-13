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

namespace Server
{
    public partial class FileForm : Form
    {
        public FileForm()
        {
            InitializeComponent();
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            ListDirectory(fileDirView1, Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileDirImgList);
            
        }

        private static void ListDirectory(TreeView treeView, string path, ImageList fileDirImgList)
        {
            treeView.Nodes.Clear();
            treeView.ImageList = fileDirImgList;

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                try { 
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    childDirectoryNode.ImageIndex = 1;
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                foreach (var file in directoryInfo.GetFiles())
                    currentNode.Nodes.Add(new TreeNode(file.Name));
                }
                catch (Exception ex) { }
            }

            treeView.Nodes.Add(node);
        }

        private void fileDirView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

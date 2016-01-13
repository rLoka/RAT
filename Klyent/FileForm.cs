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

        TreeView newTreeView = new TreeView();

        public FileForm()
        {
            InitializeComponent();
        }

        public void receiveTreeview(TreeView treeView)
        {
            newTreeView = treeView;
            newTreeView.ImageList = fileDirImgList;
            //newTreeView.ImageIndex = 1;
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            CopyTreeNodes(newTreeView, fileDirView1);
        }

        public void CopyTreeNodes(TreeView treeview1, TreeView treeview2)
        {
            treeview2.ImageList = fileDirImgList;
            treeview2.SelectedImageIndex = 2;
            TreeNode newTn;
            foreach (TreeNode tn in treeview1.Nodes)
            {
                newTn = new TreeNode(tn.Text);                
                CopyChildren(newTn, tn);
                if (newTn.ToString().Contains("."))
                {
                    newTn.ImageIndex = 0;
                }
                else
                {
                    newTn.ImageIndex = 1;
                }
                treeview2.Nodes.Add(newTn);
            }
        }

        public void CopyChildren(TreeNode parent, TreeNode original)
        {
            TreeNode newTn;
            foreach (TreeNode tn in original.Nodes)
            {
                newTn = new TreeNode(tn.Text);
                parent.Nodes.Add(newTn);
                CopyChildren(newTn, tn);
                if (newTn.ToString().Contains("."))
                {
                    newTn.ImageIndex = 0;
                }
                else
                {
                    newTn.ImageIndex = 1;
                }
            }
        }
    }
}

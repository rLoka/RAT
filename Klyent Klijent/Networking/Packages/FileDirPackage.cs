using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Klijent.Networking.Packages
{
    class FileDirPackage
    {
        public int packageId { get; set; }
        public TreeView treeView { get; set; }

        public FileDirPackage(TreeView treeview)
        {
            packageId = 9;
            treeView = treeview;
        }

        //Deserijalizacija podataka
        public FileDirPackage(byte[] data)
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream();

            memoryStream.Write(data, 4, data.Length);
            memoryStream.Position = 0;

            object treeNodesListObj = binaryFormatter.Deserialize(memoryStream);
            TreeNode[] nodeList = (treeNodesListObj as IEnumerable<TreeNode>).ToArray();
            treeView.Nodes.AddRange(nodeList);
        }

        //Serijalizacija podataka

        private byte[] treeViewToByteArray(TreeView treeview)
        {
            try
            {
                var binaryFormatter = new BinaryFormatter();
                var memoryStream = new MemoryStream();
                binaryFormatter.Serialize(memoryStream, treeView.Nodes.Cast<TreeNode>().ToList());
                return memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(packageId));
            byte[] treeViewBytes = treeViewToByteArray(treeView);
            byteList.AddRange(BitConverter.GetBytes(treeViewBytes.Length));
            byteList.AddRange(treeViewBytes);

            return byteList.ToArray();
        }
    }
}

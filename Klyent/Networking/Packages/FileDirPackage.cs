using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Networking.Packages
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
            try {
            treeView = new TreeView();

            var binaryFormatter = new BinaryFormatter();            
            var memoryStream = new MemoryStream();

            int treeViewLength = BitConverter.ToInt32(data, 4);
            byte[] fileDirPacketBytes = new byte[treeViewLength];
            Buffer.BlockCopy(data, 8, fileDirPacketBytes, 0, treeViewLength);

            memoryStream.Write(fileDirPacketBytes, 0, treeViewLength);
            memoryStream.Position = 0;

            object treeNodesListObj = binaryFormatter.Deserialize(memoryStream);
            TreeNode[] nodeList = (treeNodesListObj as IEnumerable<TreeNode>).ToArray();
            treeView.Nodes.AddRange(nodeList);
            }
            catch (Exception ex) { }
        }

        //Serijalizacija podataka

        private byte[] treeViewToByteArray(TreeView treeview)
        {
            var binaryFormatter = new BinaryFormatter();
            var memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, treeView.Nodes.Cast<TreeNode>().ToList());
            return memoryStream.ToArray();
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

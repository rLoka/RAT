namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.connectionList = new System.Windows.Forms.DataGridView();
            this.cntxtMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRefreshClientList = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSlanjeDat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOdspojiKlijenta = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTakeScreenshot = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.opcijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postaviPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbPort = new System.Windows.Forms.ToolStripTextBox();
            this.btnPostaviPort = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSlusajKonekcije = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZatvori = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.timerCheckForConnectedClients = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.connectionList)).BeginInit();
            this.cntxtMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionList
            // 
            this.connectionList.AllowUserToAddRows = false;
            this.connectionList.AllowUserToDeleteRows = false;
            this.connectionList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.connectionList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.connectionList.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.connectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectionList.ContextMenuStrip = this.cntxtMenuStrip;
            this.connectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionList.Location = new System.Drawing.Point(0, 24);
            this.connectionList.Name = "connectionList";
            this.connectionList.ReadOnly = true;
            this.connectionList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.connectionList.Size = new System.Drawing.Size(633, 255);
            this.connectionList.TabIndex = 0;
            // 
            // cntxtMenuStrip
            // 
            this.cntxtMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshClientList,
            this.btnSendMessage,
            this.btnSlanjeDat,
            this.btnOdspojiKlijenta,
            this.btnTakeScreenshot});
            this.cntxtMenuStrip.Name = "cntxtMenuStrip";
            this.cntxtMenuStrip.Size = new System.Drawing.Size(176, 114);
            this.cntxtMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cntxtMenuStrip_Opening);
            // 
            // btnRefreshClientList
            // 
            this.btnRefreshClientList.Image = global::Server.Properties.Resources.arrow_circle_double_135;
            this.btnRefreshClientList.Name = "btnRefreshClientList";
            this.btnRefreshClientList.Size = new System.Drawing.Size(175, 22);
            this.btnRefreshClientList.Text = "Osvježi";
            this.btnRefreshClientList.Click += new System.EventHandler(this.btnRefreshClientList_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Image = global::Server.Properties.Resources.mail;
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(175, 22);
            this.btnSendMessage.Text = "Pošalji poruku";
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSlanjeDat
            // 
            this.btnSlanjeDat.Image = global::Server.Properties.Resources.inbox_upload;
            this.btnSlanjeDat.Name = "btnSlanjeDat";
            this.btnSlanjeDat.Size = new System.Drawing.Size(175, 22);
            this.btnSlanjeDat.Text = "Slanje datoteke";
            this.btnSlanjeDat.Click += new System.EventHandler(this.btnSlanjeDat_Click);
            // 
            // btnOdspojiKlijenta
            // 
            this.btnOdspojiKlijenta.Image = global::Server.Properties.Resources.minus_button;
            this.btnOdspojiKlijenta.Name = "btnOdspojiKlijenta";
            this.btnOdspojiKlijenta.Size = new System.Drawing.Size(175, 22);
            this.btnOdspojiKlijenta.Text = "Odspoji klijenta";
            this.btnOdspojiKlijenta.Click += new System.EventHandler(this.btnOdspojiKlijenta_Click);
            // 
            // btnTakeScreenshot
            // 
            this.btnTakeScreenshot.Image = global::Server.Properties.Resources.monitor_image;
            this.btnTakeScreenshot.Name = "btnTakeScreenshot";
            this.btnTakeScreenshot.Size = new System.Drawing.Size(175, 22);
            this.btnTakeScreenshot.Text = "Napravi screenshot";
            this.btnTakeScreenshot.Click += new System.EventHandler(this.btnTakeScreenshot_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 279);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(633, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.Image = global::Server.Properties.Resources.globe_network_ethernet;
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(74, 17);
            this.lblStatusLabel.Text = "Neaktvno";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcijeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(633, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // opcijeToolStripMenuItem
            // 
            this.opcijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postaviPortToolStripMenuItem,
            this.btnSlusajKonekcije,
            this.btnZatvori});
            this.opcijeToolStripMenuItem.Image = global::Server.Properties.Resources.gear;
            this.opcijeToolStripMenuItem.Name = "opcijeToolStripMenuItem";
            this.opcijeToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcijeToolStripMenuItem.Text = "Opcije";
            // 
            // postaviPortToolStripMenuItem
            // 
            this.postaviPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPort,
            this.btnPostaviPort});
            this.postaviPortToolStripMenuItem.Image = global::Server.Properties.Resources.network_ip_local;
            this.postaviPortToolStripMenuItem.Name = "postaviPortToolStripMenuItem";
            this.postaviPortToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.postaviPortToolStripMenuItem.Text = "Postavi port";
            // 
            // tbPort
            // 
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 23);
            this.tbPort.Text = "6556";
            this.tbPort.TextChanged += new System.EventHandler(this.tbPort_TextChanged);
            // 
            // btnPostaviPort
            // 
            this.btnPostaviPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPostaviPort.Image = global::Server.Properties.Resources.tick_button;
            this.btnPostaviPort.Name = "btnPostaviPort";
            this.btnPostaviPort.Size = new System.Drawing.Size(160, 22);
            this.btnPostaviPort.Text = "Postavi";
            this.btnPostaviPort.Click += new System.EventHandler(this.btnPostaviPort_Click);
            // 
            // btnSlusajKonekcije
            // 
            this.btnSlusajKonekcije.Enabled = false;
            this.btnSlusajKonekcije.Image = global::Server.Properties.Resources.plug_connect;
            this.btnSlusajKonekcije.Name = "btnSlusajKonekcije";
            this.btnSlusajKonekcije.Size = new System.Drawing.Size(157, 22);
            this.btnSlusajKonekcije.Text = "Slušaj konekcije";
            this.btnSlusajKonekcije.Click += new System.EventHandler(this.btnSlusajKonekcije_Click);
            // 
            // btnZatvori
            // 
            this.btnZatvori.Image = global::Server.Properties.Resources.cross_circle;
            this.btnZatvori.Name = "btnZatvori";
            this.btnZatvori.Size = new System.Drawing.Size(157, 22);
            this.btnZatvori.Text = "Zatvori";
            this.btnZatvori.Click += new System.EventHandler(this.btnZatvori_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "application-blue.png");
            this.imageList.Images.SetKeyName(1, "application-search-result.png");
            this.imageList.Images.SetKeyName(2, "application-terminal.png");
            this.imageList.Images.SetKeyName(3, "application-tree.png");
            this.imageList.Images.SetKeyName(4, "arrow-circle-315.png");
            this.imageList.Images.SetKeyName(5, "balloon.png");
            this.imageList.Images.SetKeyName(6, "bell.png");
            this.imageList.Images.SetKeyName(7, "binocular.png");
            this.imageList.Images.SetKeyName(8, "blue-documents-stack.png");
            this.imageList.Images.SetKeyName(9, "blue-folder-horizontal-open.png");
            this.imageList.Images.SetKeyName(10, "blue-folder--plus.png");
            this.imageList.Images.SetKeyName(11, "blueprint--minus.png");
            this.imageList.Images.SetKeyName(12, "book-open.png");
            this.imageList.Images.SetKeyName(13, "box.png");
            this.imageList.Images.SetKeyName(14, "briefcase.png");
            this.imageList.Images.SetKeyName(15, "bug.png");
            this.imageList.Images.SetKeyName(16, "burn.png");
            this.imageList.Images.SetKeyName(17, "calendar-day.png");
            this.imageList.Images.SetKeyName(18, "camera-lens.png");
            this.imageList.Images.SetKeyName(19, "chart.png");
            this.imageList.Images.SetKeyName(20, "clipboard-paste.png");
            this.imageList.Images.SetKeyName(21, "cross.png");
            this.imageList.Images.SetKeyName(22, "disk.png");
            this.imageList.Images.SetKeyName(23, "disk--arrow.png");
            this.imageList.Images.SetKeyName(24, "drive-download.png");
            this.imageList.Images.SetKeyName(25, "envelope.png");
            this.imageList.Images.SetKeyName(26, "exclamation-red.png");
            this.imageList.Images.SetKeyName(27, "exclamation-shield.png");
            this.imageList.Images.SetKeyName(28, "eye.png");
            this.imageList.Images.SetKeyName(29, "folder.png");
            this.imageList.Images.SetKeyName(30, "folder--arrow.png");
            this.imageList.Images.SetKeyName(31, "funnel.png");
            this.imageList.Images.SetKeyName(32, "funnel--plus.png");
            this.imageList.Images.SetKeyName(33, "gear.png");
            this.imageList.Images.SetKeyName(34, "hammer.png");
            this.imageList.Images.SetKeyName(35, "hourglass-select-remain.png");
            this.imageList.Images.SetKeyName(36, "inbox.png");
            this.imageList.Images.SetKeyName(37, "information-italic.png");
            this.imageList.Images.SetKeyName(38, "key.png");
            this.imageList.Images.SetKeyName(39, "keyboard-full-wireless.png");
            this.imageList.Images.SetKeyName(40, "keyboards.png");
            this.imageList.Images.SetKeyName(41, "lifebuoy.png");
            this.imageList.Images.SetKeyName(42, "locale.png");
            this.imageList.Images.SetKeyName(43, "magnet.png");
            this.imageList.Images.SetKeyName(44, "mail.png");
            this.imageList.Images.SetKeyName(45, "marker.png");
            this.imageList.Images.SetKeyName(46, "megaphone.png");
            this.imageList.Images.SetKeyName(47, "memory.png");
            this.imageList.Images.SetKeyName(48, "microphone.png");
            this.imageList.Images.SetKeyName(49, "monitor.png");
            this.imageList.Images.SetKeyName(50, "monitor-network.png");
            this.imageList.Images.SetKeyName(51, "mouse.png");
            this.imageList.Images.SetKeyName(52, "network.png");
            this.imageList.Images.SetKeyName(53, "network-cloud.png");
            this.imageList.Images.SetKeyName(54, "network-clouds.png");
            this.imageList.Images.SetKeyName(55, "network-ethernet.png");
            this.imageList.Images.SetKeyName(56, "network-firewall.png");
            this.imageList.Images.SetKeyName(57, "network-hub.png");
            this.imageList.Images.SetKeyName(58, "network-ip.png");
            this.imageList.Images.SetKeyName(59, "network-ip-local.png");
            this.imageList.Images.SetKeyName(60, "network-status.png");
            this.imageList.Images.SetKeyName(61, "network-status-away.png");
            this.imageList.Images.SetKeyName(62, "network-status-busy.png");
            this.imageList.Images.SetKeyName(63, "network-status-offline.png");
            this.imageList.Images.SetKeyName(64, "network-wireless.png");
            this.imageList.Images.SetKeyName(65, "node.png");
            this.imageList.Images.SetKeyName(66, "notebook.png");
            this.imageList.Images.SetKeyName(67, "paper-plane.png");
            this.imageList.Images.SetKeyName(68, "pencil.png");
            this.imageList.Images.SetKeyName(69, "pill.png");
            this.imageList.Images.SetKeyName(70, "pin.png");
            this.imageList.Images.SetKeyName(71, "plug.png");
            this.imageList.Images.SetKeyName(72, "plug--arrow.png");
            this.imageList.Images.SetKeyName(73, "plug-connect.png");
            this.imageList.Images.SetKeyName(74, "plug-disconnect.png");
            this.imageList.Images.SetKeyName(75, "plus-button.png");
            this.imageList.Images.SetKeyName(76, "plus-circle.png");
            this.imageList.Images.SetKeyName(77, "present-label.png");
            this.imageList.Images.SetKeyName(78, "printer.png");
            this.imageList.Images.SetKeyName(79, "processor.png");
            this.imageList.Images.SetKeyName(80, "prohibition.png");
            this.imageList.Images.SetKeyName(81, "prohibition-button.png");
            this.imageList.Images.SetKeyName(82, "projection-screen.png");
            this.imageList.Images.SetKeyName(83, "puzzle.png");
            this.imageList.Images.SetKeyName(84, "question-balloon.png");
            this.imageList.Images.SetKeyName(85, "question-button.png");
            this.imageList.Images.SetKeyName(86, "question-frame.png");
            this.imageList.Images.SetKeyName(87, "radar.png");
            this.imageList.Images.SetKeyName(88, "radio.png");
            this.imageList.Images.SetKeyName(89, "radioactivity.png");
            this.imageList.Images.SetKeyName(90, "rainbow.png");
            this.imageList.Images.SetKeyName(91, "road-sign.png");
            this.imageList.Images.SetKeyName(92, "robot.png");
            this.imageList.Images.SetKeyName(93, "rocket.png");
            this.imageList.Images.SetKeyName(94, "ruler-triangle.png");
            this.imageList.Images.SetKeyName(95, "safe.png");
            this.imageList.Images.SetKeyName(96, "scissors.png");
            this.imageList.Images.SetKeyName(97, "sealing-wax.png");
            this.imageList.Images.SetKeyName(98, "selection.png");
            this.imageList.Images.SetKeyName(99, "server.png");
            this.imageList.Images.SetKeyName(100, "servers-network.png");
            this.imageList.Images.SetKeyName(101, "share.png");
            this.imageList.Images.SetKeyName(102, "shortcut.png");
            this.imageList.Images.SetKeyName(103, "sitemap-application-blue.png");
            this.imageList.Images.SetKeyName(104, "skull-sad.png");
            this.imageList.Images.SetKeyName(105, "slides-stack.png");
            this.imageList.Images.SetKeyName(106, "smiley.png");
            this.imageList.Images.SetKeyName(107, "smiley-confuse.png");
            this.imageList.Images.SetKeyName(108, "smiley-evil.png");
            this.imageList.Images.SetKeyName(109, "socket.png");
            this.imageList.Images.SetKeyName(110, "sort-alphabet.png");
            this.imageList.Images.SetKeyName(111, "sort--arrow.png");
            this.imageList.Images.SetKeyName(112, "speaker-volume.png");
            this.imageList.Images.SetKeyName(113, "sport-golf.png");
            this.imageList.Images.SetKeyName(114, "sql.png");
            this.imageList.Images.SetKeyName(115, "system-monitor.png");
            this.imageList.Images.SetKeyName(116, "television.png");
            this.imageList.Images.SetKeyName(117, "terminal.png");
            this.imageList.Images.SetKeyName(118, "thumb-up.png");
            this.imageList.Images.SetKeyName(119, "tick.png");
            this.imageList.Images.SetKeyName(120, "toggle.png");
            this.imageList.Images.SetKeyName(121, "toggle-expand.png");
            this.imageList.Images.SetKeyName(122, "toilet-male.png");
            this.imageList.Images.SetKeyName(123, "toolbox.png");
            this.imageList.Images.SetKeyName(124, "traffic-cone.png");
            this.imageList.Images.SetKeyName(125, "traffic-light.png");
            this.imageList.Images.SetKeyName(126, "transmitter.png");
            this.imageList.Images.SetKeyName(127, "tree.png");
            this.imageList.Images.SetKeyName(128, "truck.png");
            this.imageList.Images.SetKeyName(129, "truck-box.png");
            this.imageList.Images.SetKeyName(130, "ui-text-field.png");
            this.imageList.Images.SetKeyName(131, "umbrella.png");
            this.imageList.Images.SetKeyName(132, "usb-flash-drive.png");
            this.imageList.Images.SetKeyName(133, "user.png");
            this.imageList.Images.SetKeyName(134, "user--arrow.png");
            this.imageList.Images.SetKeyName(135, "user-black.png");
            this.imageList.Images.SetKeyName(136, "user-black-female.png");
            this.imageList.Images.SetKeyName(137, "user-business.png");
            this.imageList.Images.SetKeyName(138, "user--plus.png");
            this.imageList.Images.SetKeyName(139, "user-silhouette.png");
            this.imageList.Images.SetKeyName(140, "user-silhouette-question.png");
            this.imageList.Images.SetKeyName(141, "wall.png");
            this.imageList.Images.SetKeyName(142, "wall-brick.png");
            this.imageList.Images.SetKeyName(143, "wallet.png");
            this.imageList.Images.SetKeyName(144, "weather-snowflake.png");
            this.imageList.Images.SetKeyName(145, "weather-tornado.png");
            this.imageList.Images.SetKeyName(146, "webcam.png");
            this.imageList.Images.SetKeyName(147, "weight.png");
            this.imageList.Images.SetKeyName(148, "wheel.png");
            this.imageList.Images.SetKeyName(149, "wi-fi.png");
            this.imageList.Images.SetKeyName(150, "wooden-box.png");
            this.imageList.Images.SetKeyName(151, "wrench.png");
            // 
            // timerCheckForConnectedClients
            // 
            this.timerCheckForConnectedClients.Interval = 1000;
            this.timerCheckForConnectedClients.Tick += new System.EventHandler(this.timerCheckForConnectedClients_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 301);
            this.Controls.Add(this.connectionList);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Server RAT";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.connectionList)).EndInit();
            this.cntxtMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView connectionList;
        private System.Windows.Forms.ContextMenuStrip cntxtMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnRefreshClientList;
        private System.Windows.Forms.ToolStripMenuItem btnSendMessage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem opcijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postaviPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSlusajKonekcije;
        private System.Windows.Forms.ToolStripMenuItem btnZatvori;
        private System.Windows.Forms.ToolStripTextBox tbPort;
        private System.Windows.Forms.ToolStripMenuItem btnPostaviPort;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem btnSlanjeDat;
        private System.Windows.Forms.Timer timerCheckForConnectedClients;
        private System.Windows.Forms.ToolStripMenuItem btnOdspojiKlijenta;
        private System.Windows.Forms.ToolStripMenuItem btnTakeScreenshot;
    }
}


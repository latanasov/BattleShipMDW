namespace Client
{
    partial class frmBattleship
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAlly = new System.Windows.Forms.Panel();
            this.lobbyPanel = new System.Windows.Forms.Panel();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtToSend = new System.Windows.Forms.TextBox();
            this.richTextBoxLobby = new System.Windows.Forms.RichTextBox();
            this.ActivePlayers = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonLoginPlayer = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.randomGameButton = new System.Windows.Forms.Button();
            this.invitePlayer = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panelEnemy = new System.Windows.Forms.Panel();
            this.btnReady = new System.Windows.Forms.Button();
            this.label_YourState = new System.Windows.Forms.Label();
            this.label_EnemyState = new System.Windows.Forms.Label();
            this.textBoxSendText = new System.Windows.Forms.TextBox();
            this.btnSendText = new System.Windows.Forms.Button();
            this.richTextBoxChatWindow = new System.Windows.Forms.RichTextBox();
            this.btnRotate = new System.Windows.Forms.Button();
            this.pictureBoxCarrierR = new System.Windows.Forms.PictureBox();
            this.pictureBoxCarrier = new System.Windows.Forms.PictureBox();
            this.pictureBoxBattleshipR = new System.Windows.Forms.PictureBox();
            this.pictureBoxDestroyerR = new System.Windows.Forms.PictureBox();
            this.pictureBoxBattleship = new System.Windows.Forms.PictureBox();
            this.pictureBoxTinyShipR = new System.Windows.Forms.PictureBox();
            this.pictureBoxTinyShip = new System.Windows.Forms.PictureBox();
            this.pictureBoxSmallShipR = new System.Windows.Forms.PictureBox();
            this.pictureBoxSmallShip = new System.Windows.Forms.PictureBox();
            this.pictureBoxDestroyer = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lobbyPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarrierR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattleshipR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestroyerR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattleship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTinyShipR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTinyShip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmallShipR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmallShip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestroyer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Your Sea";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enemy Sea";
            // 
            // panelAlly
            // 
            this.panelAlly.AllowDrop = true;
            this.panelAlly.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelAlly.Location = new System.Drawing.Point(2, 23);
            this.panelAlly.Name = "panelAlly";
            this.panelAlly.Size = new System.Drawing.Size(500, 500);
            this.panelAlly.TabIndex = 4;
            this.panelAlly.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAlly_Paint);
            this.panelAlly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAlly_MouseClick);
            // 
            // lobbyPanel
            // 
            this.lobbyPanel.BackColor = System.Drawing.Color.Transparent;
            this.lobbyPanel.BackgroundImage = global::Client.Properties.Resources.warships_battle_sea_art_artwork_desktop_hd_wallpaper;
            this.lobbyPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lobbyPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lobbyPanel.Controls.Add(this.btnSend);
            this.lobbyPanel.Controls.Add(this.txtToSend);
            this.lobbyPanel.Controls.Add(this.richTextBoxLobby);
            this.lobbyPanel.Controls.Add(this.ActivePlayers);
            this.lobbyPanel.Controls.Add(this.panel1);
            this.lobbyPanel.Controls.Add(this.randomGameButton);
            this.lobbyPanel.Controls.Add(this.invitePlayer);
            this.lobbyPanel.Controls.Add(this.listBox1);
            this.lobbyPanel.Location = new System.Drawing.Point(1, 7);
            this.lobbyPanel.Name = "lobbyPanel";
            this.lobbyPanel.Size = new System.Drawing.Size(1015, 739);
            this.lobbyPanel.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(24, 66);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 23);
            this.btnSend.TabIndex = 36;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtToSend
            // 
            this.txtToSend.Location = new System.Drawing.Point(130, 69);
            this.txtToSend.Name = "txtToSend";
            this.txtToSend.Size = new System.Drawing.Size(667, 20);
            this.txtToSend.TabIndex = 35;
            // 
            // richTextBoxLobby
            // 
            this.richTextBoxLobby.AutoWordSelection = true;
            this.richTextBoxLobby.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxLobby.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxLobby.Location = new System.Drawing.Point(24, 95);
            this.richTextBoxLobby.Name = "richTextBoxLobby";
            this.richTextBoxLobby.ReadOnly = true;
            this.richTextBoxLobby.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLobby.Size = new System.Drawing.Size(773, 508);
            this.richTextBoxLobby.TabIndex = 34;
            this.richTextBoxLobby.Text = "";
            this.richTextBoxLobby.TextChanged += new System.EventHandler(this.richTextBoxLobby_TextChanged);
            // 
            // ActivePlayers
            // 
            this.ActivePlayers.AutoSize = true;
            this.ActivePlayers.BackColor = System.Drawing.Color.Transparent;
            this.ActivePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActivePlayers.ForeColor = System.Drawing.Color.GreenYellow;
            this.ActivePlayers.Location = new System.Drawing.Point(838, 42);
            this.ActivePlayers.Name = "ActivePlayers";
            this.ActivePlayers.Size = new System.Drawing.Size(147, 24);
            this.ActivePlayers.TabIndex = 32;
            this.ActivePlayers.Text = "Active Players:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonLoginPlayer);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Location = new System.Drawing.Point(-2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(122, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(60, 23);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Enter your Nickname:";
            // 
            // buttonLoginPlayer
            // 
            this.buttonLoginPlayer.Location = new System.Drawing.Point(122, 16);
            this.buttonLoginPlayer.Name = "buttonLoginPlayer";
            this.buttonLoginPlayer.Size = new System.Drawing.Size(60, 23);
            this.buttonLoginPlayer.TabIndex = 12;
            this.buttonLoginPlayer.Text = "Log In";
            this.buttonLoginPlayer.UseVisualStyleBackColor = true;
            this.buttonLoginPlayer.Click += new System.EventHandler(this.buttonFindPlayers_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(3, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(113, 20);
            this.textBoxName.TabIndex = 11;
            // 
            // randomGameButton
            // 
            this.randomGameButton.Location = new System.Drawing.Point(849, 641);
            this.randomGameButton.Name = "randomGameButton";
            this.randomGameButton.Size = new System.Drawing.Size(101, 23);
            this.randomGameButton.TabIndex = 29;
            this.randomGameButton.Text = "Random game!";
            this.randomGameButton.UseVisualStyleBackColor = true;
            this.randomGameButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // invitePlayer
            // 
            this.invitePlayer.Location = new System.Drawing.Point(849, 610);
            this.invitePlayer.Name = "invitePlayer";
            this.invitePlayer.Size = new System.Drawing.Size(101, 23);
            this.invitePlayer.TabIndex = 30;
            this.invitePlayer.Text = "Invite player!";
            this.invitePlayer.UseVisualStyleBackColor = true;
            this.invitePlayer.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(842, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(151, 535);
            this.listBox1.TabIndex = 28;
            // 
            // panelEnemy
            // 
            this.panelEnemy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelEnemy.Location = new System.Drawing.Point(516, 23);
            this.panelEnemy.Name = "panelEnemy";
            this.panelEnemy.Size = new System.Drawing.Size(500, 500);
            this.panelEnemy.TabIndex = 5;
            this.panelEnemy.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEnemy_Paint);
            this.panelEnemy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelEnemy_MouseClick);
            // 
            // btnReady
            // 
            this.btnReady.Location = new System.Drawing.Point(515, 532);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(75, 23);
            this.btnReady.TabIndex = 7;
            this.btnReady.Text = "Ready!";
            this.btnReady.UseVisualStyleBackColor = true;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // label_YourState
            // 
            this.label_YourState.AutoSize = true;
            this.label_YourState.Location = new System.Drawing.Point(380, 526);
            this.label_YourState.Name = "label_YourState";
            this.label_YourState.Size = new System.Drawing.Size(122, 13);
            this.label_YourState.TabIndex = 8;
            this.label_YourState.Text = "Waiting For Other Player";
            // 
            // label_EnemyState
            // 
            this.label_EnemyState.AutoSize = true;
            this.label_EnemyState.Location = new System.Drawing.Point(771, 532);
            this.label_EnemyState.Name = "label_EnemyState";
            this.label_EnemyState.Size = new System.Drawing.Size(122, 13);
            this.label_EnemyState.TabIndex = 10;
            this.label_EnemyState.Text = "Waiting For Other Player";
            // 
            // textBoxSendText
            // 
            this.textBoxSendText.Location = new System.Drawing.Point(426, 579);
            this.textBoxSendText.Name = "textBoxSendText";
            this.textBoxSendText.Size = new System.Drawing.Size(113, 20);
            this.textBoxSendText.TabIndex = 15;
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(464, 606);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(75, 23);
            this.btnSendText.TabIndex = 16;
            this.btnSendText.Text = "Send Text";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // richTextBoxChatWindow
            // 
            this.richTextBoxChatWindow.AutoWordSelection = true;
            this.richTextBoxChatWindow.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxChatWindow.Location = new System.Drawing.Point(545, 579);
            this.richTextBoxChatWindow.Name = "richTextBoxChatWindow";
            this.richTextBoxChatWindow.ReadOnly = true;
            this.richTextBoxChatWindow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxChatWindow.Size = new System.Drawing.Size(463, 63);
            this.richTextBoxChatWindow.TabIndex = 17;
            this.richTextBoxChatWindow.Text = "";
            this.richTextBoxChatWindow.TextChanged += new System.EventHandler(this.richTextBoxChatWindow_TextChanged);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(426, 532);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(75, 23);
            this.btnRotate.TabIndex = 27;
            this.btnRotate.Text = "Rotate";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // pictureBoxCarrierR
            // 
            this.pictureBoxCarrierR.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxCarrierR.Image = global::Client.Properties.Resources.carrierR;
            this.pictureBoxCarrierR.Location = new System.Drawing.Point(320, 529);
            this.pictureBoxCarrierR.Name = "pictureBoxCarrierR";
            this.pictureBoxCarrierR.Size = new System.Drawing.Size(50, 250);
            this.pictureBoxCarrierR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxCarrierR.TabIndex = 26;
            this.pictureBoxCarrierR.TabStop = false;
            this.pictureBoxCarrierR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCarrierR_MouseDown);
            // 
            // pictureBoxCarrier
            // 
            this.pictureBoxCarrier.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxCarrier.Image = global::Client.Properties.Resources.carrier;
            this.pictureBoxCarrier.Location = new System.Drawing.Point(208, 605);
            this.pictureBoxCarrier.Name = "pictureBoxCarrier";
            this.pictureBoxCarrier.Size = new System.Drawing.Size(250, 50);
            this.pictureBoxCarrier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxCarrier.TabIndex = 25;
            this.pictureBoxCarrier.TabStop = false;
            this.pictureBoxCarrier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxCarrier_MouseDown);
            // 
            // pictureBoxBattleshipR
            // 
            this.pictureBoxBattleshipR.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxBattleshipR.Image = global::Client.Properties.Resources.battleshipR;
            this.pictureBoxBattleshipR.Location = new System.Drawing.Point(242, 529);
            this.pictureBoxBattleshipR.Name = "pictureBoxBattleshipR";
            this.pictureBoxBattleshipR.Size = new System.Drawing.Size(50, 200);
            this.pictureBoxBattleshipR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxBattleshipR.TabIndex = 24;
            this.pictureBoxBattleshipR.TabStop = false;
            this.pictureBoxBattleshipR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattleshipR_MouseDown);
            // 
            // pictureBoxDestroyerR
            // 
            this.pictureBoxDestroyerR.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxDestroyerR.Image = global::Client.Properties.Resources.destroyerR;
            this.pictureBoxDestroyerR.Location = new System.Drawing.Point(164, 529);
            this.pictureBoxDestroyerR.Name = "pictureBoxDestroyerR";
            this.pictureBoxDestroyerR.Size = new System.Drawing.Size(50, 150);
            this.pictureBoxDestroyerR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxDestroyerR.TabIndex = 23;
            this.pictureBoxDestroyerR.TabStop = false;
            this.pictureBoxDestroyerR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDestroyerR_MouseDown);
            // 
            // pictureBoxBattleship
            // 
            this.pictureBoxBattleship.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxBattleship.Image = global::Client.Properties.Resources.battleship;
            this.pictureBoxBattleship.Location = new System.Drawing.Point(2, 605);
            this.pictureBoxBattleship.Name = "pictureBoxBattleship";
            this.pictureBoxBattleship.Size = new System.Drawing.Size(200, 50);
            this.pictureBoxBattleship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxBattleship.TabIndex = 22;
            this.pictureBoxBattleship.TabStop = false;
            this.pictureBoxBattleship.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBattleship_MouseDown);
            // 
            // pictureBoxTinyShipR
            // 
            this.pictureBoxTinyShipR.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxTinyShipR.Image = global::Client.Properties.Resources.tinyshipR;
            this.pictureBoxTinyShipR.Location = new System.Drawing.Point(2, 529);
            this.pictureBoxTinyShipR.Name = "pictureBoxTinyShipR";
            this.pictureBoxTinyShipR.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxTinyShipR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTinyShipR.TabIndex = 20;
            this.pictureBoxTinyShipR.TabStop = false;
            this.pictureBoxTinyShipR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTinyShipR_MouseDown);
            // 
            // pictureBoxTinyShip
            // 
            this.pictureBoxTinyShip.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxTinyShip.Image = global::Client.Properties.Resources.tinyship;
            this.pictureBoxTinyShip.Location = new System.Drawing.Point(2, 529);
            this.pictureBoxTinyShip.Name = "pictureBoxTinyShip";
            this.pictureBoxTinyShip.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxTinyShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTinyShip.TabIndex = 19;
            this.pictureBoxTinyShip.TabStop = false;
            this.pictureBoxTinyShip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTinyShip_MouseDown);
            // 
            // pictureBoxSmallShipR
            // 
            this.pictureBoxSmallShipR.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxSmallShipR.Image = global::Client.Properties.Resources.smallshipR;
            this.pictureBoxSmallShipR.Location = new System.Drawing.Point(84, 529);
            this.pictureBoxSmallShipR.Name = "pictureBoxSmallShipR";
            this.pictureBoxSmallShipR.Size = new System.Drawing.Size(50, 100);
            this.pictureBoxSmallShipR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSmallShipR.TabIndex = 18;
            this.pictureBoxSmallShipR.TabStop = false;
            this.pictureBoxSmallShipR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSmallShipR_MouseDown);
            // 
            // pictureBoxSmallShip
            // 
            this.pictureBoxSmallShip.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxSmallShip.Image = global::Client.Properties.Resources.smallship;
            this.pictureBoxSmallShip.Location = new System.Drawing.Point(84, 529);
            this.pictureBoxSmallShip.Name = "pictureBoxSmallShip";
            this.pictureBoxSmallShip.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxSmallShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSmallShip.TabIndex = 6;
            this.pictureBoxSmallShip.TabStop = false;
            this.pictureBoxSmallShip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSmallShip_MouseDown);
            // 
            // pictureBoxDestroyer
            // 
            this.pictureBoxDestroyer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxDestroyer.Image = global::Client.Properties.Resources.destroyer;
            this.pictureBoxDestroyer.Location = new System.Drawing.Point(220, 529);
            this.pictureBoxDestroyer.Name = "pictureBoxDestroyer";
            this.pictureBoxDestroyer.Size = new System.Drawing.Size(150, 50);
            this.pictureBoxDestroyer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxDestroyer.TabIndex = 21;
            this.pictureBoxDestroyer.TabStop = false;
            this.pictureBoxDestroyer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDestroyer_MouseDown);
            // 
            // frmBattleship
            // 
            this.AcceptButton = this.btnSendText;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1017, 743);
            this.Controls.Add(this.lobbyPanel);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.pictureBoxCarrierR);
            this.Controls.Add(this.pictureBoxCarrier);
            this.Controls.Add(this.pictureBoxBattleshipR);
            this.Controls.Add(this.pictureBoxDestroyerR);
            this.Controls.Add(this.pictureBoxBattleship);
            this.Controls.Add(this.pictureBoxTinyShipR);
            this.Controls.Add(this.pictureBoxTinyShip);
            this.Controls.Add(this.pictureBoxSmallShipR);
            this.Controls.Add(this.richTextBoxChatWindow);
            this.Controls.Add(this.btnSendText);
            this.Controls.Add(this.textBoxSendText);
            this.Controls.Add(this.label_EnemyState);
            this.Controls.Add(this.label_YourState);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.pictureBoxSmallShip);
            this.Controls.Add(this.panelEnemy);
            this.Controls.Add(this.panelAlly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxDestroyer);
            this.Name = "frmBattleship";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battleship";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBattleship_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBattleship_FormClosed);
            this.lobbyPanel.ResumeLayout(false);
            this.lobbyPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarrierR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattleshipR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestroyerR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBattleship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTinyShipR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTinyShip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmallShipR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSmallShip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestroyer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAlly;
        private System.Windows.Forms.Panel panelEnemy;
        private System.Windows.Forms.PictureBox pictureBoxSmallShip;
        private System.Windows.Forms.Button btnReady;
        private System.Windows.Forms.Label label_YourState;
        private System.Windows.Forms.Label label_EnemyState;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSendText;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.RichTextBox richTextBoxChatWindow;
        private System.Windows.Forms.PictureBox pictureBoxSmallShipR;
        private System.Windows.Forms.PictureBox pictureBoxTinyShip;
        private System.Windows.Forms.PictureBox pictureBoxTinyShipR;
        private System.Windows.Forms.PictureBox pictureBoxDestroyer;
        private System.Windows.Forms.PictureBox pictureBoxBattleship;
        private System.Windows.Forms.PictureBox pictureBoxDestroyerR;
        private System.Windows.Forms.PictureBox pictureBoxBattleshipR;
        private System.Windows.Forms.PictureBox pictureBoxCarrier;
        private System.Windows.Forms.PictureBox pictureBoxCarrierR;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonLoginPlayer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button randomGameButton;
        private System.Windows.Forms.Button invitePlayer;
        private System.Windows.Forms.Panel lobbyPanel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label ActivePlayers;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.RichTextBox richTextBoxLobby;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtToSend;
    }
}


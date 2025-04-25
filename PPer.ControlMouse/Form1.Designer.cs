namespace PPer.ControlMouse
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNewPos = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePos = new System.Windows.Forms.ToolStripButton();
            this.btnEditPos = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtKeySelected = new System.Windows.Forms.ToolStripTextBox();
            this.txtPosSelected = new System.Windows.Forms.ToolStripTextBox();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.mousePosTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblWaitTimer = new System.Windows.Forms.ToolStripLabel();
            this.cbbWaitTimer = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewPos,
            this.btnDeletePos,
            this.btnEditPos,
            this.toolStripLabel1,
            this.txtKeySelected,
            this.txtPosSelected,
            this.btnReload,
            this.toolStripButton1,
            this.lblWaitTimer,
            this.cbbWaitTimer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(715, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNewPos
            // 
            this.btnAddNewPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewPos.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewPos.Image")));
            this.btnAddNewPos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewPos.Name = "btnAddNewPos";
            this.btnAddNewPos.Size = new System.Drawing.Size(23, 22);
            this.btnAddNewPos.Text = "toolStripButton1";
            this.btnAddNewPos.Click += new System.EventHandler(this.btnAddNewPos_Click);
            // 
            // btnDeletePos
            // 
            this.btnDeletePos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeletePos.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePos.Image")));
            this.btnDeletePos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePos.Name = "btnDeletePos";
            this.btnDeletePos.Size = new System.Drawing.Size(23, 22);
            this.btnDeletePos.Text = "toolStripButton1";
            this.btnDeletePos.Click += new System.EventHandler(this.btnDeletePos_Click);
            // 
            // btnEditPos
            // 
            this.btnEditPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditPos.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPos.Image")));
            this.btnEditPos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditPos.Name = "btnEditPos";
            this.btnEditPos.Size = new System.Drawing.Size(23, 22);
            this.btnEditPos.Text = "toolStripButton2";
            this.btnEditPos.Click += new System.EventHandler(this.btnEditPos_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "Key:";
            // 
            // txtKeySelected
            // 
            this.txtKeySelected.Enabled = false;
            this.txtKeySelected.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKeySelected.Name = "txtKeySelected";
            this.txtKeySelected.Size = new System.Drawing.Size(80, 25);
            // 
            // txtPosSelected
            // 
            this.txtPosSelected.Enabled = false;
            this.txtPosSelected.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPosSelected.Name = "txtPosSelected";
            this.txtPosSelected.Size = new System.Drawing.Size(100, 25);
            // 
            // btnReload
            // 
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "toolStripButton2";
            this.btnReload.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // mousePosTimer
            // 
            this.mousePosTimer.Tick += new System.EventHandler(this.mousePosTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 41);
            this.panel1.TabIndex = 1;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // lblWaitTimer
            // 
            this.lblWaitTimer.Name = "lblWaitTimer";
            this.lblWaitTimer.Size = new System.Drawing.Size(65, 22);
            this.lblWaitTimer.Text = "WaitTimer:";
            // 
            // cbbWaitTimer
            // 
            this.cbbWaitTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbWaitTimer.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cbbWaitTimer.Name = "cbbWaitTimer";
            this.cbbWaitTimer.Size = new System.Drawing.Size(75, 25);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 66);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddNewPos;
        private System.Windows.Forms.Timer mousePosTimer;
        private System.Windows.Forms.ToolStripButton btnDeletePos;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripTextBox txtKeySelected;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnEditPos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox txtPosSelected;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel lblWaitTimer;
        private System.Windows.Forms.ToolStripComboBox cbbWaitTimer;
    }
}


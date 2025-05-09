﻿namespace PPer.ControlMouse
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
            this.btnEditPos = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtKeySelected = new System.Windows.Forms.ToolStripTextBox();
            this.txtPosSelected = new System.Windows.Forms.ToolStripTextBox();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.lblRunMode = new System.Windows.Forms.ToolStripLabel();
            this.cbbRunMode = new System.Windows.Forms.ToolStripComboBox();
            this.mousePosTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewPos,
            this.btnEditPos,
            this.toolStripLabel1,
            this.txtKeySelected,
            this.txtPosSelected,
            this.btnHelp,
            this.btnSave,
            this.btnReload,
            this.lblRunMode,
            this.cbbRunMode});
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
            // btnSave
            // 
            this.btnSave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReload
            // 
            this.btnReload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(23, 22);
            this.btnReload.Text = "toolStripButton2";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblRunMode
            // 
            this.lblRunMode.Name = "lblRunMode";
            this.lblRunMode.Size = new System.Drawing.Size(41, 22);
            this.lblRunMode.Text = "Mode:";
            // 
            // cbbRunMode
            // 
            this.cbbRunMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRunMode.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cbbRunMode.Name = "cbbRunMode";
            this.cbbRunMode.Size = new System.Drawing.Size(121, 25);
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
            // btnHelp
            // 
            this.btnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.Text = "toolStripButton1";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
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
        private System.Windows.Forms.ToolStripTextBox txtKeySelected;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnEditPos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripTextBox txtPosSelected;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripLabel lblRunMode;
        private System.Windows.Forms.ToolStripComboBox cbbRunMode;
        private System.Windows.Forms.ToolStripButton btnHelp;
    }
}


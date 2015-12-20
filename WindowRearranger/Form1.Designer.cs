namespace WindowRearranger
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbActiveWindows = new System.Windows.Forms.ComboBox();
            this.cmbAvailableScreens = new System.Windows.Forms.ComboBox();
            this.btnMoveWindow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sig = new System.Windows.Forms.Label();
            this.btnMoveAllWindows = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Windows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(311, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Available Screens";
            // 
            // cmbActiveWindows
            // 
            this.cmbActiveWindows.FormattingEnabled = true;
            this.cmbActiveWindows.Location = new System.Drawing.Point(58, 120);
            this.cmbActiveWindows.Name = "cmbActiveWindows";
            this.cmbActiveWindows.Size = new System.Drawing.Size(152, 21);
            this.cmbActiveWindows.TabIndex = 2;
            this.cmbActiveWindows.Click += new System.EventHandler(this.cmbActiveWindows_Click);
            // 
            // cmbAvailableScreens
            // 
            this.cmbAvailableScreens.Enabled = false;
            this.cmbAvailableScreens.FormattingEnabled = true;
            this.cmbAvailableScreens.Location = new System.Drawing.Point(303, 120);
            this.cmbAvailableScreens.Name = "cmbAvailableScreens";
            this.cmbAvailableScreens.Size = new System.Drawing.Size(152, 21);
            this.cmbAvailableScreens.TabIndex = 3;
            this.cmbAvailableScreens.SelectedIndexChanged += new System.EventHandler(this.cmbAvailableScreens_SelectedIndexChanged);
            // 
            // btnMoveWindow
            // 
            this.btnMoveWindow.Location = new System.Drawing.Point(204, 169);
            this.btnMoveWindow.Name = "btnMoveWindow";
            this.btnMoveWindow.Size = new System.Drawing.Size(100, 23);
            this.btnMoveWindow.TabIndex = 4;
            this.btnMoveWindow.Text = "Move Window";
            this.btnMoveWindow.UseVisualStyleBackColor = true;
            this.btnMoveWindow.Click += new System.EventHandler(this.btnMoveWindow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(239, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chucky\'s Window Mover";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(361, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "damn windows moved to the telly, the other side of the room!";
            // 
            // sig
            // 
            this.sig.AutoSize = true;
            this.sig.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sig.Location = new System.Drawing.Point(-1, 266);
            this.sig.Name = "sig";
            this.sig.Size = new System.Drawing.Size(54, 19);
            this.sig.TabIndex = 7;
            this.sig.Text = "ChuckE";
            // 
            // btnMoveAllWindows
            // 
            this.btnMoveAllWindows.Location = new System.Drawing.Point(204, 216);
            this.btnMoveAllWindows.Name = "btnMoveAllWindows";
            this.btnMoveAllWindows.Size = new System.Drawing.Size(100, 47);
            this.btnMoveAllWindows.TabIndex = 8;
            this.btnMoveAllWindows.Text = "Move All Windows";
            this.btnMoveAllWindows.UseVisualStyleBackColor = true;
            this.btnMoveAllWindows.Click += new System.EventHandler(this.btnMoveAllWindows_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 283);
            this.Controls.Add(this.btnMoveAllWindows);
            this.Controls.Add(this.sig);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMoveWindow);
            this.Controls.Add(this.cmbAvailableScreens);
            this.Controls.Add(this.cmbActiveWindows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbActiveWindows;
        private System.Windows.Forms.ComboBox cmbAvailableScreens;
        private System.Windows.Forms.Button btnMoveWindow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sig;
        private System.Windows.Forms.Button btnMoveAllWindows;
    }
}


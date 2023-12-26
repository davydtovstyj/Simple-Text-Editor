namespace File_Editor
{
    partial class Settings
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
            this.LineNumber = new System.Windows.Forms.CheckBox();
            this.Theme = new System.Windows.Forms.CheckBox();
            this.opacity = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FontSize = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.WordSelection = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.opacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // LineNumber
            // 
            this.LineNumber.AutoSize = true;
            this.LineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LineNumber.ForeColor = System.Drawing.Color.White;
            this.LineNumber.Location = new System.Drawing.Point(12, 12);
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.Size = new System.Drawing.Size(183, 28);
            this.LineNumber.TabIndex = 1;
            this.LineNumber.Text = "Show line number";
            this.LineNumber.UseVisualStyleBackColor = true;
            // 
            // Theme
            // 
            this.Theme.AutoSize = true;
            this.Theme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Theme.ForeColor = System.Drawing.Color.White;
            this.Theme.Location = new System.Drawing.Point(12, 46);
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(125, 28);
            this.Theme.TabIndex = 2;
            this.Theme.Text = "Dark theme";
            this.Theme.UseVisualStyleBackColor = true;
            // 
            // opacity
            // 
            this.opacity.Location = new System.Drawing.Point(12, 139);
            this.opacity.Maximum = 100;
            this.opacity.Minimum = 1;
            this.opacity.Name = "opacity";
            this.opacity.Size = new System.Drawing.Size(210, 45);
            this.opacity.TabIndex = 3;
            this.opacity.Value = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Opacity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Font size";
            // 
            // FontSize
            // 
            this.FontSize.Location = new System.Drawing.Point(16, 204);
            this.FontSize.Maximum = 60;
            this.FontSize.Minimum = 1;
            this.FontSize.Name = "FontSize";
            this.FontSize.Size = new System.Drawing.Size(210, 45);
            this.FontSize.TabIndex = 5;
            this.FontSize.Value = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WordSelection
            // 
            this.WordSelection.AutoSize = true;
            this.WordSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WordSelection.ForeColor = System.Drawing.Color.White;
            this.WordSelection.Location = new System.Drawing.Point(12, 80);
            this.WordSelection.Name = "WordSelection";
            this.WordSelection.Size = new System.Drawing.Size(195, 28);
            this.WordSelection.TabIndex = 8;
            this.WordSelection.Text = "Auto word selection";
            this.WordSelection.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(256, 280);
            this.Controls.Add(this.WordSelection);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opacity);
            this.Controls.Add(this.Theme);
            this.Controls.Add(this.LineNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.opacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox LineNumber;
        private System.Windows.Forms.CheckBox Theme;
        private System.Windows.Forms.TrackBar opacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar FontSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox WordSelection;
    }
}
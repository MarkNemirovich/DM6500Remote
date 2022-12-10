namespace DM6500Remote
{
    partial class Background
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Language = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Voltage = new System.Windows.Forms.TextBox();
            this.Temperature = new System.Windows.Forms.TextBox();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.Count = new System.Windows.Forms.TextBox();
            this.Interval = new System.Windows.Forms.TextBox();
            this.CountLabel = new System.Windows.Forms.Label();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.IntervalPanel = new System.Windows.Forms.Panel();
            this.CountPanel = new System.Windows.Forms.Panel();
            this.VoltagePanel = new System.Windows.Forms.Panel();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.TemperaturePanel = new System.Windows.Forms.Panel();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.IntervalPanel.SuspendLayout();
            this.CountPanel.SuspendLayout();
            this.VoltagePanel.SuspendLayout();
            this.TemperaturePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Language
            // 
            this.Language.BackColor = System.Drawing.Color.Gold;
            this.Language.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Language.Location = new System.Drawing.Point(100, 400);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(100, 50);
            this.Language.TabIndex = 0;
            this.Language.Text = "ENG";
            this.Language.UseVisualStyleBackColor = false;
            this.Language.Click += new System.EventHandler(this.Language_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.Lime;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Start.Location = new System.Drawing.Point(700, 100);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(200, 50);
            this.Start.TabIndex = 1;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.Red;
            this.Stop.Enabled = false;
            this.Stop.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stop.Location = new System.Drawing.Point(700, 300);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(200, 50);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = false;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.Highlight;
            this.Exit.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Exit.Location = new System.Drawing.Point(800, 400);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(100, 50);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Voltage
            // 
            this.Voltage.Enabled = false;
            this.Voltage.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Voltage.Location = new System.Drawing.Point(195, 5);
            this.Voltage.Name = "Voltage";
            this.Voltage.Size = new System.Drawing.Size(150, 39);
            this.Voltage.TabIndex = 4;
            // 
            // Temperature
            // 
            this.Temperature.Enabled = false;
            this.Temperature.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Temperature.Location = new System.Drawing.Point(195, 5);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(150, 39);
            this.Temperature.TabIndex = 5;
            // 
            // Progress
            // 
            this.Progress.Enabled = false;
            this.Progress.Location = new System.Drawing.Point(100, 300);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(500, 50);
            this.Progress.TabIndex = 6;
            // 
            // Count
            // 
            this.Count.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Count.Location = new System.Drawing.Point(172, 6);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(75, 39);
            this.Count.TabIndex = 7;
            this.Count.Text = "100";
            // 
            // Interval
            // 
            this.Interval.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Interval.Location = new System.Drawing.Point(172, 5);
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(75, 39);
            this.Interval.TabIndex = 8;
            this.Interval.Text = "1";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountLabel.Location = new System.Drawing.Point(3, 5);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(79, 32);
            this.CountLabel.TabIndex = 9;
            this.CountLabel.Text = "Count";
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IntervalLabel.Location = new System.Drawing.Point(3, 5);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(93, 32);
            this.IntervalLabel.TabIndex = 10;
            this.IntervalLabel.Text = "Interval";
            // 
            // IntervalPanel
            // 
            this.IntervalPanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.IntervalPanel.Controls.Add(this.IntervalLabel);
            this.IntervalPanel.Controls.Add(this.Interval);
            this.IntervalPanel.Location = new System.Drawing.Point(400, 100);
            this.IntervalPanel.Name = "IntervalPanel";
            this.IntervalPanel.Size = new System.Drawing.Size(250, 50);
            this.IntervalPanel.TabIndex = 11;
            // 
            // CountPanel
            // 
            this.CountPanel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.CountPanel.Controls.Add(this.CountLabel);
            this.CountPanel.Controls.Add(this.Count);
            this.CountPanel.Location = new System.Drawing.Point(100, 100);
            this.CountPanel.Name = "CountPanel";
            this.CountPanel.Size = new System.Drawing.Size(250, 50);
            this.CountPanel.TabIndex = 12;
            // 
            // VoltagePanel
            // 
            this.VoltagePanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.VoltagePanel.Controls.Add(this.VoltageLabel);
            this.VoltagePanel.Controls.Add(this.Voltage);
            this.VoltagePanel.Enabled = false;
            this.VoltagePanel.Location = new System.Drawing.Point(100, 200);
            this.VoltagePanel.Name = "VoltagePanel";
            this.VoltagePanel.Size = new System.Drawing.Size(350, 50);
            this.VoltagePanel.TabIndex = 13;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.AutoSize = true;
            this.VoltageLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VoltageLabel.Location = new System.Drawing.Point(5, 10);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(94, 32);
            this.VoltageLabel.TabIndex = 0;
            this.VoltageLabel.Text = "Voltage";
            // 
            // TemperaturePanel
            // 
            this.TemperaturePanel.BackColor = System.Drawing.Color.Coral;
            this.TemperaturePanel.Controls.Add(this.TemperatureLabel);
            this.TemperaturePanel.Controls.Add(this.Temperature);
            this.TemperaturePanel.Enabled = false;
            this.TemperaturePanel.Location = new System.Drawing.Point(550, 200);
            this.TemperaturePanel.Name = "TemperaturePanel";
            this.TemperaturePanel.Size = new System.Drawing.Size(350, 50);
            this.TemperaturePanel.TabIndex = 14;
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TemperatureLabel.Location = new System.Drawing.Point(5, 10);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(149, 32);
            this.TemperatureLabel.TabIndex = 0;
            this.TemperatureLabel.Text = "Temperature";
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 503);
            this.Controls.Add(this.TemperaturePanel);
            this.Controls.Add(this.VoltagePanel);
            this.Controls.Add(this.CountPanel);
            this.Controls.Add(this.IntervalPanel);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Language);
            this.Name = "Background";
            this.Text = "Form1";
            this.IntervalPanel.ResumeLayout(false);
            this.IntervalPanel.PerformLayout();
            this.CountPanel.ResumeLayout(false);
            this.CountPanel.PerformLayout();
            this.VoltagePanel.ResumeLayout(false);
            this.VoltagePanel.PerformLayout();
            this.TemperaturePanel.ResumeLayout(false);
            this.TemperaturePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Language;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox Voltage;
        private System.Windows.Forms.TextBox Temperature;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.TextBox Interval;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Panel IntervalPanel;
        private System.Windows.Forms.Panel CountPanel;
        private System.Windows.Forms.Panel VoltagePanel;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Panel TemperaturePanel;
        private System.Windows.Forms.Label TemperatureLabel;
    }
}

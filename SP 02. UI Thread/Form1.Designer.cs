namespace SP_02._UI_Thread
{
    partial class Form1
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
            StartButton = new Button();
            CountLabel = new Label();
            MainLabel = new Label();
            ThreadLabel = new Label();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            StartButton.Location = new Point(42, 113);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(130, 47);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // CountLabel
            // 
            CountLabel.AutoSize = true;
            CountLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            CountLabel.Location = new Point(84, 37);
            CountLabel.Name = "CountLabel";
            CountLabel.Size = new Size(33, 40);
            CountLabel.TabIndex = 1;
            CountLabel.Text = "0";
            // 
            // MainLabel
            // 
            MainLabel.AutoSize = true;
            MainLabel.Location = new Point(279, 53);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new Size(38, 15);
            MainLabel.TabIndex = 2;
            MainLabel.Text = "label1";
            // 
            // ThreadLabel
            // 
            ThreadLabel.AutoSize = true;
            ThreadLabel.Location = new Point(279, 113);
            ThreadLabel.Name = "ThreadLabel";
            ThreadLabel.Size = new Size(38, 15);
            ThreadLabel.TabIndex = 2;
            ThreadLabel.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 295);
            Controls.Add(ThreadLabel);
            Controls.Add(MainLabel);
            Controls.Add(CountLabel);
            Controls.Add(StartButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartButton;
        private Label CountLabel;
        private Label MainLabel;
        private Label ThreadLabel;
    }
}

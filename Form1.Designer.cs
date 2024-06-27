namespace AppLoad3images
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
            progressBarOverall = new ProgressBar();
            listBoxProgress = new ListBox();
            buttonStart = new Button();
            SuspendLayout();
            // 
            // progressBarOverall
            // 
            progressBarOverall.Location = new Point(12, 112);
            progressBarOverall.Name = "progressBarOverall";
            progressBarOverall.Size = new Size(776, 23);
            progressBarOverall.TabIndex = 0;
            // 
            // listBoxProgress
            // 
            listBoxProgress.FormattingEnabled = true;
            listBoxProgress.ItemHeight = 15;
            listBoxProgress.Location = new Point(12, 12);
            listBoxProgress.Name = "listBoxProgress";
            listBoxProgress.Size = new Size(776, 94);
            listBoxProgress.TabIndex = 1;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 141);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 177);
            Controls.Add(buttonStart);
            Controls.Add(listBoxProgress);
            Controls.Add(progressBarOverall);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBarOverall;
        private ListBox listBoxProgress;
        private Button buttonStart;
    }
}

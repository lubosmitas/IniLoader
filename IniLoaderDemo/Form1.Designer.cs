namespace IniLoaderDemo
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
            propertyGrid1 = new PropertyGrid();
            btnLoadIni = new Button();
            SuspendLayout();
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(102, 148);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(869, 380);
            propertyGrid1.TabIndex = 0;
            // 
            // btnLoadIni
            // 
            btnLoadIni.Location = new Point(102, 50);
            btnLoadIni.Name = "btnLoadIni";
            btnLoadIni.Size = new Size(215, 42);
            btnLoadIni.TabIndex = 2;
            btnLoadIni.Text = "Načti INI soubor";
            btnLoadIni.UseVisualStyleBackColor = true;
            btnLoadIni.Click += btnLoadIni_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 582);
            Controls.Add(btnLoadIni);
            Controls.Add(propertyGrid1);
            Name = "Form1";
            Text = "Načítání INI souborů";
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid propertyGrid1;
        private Button button1;
        private Button btnLoadIni;
    }
}

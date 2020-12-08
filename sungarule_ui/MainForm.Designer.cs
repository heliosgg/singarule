namespace sungarule_ui
{
   partial class MainForm
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
         this.btnOpen = new System.Windows.Forms.Button();
         this.btnSave = new System.Windows.Forms.Button();
         this.btnRun = new System.Windows.Forms.Button();
         this.txtOut = new System.Windows.Forms.TextBox();
         this.txtFileMask = new System.Windows.Forms.TextBox();
         this.rtxtCode = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // btnOpen
         // 
         this.btnOpen.Location = new System.Drawing.Point(836, 11);
         this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.btnOpen.Name = "btnOpen";
         this.btnOpen.Size = new System.Drawing.Size(171, 56);
         this.btnOpen.TabIndex = 0;
         this.btnOpen.Text = "Открыть";
         this.btnOpen.UseVisualStyleBackColor = true;
         this.btnOpen.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(836, 75);
         this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(171, 56);
         this.btnSave.TabIndex = 1;
         this.btnSave.Text = "Сохранить";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // btnRun
         // 
         this.btnRun.Location = new System.Drawing.Point(836, 139);
         this.btnRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.btnRun.Name = "btnRun";
         this.btnRun.Size = new System.Drawing.Size(171, 56);
         this.btnRun.TabIndex = 2;
         this.btnRun.Text = "Запустить";
         this.btnRun.UseVisualStyleBackColor = true;
         this.btnRun.Click += new System.EventHandler(this.btnCompile_Click);
         // 
         // txtOut
         // 
         this.txtOut.Location = new System.Drawing.Point(14, 348);
         this.txtOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.txtOut.Multiline = true;
         this.txtOut.Name = "txtOut";
         this.txtOut.Size = new System.Drawing.Size(816, 328);
         this.txtOut.TabIndex = 4;
         // 
         // txtFileMask
         // 
         this.txtFileMask.Location = new System.Drawing.Point(14, 685);
         this.txtFileMask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.txtFileMask.Name = "txtFileMask";
         this.txtFileMask.Size = new System.Drawing.Size(816, 27);
         this.txtFileMask.TabIndex = 5;
         // 
         // rtxtCode
         // 
         this.rtxtCode.Location = new System.Drawing.Point(14, 11);
         this.rtxtCode.Name = "rtxtCode";
         this.rtxtCode.Size = new System.Drawing.Size(816, 330);
         this.rtxtCode.TabIndex = 6;
         this.rtxtCode.Text = "";
         this.rtxtCode.FontChanged += new System.EventHandler(this.rtxtCode_FontChanged);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1019, 735);
         this.Controls.Add(this.rtxtCode);
         this.Controls.Add(this.txtFileMask);
         this.Controls.Add(this.txtOut);
         this.Controls.Add(this.btnRun);
         this.Controls.Add(this.btnSave);
         this.Controls.Add(this.btnOpen);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.Text = "Компялетор";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOpen;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Button btnRun;
      private System.Windows.Forms.TextBox txtOut;
      private System.Windows.Forms.TextBox txtFileMask;
      private System.Windows.Forms.RichTextBox rtxtCode;
   }
}


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
         this.txtCode = new System.Windows.Forms.TextBox();
         this.txtOut = new System.Windows.Forms.TextBox();
         this.txtFileMask = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // btnLoad
         // 
         this.btnOpen.Location = new System.Drawing.Point(442, 12);
         this.btnOpen.Name = "btnLoad";
         this.btnOpen.Size = new System.Drawing.Size(150, 42);
         this.btnOpen.TabIndex = 0;
         this.btnOpen.Text = "Открыть";
         this.btnOpen.UseVisualStyleBackColor = true;
         this.btnOpen.Click += new System.EventHandler(this.btnLoad_Click);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(442, 60);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(150, 42);
         this.btnSave.TabIndex = 1;
         this.btnSave.Text = "Сохранить";
         this.btnSave.UseVisualStyleBackColor = true;
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // btnCompile
         // 
         this.btnRun.Location = new System.Drawing.Point(442, 108);
         this.btnRun.Name = "btnCompile";
         this.btnRun.Size = new System.Drawing.Size(150, 42);
         this.btnRun.TabIndex = 2;
         this.btnRun.Text = "Запустить";
         this.btnRun.UseVisualStyleBackColor = true;
         this.btnRun.Click += new System.EventHandler(this.btnCompile_Click);
         // 
         // txtCode
         // 
         this.txtCode.Location = new System.Drawing.Point(12, 8);
         this.txtCode.Multiline = true;
         this.txtCode.Name = "txtCode";
         this.txtCode.Size = new System.Drawing.Size(424, 247);
         this.txtCode.TabIndex = 3;
         // 
         // txtOut
         // 
         this.txtOut.Location = new System.Drawing.Point(12, 261);
         this.txtOut.Multiline = true;
         this.txtOut.Name = "txtOut";
         this.txtOut.Size = new System.Drawing.Size(424, 247);
         this.txtOut.TabIndex = 4;
         // 
         // txtFileMask
         // 
         this.txtFileMask.Location = new System.Drawing.Point(12, 514);
         this.txtFileMask.Name = "txtFileMask";
         this.txtFileMask.Size = new System.Drawing.Size(424, 23);
         this.txtFileMask.TabIndex = 5;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(604, 551);
         this.Controls.Add(this.txtFileMask);
         this.Controls.Add(this.txtOut);
         this.Controls.Add(this.txtCode);
         this.Controls.Add(this.btnRun);
         this.Controls.Add(this.btnSave);
         this.Controls.Add(this.btnOpen);
         this.Name = "MainForm";
         this.Text = "Компялетор";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOpen;
      private System.Windows.Forms.Button btnSave;
      private System.Windows.Forms.Button btnRun;
      private System.Windows.Forms.TextBox txtCode;
      private System.Windows.Forms.TextBox txtOut;
      private System.Windows.Forms.TextBox txtFileMask;
   }
}


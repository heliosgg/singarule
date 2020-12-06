using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using singarule.models;
using singarule_lib;
using System.Globalization;

namespace sungarule_ui
{
   public partial class MainForm : Form
   {
      private string _currentFilePath;
      private CultureInfo _cultureInfo;

      public MainForm()
      {
         InitializeComponent();

         _cultureInfo = CultureInfo.GetCultureInfo("ru");

         this.Text = Localization.ResourceManager.GetString("FormName", _cultureInfo);
         btnOpen.Text = Localization.ResourceManager.GetString("Open", _cultureInfo);
         btnSave.Text = Localization.ResourceManager.GetString("Save", _cultureInfo);
         btnRun.Text = Localization.ResourceManager.GetString("Run", _cultureInfo);
      }

      private void btnLoad_Click(object sender, EventArgs e)
      {
         var fd = new OpenFileDialog();

         if (fd.ShowDialog() != DialogResult.OK)
         {
            return;
         }

         if (!File.Exists(fd.FileName))
         {
            return;
         }

         _currentFilePath = fd.FileName;
         txtCode.Text = File.ReadAllText(_currentFilePath);
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(_currentFilePath))
         {
            return;
         }

         File.WriteAllText(_currentFilePath, txtCode.Text);
      }

      private void btnCompile_Click(object sender, EventArgs e)
      {
         SingaError compilerResult = SingaRule.Compile(txtCode.Text);
         Directory.GetFiles(Directory.GetCurrentDirectory(), txtFileMask.Text).ToList().ForEach(f =>
         {
            string normalizedPath = Path.GetFullPath(f);
            byte[] fileToScanContent = File.ReadAllBytes(normalizedPath);

            if (compilerResult.rule.Scan(fileToScanContent))
            {
               Console.WriteLine($"`{compilerResult.rule.name}` triggered on `{normalizedPath}`");
            }
         });
      }
   }
}

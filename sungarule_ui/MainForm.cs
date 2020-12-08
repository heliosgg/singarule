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
using System.Globalization;

using singarule_lib;
using singarule_lib.models;
using singarule_lib.implementations.expectors;

namespace sungarule_ui
{
   public partial class MainForm : Form
   {
      private string _currentFilePath;
      private CultureInfo _cultureInfo;
      private readonly Font _defaultFont;
      private Color _errorColor = Color.Red;

      public MainForm()
      {
         InitializeComponent();

         _cultureInfo = CultureInfo.GetCultureInfo("ru");

         this.Text = Localization.ResourceManager.GetString("FormName", _cultureInfo);
         btnOpen.Text = Localization.ResourceManager.GetString("Open", _cultureInfo);
         btnSave.Text = Localization.ResourceManager.GetString("Save", _cultureInfo);
         btnRun.Text = Localization.ResourceManager.GetString("Run", _cultureInfo);

         _defaultFont = rtxtCode.Font;

         string[] argv = Environment.GetCommandLineArgs();

         if (argv.Length >= 2)
         {
            OpenRule(argv[1]);
         }

         if (argv.Length == 3)
         {
            txtFileMask.Text = argv[2];
         }
      }

      private void ResetCodeFont()
      {
         rtxtCode.Font = _defaultFont;
      }

      private void OpenRule(string path)
      {
         if (!File.Exists(path))
         {
            return;
         }

         _currentFilePath = path;
         rtxtCode.Text = File.ReadAllText(_currentFilePath);

         ResetCodeFont();
      }

      private void btnLoad_Click(object sender, EventArgs e)
      {
         var fd = new OpenFileDialog();

         if (fd.ShowDialog() != DialogResult.OK)
         {
            return;
         }

         OpenRule(fd.FileName);
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(_currentFilePath))
         {
            return;
         }

         File.WriteAllText(_currentFilePath, rtxtCode.Text);
      }

      private void btnCompile_Click(object sender, EventArgs e)
      {
         ResetCodeFont();

         txtOut.ResetText();

         SingaError compilerResult = SingaRule.Compile(rtxtCode.Text);
         if (compilerResult.rule is null)
         {
            txtOut.Text = compilerResult.ErrorMessage;

            var wordSkipper = new CRegexSkipper(@"\w");
            var ww = compilerResult.ww;

            int errorStartPos = ww.GetCurrentPosition();
            wordSkipper.ExpectIt(ref ww);
            int errorEndPos = ww.GetCurrentPosition();

            rtxtCode.Select(errorStartPos, errorEndPos - errorStartPos + 1);
            rtxtCode.SelectionFont = new Font(_defaultFont, FontStyle.Bold);
            rtxtCode.SelectionColor = _errorColor;

            return;
         }

         StringBuilder output = new StringBuilder("");
         Directory.GetFiles(Directory.GetCurrentDirectory(), txtFileMask.Text).ToList().ForEach(f =>
         {
            string normalizedPath = Path.GetFullPath(f);
            byte[] fileToScanContent = File.ReadAllBytes(normalizedPath);

            if (compilerResult.rule.Scan(fileToScanContent))
            {
               var temp = $"`{compilerResult.rule.name}` {Localization.ResourceManager.GetString("TriggeredOn", _cultureInfo).ToLower()} `{normalizedPath}`";
               output.Append(temp);
               output.Append(Environment.NewLine);
            }

         });

         txtOut.Text = output.ToString();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {

      }

      private void rtxtCode_FontChanged(object sender, EventArgs e)
      {
         
      }
   }
}

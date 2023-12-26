using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace File_Editor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LineNumber.CheckState = Main.showLineNumber ? CheckState.Checked : CheckState.Unchecked;
            Theme.CheckState = Main.theme == "Dark" ? CheckState.Checked : CheckState.Unchecked;
            WordSelection.CheckState = Main.autoWordSelection ? CheckState.Checked : CheckState.Unchecked;
            opacity.Value = Main.opacity;
            FontSize.Value = Main.fontSize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream fs = File.Create(Main.settingsPath))
            {
                Byte[] showlines = new UTF8Encoding(true).GetBytes(LineNumber.Checked ? "True\n" : "False\n");
                fs.Write(showlines, 0, showlines.Length);
                Byte[] last = new UTF8Encoding(true).GetBytes(Main.lastOpenedPath + "\n");
                fs.Write(last, 0, last.Length);
                Byte[] theme = new UTF8Encoding(true).GetBytes(Theme.Checked ? "Dark\n" : "Light\n");
                fs.Write(theme, 0, theme.Length);
                Byte[] opasity = new UTF8Encoding(true).GetBytes(Convert.ToString(opacity.Value) + "\n");
                fs.Write(opasity, 0, opasity.Length);
                Byte[] size = new UTF8Encoding(true).GetBytes(Convert.ToString(FontSize.Value )+ "\n");
                fs.Write(size, 0, size.Length);
                Byte[] autowordsel = new UTF8Encoding(true).GetBytes(WordSelection.Checked ? "True" : "False");
                fs.Write(autowordsel, 0, autowordsel.Length);
            }
            this.Close();
        }
    }
}

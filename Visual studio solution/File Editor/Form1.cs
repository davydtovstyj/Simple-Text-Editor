using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace File_Editor
{
    public partial class Main : Form
    {
        public static bool savedFile = false;
        public string savedPath;
        public static string settingsPath = @"C:\Users\Public\Documents\Settings.stngs";
        public static bool showLineNumber; 
        public static string lastOpenedPath;
        public static string theme;
        public static int opacity;
        public static int fontSize;
        public static bool autoWordSelection;


        public Main()
        {
            InitializeComponent();
        }
        private void OnLoad(object sender, EventArgs e)
        {
            this.Text = "Text Editor";
            if (File.Exists(settingsPath))
            {
                ReadSettings();
            }
            else
            {
                CreateSettingsFile();
                ReadSettings();
            }
            Lines.Font = FieldText.Font;
            FieldText.Select();
            AddLineNumbers();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string path = SaveFile.FileName;
            string fieldText = FieldText.Text;

            using (FileStream fs = File.Create(path))
            {
                Byte[] text = new UTF8Encoding(true).GetBytes(fieldText);
                fs.Write(text, 0, text.Length);
            }
            this.Text = "Text Editor ";
            this.Text += path;
        }

        public void ReadSettings()
        {
            using (StreamReader sr = File.OpenText(settingsPath))
            {
                showLineNumber = Convert.ToBoolean(sr.ReadLine());
                lastOpenedPath = sr.ReadLine();
                theme = sr.ReadLine();
                opacity = Convert.ToInt32(sr.ReadLine());
                fontSize = Convert.ToInt32(sr.ReadLine());
                autoWordSelection = Convert.ToBoolean(sr.ReadLine());
            }

            this.Opacity = (double)(opacity) / 100;
            FieldText.Font = new System.Drawing.Font(FieldText.Font.Name, fontSize);
            FieldText.AutoWordSelection = autoWordSelection;

            if (showLineNumber)
            {
                Lines.Visible = true;
                FieldText.Size = new System.Drawing.Size((this.Width - Lines.Width)-17, this.Height - 64);
                FieldText.Location = new System.Drawing.Point(Lines.Width, 25);
            }
            else
            {
                Lines.Visible = false;
                FieldText.Size = new System.Drawing.Size(this.Width - 16, this.Height - 64);
                FieldText.Location = new System.Drawing.Point(0, 25);
            }
            if (theme == "Dark")
            {
                this.BackColor = System.Drawing.Color.Gray;
                FieldText.BackColor = System.Drawing.Color.FromArgb(64,64,64);
                FieldText.ForeColor = System.Drawing.Color.White;
                Lines.BackColor = System.Drawing.Color.Gray;
                Lines.ForeColor = System.Drawing.Color.FromArgb(224,224,224);
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                FieldText.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                FieldText.ForeColor = System.Drawing.Color.Black;
                Lines.BackColor = System.Drawing.Color.White;
                Lines.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            }
        }
        private void CreateSettingsFile()
        {
            using (FileStream fs = File.Create(settingsPath))
            {
                Byte[] showlines = new UTF8Encoding(true).GetBytes("False\n");
                fs.Write(showlines, 0, showlines.Length);
                Byte[] last = new UTF8Encoding(true).GetBytes(settingsPath + "\n");
                fs.Write(last, 0, last.Length);
                Byte[] theme = new UTF8Encoding(true).GetBytes("Dark\n");
                fs.Write(theme, 0, theme.Length);
                Byte[] opasity = new UTF8Encoding(true).GetBytes("100\n");
                fs.Write(opasity, 0, opasity.Length);
                Byte[] size = new UTF8Encoding(true).GetBytes("14\n");
                fs.Write(size, 0, size.Length);
                Byte[] autowordsel = new UTF8Encoding(true).GetBytes("True");
                fs.Write(autowordsel, 0, autowordsel.Length);
            }
        }
        private void RevriteSettingsFile()
        {
            using (FileStream fs = File.Create(settingsPath))
            {
                Byte[] showlines = new UTF8Encoding(true).GetBytes(showLineNumber ? "True\n" : "False\n");
                fs.Write(showlines, 0, showlines.Length);
                Byte[] last = new UTF8Encoding(true).GetBytes(lastOpenedPath + "\n");
                fs.Write(last, 0, last.Length);
                Byte[] theme1 = new UTF8Encoding(true).GetBytes(theme + "\n");
                fs.Write(theme1, 0, theme1.Length);
                Byte[] opasity1 = new UTF8Encoding(true).GetBytes(opacity.ToString() + "\n");
                fs.Write(opasity1, 0, opasity1.Length);
                Byte[] size = new UTF8Encoding(true).GetBytes(fontSize.ToString() + "\n");
                fs.Write(size, 0, size.Length);
                Byte[] autowordsel = new UTF8Encoding(true).GetBytes(autoWordSelection ? "True" : "False");
                fs.Write(autowordsel, 0, autowordsel.Length);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
            ReadSettings();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(OpenFile.ShowDialog() != DialogResult.OK) return;
            string path = OpenFile.FileName;
            lastOpenedPath = path;
            RevriteSettingsFile();
            savedPath = path;
            savedFile = true;
            FieldText.Text = "";
            Task.Run(() => {
                using (StreamReader sr = File.OpenText(path))
                {
                    FieldText.Text = sr.ReadToEnd();
                }
            });
            this.Text = "Text Editor ";
            this.Text += path;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FieldText.Text = "";
            this.Text = "Text Editor" + "*";
            savedFile = false;
            savedPath = null;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savedFile)
            {
                using (FileStream fs = File.Create(savedPath))
                {
                    Byte[] text = new UTF8Encoding(true).GetBytes(FieldText.Text);
                    fs.Write(text, 0, text.Length);
                }
                this.Text = "Text Editor ";
                this.Text += savedPath;
            }
            else
            {
                if (SaveFile.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string path = SaveFile.FileName;
                savedPath = path;
                string fieldText = FieldText.Text;

                using (FileStream fs = File.Create(path))
                {
                    Byte[] text = new UTF8Encoding(true).GetBytes(fieldText);
                    fs.Write(text, 0, text.Length);
                }
                savedFile = true;
                this.Text = "Text Editor ";
                this.Text += savedPath;
            }
        }

        private void FieldText_TextChanged(object sender, EventArgs e)
        {
            if(!this.Text.Contains("*"))
                this.Text += " *";
            if (FieldText.Text == "")
            {
                AddLineNumbers();
            }
        }

        private void lastOpenedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            savedPath = lastOpenedPath;
            savedFile = true;
            FieldText.Text = "";
            Task.Run(() => {
                using (StreamReader sr = File.OpenText(lastOpenedPath))
                {
                    FieldText.Text = sr.ReadToEnd();
                }
            });
            this.Text = "Text Editor ";
            this.Text += lastOpenedPath;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FieldText.Undo();
        }

        private void rendoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FieldText.Redo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FieldText.SelectAll();
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FieldText.DeselectAll();
        }


        public void AddLineNumbers()
        {  
            Point pt = new Point(0, 0);
            int First_Index = FieldText.GetCharIndexFromPosition(pt);
            int First_Line = FieldText.GetLineFromCharIndex(First_Index); 
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            int Last_Index = FieldText.GetCharIndexFromPosition(pt);
            int Last_Line = FieldText.GetLineFromCharIndex(Last_Index);
            Lines.SelectionAlignment = HorizontalAlignment.Center;
            Lines.Text = "";
            Lines.Width = getWidth();
            for (int i = First_Line; i <= Last_Line+1; i++)
            {
                Lines.Text += i + 1 + "\n";
            }
        }
        public int getWidth()
        {
            int w = 25;
            int line = FieldText.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)FieldText.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)FieldText.Font.Size;
            }
            else
            {
                w = 50 + (int)FieldText.Font.Size;
            }

            return w;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void FieldText_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = FieldText.GetPositionFromCharIndex(FieldText.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void FieldText_VScroll(object sender, EventArgs e)
        {
            Lines.Text = "";
            AddLineNumbers();
            Lines.Invalidate();
        }

        private void FieldText_FontChanged(object sender, EventArgs e)
        {
            Lines.Font = FieldText.Font;
            FieldText.Select();
            AddLineNumbers();
        }

        private void Lines_MouseDown(object sender, MouseEventArgs e)
        {
            FieldText.Select();
            Lines.DeselectAll();
        }

        private void Lines_TextChanged(object sender, EventArgs e)
        {
            if (showLineNumber)
            {
                FieldText.Size = new System.Drawing.Size((this.Width - Lines.Width) - 17, this.Height - 64);
                FieldText.Location = new System.Drawing.Point(Lines.Width, 25);
            }
        }
    }
}

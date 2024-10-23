using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Notbade : Form
    {
        string path;
        bool isTextChanged = false; 
        public Notbade()
        {
            InitializeComponent();
            path = null;
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            if (string.IsNullOrEmpty(path))
                this.Text = "Untitled - Notbade";
            else
                this.Text = System.IO.Path.GetFileName(path) + " - Notbade";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(path))
            {
                rtb_body.SaveFile(path);
                ClearBackColor(); 
                rtb_body.Clear();
                isTextChanged = false; 
            }
            else
            {
                if (saveFD.ShowDialog() == DialogResult.OK)
                {
                    rtb_body.SaveFile(saveFD.FileName);
                    path = saveFD.FileName;
                    ClearBackColor(); 
                    rtb_body.Clear();
                    isTextChanged = false; 
                    UpdateTitle();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTextChanged && ConfirmSaveChanges()) 
            {
                saveToolStripMenuItem_Click(null, null);
            }

            if (openFD.ShowDialog() == DialogResult.OK)
            {
                rtb_body.LoadFile(openFD.FileName);
                path = openFD.FileName;
                isTextChanged = false; 
                UpdateTitle();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFD.ShowDialog() == DialogResult.OK)
            {
                rtb_body.SaveFile(saveFD.FileName);
                path = saveFD.FileName;
                ClearBackColor(); 
                rtb_body.Clear();
                isTextChanged = false;   
                UpdateTitle();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTextChanged && ConfirmSaveChanges()) 
            {
                saveToolStripMenuItem_Click(null, null);
            }

            rtb_body.Clear();
            path = null;
            isTextChanged = false; 
            UpdateTitle();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTextChanged && ConfirmSaveChanges()) 
            {
                saveToolStripMenuItem_Click(null, null);
            }

            this.Close();
        }

        private bool ConfirmSaveChanges()
        {
            return MessageBox.Show("You have unsaved changes. Do you want to save them?", "Unsaved Changes", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void rtb_body_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_body.SelectedText.Length > 0)
                {
                    rtb_body.SelectionFont = fontD.Font;
                }
                else
                {
                    rtb_body.Font = fontD.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_body.SelectedText.Length > 0)
                {
                    rtb_body.SelectionColor = colorD.Color;
                }
                else
                {
                    rtb_body.ForeColor = colorD.Color;
                }
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorD.ShowDialog() == DialogResult.OK)
            {
                if (rtb_body.SelectedText.Length > 0)
                {
                    rtb_body.SelectionBackColor = colorD.Color;
                }
                else
                {
                    rtb_body.BackColor = colorD.Color;
                }
            }
        }

        private void ClearBackColor()
        {
            rtb_body.BackColor = Color.White; 
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_body.CanUndo)
            {
                rtb_body.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_body.CanRedo)
            {
                rtb_body.Redo();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorMusica
{
    public partial class Form1 : Form
    {
        Lista addlist = new Lista();
        OpenFileDialog addpath = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void lstCanciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex != -1)
            {
                axWindowsMediaPlayer1.URL = addpath.FileNames[lstCanciones.SelectedIndex];

            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex > 0)
            {
                lstCanciones.SelectedIndex -= 1;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (lstCanciones.SelectedIndex < lstCanciones.Items.Count - 1)
            {
                lstCanciones.SelectedIndex += 1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addpath.Multiselect = true;
                addpath.Filter = "Archivos audios (*.mp3),(*.mp4),(*.wav),(*.png)|";

                if (addpath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    for (int i = 0; i < addpath.SafeFileNames.Length; i++)
                    {
                        addlist.insertarCanciones(addpath.FileNames[i]);
                        lstCanciones.Items.Add(addpath.SafeFileNames[i]);

                    }
                    axWindowsMediaPlayer1.URL = addpath.FileNames[0];
                    lstCanciones.SelectedIndex = 0;
                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int indice = lstCanciones.SelectedIndex;

            addlist.deleteMusic(indice);
            lstCanciones.Items.RemoveAt(indice);
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}

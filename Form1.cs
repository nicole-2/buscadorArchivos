﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.Devices;
using System.Windows.Forms;

namespace Buscador_de_Archivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string CarpetaBusquedad="";

        Computer Ju = new Computer();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (CarpetaBusquedad=="")
            {
                MessageBox.Show("Falta seleccionar la carpeta");
            }
            else
            {
                Motor(CarpetaBusquedad);
            }
           
        }

        void Motor(string Mot)
        {
            string pop = Mot;

            //Archivos
            for (int i = 0; i < Directory.EnumerateFiles(Mot).Count(); i++)
            {
                FileInfo k = new FileInfo(Directory.GetFiles(Mot)[i]);
                if (k.Name == textBox1.Text)
                {
                    listBox1.Items.Add("Archivo encontrado en: " + k.FullName);
                }
            }

            //Carpetas
            if (Directory.EnumerateDirectories(Mot).Count() > 0)
            {
                for (int i = 0; i < Directory.EnumerateDirectories(Mot).Count(); i++)
                {
                    Motor(Directory.GetDirectories(Mot)[i]);
                }
            }
        }

        private void BtnCarpeta_Click(object sender, EventArgs e)
        {
            //Crear Cuadro de Seleccionar Carpeta
            FolderBrowserDialog Carpeta = new FolderBrowserDialog();

            //Si la carpeta ha sido elegida
            if (Carpeta.ShowDialog()==DialogResult.OK)
            {
                //Carpeta que hemos seleccionado
                CarpetaBusquedad = Carpeta.SelectedPath;

                //Verificar si es correcto
                //MessageBox.Show(CarpetaBusquedad);
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using S3Login.modelo;
namespace S3Login
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Usuario usu = new Usuario();
        ClsDatos1 datos1 = new ClsDatos1();
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            usu.Usuarios = user.Text;
            usu.clave = pass.Text;
            if(datos1.VerificarAcceso(usu) == true)
            {
                MessageBox.Show("Bienvenido a la Aplicacion");

            }
            else
            {
                MessageBox.Show("Error en el acceso");
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

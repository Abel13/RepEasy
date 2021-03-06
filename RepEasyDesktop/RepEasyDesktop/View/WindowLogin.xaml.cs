﻿using RepEasyDesktop.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RepEasyDesktop.View
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        ControlLogin control;
        public WindowLogin()
        {
            InitializeComponent();
            control = new ControlLogin();
        }

        private void ButtonEntrar_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var messageQueue = SnackbarThree.MessageQueue;

            if (String.IsNullOrEmpty(TextBoxCpf.Text))
            {
                TextBoxCpf.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("CPF não informado."));
                return;
            }

            if (String.IsNullOrEmpty(TextBoxSenha.Password))
            {
                TextBoxSenha.Focus();
                Task.Factory.StartNew(() => messageQueue.Enqueue("Senha não informada."));
                return;
            }

            if (control.Logar(TextBoxCpf.Text, TextBoxSenha.Password))
            {
                Dashboard dash = new Dashboard();
                dash.Show();
                this.Close();
            }
            else
            {
                Task.Factory.StartNew(() => messageQueue.Enqueue("CPF ou senha incorreto"));
            }
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            WindowCadastro cadastro = new WindowCadastro();
            cadastro.Show();
            this.Close();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void KeyPress(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                Login();
        }
    }
}

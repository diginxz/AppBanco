﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            logo.Source = ImageSource.FromResource("AppBancoDigital.Assets.JotaBank_Logo.png");
        }

        private async void btn_acessar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (onlynumber(cpf_inserido.Text) == "11111111111" & senha_inserida.Text == "123")
                {
                    //--criar página inicial para o usuario depois do login
                    //await Navigation.PushAsync(new CadastroCliente());

                    await DisplayAlert("Sucesso!", "Login correto", "OK");
                }
                else
                {
                    DisplayAlert("Erro!", "CPF ou senha Inválidos.\nTente Novamente", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private void btn_novo_correntista_Clicked(object sender, EventArgs e)
        {
            try
            {
                 App.Current.MainPage = new CadastroCliente();
            }
            catch(Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        string onlynumber(string str)
        {
            var onlynumber = new Regex(@"[^\d]");
            return onlynumber.Replace(str, "");
        }
    }
}
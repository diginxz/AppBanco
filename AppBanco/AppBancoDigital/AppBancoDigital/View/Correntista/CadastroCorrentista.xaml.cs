using AppBancoDigital.Model;
using AppBancoDigital.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroCliente : ContentPage
    {
        public CadastroCliente()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            dtpck_dataNasc.MaximumDate = DateTime.Now;
            dtpck_dataNasc.MinimumDate = new DateTime(1900, 1, 1);
        }
        private async void btn_cadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (senhaConfirm_inserido.Text == senha_inserido.Text)
                {
                    string senha = senha_inserido.Text;

                    Correntista c = new Correntista
                    {
                        Nome = nome_inserido.Text,
                        CPF = onlynumber(cpf_inserido.Text),
                        Data_nasc = dtpck_dataNasc.Date.ToString("yyyy-MM-dd"),
                        Senha = senha
                    };

                    if (c.Id == null)
                    {
                        await DataServiceCorrentista.CadastrarCorrentistas(c);
                        App.DadosCorrentista = c;
                        await DisplayAlert("Sucesso!", "Novo Cliente Cadastrado com Sucesso!", "Ir para Tela Inicial");

                    }
                    else
                        throw new Exception("Ocorreu um erro ao realizar seu cadastro.\nTente Novamente ou realize o Login se já possui uma conta.");
                }
                else
                {
                    await DisplayAlert("Senhas diferentes!", "Confirme a senha digitada inicialmente", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        private void btn_voltar_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new NavigationPage(new Login());
            }
            catch (Exception ex)
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

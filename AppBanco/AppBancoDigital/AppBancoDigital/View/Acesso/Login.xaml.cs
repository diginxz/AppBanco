using System;
using AppBancoDigital.Service;
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
            var webImage = new Image
            {
                Source = ImageSource.FromUri(
        new Uri("https://bucket.utua.com.br/img/2019/11/nase-marcos-utqK_nX1m4U-unsplash-1-1-e1573655839904.jpg")
     )
            };
        }

        private async void btn_acessar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Model.Correntista c = await DataServiceCorrentista.LoginAsync(new Model.Correntista
                {
                    CPF = onlynumber(cpf_inserido.Text),
                    Senha = senha_inserida.Text,
                });

                if (c.Id != null)
                {
                    App.DadosCorrentista = c;
                    App.Current.MainPage = new NavigationPage(new View.Home());
                }
                else
                    throw new Exception("CPF ou senha Inválidos.\nTente Novamente!");
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
                Navigation.PushAsync(new View.CadastroCliente());
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBancoDigital.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            nome_user = "Olá, " + App.DadosCorrentista.Nome;

            ContaPoupanca = "Iniciar\nConta\nPoupança";
        }

        private void CorrentistaImage_Clicked(object sender, EventArgs e)
        {

        }

        private void Depositar_Clicked(object sender, EventArgs e)
        {

        } 
    }
}
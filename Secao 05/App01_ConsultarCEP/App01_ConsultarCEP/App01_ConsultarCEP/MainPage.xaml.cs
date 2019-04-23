using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
       }

        private void BuscarCEP(object sender, EventArgs args) {

            //TODO - lógica do programa

            //TODO - Validações
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try { 

                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                if(end != null)
                    {
                        RESULTADO.Text = string.Format("{0}, {1} - {2}/{3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                
                } catch(Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter 8 (oito) caracteres.", "OK");

                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve ser composto apenas por números.", "OK");

                valido = false;
            }

            return valido;
        }
    }
}

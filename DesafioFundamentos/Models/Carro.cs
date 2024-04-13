using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    internal class Carro
    {
        private readonly string modelo;
        private readonly string cor;
        private readonly string placa;

        public Carro(string modelo, string cor, string placa)
        {
            this.modelo = modelo;
            this.cor = cor;
            this.placa = placa;
        }

        public override string ToString()
        {
            int tamanhoPadding = 10;

            //Ajusta o padding dos campos
            string paddingModelo = new string(' ', tamanhoPadding - this.modelo.Length);
            string paddingCor = new string(' ', tamanhoPadding - this.cor.Length);
            string paddingPlaca = new string(' ', tamanhoPadding - this.placa.Length);

            StringBuilder st = new StringBuilder();
            st.Append("Modelo: " + paddingModelo + this.modelo + " |");
            st.Append(" Cor: " + paddingCor + this.cor + " |");
            st.Append(" Placa: " + paddingPlaca + this.placa + " |");
            return st.ToString();
        }
    }
}

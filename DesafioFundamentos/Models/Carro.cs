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
            StringBuilder st = new StringBuilder();
            st.Append("Modelo: " + this.modelo);
            st.Append(" Cor: " + this.cor);
            st.Append(" Placa: " + this.placa);
            return st.ToString();
        }
    }
}

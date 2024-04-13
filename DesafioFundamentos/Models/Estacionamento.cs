using System.Text;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<Carro> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<Carro>();
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();

            string modelo, cor, placa;

            Console.WriteLine("Digite os dados do veículo para estacionar:\n");

            Console.Write("Modelo: ");
            modelo = Console.ReadLine();
            modelo = FormatarDados(modelo);
            Console.Write("Cor: ");
            cor = Console.ReadLine();
            cor = FormatarDados(cor);
            Console.Write("Placa: ");
            placa = Console.ReadLine();
            placa = FormatarPlaca(placa);

            // Verifica se a string digitada não é nula ou vazia
            if (string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(cor) || string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("\nOs dados do veículo são de preenchimento obrigatório. A placa deve estar no formato ABC-1234");
                return;
            }
            else
            {
                veiculos.Add(new Carro(modelo, cor, placa));
            }
        }

        public void VeiculosExemplo()
        {
            //Adiciona veículos na lista
            veiculos.Add(new Carro("Onix", "Preto", "AHP-4927"));
            veiculos.Add(new Carro("Palio", "Verde", "DML-2848"));
            veiculos.Add(new Carro("Fit", "Prata", "PDW-9173"));
            veiculos.Add(new Carro("Corola", "Preto", "CID-1804"));
            veiculos.Add(new Carro("Fox", "Vermelho", "SKR-9267"));
            veiculos.Add(new Carro("Gol", "Azul", "NFK-6220"));
            veiculos.Add(new Carro("Toro", "Roxo", "DWJ-5018"));
        }

        // Formatar modelo e cor do veículo
        private string FormatarDados(string dado)
        {
            if (!string.IsNullOrEmpty(dado))
            {
                char[] primeiraLetra = new char[1];
                primeiraLetra[0] = dado.ElementAt(0);
                string st = new string(primeiraLetra);
                dado = dado.Remove(0, 1);
                StringBuilder sb = new StringBuilder();
                sb.Append(st.ToUpper());
                sb.Append(dado.ToLower());
                return sb.ToString();
            }
            return string.Empty;
        }

        // Confere se o formato da placa está de acordo com as regras
        private string FormatarPlaca(string placa)
        {
            if (placa.Length != 8)
            {
                return string.Empty;
            }
            else
            {
                string placaLetras = placa.Remove(3, 5).ToUpper();
                string placaSeparador = placa[3].ToString();
                string placaNumeros = placa.Remove(0, 4);

                bool placaLetrasOk = placaLetras.All(letra => char.IsLetter(letra));
                bool placaNumerosOk = placaNumeros.All(numero => char.IsNumber(numero));
                bool placaSeparadorOk;

                if (placaSeparador == "-") placaSeparadorOk = true;
                else placaSeparadorOk = false;

                if (placaLetrasOk && placaSeparadorOk && placaNumerosOk)
                {
                    return (placaLetras + placaSeparador + placaNumeros);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public Carro VeiculoExiste()
        {
            Console.WriteLine("Digite a placa do veículo para remover:\n");

            string placaProcurada = Console.ReadLine();

            //Procura o veículo na lista do estacionamento
            return veiculos.Find(carro => carro.placa == placaProcurada.ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.Clear();

            // Verifica se o veículo existe
            Carro carro = VeiculoExiste();

            if (carro != null)
            {
                int horas = 0;

                // Verifica se o tempo de permanência é maior que zero
                do
                {
                    Console.Write("\nDigite a quantidade de horas que o veículo permaneceu estacionado: ");
                    horas = Convert.ToInt32(Console.ReadLine());

                    if (horas == 0) Console.WriteLine("\nO tempo de permanência tem quer ser de no mínimo uma hora.");

                } while (horas == 0);

                decimal valorTotal = this.precoInicial + this.precoPorHora * horas;

                veiculos.Remove(carro);

                Console.WriteLine($"\nO veículo {carro.placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("\nDesculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();

            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:\n");

                foreach (Carro veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToString());
                }
            }
            else
            {
                Console.WriteLine("\nNão há veículos estacionados.");
            }
        }
    }
}

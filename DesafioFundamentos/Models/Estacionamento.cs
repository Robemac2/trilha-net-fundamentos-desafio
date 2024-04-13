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
            Console.Write("Cor: ");
            cor = Console.ReadLine();
            Console.Write("Placa: ");
            placa = Console.ReadLine();

            // Verifica se a string digitada não é nula ou vazia
            if (string.IsNullOrEmpty(modelo) && string.IsNullOrEmpty(cor) && string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("\nOs dados do veículo são de preenchimento obrigatório.");
                return;
            }
            else
            {
                veiculos.Add(new Carro(modelo, cor, placa.ToUpper()));
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

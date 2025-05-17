namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial;
        private decimal _precoPorHora;
        private List<Carro> _veiculos = new List<Carro>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this._precoInicial = precoInicial;
            this._precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            
            Console.WriteLine("Digite a marca do veículo para estacionar:");
            string marca = Console.ReadLine();
            
            Console.WriteLine("Digite o modelo do veículo para estacionar:");
            string modelo = Console.ReadLine();
            
            Console.WriteLine("Digite a cor do veículo para estacionar:");
            string cor = Console.ReadLine();
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();
            
            if (ValidarPlaca(placa))
            {
                if (!VeiculoExiste(placa))
                {
                    Carro carro = new Carro(marca, modelo, cor, placa);
                    _veiculos.Add(carro);
                }
                else
                {
                    Console.WriteLine("Este veículo já esta estacionado");
                }
            }
            else
            {
                Console.WriteLine("Confira se digitou a placa corretamente, o formato deve ser ABC-1234");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();
            placa = placa.ToUpper();
            
            //Validar se a placa está no formato correto e o veículo existe
            if (ValidarPlaca(placa) && _veiculos.Any(c=> c.Placa == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                
                string horasDigitadas = Console.ReadLine();
                int horas;
                
                // Validar se o valor digitado para as horas é um número
                if (ValidarHora(horasDigitadas))
                {
                    horas = int.Parse(horasDigitadas);
                }
                else
                {
                    Console.WriteLine("Digite apenas números para as horas estacionadas");
                    return;
                }
                
                decimal valorTotal = _precoInicial + _precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                
                _veiculos.RemoveAll(c => c.Placa == placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                Console.WriteLine("Marca || Modelo || Cor || Placa");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*

                foreach (var veiculo in _veiculos)
                {
                    Console.WriteLine($"{veiculo.Marca} || {veiculo.Modelo} || {veiculo.Cor} || {veiculo.Placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        
        private bool ValidarPlaca(string placa)
        {
            // Checar se a placa contém o número correto de digítos ( 8 ) no formato ABC-1234
            if (placa.Length == 8)
            {
                string placaLetras = placa.Substring(0, 3);
                string placaNumeros = placa.Substring(4, 4);
            
                // Checar se os 3 primeiros digítos são letras
                bool resultadoLetras = placaLetras.All(Char.IsLetter);
            
                // Checar se os ultimos digítos são números
                bool resultadoNumeros = placaNumeros.All(Char.IsDigit);
            
                // Checar se o separador é um sinal de menos ( - )
                bool resultadoSeparador = placa.Any(c => c == '-');

                if (resultadoLetras && resultadoNumeros && resultadoSeparador)
                {
                    return true;
                }
            }
        
            return false;
        }

        private bool ValidarHora(string hora)
        {
            bool resultadoHora = hora.All(c => char.IsDigit(c));

            if (resultadoHora)
            {
                return true;
            }
            
            return false;
        }

        private bool VeiculoExiste(string placa)
        {
            if (_veiculos.Any(c => c.Placa == placa))
            {
                return true;
            }
            
            return false;
        }
    }
}

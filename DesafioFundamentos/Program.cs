﻿using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.Write("Seja bem vindo ao sistema de estacionamento!\n\n" +
                  "Digite o preço inicial: R$ ");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.Write("Agora digite o preço por hora: R$ ");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool carregarExemplo = true;

// Opção para carregar a lista de veículos de exemplo
while (carregarExemplo)
{
    Console.Clear();
    Console.Write("\nDeseja carregar a lista de veículos de Exemplo?\n");
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não\n");
    int exemplo = Convert.ToInt32(Console.ReadLine());

    switch (exemplo)
    {
        case 1:
            es.VeiculosExemplo();
            carregarExemplo = false;
            break;
        case 2:
            carregarExemplo = false;
            break;
        default:
            Console.WriteLine("\nOpção inválida");
            Console.WriteLine("\nPressione uma tecla para continuar");
            Console.ReadLine();
            break;
    }
}

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:\n");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar\n");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("\nOpção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("\nO programa se encerrou");

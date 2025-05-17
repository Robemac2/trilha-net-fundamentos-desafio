namespace DesafioFundamentos.Models;

public class Carro
{
    private string _placa;
    private string _modelo;
    private string _cor;
    private string _marca;

    public string Placa => _placa;
    public string Modelo => _modelo;
    public string Cor => _cor;
    public string Marca => _marca;

    public Carro(string marca, string modelo, string cor, string placa)
    {
        this._placa = placa;
        this._modelo = modelo;
        this._cor = cor;
        this._marca = marca;
    }
}
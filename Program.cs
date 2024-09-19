using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("HOTEL");
Console.Write("Numero de hospedes para hospedar: ");
int numHospedes = Convert.ToInt32(Console.ReadLine());

List<Pessoa> hospedes = new List<Pessoa>();
Reserva reserva;

for (int i = 1; i <= numHospedes; i++)
{
    Console.WriteLine($"HOSPEDE {i}");
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Sobrenome: ");
    string sobrenome = Console.ReadLine();
    Console.WriteLine();

    Pessoa pessoa = new Pessoa(nome, sobrenome);
    hospedes.Add(pessoa);
}

Console.WriteLine("SUITES:");
Suite suite1 = new Suite(numero: 1, tipoSuite: "Básica", capacidade: 2, valorDiaria: 50);
Suite suite2 = new Suite(numero: 2, tipoSuite: "Confort", capacidade: 3, valorDiaria: 100);
Suite suite3 = new Suite(numero: 3, tipoSuite: "Premium", capacidade: 5, valorDiaria: 150);

Console.WriteLine($"Numero {suite1.Numero} | {suite1.TipoSuite}  | Capacidade -> {suite1.Capacidade} | R$ {suite1.ValorDiaria}");
Console.WriteLine($"Numero {suite2.Numero} | {suite2.TipoSuite} | Capacidade -> {suite2.Capacidade} | R$ {suite2.ValorDiaria}");
Console.WriteLine($"Numero {suite3.Numero} | {suite3.TipoSuite} | Capacidade -> {suite3.Capacidade} | R$ {suite3.ValorDiaria}");
Console.WriteLine();

Console.Write("Informe o número da suíte que deseja: ");
int numSuite = Convert.ToInt32(Console.ReadLine());
Console.Write("Informe quantos dias deseja reservar: ");
int diasReservados = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

reserva = new Reserva(diasReservados);

switch (numSuite)
{
    case 1:
        reserva.CadastrarSuite(suite1);
        break;
    case 2:
        reserva.CadastrarSuite(suite2);
        break;
    case 3:
        reserva.CadastrarSuite(suite3);
        break;
    default:
        Console.WriteLine("Suíte inválida.");
        return;
}

// Cadastrar os hóspedes
try
{
    reserva.CadastrarHospedes(hospedes);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

// Calcular e exibir o valor da diária
decimal valorTotal = reserva.CalcularValorDiaria();
Console.WriteLine($"Valor total da estadia para {reserva.DiasReservados} dias e " +
                  $"{reserva.ObterQuantidadeHospedes()} hospedes: R$ {valorTotal}");

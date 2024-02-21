
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound!";
//List<string> bandas = new List<string>();
Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();

void ExibirLogo() 
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("\n1 - Registrar uma banda");
    Console.WriteLine("2 - Mostrar todas as bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Exibir a média de uma banda");
    Console.WriteLine("0 - Sair");

    Console.Write("\nDigite a sua opção: ");
    int opcao = int.Parse(Console.ReadLine()!);
    switch (opcao)
    {
        case 1: RegistrarBanda();
                break;
        case 2: ExibirBandas();
                break;
        case 3: AvaliarUmaBanda();
                break;
        case 4: MediaDaBanda();
                break;
        case 0: Console.Clear();
                Console.WriteLine("Obrigado pela visita, volte sempre! <3");
                Thread.Sleep(3000);
                break;
        default:
                Console.WriteLine("Opção inválida!");
                break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulo("Registro de Bandas");
    Console.Write("Digite o nome da banda que será registrada: ");
    string nomeBanda = Console.ReadLine()!;
    bandas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeBanda} foi registrada com sucesso!\n");
    Console.Write("Aguarde...");
    Thread.Sleep(3000);
    Console.Clear();   
    ExibirMenu();
}

void ExibirBandas()
{
    Console.Clear();
    ExibirTitulo("Lista de Bandas");
    int i = 1;
    foreach (var banda in bandas)
    { 
        Console.WriteLine($"{i} - {banda.Key}\n");
        i++;
    }
    Console.Write("Pressione uma tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTitulo("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        Console.Write($"Qual nota que a banda '{nomeBanda}' merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi atribuída com sucesso à banda {nomeBanda}");
        Console.Write("\nAguarde...");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirMenu();
    }else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.Write("\nPressione uma tecla para ir à aba Lista de Bandas...");
        Console.ReadKey();
        Console.Clear();
        ExibirBandas();
    }
}

void MediaDaBanda()
{
    Console.Clear();
    ExibirTitulo("Média da Banda");
    Console.Write("Você gostaria de ver a média de qual banda? ");
    string nomeBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeBanda))
    {
        double media = bandas[nomeBanda].Average();
        Console.WriteLine($"\nA média da banda '{nomeBanda}' é de: {media.ToString("F")}");
        Console.Write("\nPressione uma tecla pra voltar ao menu principal!");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeBanda} não foi encontrada!");
        Console.Write("\nPressione uma tecla para ir à aba Lista de Bandas...");
        Console.ReadKey();
        Console.Clear();
        ExibirBandas();
    }

}
void ExibirTitulo(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string hifens = string.Empty.PadLeft(quantidadeDeLetras, '-');
    Console.WriteLine(hifens);
    Console.WriteLine(titulo);
    Console.WriteLine(hifens + "\n");
}

ExibirMenu();

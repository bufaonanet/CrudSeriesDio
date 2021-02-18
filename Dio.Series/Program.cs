using System;
using Dio.Series.Classes;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            var opcao = ObterOpcaoUsuario();

            while (opcao != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentException("opão inválida");
                }

                opcao = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar nossos serviços");
            System.Console.ReadKey();
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o indice da série");
            int.TryParse(Console.ReadLine(), out var indice);

            var serie = repositorio.RetornaPorId(indice);

            System.Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o indice da série");
            int.TryParse(Console.ReadLine(), out var indice);

            repositorio.Exclui(indice);
        }

        private static Serie IniciaSerie(bool novoRegistro, int? indice)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite uma descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            if (novoRegistro)
                indice = repositorio.ProximoId();

            var serie = new Serie(
                id: indice.GetValueOrDefault(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno,
                excluido: false
            );

            return serie;
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série");
            int.TryParse(Console.ReadLine(), out int indiceEntrada);

            var serie = IniciaSerie(false, indiceEntrada);

            repositorio.Atualiza(indiceEntrada, serie);
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir Nova Série");

            var serie = IniciaSerie(true, 0);

            repositorio.Insere(serie);
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Lista Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {
                var foiExcluido = (serie.Excluido ? "Sim" : "Não");

                System.Console.WriteLine("#ID {0}: - {1} - Saiu do catálogo? ({2})", serie.GetId(), serie.GetTitulo(), foiExcluido);
            }
        }

        static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("DIO Séries ao seu dispor");
            System.Console.WriteLine("Escolha a opção desejada");

            System.Console.WriteLine("1 - Listar Séries");
            System.Console.WriteLine("2 - Inserir nova Série");
            System.Console.WriteLine("3 - Atualizar Série");
            System.Console.WriteLine("4 - Excluir Série");
            System.Console.WriteLine("5 - Vizualizar Série");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }
    }
}

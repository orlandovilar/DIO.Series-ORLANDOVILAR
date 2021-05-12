using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = "";

            while(opcaoUsuario.ToUpper() != "X")
            {
                opcaoUsuario = ObterOpcaoUsuario();
                switch(opcaoUsuario)
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
                    case "X":
                        Console.WriteLine(">>>>> E que a sorte esteja sempre ao seu favor! <<<<<");
                        Console.WriteLine("> Até Mais!");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("> Listar séries");

            var lista = repositorio.Listar();

            if(lista.Count == 0)
            {
                Console.WriteLine("> Nenhuma série cadastrada! <");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.RetornarExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.RetornarId(), serie.RetornarTitulo(), excluido ? "*Série Excluída*" : "");
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine(">> Gêneros de Séries Disponíveis: ");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write(">> Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write(">> Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write(">> Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write(">> Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Inserir(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write(">>> Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            if(repositorio.RetornarPorId(indiceSerie) != null)
            {
                Console.WriteLine(">>> Gêneros de Séries Disponíveis: ");
                foreach(int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write(">>> Digite o Gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write(">> Digite o Título da Série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write(">>> Digite o Ano de Início da Série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.Write(">>> Digite a Descrição da Série: ");
                string entradaDescricao = Console.ReadLine();

                Serie serieAtualizada = new Serie(id: indiceSerie,
                                            genero: (Genero) entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                
                repositorio.Atualizar(indiceSerie, serieAtualizada);
            }
        }
        private static void ExcluirSerie()
        {
            Console.Write(">>>> Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            int indexExclusao = 0;

            if(repositorio.RetornarPorId(indiceSerie) != null)
            {
                Console.WriteLine(">>>> Tem certeza que deseja excluir esta série?");
                do
                {
                    Console.WriteLine(">>>> Digite 1 - Sim ou 2 - Não");
                    Console.Write(">>>> ");
                    indexExclusao = int.Parse(Console.ReadLine());
                }while(indexExclusao != 1 && indexExclusao != 2);
                
                if(indexExclusao == 1)
                {
                        repositorio.Excluir(indiceSerie);
                }
            }
        }

        private static void VisualizarSerie()
        {
            Console.Write(">>>>> Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(indiceSerie);

            if(serie != null)
            {
                Console.WriteLine(serie);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(">>>>> DIO Séries <<<<<");
            Console.WriteLine("Informe a opção desejada:");

            
            Console.WriteLine("1 - Listar séries;");
            Console.WriteLine("2 - Inserir nova série;");
            Console.WriteLine("3 - Atualizar série;");
            Console.WriteLine("4 - Excluir série;");
            Console.WriteLine("5 - Visualizar série;");
            Console.WriteLine("C - Limpar Tela;");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

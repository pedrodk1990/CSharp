using System;
using System.Collections.Generic;

class Program
{
    private static List<Usuario> usuarios = UserStorage.LoadUsers();
    private static Usuario usuarioAtivo;

    static void Main(string[] args)
    {
        MenuPonto();
    }

    static void MenuPonto()
    {
        var registros = JsonStorage.Load();
        while (true)
        {
            Console.WriteLine("\nMenu Ponto Eletrônico");
            Console.WriteLine("1. Registrar Entrada");
            Console.WriteLine("2. Registrar Saída");
            Console.WriteLine("3. Gerar Relatório");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    RegistrarEntradaOuUsuario(registros, "Entrada");
                    break;
                case "2":
                    RegistrarEntradaOuUsuario(registros, "Saída");
                    break;
                case "3":
                    GerarRelatorio(registros);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void RegistrarEntradaOuUsuario(List<RegistroPonto> registros, string tipo)
    {
        while (true)
        {
            Console.WriteLine($"\nRegistrar {tipo}");
            Console.WriteLine("1. Registrar Usuário");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Voltar");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    RegistrarUsuario();
                    break;
                case "2":
                    if (Login())
                    {
                        if (tipo == "Entrada")
                        {
                            RegistrarEntrada(registros);
                        }
                        else
                        {
                            RegistrarSaida(registros);
                        }
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void RegistrarUsuario()
    {
        var novoUsuario = new Usuario();
        Console.Write("Digite seu nome: ");
        novoUsuario.Nome = Console.ReadLine();
        Console.Write("Digite seu CPF: ");
        var cpf = Console.ReadLine();

        if (!Validador.ValidarCPF(cpf))
        {
            Console.WriteLine("CPF inválido.");
            return;
        }

        // Verificar se o CPF já existe
        if (usuarios.Exists(u => u.CPF == cpf))
        {
            Console.WriteLine("CPF já cadastrado.");
            return;
        }

        novoUsuario.CPF = cpf;
        Console.Write("Digite sua senha: ");
        novoUsuario.Senha = Console.ReadLine();

        usuarios.Add(novoUsuario);
        UserStorage.SaveUsers(usuarios);
        Console.WriteLine("Usuário registrado com sucesso.");
    }

    static bool Login()
    {
        Console.Write("Digite seu CPF: ");
        var cpf = Console.ReadLine();
        Console.Write("Digite sua senha: ");
        var senha = Console.ReadLine();

        usuarioAtivo = usuarios.Find(u => u.CPF == cpf && u.Senha == senha);
        if (usuarioAtivo != null)
        {
            Console.WriteLine($"Bem-vindo, {usuarioAtivo.Nome}!");
            return true;
        }
        else
        {
            Console.WriteLine("CPF ou senha inválidos.");
            return false;
        }
    }

    static void RegistrarEntrada(List<RegistroPonto> registros)
    {
        var registro = new RegistroPonto
        {
            Usuario = usuarioAtivo, // Armazena a instância do usuário que registrou a entrada
            Data = DateTime.Now.Date,
            Entrada = DateTime.Now
        };
        registros.Add(registro);
        JsonStorage.Save(registros);
        Console.WriteLine("Entrada registrada com sucesso.");
    }

    static void RegistrarSaida(List<RegistroPonto> registros)
    {
        var registro = registros.FindLast(r => r.Data == DateTime.Now.Date && r.Saida == null && r.Usuario.CPF == usuarioAtivo.CPF);
        if (registro != null)
        {
            registro.Saida = DateTime.Now;
            JsonStorage.Save(registros);
            Console.WriteLine("Saída registrada com sucesso.");
        }
        else
        {
            Console.WriteLine("Nenhuma entrada registrada para hoje ou o usuário não está logado.");
        }
    }

    static void GerarRelatorio(List<RegistroPonto> registros)
    {
        Console.WriteLine("Filtrar por:");
        Console.WriteLine("1. Nome");
        Console.WriteLine("2. CPF");
        Console.WriteLine("3. Todos");
        Console.Write("Escolha uma opção: ");
        var opcao = Console.ReadLine();

        List<RegistroPonto> registrosFiltrados = registros;

        if (opcao == "1")
        {
            Console.Write("Digite o nome do usuário: ");
            var nome = Console.ReadLine();
            registrosFiltrados = registros.FindAll(r => r.Usuario.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        else if (opcao == "2")
        {
            Console.Write("Digite o CPF do usuário: ");
            var cpf = Console.ReadLine();
            registrosFiltrados = registros.FindAll(r => r.Usuario.CPF.Equals(cpf, StringComparison.OrdinalIgnoreCase));
        }

        Console.WriteLine("Relatório de Horas Trabalhadas:");
        foreach (var registro in registrosFiltrados)
        {
            if (registro.HorasTrabalhadas.HasValue)
            {
                Console.WriteLine($"{registro.Usuario.Nome} - {registro.Data.ToShortDateString()} - Entrada: {registro.Entrada?.ToShortTimeString()}, Saída: {registro.Saida?.ToShortTimeString()}, Horas Trabalhadas: {registro.HorasTrabalhadas.Value}");
            }
        }
    }
}
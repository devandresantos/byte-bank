using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteBank
{

    public class Program
    {

        static void MostrarMenu()
        {

            Console.WriteLine("Bem-vindo(a) ao ByteBank!\n");
            Console.WriteLine("Menu principal\n");

            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Excluir conta");
            Console.WriteLine("3 - Listar todas as contas cadastradas");
            Console.WriteLine("4 - Detalhar dados do usuário");
            Console.WriteLine("5 - Mostrar quantia armazenada no banco");
            Console.WriteLine("6 - Manipular conta");
            Console.WriteLine("0 - Sair do programa");

            Console.Write("\nDigite a opção desejada: ");

        }


        static void CriarConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {

            Console.Clear();

            Console.Write("Digite seu cpf: ");
            string cpfUsuario = Console.ReadLine();

            int indiceCpf = cpfs.FindIndex(cpf => cpf == cpfUsuario);

            if(indiceCpf == -1)
            {

                cpfs.Add(cpfUsuario);

                Console.Write("Digite seu nome: ");
                titulares.Add(Console.ReadLine());

                Console.Write("Digite uma senha forte: ");
                senhas.Add(Console.ReadLine());

                saldos.Add(0);

                Console.Clear();
                Console.WriteLine("Conta criada com sucesso!");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Clear();
                Console.WriteLine("O usuário informado já possui cadastro no banco!");
                Console.WriteLine("----------------------------------\n");

            }

        }


        static void ExcluirConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {

            Console.Clear();
            Console.Write("Digite seu cpf: ");

            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {

                Console.Clear();
                Console.WriteLine("Usuário não cadastrado!");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Write("Digite sua senha: ");
                string senhaInformada = Console.ReadLine();

                if (senhas[indexParaDeletar] == senhaInformada)
                {

                    cpfs.Remove(cpfParaDeletar);
                    titulares.RemoveAt(indexParaDeletar);
                    senhas.RemoveAt(indexParaDeletar);
                    saldos.RemoveAt(indexParaDeletar);
                    Console.Clear();
                    Console.WriteLine("Conta excluída com sucesso!");
                    Console.WriteLine("----------------------------------\n");

                }
                else
                {

                    Console.Clear();
                    Console.WriteLine("Senha incorreta! Nenhuma conta foi excluída.");
                    Console.WriteLine("----------------------------------\n");

                }

            }

        }


        static void ListarTodasContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            Console.Clear();

            if (cpfs.Count != 0)
            {

                for (int i = 0; i < cpfs.Count; i++)
                {

                    MostrarContaUsuario(i, cpfs, titulares, saldos);

                }

            }
            else
            {

                Console.WriteLine("Nenhuma conta cadastrada!");

            }

        }


        static void DetalharUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            Console.Write("Digite seu cpf: ");

            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {

                Console.Clear();
                Console.WriteLine("Não foi possível detalhar dados do usuario!");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Clear();
                MostrarContaUsuario(indexParaApresentar, cpfs, titulares, saldos);

            }

        }


        static void MostrarQuantiaArmazenada(List<double> saldos)
        {

            Console.Clear();
            Console.WriteLine($"Total da quantia armazenada no banco: R${saldos.Sum()}");
            Console.WriteLine("----------------------------------\n");

        }


        static void MostrarContaUsuario(int indice, List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            Console.WriteLine($"CPF = {cpfs[indice]} | Titular = {titulares[indice]} | Saldo = R${saldos[indice]:F2}");
            Console.WriteLine("----------------------------------\n");

        }


        static void Depositar(List<double> saldos, int indiceLogin)
        {

            Console.Clear();
            Console.Write("Digite o valor para depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            saldos[indiceLogin] += valorDeposito;

            Console.Clear();
            Console.WriteLine($"Valor depositado com sucesso! Seu novo saldo é R${saldos[indiceLogin]}");
            Console.WriteLine("----------------------------------\n");

        }


        static void VerSaldo(List<double> saldos, int indiceLogin)
        {

            Console.Clear();
            Console.WriteLine($"Seu saldo é R${saldos[indiceLogin]}");
            Console.WriteLine("----------------------------------\n");

        }


        static void Sacar(List<double> saldos, int indiceLogin)
        {

            Console.Write("Digite o valor para saque: ");
            double valorParaSaque = double.Parse(Console.ReadLine());

            if(saldos[indiceLogin] >= valorParaSaque)
            {

                saldos[indiceLogin] -= valorParaSaque;
                Console.Clear();
                Console.WriteLine($"Saque realizado com sucesso! Seu novo saldo é R${saldos[indiceLogin]}");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Clear();
                Console.WriteLine($"Não foi possível sacar o valor informado. Seu saldo é R${saldos[indiceLogin]}");
                Console.WriteLine("----------------------------------\n");

            }

        }


        static void Transferir(List<double> saldos, int indiceLogin, List<string> cpfs)
        {

            if (saldos[indiceLogin] != 0)
            {

                Console.Write("Digite o CPF do titular da conta de destino: ");
                string cpfContaDestino = Console.ReadLine();
                string cpfUsuario = cpfs[indiceLogin];

                if(cpfUsuario != cpfContaDestino)
                {

                    int indiceContaDestino = cpfs.FindIndex(cpf => cpf == cpfContaDestino);

                    if(indiceContaDestino != -1)
                    {

                        Console.Clear();
                        Console.WriteLine($"Seu saldo é R${saldos[indiceLogin]}\n");

                        Console.Write("Digite o valor da transferência: ");
                        double valorTransferencia = double.Parse(Console.ReadLine());

                        if(saldos[indiceLogin] >= valorTransferencia)
                        {

                            saldos[indiceContaDestino] += valorTransferencia;
                            saldos[indiceLogin] -= valorTransferencia;

                            Console.Clear();
                            Console.WriteLine($"Transferência realizada com sucesso! Seu novo saldo é R${saldos[indiceLogin]}");
                            Console.WriteLine("----------------------------------\n");

                        }
                        else
                        {

                            Console.Clear();
                            Console.WriteLine($"Não foi possível transferir o valor informado! Seu saldo é R${saldos[indiceLogin]}");
                            Console.WriteLine("----------------------------------\n");

                        }

                    }
                    else
                    {

                        Console.Clear();
                        Console.WriteLine("O usuário da conta de destino não está cadastrado no banco!");
                        Console.WriteLine("----------------------------------\n");

                    }

                }
                else
                {

                    Console.Clear();
                    Console.WriteLine("Não é possível realizar transferência para você mesmo!");
                    Console.WriteLine("----------------------------------\n");

                }

            }
            else
            {

                Console.Clear();
                Console.WriteLine("Não é possível realizar nenhuma transferência porque seu saldo é R$0");
                Console.WriteLine("----------------------------------\n");

            }

        }


        static int MenuManipularConta(List<double> saldos, List<string> cpfs, List<string> senhas, List<string> titulares)
        {

            Console.Clear();
            Console.WriteLine("Bem-vindo(a) ao ByteBank!\n");
            Console.WriteLine("Login\n");

            Console.Write("Digite seu CPF: ");
            string cpfUsuario = Console.ReadLine();

            int indiceLogin = cpfs.FindIndex(cpf => cpf == cpfUsuario);

            if(indiceLogin != -1)
            {

                Console.Write("Informe sua senha: ");
                string senhaUsuario = Console.ReadLine();

                if (senhas[indiceLogin] != senhaUsuario)
                {

                    Console.Clear();
                    Console.WriteLine("Senha incorreta!");
                    return 0;

                }

            }
            else
            {

                Console.Clear();
                Console.WriteLine("Usuário não cadastrado!");
                return 0;

            }

            Console.Clear();
            Console.WriteLine($"Bem-vindo(a), {titulares[indiceLogin]}\n");
            Console.WriteLine("Menu principal > Manipular conta\n");

            int opcao;

            do
            {

                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Sacar");
                Console.WriteLine("3 - Transferir");
                Console.WriteLine("4 - Ver saldo");
                Console.WriteLine("5 - Voltar para o menu principal");
                Console.WriteLine("0 - Sair do programa");

                Console.Write("\nInforme a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());

                if (opcao == 0)
                {

                    Console.Clear();
                    Console.WriteLine("Você saiu!");
                    return 0;

                }

                switch (opcao)
                {

                    case 1:
                        Depositar(saldos, indiceLogin);
                        break;
                    case 2:
                        Sacar(saldos, indiceLogin);
                        break;
                    case 3:
                        Transferir(saldos, indiceLogin, cpfs);
                        break;
                    case 4:
                        VerSaldo(saldos, indiceLogin);
                        break;

                }

            } while (opcao != 5);

            Console.Clear();

            return -1;

        }


        public static void Main(string[] args)
        {

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int opcao;

            do
            {

                MostrarMenu();

                try
                {

                    opcao = int.Parse(Console.ReadLine());

                }
                catch
                {

                    opcao = -1;

                }

                switch (opcao)
                {

                    case 0:
                        Console.Clear();
                        Console.WriteLine("Você saiu!");
                        break;
                    case 1:
                        CriarConta(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        ExcluirConta(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        DetalharUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        MostrarQuantiaArmazenada(saldos);
                        break;
                    case 6:
                        opcao = MenuManipularConta(saldos, cpfs, senhas, titulares);
                        break;
                    default:
                        Console.Clear();
                        break;

                }


            } while (opcao != 0);

        }

    }

}
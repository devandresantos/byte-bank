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
            Console.WriteLine("4 - Detalhar conta do usuário");
            Console.WriteLine("5 - Mostrar quantia armazenada no banco");
            Console.WriteLine("6 - Manipular conta");
            Console.WriteLine("0 - Sair do programa");

            Console.Write("\nDigite a opção desejada: ");

        }


        static void CriarConta(List<string> numerosConta, List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {

            Console.Clear();

            Console.WriteLine("Para criar uma conta, informe os dados abaixo:\n");

            Console.Write("Digite seu cpf: ");
            string cpfUsuario = Console.ReadLine();

            int indiceCpf = cpfs.FindIndex(cpf => cpf == cpfUsuario);

            if(indiceCpf == -1)
            {

                cpfs.Add(cpfUsuario);

                Console.Write("Digite seu nome completo: ");
                titulares.Add(Console.ReadLine());

                Console.Write("Digite uma senha forte: ");
                senhas.Add(Console.ReadLine());

                saldos.Add(0);

                Random numeroRandomico = new Random();
                string numeroConta = numeroRandomico.Next(10000000, 99999999).ToString();
                numerosConta.Add(numeroConta);

                Console.Clear();
                Console.WriteLine("Conta criada com sucesso!\n");
                Console.WriteLine($"O número da sua conta é {numeroConta}");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Clear();
                Console.WriteLine("O usuário informado já possui cadastro no banco!");
                Console.WriteLine("----------------------------------\n");

            }

        }


        static void ExcluirConta(List<string> numerosConta, List<string> titulares, List<string> senhas, List<double> saldos)
        {

            Console.Clear();
            Console.WriteLine("Para excluir sua conta, informe os dados abaixo:\n");
            Console.Write("Digite o número da sua conta: ");

            string nroContaParaExcluir = Console.ReadLine();
            int indiceParaExcluir = numerosConta.FindIndex(nroConta => nroConta == nroContaParaExcluir);

            if (indiceParaExcluir == -1)
            {

                Console.Clear();
                Console.WriteLine("A conta informada não está cadastrada no banco!");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Write("Digite sua senha: ");
                string senhaInformada = Console.ReadLine();

                if (senhas[indiceParaExcluir] == senhaInformada)
                {

                    numerosConta.Remove(nroContaParaExcluir);
                    titulares.RemoveAt(indiceParaExcluir);
                    senhas.RemoveAt(indiceParaExcluir);
                    saldos.RemoveAt(indiceParaExcluir);

                    Console.Clear();
                    Console.WriteLine("Conta excluída com sucesso!");
                    Console.WriteLine("----------------------------------\n");

                }
                else
                {

                    Console.Clear();
                    Console.WriteLine("Senha incorreta! Sua conta não foi excluída.");
                    Console.WriteLine("----------------------------------\n");

                }

            }

        }


        static void ListarTodasContas(List<string> numerosConta, List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            Console.Clear();

            if (numerosConta.Count != 0)
            {

                Console.WriteLine("Listagem de todas as contas:\n");

                for (int i = 0; i < numerosConta.Count; i++)
                {

                    MostrarContaUsuario(i, numerosConta, cpfs, titulares, saldos);

                }

                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.WriteLine("Nenhuma conta cadastrada!");
                Console.WriteLine("----------------------------------\n");

            }

        }


        static void DetalharConta(List<string> numerosConta, List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            Console.Clear();
            Console.WriteLine("Para detalhar uma conta, informe os dados abaixo:\n");

            Console.Write("Digite o número da conta: ");

            string nroContaParaApresentar = Console.ReadLine();
            int indiceParaApresentar = numerosConta.FindIndex(nroConta => nroConta == nroContaParaApresentar);

            if (indiceParaApresentar == -1)
            {

                Console.Clear();
                Console.WriteLine("A conta informada não está cadastrada no banco!");
                Console.WriteLine("----------------------------------\n");

            }
            else
            {

                Console.Clear();
                Console.WriteLine("Detalhes da conta:\n");

                MostrarContaUsuario(indiceParaApresentar, numerosConta, cpfs, titulares, saldos);
                Console.WriteLine("----------------------------------\n");

            }

        }


        static void MostrarQuantiaArmazenada(List<double> saldos)
        {

            Console.Clear();
            Console.WriteLine($"Total da quantia armazenada no banco: R${saldos.Sum()}");
            Console.WriteLine("----------------------------------\n");

        }


        static void MostrarContaUsuario(int indice, List<string> numerosConta, List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            Console.WriteLine($"Número da conta = {numerosConta[indice]} | CPF = {cpfs[indice]} | Titular = {titulares[indice]} | Saldo = R${saldos[indice]:F2}");

        }


        static void Depositar(List<double> saldos, int indiceLogin)
        {

            Console.Clear();
            Console.WriteLine("Menu principal > Manipular conta > Depositar\n");

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
            Console.WriteLine("Menu principal > Manipular conta > Ver saldo\n");

            Console.WriteLine($"Seu saldo é R${saldos[indiceLogin]}");
            Console.WriteLine("----------------------------------\n");

        }


        static void Sacar(List<double> saldos, int indiceLogin)
        {

            double valorParaSaque;

            while (true)
            {

                try
                {

                    Console.Clear();
                    Console.WriteLine("Menu principal > Manipular conta > Sacar\n");

                    Console.WriteLine($"Seu saldo é R${saldos[indiceLogin]}\n");

                    Console.Write("Digite o valor para saque: ");
                    valorParaSaque = double.Parse(Console.ReadLine());

                    if(valorParaSaque > 0) break;

                }
                catch { }

            }

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


        static void Transferir(List<string> numerosConta, List<double> saldos, int indiceLogin)
        {

            if (saldos[indiceLogin] != 0)
            {

                string numeroConta = numerosConta[indiceLogin];

                Console.Clear();
                Console.WriteLine("Menu principal > Manipular conta > Transferir\n");

                Console.Write("Digite o número da conta de destino: ");
                string numeroContaDestino = Console.ReadLine();

                if(numeroConta != numeroContaDestino)
                {

                    int indiceContaDestino = numerosConta.FindIndex(nroConta => nroConta == numeroContaDestino);

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
                            Console.WriteLine($"Não foi possível transferir o valor informado porque saldo é R${saldos[indiceLogin]}");
                            Console.WriteLine("----------------------------------\n");

                        }

                    }
                    else
                    {

                        Console.Clear();
                        Console.WriteLine("O usuário da conta de destino não possui cadastro no banco!");
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


        static int MenuManipularConta(List<string> numerosConta, List<double> saldos, List<string> cpfs, List<string> senhas, List<string> titulares)
        {

            Console.Clear();
            Console.WriteLine("ByteBank\n");
            Console.WriteLine("Para fazer login, informe os dados abaixo:\n");

            Console.Write("Digite o número da sua conta: ");
            string numeroConta = Console.ReadLine();

            int indiceLogin = numerosConta.FindIndex(nroConta => nroConta == numeroConta);

            if(indiceLogin != -1)
            {

                Console.Write("Digite sua senha: ");
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
                Console.WriteLine("A conta informada não está cadastrada no banco!");
                return 0;

            }

            Console.Clear();
            Console.WriteLine("Menu principal > Manipular conta\n");
            Console.WriteLine($"Bem-vindo(a), {titulares[indiceLogin]}\n");

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
                        Transferir(numerosConta, saldos, indiceLogin);
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

            List<string> numerosConta = new List<string>();
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
                        CriarConta(numerosConta, cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        ExcluirConta(numerosConta, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasContas(numerosConta, cpfs, titulares, saldos);
                        break;
                    case 4:
                        DetalharConta(numerosConta, cpfs, titulares, saldos);
                        break;
                    case 5:
                        MostrarQuantiaArmazenada(saldos);
                        break;
                    case 6:
                        opcao = MenuManipularConta(numerosConta, saldos, cpfs, senhas, titulares);
                        break;
                    default:
                        Console.Clear();
                        break;

                }


            } while (opcao != 0);

        }

    }

}
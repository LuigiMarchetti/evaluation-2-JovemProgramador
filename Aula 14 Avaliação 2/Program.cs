using System;

namespace Aula_14_Avaliação_2
{
    class Program
    {
        static int saldo, quantidadeNotasDoisReais, quantidadeNotasCincoReais, quantidadeNotasDezReais, quantidadeNotasVinteReais, quantidadeNotasCinquentaReais, quantidadeNotasCemReais, quantidadeNotasDuzentosReais;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Digite 1 para depositar, 2 para sacar um valor ou 0 para sair");

                if(int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica == 1 || respostaNumerica == 2 || respostaNumerica == 0)
                {
                    switch (respostaNumerica)
                    {
                        case 1: Depositar(); break;
                        case 2: Sacar(); break;
                        case 0: break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida!");
                    Console.ResetColor();
                    Console.WriteLine("");
                }
            } while (true);
        }

        static void Sacar()
        {
            CalcularSaldo();
            if (saldo != 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Saldo disponível: {saldo}");
                Console.ResetColor();
                Console.WriteLine("");

                Console.WriteLine("Digite o valor que deseja sacar:");
                if (int.TryParse(Console.ReadLine(), out int valorSaque))
                { 
                    Console.WriteLine("Digite 1 para especificar as notas que deseja receber, 2 para prosseguir ou 0 para voltar");
                    if (int.TryParse(Console.ReadLine(), out int opcaoSaque) && (opcaoSaque == 1 || opcaoSaque == 2))
                    {
                        if (opcaoSaque == 1)
                        {
                            CalcularSaque1(valorSaque);
                            return;
                        }
                        else if (opcaoSaque == 2)
                        {
                            
                            bool auxiliarSenha = false;
                            auxiliarSenha = VerificarSenha();
                            if (auxiliarSenha == true)
                            {
                                CalcularSaque2(valorSaque);
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else if (opcaoSaque == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção de saque inválida!");
                        Console.ResetColor();
                        Console.WriteLine("");
                        return;
                    }
                }
                else if (valorSaque > 1000 && DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                {
                    Console.WriteLine("Operação não permitida! Aos sábados o valor máximo para saque é de R$ 1.000,00");
                    return;
                }
                else if(valorSaque > 800 && DateTime.Today.DayOfWeek == DayOfWeek.Saturday)           
                {
                    Console.WriteLine("Operação não permitida! Aos sábados o valor máximo para saque é de R$ 800,00");
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valor inválido para saque!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    return;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Saldo disponível: R$ 0,00");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saldo indisponível!");
                Console.ResetColor();
                Console.WriteLine("");
                MostrarNotas();
            }
        }

        static void CalcularSaque2(int valorSaque)
        {
            int valorAuxiliarSaque;
            valorAuxiliarSaque = valorSaque;
            do
            {
                if (quantidadeNotasDuzentosReais > 0 && valorAuxiliarSaque % 200 == 0 && DateTime.Today.DayOfWeek != DayOfWeek.Wednesday)
                { 
                    valorAuxiliarSaque = valorAuxiliarSaque - 200;
                    quantidadeNotasDuzentosReais--;
                }
                else if (quantidadeNotasCemReais > 0 && valorAuxiliarSaque % 100 == 0)
                {
                    valorAuxiliarSaque = valorAuxiliarSaque - 100;
                    quantidadeNotasCemReais--;
                }
                else if (quantidadeNotasCinquentaReais > 0 && valorAuxiliarSaque % 50 == 0)
                {
                    valorAuxiliarSaque = valorAuxiliarSaque - 50;
                    quantidadeNotasCinquentaReais--;
                }
                else if (quantidadeNotasVinteReais > 0 && valorAuxiliarSaque % 20 == 0)
                {
                    valorAuxiliarSaque = valorAuxiliarSaque - 20;
                    quantidadeNotasVinteReais--;
                }
                else if (quantidadeNotasDezReais > 0 && valorAuxiliarSaque % 10 == 0)
                {
                    valorAuxiliarSaque = valorAuxiliarSaque - 10;
                    quantidadeNotasDezReais--;
                }
                else if (quantidadeNotasCincoReais > 0 && valorAuxiliarSaque % 5 == 0)
                { 
                    valorAuxiliarSaque = valorAuxiliarSaque - 5;
                    quantidadeNotasCincoReais--;
                }
                else if (quantidadeNotasDoisReais > 0 && valorAuxiliarSaque % 2 == 0)
                {
                    valorAuxiliarSaque = valorAuxiliarSaque - 2;
                    quantidadeNotasDoisReais--;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Não foi possível montar o valor solicitado!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    MostrarNotas();
                    return;
                }
            } while (valorAuxiliarSaque > 0);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saque realizado com sucesso!");
            Console.ResetColor();

            saldo -= valorSaque;

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Saldo disponível: {saldo}");
            Console.ResetColor();
            MostrarNotas();
        }

        static void CalcularSaque1(int valorSaque)
        {
            bool continuar = true;
            int totalSacar = 0;
            while (continuar == true && DateTime.Today.DayOfWeek != DayOfWeek.Wednesday)
            {
                continuar = true;
                Console.WriteLine("Digite a quantidade de notas de 200 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasDuzentosReaisSacar))
                {
                    if (quantidadeNotasDuzentosReaisSacar <= quantidadeNotasDuzentosReais || quantidadeNotasDuzentosReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasDuzentosReaisSacar * 200;
                        quantidadeNotasDuzentosReais -= quantidadeNotasDuzentosReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } 
            do
            {
                continuar = true;
                Console.WriteLine("Digite a quantidade de notas de 100 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasCemReaisSacar))
                {
                    if (quantidadeNotasCemReaisSacar <= quantidadeNotasCemReais || quantidadeNotasCemReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasCemReaisSacar * 100;
                        quantidadeNotasCemReais -= quantidadeNotasCemReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } while (continuar);
            do
            {
                continuar = true;
                Console.WriteLine("Digite a quantidade de notas de 50 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasCinquentaReaisSacar))
                {
                    if (quantidadeNotasCinquentaReaisSacar <= quantidadeNotasCinquentaReais || quantidadeNotasCinquentaReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasCinquentaReaisSacar * 50;
                        quantidadeNotasCinquentaReais -= quantidadeNotasCinquentaReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } while (continuar);
            do
            {
                continuar = true;
                Console.WriteLine("Digite a quantidade de notas de 20 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasVinteReaisSacar))
                {
                    if (quantidadeNotasVinteReaisSacar <= quantidadeNotasVinteReais || quantidadeNotasVinteReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasVinteReaisSacar * 20;
                        quantidadeNotasVinteReais -= quantidadeNotasVinteReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } while (continuar);
            do
            {
                continuar = true;
                Console.WriteLine("Digite a quantidade de notas de 10 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasDezReaisSacar))
                {
                    if (quantidadeNotasDezReaisSacar <= quantidadeNotasDezReais || quantidadeNotasDezReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasDezReaisSacar * 10;
                        quantidadeNotasDezReais -= quantidadeNotasDezReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } while (continuar);

            continuar = true;
            do
            {
                Console.WriteLine("Digite a quantidade de notas de 5 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasCincoReaisSacar))
                {
                    if (quantidadeNotasCincoReaisSacar <= quantidadeNotasCincoReais || quantidadeNotasCincoReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasCincoReaisSacar * 5;
                        quantidadeNotasCincoReais -= quantidadeNotasCincoReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } while (continuar);
            do
            {
                continuar = true;
                Console.WriteLine("Digite a quantidade de notas de 2 reais:");
                if (int.TryParse(Console.ReadLine(), out int quantidadeNotasDoisReaisSacar))
                {
                    if (quantidadeNotasDoisReaisSacar <= quantidadeNotasDoisReais || quantidadeNotasDoisReaisSacar == 0)
                    {
                        totalSacar += quantidadeNotasDoisReaisSacar * 2;
                        quantidadeNotasDoisReais -= quantidadeNotasDoisReaisSacar;
                        continuar = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Quantidade de notas é superior a quantidade disponível!");
                        Console.ResetColor();
                        MostrarNotas();
                        Console.WriteLine("");
                        return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade inválida! Tente novamente!");
                    Console.ResetColor();
                    Console.WriteLine("");

                }
            } while (continuar);

            bool auxiliarSenha = VerificarSenha();
            
            if (auxiliarSenha == false)
            {
                Console.WriteLine("As tentativas de digitação de senhas foram esgotadas. O Saque não poderá ser realizado!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saque realizado com sucesso!");
            Console.ResetColor();

            saldo -= totalSacar;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Saldo disponível: {saldo}");
            Console.ResetColor();
            MostrarNotas();
        }


        static Boolean VerificarSenha()
        {
            int tentativas = 4;
            bool auxiliarSenha;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                tentativas = 3;
            }
            do
            {
                Console.WriteLine("Digite sua senha:");
                if (int.TryParse(Console.ReadLine(), out int senha) && senha > 10000 && senha < 10060)
                {
                    auxiliarSenha = true;
                    return auxiliarSenha;
                }
                else
                {
                    tentativas--;
                    if (tentativas == 0)
                    {
                        Console.WriteLine("As tentativas de digitação de senhas foram esgotadas. O Saque não poderá ser realizado!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Senha inválida! Você ainda tem: {tentativas} tentativa(s).");
                        Console.ResetColor();
                    }
                }
            } while (tentativas > 0);

            auxiliarSenha = false;
            return auxiliarSenha;
        }

        static void CalcularSaldo()
        {
            saldo = (quantidadeNotasDoisReais * 2) + (quantidadeNotasCincoReais * 5) + (quantidadeNotasDezReais * 10) + (quantidadeNotasVinteReais * 20) + (quantidadeNotasCinquentaReais * 50) + (quantidadeNotasCemReais * 100) + (quantidadeNotasDuzentosReais * 200);
        }

        static void Depositar()
        {
            bool continuar = false;
            do
            {
                Console.WriteLine("Digite uma nota para depositar ou 0 para voltar ao menu anterior.");
                string notaDigitada = Console.ReadLine();

                if (notaDigitada == "2")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasDoisReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasDoisReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }     
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "5")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasCincoReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasCincoReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "10")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasDezReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasDezReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "20")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasVinteReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasVinteReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "50")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasCinquentaReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasCinquentaReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "100")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasCemReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasCemReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "200")
                {
                    bool continuarNota = false;
                    do
                    {
                        Console.WriteLine($"Digite uma quantidade para a nota de {notaDigitada} reais ou 0 para voltar ao menu anterior");
                        if (int.TryParse(Console.ReadLine(), out int respostaNumerica) && respostaNumerica <= 1000000000 && respostaNumerica != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"A quantidade da nota de {notaDigitada} reais foi atualizada para:");
                            Console.ResetColor();
                            quantidadeNotasDuzentosReais += respostaNumerica;
                            Console.WriteLine(quantidadeNotasDuzentosReais);
                            Console.WriteLine("");
                            continuarNota = false;
                        }
                        else if (respostaNumerica == 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Quantidade inválida! Tente novamente.");
                            continuarNota = true;
                        }
                    } while (continuarNota == true);
                    continuar = false;
                }
                else if (notaDigitada == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Valor inválido!Tente novamente.");
                    continuar = true;
                }
            } while (continuar == true);
        }
        static void MostrarNotas()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("");
            Console.WriteLine($"Quandidade disponível de notas de R$ 200: {quantidadeNotasDuzentosReais}");
            Console.WriteLine($"Quandidade disponível de notas de R$ 100: {quantidadeNotasCemReais}");
            Console.WriteLine($"Quandidade disponível de notas de R$ 50: {quantidadeNotasCinquentaReais}");
            Console.WriteLine($"Quandidade disponível de notas de R$ 20: {quantidadeNotasVinteReais}");
            Console.WriteLine($"Quandidade disponível de notas de R$ 10: {quantidadeNotasDezReais}");
            Console.WriteLine($"Quandidade disponível de notas de R$ 5: {quantidadeNotasCincoReais}");
            Console.WriteLine($"Quandidade disponível de notas de R$ 2: {quantidadeNotasDoisReais}");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
}

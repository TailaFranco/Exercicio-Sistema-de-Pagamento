using System;
using  Aula_09._12._2020___Abstracao.Classes;
namespace Aula_09._12._2020___Abstracao
{
    class Program
    {
        static void Main(string[] args)
        {   int cartao = 0;
            Console.Clear();
               Console.WriteLine("Data:"+DateTime.Now.ToShortDateString());
            
            Boleto boleto = new Boleto();
            Credito credito = new Credito();
            Debito debito = new Debito();
            boleto.DataDeVencimento = 20;
            int menuPrincipal =0;
            do
            {   Console.ForegroundColor = ConsoleColor.Yellow;
               Console.WriteLine("Bem Vindo ao Sistema de Pagamentos C-Nai"); 
               Console.WriteLine("Por favor, selecione a forma de pagamento a ser realizada"); 
               Console.WriteLine("[1] Pagamento em boleto");
               Console.WriteLine("[2] Pagamento com Cartão");
               Console.WriteLine("[0] Sair");
               Console.ResetColor();
               menuPrincipal = int.Parse(Console.ReadLine());

               switch (menuPrincipal)
               {
                   case 1:
                   Console.WriteLine("Digite o código de barras do boleto");
                   boleto.CodigoDeBarras = Console.ReadLine();
                   Console.WriteLine("Digite o valor do boleto");
                   boleto.Valor = float.Parse(Console.ReadLine());
                   Console.WriteLine("Digite o Dia de Vencimento");
                   boleto.DataDeVencimento = int.Parse(Console.ReadLine()); 
                   Console.WriteLine("Digite o dia de Pagamento");
                   boleto.DataDePagamento = int.Parse(Console.ReadLine());
                   if(boleto.Desconto(boleto.Valor))
                   {
                       boleto.Valor = boleto.Valor*0.88f;
                       Console.WriteLine("Pagando antes da data desconto de 12%");
                       Console.WriteLine($"Boleto pago no valor de {boleto.Valor}");

                   }
                   else{
                       boleto.Valor = boleto.Valor*1.01f;
                       Console.WriteLine("Pagando após a data juros de 1%");
                       Console.WriteLine($"Boleto pago no valor de {boleto.Valor}");
                   }
                    break;
                    case 2:
                    if (cartao == 0)
                    {Console.WriteLine("Você ainda não possue cartões cadastrados, deseja cadastrar novo cartão? \n Responda apenas com sim ou não");
                     string cartao1 = Console.ReadLine();
                     if (cartao1 == "sim")
                     { int escolher = 0;
                        do
                        {   Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("[1] Novo Cartão de Débito");
                            Console.WriteLine("[2] Novo Cartão de Crédito");
                            Console.WriteLine("[3] Pagar com cartão de Débito");
                            Console.WriteLine("[4] Pagar com cartão de Crédito");
                            Console.WriteLine("[0] Sair");
                            Console.ResetColor();
                            escolher = int.Parse(Console.ReadLine());
                            switch (escolher)
                            {
                                case 1:
                                Console.WriteLine("Digite a bandeira do cartão");
                                debito.bandeira = Console.ReadLine();
                                Console.WriteLine("Digite o número do cartão");
                                debito.numero = Console.ReadLine();
                                Console.WriteLine("Digite o nome do Titular do Cartão");
                                debito.titular = Console.ReadLine();
                                Console.WriteLine("Digite o código de segurança do cartão \n Número que fica na parte de trás do cartão de 3 dígitos");
                                debito.cvv = Console.ReadLine();
                                Console.WriteLine("Você gostaria de salvar este cartão para compras futuras?");
                                string resposta = Console.ReadLine();
                                debito.SalvarCartao(resposta);
                                break;
                                case 2:
                                Console.WriteLine("Digite a bandeira do cartão");
                                credito.bandeira = Console.ReadLine();
                                Console.WriteLine("Digite o número do cartão");
                                credito.numero = Console.ReadLine();
                                Console.WriteLine("Digite o nome do Titular do Cartão");
                                credito.titular = Console.ReadLine();
                                Console.WriteLine("Digite o código de segurança do cartão \n Número que fica na parte de trás do cartão de 3 dígitos");
                                credito.cvv = Console.ReadLine();
                                Console.WriteLine("Você gostaria de salvar este cartão para compras futuras?");
                                string resposta1 = Console.ReadLine();
                                credito.SalvarCartao(resposta1);
                                break;
                                case 3:
                                Console.WriteLine("Favor confirmar se os dados do cartão estão corretos");
                                Console.WriteLine($"Bandeira {debito.bandeira} \nNúmero:{debito.numero} \nTitular:{debito.titular} cvv: {debito.cvv}");
                                Console.WriteLine("Para confirmar digite sim");
                                string resposta2 = Console.ReadLine();
                                if (resposta2 == "sim")
                                {
                                    Console.WriteLine("Digite o valor da compra");
                                    debito.Valor = float.Parse(Console.ReadLine());
                                    
                                    if (debito.Pagar(debito.Valor))
                                    {
                                    debito.Saldo = debito.Saldo - debito.Valor;
                                    Console.WriteLine("Pagamento realizado com sucesso");
                                    Console.WriteLine($"O seu saldo disponível restante é de {debito.Saldo}");
                                    }
                                    else{
                                        Console.WriteLine("Pagamento não realizado, saldo não disponível");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Por favor, revise os dados do cartão...");
                                }
                                break;
                                case 4:
                                Console.WriteLine("Favor confirmar se os dados do cartão estão corretos");
                                Console.WriteLine($"Bandeira {credito.bandeira} \nNúmero:{credito.numero} \nTitular:{credito.titular} cvv: {credito.cvv}");
                                Console.WriteLine("Para confirmar digite sim");
                                string resposta3 = Console.ReadLine();
                                if (resposta3 == "sim")
                                {
                                    Console.WriteLine("Digite o valor da compra");
                                    credito.Valor = float.Parse(Console.ReadLine());
                                    
                                    if (credito.Pagar(credito.Valor))
                                    {
                                    Console.WriteLine("Deseja parcelar? Responda apenas com sim ou não");
                                    string resposta4 = Console.ReadLine();
                                    if(resposta4 == "sim")
                                    {   Console.WriteLine("Até 6 parcelas juros de 5%, de 6 a 12 parcelas o juros é de 8%");
                                        Console.WriteLine("Em quantas parcelas? Min: 2 Max: 12");
                                        credito.parcelar = int.Parse(Console.ReadLine());
                                        credito.Parcelamento(credito.Valor, credito.parcelar);
                                        if(credito.Parcelamento(credito.Valor, credito.parcelar))
                                        {
                                            if(credito.parcelar >1 && credito.parcelar <=6)
                                            {
                                                credito.Valor = credito.Valor *1.05f;
                                            }
                                            else if (credito.parcelar >6 && credito.parcelar <=12)
                                            {
                                                 credito.Valor= credito.Valor * 1.08f;
                                            }
                                                else
                                                {
                                                     Console.WriteLine("Valor selecionado para parcelamento, INDISPONÍVEL");
                                                }
                                        }
                                        credito.Limite = credito.Limite - credito.Valor;
                                    Console.WriteLine($"Compra no valor total com juros de {credito.Valor}, dividido em {credito.parcelar} parcelas, de {credito.Valor/credito.parcelar}");
                                    Console.WriteLine("Pagamento realizado com sucesso");
                                    Console.WriteLine($"O seu limite disponível restante é de {credito.Limite}");
                                    }
                                    else{
                                    Console.WriteLine("Pagamento no crédito a vista");
                                    credito.Limite = credito.Limite - credito.Valor;
                                    Console.WriteLine("Pagamento realizado com sucesso");
                                    Console.WriteLine($"O seu saldo disponível restante é de {credito.Limite}");}
                                    }
                                    else{
                                        Console.WriteLine("Pagamento não realizado, limite não disponível");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Por favor, revise os dados do cartão...");
                                }
                                break;
                                case 0:
                                break;
                                default:
                                break;
                            }
                        } while (escolher != 0);
                         
                     }
                    }
                    break;
                    case 0:
                    credito.Cancelar(menuPrincipal);
                    break;
                   default:
                       break;
               }
               
            } while (menuPrincipal != 0);
            
        
        }
    }
}

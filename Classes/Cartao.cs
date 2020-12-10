namespace Aula_09._12._2020___Abstracao.Classes
{
    public class Cartao : Pagamento
    {
       public string bandeira;
       public string numero;
       public string titular;
       public string cvv;

       public string SalvarCartao(string resposta)
       {
           if(resposta == "sim")
           {
             return "Cartão Salvo com sucesso";
           }
           else
           {
               return "Este cartão não será salvo para pagamentos futuros.";
           }
       }


    }
}
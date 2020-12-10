namespace Aula_09._12._2020___Abstracao.Classes
{
    public abstract class Pagamento
    {
        // Atributos
        private string data = "10/12/2020";
        
        public string Data
        {
            get{return data;}
        }

        // Métodos

        public string Cancelar(int opcao)
        {
            return "Pagamento Cancelado, fim da operação";
        }
    }
}
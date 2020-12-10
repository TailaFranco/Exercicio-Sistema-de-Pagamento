namespace Aula_09._12._2020___Abstracao.Classes
{
    public class Boleto : Pagamento
    
    {
        private string codigodeBarras;
        public string CodigoDeBarras
        {
            get{return codigodeBarras;}
            set{codigodeBarras = value;}
        }
        private int datadeVencimento;
        public int DataDeVencimento
        {
            get{return datadeVencimento;}
            set{datadeVencimento=value;}
        }
        private int datadePagamento;
        public int DataDePagamento
        {
            get{return datadePagamento;}
            set{datadePagamento=value;}
        }
        public string Registrar()
        {
            return "Registrado";
        }
        public bool Desconto(float valor)
        {
            if (datadePagamento < datadeVencimento)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
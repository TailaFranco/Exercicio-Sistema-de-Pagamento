namespace Aula_09._12._2020___Abstracao.Classes
{
    public class Debito : Cartao
    {
        private float saldo = 600;
        public float Saldo
        {
            get{return saldo;}
            set{saldo = value;}
        }
        public bool Pagar(float valor)
        {
            if (valor <= Saldo)
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
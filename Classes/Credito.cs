namespace Aula_09._12._2020___Abstracao.Classes
{
    public class Credito : Cartao
    {
        private float limite = 3000;

        public float Limite
        {
            get{return limite;}
            set {limite = value;}
        }
        
        public bool Pagar(float valor)
        {
            if (valor <= limite)
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }
        public int parcelar;
        public bool Parcelamento(float valor, int parcelar)
        {
            return true;
        }
    }

}
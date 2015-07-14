namespace AMail.Dominio
{
    public class Categoria
    {
        public string Descricao { get; private set; }

        public Categoria(string descricao)
        {
            Descricao = descricao;
        }
    }
}
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public double Quantidade { get; set; } = 0;

        public double Preco { get; set; } = 0;
    }




    }

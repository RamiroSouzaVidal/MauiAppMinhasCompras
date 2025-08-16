using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SqLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
          public SqLiteDataBaseHelper(string path) 
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }


        public Task<int> Insert(Produto p) 
        {
            return _conn.InsertAsync(p);
        }
        
        public Task<List<Produto >>Update(Produto p) 
        {
            string sql = " UPDATE produto SET Descricao=?,Quantidade =? , Preço=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade , p.Preco , p.Id
                );
        }

        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }



        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE ?";
            return _conn.QueryAsync<Produto>(sql, "%" + q + "%");
        }

    }
}

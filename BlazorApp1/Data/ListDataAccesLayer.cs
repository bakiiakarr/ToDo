using BlazorApp1.Shared.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


public class ListDataAccesLayer : DbContext
{
    public IConfiguration Configuration;
    private const string BAKAR_DATABASE = "DefaultConnection";
    private const string SELECT_LIST = "select * from list";

    private const string SELECT_TODO = "select * from toDo";
    private const string _connectionString = "Server=BAKAR;Database=toDoList;User Id=sa;Password= Muba2808.;TrustServerCertificate=True";

    public ListDataAccesLayer()
    {
        //donothing
        var sat = string.Empty;
    }
    public ListDataAccesLayer(IConfiguration configuration)
    {
        Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }

    public void Test()
    { 
    
    }

    public async Task<List<list>> GetListAsync()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            db.Open();
            IEnumerable<list> result = await db.QueryAsync<list>(SELECT_LIST);
            return result.ToList(); 
        }

        //IDbConnection dbconnect = new SqlConnection(Configuration.GetConnectionString(BAKAR_DATABASE));
        //dbconnect.Open();
        //IEnumerable<toDoList> conn = await dbconnect.QueryAsync<toDoList>(SELECT_LIST);
        //return conn.ToList();
    }
    public async Task<List<toDoList>> GetToDoListAsync()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            db.Open();
            IEnumerable<toDoList> result = await db.QueryAsync<toDoList>(SELECT_TODO);
            return result.ToList();
        }

        //IDbConnection dbconnect = new SqlConnection(Configuration.GetConnectionString(BAKAR_DATABASE));
        //dbconnect.Open();
        //IEnumerable<toDoList> conn = await dbconnect.QueryAsync<toDoList>(SELECT_LIST);
        //return conn.ToList();
    }

    public async Task<int> GetListCountAsync()
    {
        using (IDbConnection db = new SqlConnection())
        {
            db.Open();
            int result = await db.ExecuteScalarAsync<int>("select count(*) from lists");
            return result;
        }
    }

    public async Task AddListAsync(toDoList list)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {

            db.Open();
            string a = "insert into toDo ( text, ısEnabled, listId) values ( '" + list.text + "', 0, "+list.listId+")";
            await db.ExecuteAsync(a);

        }
    }

    public async Task UpdateListAsync(toDoList list)
    {
        using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(BAKAR_DATABASE)))
        {
            db.Open();
            await db.ExecuteAsync("update lists set Id=@Id, Text=@Text, ListId=@ListId, where id=@Id", list);
        }
    }

    public async Task RemoveToDoAsync(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            db.Open();
            await db.ExecuteAsync("delete from toDo Where ıd="+id+"");
        }
    }
}
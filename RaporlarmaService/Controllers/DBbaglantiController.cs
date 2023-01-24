using Newtonsoft.Json;
using RaporlarmaService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace RaporlarmaService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DBbaglantiController : ApiController
    {
        // GET:  api/DBbaglanti
        public string Get()     // databasedeki hazır rapor kayıtlarını dondurcek
        {

            return "deneme";
        }
        SqlConnection connection = new SqlConnection();
        // POST api/DBbaglanti
      

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string POST([FromBody] string data, string islem)     
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    DataTable tableNames = connection.GetSchema("Tables");
            //    foreach (DataRow row in tableNames.Rows)
            //    {
            //        string tableName = row["Table_Name"].ToString();
            //        Console.WriteLine(tableName);
            //    }
            //}
        //    connection.ConnectionString = connectionString;

            try
            {
                if (islem == "1") // baglantıyı kontrol et
                {
                    connection.ConnectionString = data;
                    connection.Open();
                    return "Baglanti Kuruldu";
                }
                else if (islem == "2")//gelen sql kodunu calistir geri json dondur
                {                 
                    var gelen = (dynamic)JsonConvert.DeserializeObject(data);
                    connection.ConnectionString = gelen.baglanti.ToString();
                    SqlCommand cmd = new SqlCommand(gelen.sqlkod.ToString(),connection);
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    var json=JsonConvert.SerializeObject(table);
                    return json;
                }
                else if (islem=="3") //Gelen Sorgu ve Sorgu ismini Raporlar tablosuna kaydedir
                {
                    var gelen = (dynamic)JsonConvert.DeserializeObject(data);
                    SqlConnection con = new SqlConnection("Server=MuratBayir;Database=Raporlar;User Id=sa;Password=Murat2000;");
                    con.Open();
                    
                    return "Sorgu Kyadedildi";
                }
                else
                {
                    return "işleminiz gerçekleştirilemedi";
                }
              
            }
            catch (Exception)
            {
                return "HATA bağlantı kurmaya çalıştığınız DB Serverda Mevcut değil";

            }
            finally
            {
                connection.Close();
            }


        }
 
       
    }
}
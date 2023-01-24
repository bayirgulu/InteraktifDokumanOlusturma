using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Web.Http.Cors;
using System.Collections;


namespace RaporlarmaService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection("Server=MuratBayir;Database=Raporlar;User Id=sa;Password=Murat2000;");
      
        // GET api/values
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Get()     // databasedeki hazır rapor kayıtlarını dondurcek
        {
            try
            {
                List<Rapor> raporList = new List<Rapor>();
                DataTable table = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Rapor", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                raporList = (from DataRow dr in table.Rows
                             select new Rapor()
                             {
                                 name = dr["name"].ToString(),
                                 pagewidth = dr["pagewidht"].ToString(),
                                 pageheight = dr["pageheight"].ToString(),
                                 html = dr["html"].ToString()
                             }).ToList();


                var json = JsonConvert.SerializeObject(raporList);
                con.Close();
                return json;
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
          
        }

        // GET api/values/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Get(int id)  
        {
          
           
            return "value";
        }

        // POST api/values
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post([FromBody] string value)    // gelen raporun databaseden olup olmadığını kontrol edip yoksa ekleme olcak
        {
            try
            {
                Rapor gelenrapor = JsonConvert.DeserializeObject<Rapor>(value);


                DataTable table = new DataTable();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Rapor", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                bool mevcutmu = false;
                foreach (DataRow dr in table.Rows)
                {
                    if (dr["name"].ToString() == gelenrapor.name) // databasede gonderilen isimde kayıt var
                    {
                        mevcutmu = true;
                        break;
                    }
                }
                if (mevcutmu) // guncelle
                {
                    SqlCommand guncelle = new SqlCommand("update Rapor set pagewidht=@p1,pageheight=@p2,html=@p3 where name = @p4", con);
                    guncelle.Parameters.AddWithValue("@p1", gelenrapor.pagewidth);
                    guncelle.Parameters.AddWithValue("@p2", gelenrapor.pageheight);
                    guncelle.Parameters.AddWithValue("@p3", gelenrapor.html);
                    guncelle.Parameters.AddWithValue("@p4", gelenrapor.name);
                    guncelle.ExecuteNonQuery();
                    con.Close();
                    return gelenrapor.name + " ismindeki mevcut rapor güncellendi";
                }
                else  // ekle
                {
                    SqlCommand ekle = new SqlCommand("insert into Rapor(name,pagewidht,pageheight,html) VALUES(@p1,@p2,@p3,@p4)", con);
                    ekle.Parameters.AddWithValue("@p1", gelenrapor.name);
                    ekle.Parameters.AddWithValue("@p2", gelenrapor.pagewidth);
                    ekle.Parameters.AddWithValue("@p3", gelenrapor.pageheight);
                    ekle.Parameters.AddWithValue("@p4", gelenrapor.html);
                    ekle.ExecuteNonQuery();
                    con.Close();
                    return gelenrapor.name + " rapor kaydınız sisteme yüklenmistir";
                }
            }
            catch (Exception ex)
            {
                
                return ex.ToString();
            }
        
        }
          
            

        // PUT api/values/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Put(string name, [FromBody] string HtmlData)   
        {
            DataTable table = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Rapor", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            bool mevcutmu = false;
            foreach (DataRow dr in table.Rows)
            {
                //    if (dr["name"].ToString()==name) // databasede gonderilen isimde kayıt var
                //    {
                //        mevcutmu = true;
                //        break;
                //    }
                //}
                //if (mevcutmu)
                //{
                //    return name + " ismindeki mevcut rapor güncellendi";
                //}
                //else
                //{
                //    return name + " rapor kaydınız sisteme yüklenmistir";
                //}          
        }
            return "puta girdi";
        }

        // DELETE api/values/5
        public string Delete(string name)
        {
            try
            {
                con.Open();
                SqlCommand silinecek = new SqlCommand("delete from Rapor where name = @p1", con);
                silinecek.Parameters.AddWithValue("@p1",name);
                silinecek.ExecuteNonQuery();
                return name + " adli Rapor kaydı silinmiştir";
            }
            catch (Exception ex)
            {
                return ex.ToString();
               
            }
           
           

        }
    }
}

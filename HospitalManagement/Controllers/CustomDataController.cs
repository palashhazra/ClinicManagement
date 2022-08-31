using HospitalManagement.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace HospitalManagement.Controllers
{
    public class CustomDataController : Controller
    {
        string ConfigString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private ApplicationDbContext _context;
        public CustomDataController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CustomData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData(string TableName)
        {
            var data = "";
            if (!string.IsNullOrWhiteSpace(TableName))
            {
                data= GetTabledata(TableName.Trim());
                ViewData["Result"] = data;
            }
            //var result = _context.Database.SqlQuery<dynamic>("SELECT * FROM "+TableName).ToList();
            
            //Response.Redirect(data);
            return View("Index");           
        }

        public ActionResult RemoveData(string table,string ID)
        {
            string qryStr = Convert.ToString(Request.Url.ToString().Split('?')[1]);
            string strId = Convert.ToString(qryStr.Split('&')[1]);
            string paramId=(strId.Split('=')[0]).ToString();
            string strquery = @"DELETE from " + table + " where " + paramId + "='" + ID+"'";
            int status=RemoveEntry(strquery);
            return View("Index");
        }

        public string GetTabledata(string table)
        {            
            string strQuery = "select * from  "+table;
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;

                    cmd.Connection = con;
                    //con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    con.Close();
                }
            }
            DataTable dt = ds.Tables[0];
            StringBuilder sb = new StringBuilder();
            sb = sb.Clear();

            var csvColumnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            //ViewBag.CSVResult = csvColumnNames;
            string columnName = Convert.ToString(csvColumnNames[0]);
            if (dt.Rows.Count == 0)
            {
                sb.Append("<font color=\"Red\">No table exists!</font>");
            }
            else
            {
                sb.Append("<table class='table table-bordered' style='border:3px black'><thead><tr>");               
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append("<td>" + csvColumnNames[i].ToString() + "</td>");                    
                }
                sb.Append("<td>Action</td></tr></thead>");
            }

            if (dt.Rows.Count > 0)
            {                
                    sb.Append("<tbody>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            sb.Append("<td>" + dt.Rows[i][j].ToString() + "</td>");                        
                        }
                    string link = "/CustomData/RemoveData?table=" + table + "&" + columnName + "=" + dt.Rows[i][0].ToString() + "";
                    sb.Append("<td><a href="+link+" class=\"'btn btn-primary'\">Delete</a></td>");
                    sb.Append("</tr>");
                    }
                    sb.Append("</tbody></table>");                
            }
            else
            {
                sb.Append("<tbody><tr>No data present in the required table.</tr></tbody></table>");
            }
            return sb.ToString();
        }

        public int RemoveEntry(string query)
        {
            int i = 0;
            using(SqlConnection con=new SqlConnection(ConfigString))
            {
                SqlCommand cmd = new SqlCommand(query,con);
                con.Open();
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(" Not Deleted as" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return i;
        }
    }
}
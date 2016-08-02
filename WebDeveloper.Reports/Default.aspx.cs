using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDeveloper.Reports
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var name = Page.RouteData.Values["name"].ToString();

                var reportParameter = new ReportParameter("reportName", name);
                
                rptViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                rptViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/StateProvinceCountryRegion.rdlc");

                var dataset = GetData();
                var reportDataSource = new ReportDataSource("AdventureWorksDataSet", dataset.Tables[0]);
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.SetParameters(reportParameter);
                rptViewer.LocalReport.DataSources.Add(reportDataSource);
            }
        }

        private AdventureWorks2014DataSet GetData()
        {
            var query = "select * from Person.vStateProvinceCountryRegion";
            var connectionString = ConfigurationManager
                                   .ConnectionStrings["WebDeveloperConnectionString"]
                                   .ConnectionString;

            var command = new SqlCommand(query);
            using (var connection = new SqlConnection(connectionString))
            {
                command.Connection = connection;

                using (var adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = command;

                    using (var dataset = new AdventureWorks2014DataSet())
                    {
                        adapter.Fill(dataset, "AdventureWorksDataser");
                        return dataset;

                    }

                }


            }

        }

    }
}
using Agresso.Interface.CommonExtension;
using Agresso.ServerExtension;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsqlHelp
{
    [ServerProgram("ACT_SQL")]
    public class Class1 : IServerProgram
    {
        private IReport m_Report;

        /// <summary>
        /// Constructor
        /// </summary>
        public Class1()
        {
            // Avoid using Agresso objects here.
        }
        #region IServerProgram Members
        public void End()
        {
            ServerAPI.Current.WriteLog("end");
            // Place End code here
        }
        public void Initialize(IReport report)
        {
            ServerAPI.Current.WriteLog("Starta rapport för UsqlHelp");
            // Save reference to IReport object
            m_Report = report;
            // Needs the ACT.SE.Common subsystem
        }
        public void Run()
        {
            try
            {
                // TODO: Do the coding
                IServerDbAPI api = ServerAPI.Current.DatabaseAPI;
                string tbl_temp = api.GetNextTempTableName();
                ServerAPI.Current.WriteLog("TEMPTABELL");
                RunSQL("DATABASE " + string.Format("select client, client_name, CONVERT(VARCHAR(255),client_name + ' - ********** litet tillagg *********') AS 'extra kolumn' " +
                " into " + tbl_temp +
                " from acrclient"));

                IStatement sql = CurrentContext.Database.CreateStatement();
                sql.Assign("SELECT * FROM " + tbl_temp);

                DataTable dt = new DataTable();
                dt.Clear();
                CurrentContext.Database.Read(sql, dt);

                string client = "";
                string clientName = "";
                string extra_kolumn = "";
                var csv = new StringBuilder();
                string filePath = @"C:\test\testcsv1.csv";
                foreach (DataRow row in dt.Rows)
                {
                    client = row["client"].ToString();
                    clientName = row["client_name"].ToString();
                    extra_kolumn = row["extra kolumn"].ToString();
                    var newLine = $"{client};{clientName}; {extra_kolumn}";
                    csv.AppendLine(newLine);
                }
                File.WriteAllText(filePath, csv.ToString());
            }
            catch (Exception ex)
            {
                m_Report.StopReport(ex.Message);
            }
        }
        #endregion

        private void RunSQL(string sql)
        {
            IStatement statement = CurrentContext.Database.CreateStatement();
            statement.UseAgrParser = false;
            statement.CommandText = sql;
            CurrentContext.Database.Execute(statement);
        }

    }
}
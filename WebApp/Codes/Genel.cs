using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Text.Json;

namespace WebApp1.Codes
{
    #region MyApp

    public class MyApp
    {
        public static IWebHostEnvironment? Env { get; set; } = null;

        #region app Version
        public static string Version
        {
            get
            {
                string Version = "1.0.0.0";
                if (Env?.EnvironmentName == "Development")
                {
                    Version += "_";
                    Version += DateTime.Now.ToString("MMddHHmmss");
                }
                return Version;
            }
        }
        #endregion

        #region DB Compare
        public static System.Text.StringBuilder CompareDatabase(string sourceConStr, string targetConStr)
        {
            var logs = new System.Text.StringBuilder();

            var kaynakSchema = new DatabaseSchemaReader.DatabaseReader(new SqlConnection(sourceConStr)).ReadAll();
            var hedefSchema = new DatabaseSchemaReader.DatabaseReader(new SqlConnection(targetConStr)).ReadAll();

            var comparison = new DatabaseSchemaReader.Compare.CompareSchemas(hedefSchema, kaynakSchema);

            logs.Append(comparison.Execute());

            return logs;
        }
        #endregion
    }

    #endregion
}

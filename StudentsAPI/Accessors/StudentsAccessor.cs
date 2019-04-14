using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Npgsql;

//documentation:  https://www.npgsql.org/doc/index.html

namespace StudentsAPI.Accessors
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    internal class StudentsAccessor
    {
        private readonly RequestDelegate _next;

        //TODO BEN move this connection string to the appsettings.json
        //private string _conn = @"Data Source = myServerAddress;
        //location=myDataBase;User ID = myUsername; password=myPassword;timeout=1000;";


        private string _conn = "Server=localhost;Port=5432;Database=Training;User Id=postgres;Password=password;";
        internal StudentsAccessor(RequestDelegate next)
        {
            _next = next;
        }
        internal StudentsAccessor() { }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }

        internal List<Models.StudentModel> GetAllStudents()
        {
            DataTable tmpTable = new DataTable("students");

            List<Models.StudentModel> Students = new List<Models.StudentModel>();

            using (var conn = new NpgsqlConnection(_conn))
            {
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT id, firstname, lastname, age, school, major FROM students", conn);

                adapter.Fill(tmpTable);

            }

            //var temp = tmpTable.Rows.ForEach(row => Models.StudentModel(row)).ToList();


            foreach (DataRow row in tmpTable.Rows)
            {
                Students.Add(new Models.StudentModel(row));
            }


            return Students;

        }

        //NpgsqlDataAdapter npDataAdapterSingle = new NpgsqlDataAdapter("SELECT * from \"Weight\" ORDER BY id DESC LIMIT 1", this.npConnection);
        //DataTable tmpTable = new DataTable("tmpTable");
        //npDataAdapterSingle.Fill(tmpTable);

        //row = tmpTable.NewRow();

        //foreach (DataColumn col in tmpTable.Columns)
        //    row[col.ColumnName] = tmpTable.Rows[0][col.ColumnName];

        //tmpTable.Rows.Add(row, 0);



        // Extension method used to add the middleware to the HTTP request pipeline.
        //public static class StudentsAccessorExtensions
        //{
        //    public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        //    {
        //        return builder.UseMiddleware<StudentsAccessor>();
        //    }
        //}
    }
}

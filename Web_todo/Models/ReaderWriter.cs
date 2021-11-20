using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Web_todo.Database;

namespace Web_todo.Models
{
    public class ReaderWriter
    {
        public ReaderWriter()
        {
            this.items = new List<ToDoModel>();
        }


        //writer function
        public void Writer(ToDoModel model)
        {
            using (var db = DataAccess.DbAccess())
            {
               
                string insertQuery = @"INSERT INTO TODOTBL VALUES (@TODODATE, @TITLE, @ISCOMPLETED)";
                var result = db.Execute(insertQuery, model);

            }

        }
            public List<ToDoModel> Reader()
            {
                using (var db = DataAccess.DbAccess())
                {
                    this.items = db.Query<ToDoModel>("Select * from ToDoTbl").ToList();
                }
                return this.items;
            }

        //update function
            public void Update(int id, bool isDone)
            {
                string updateQuery = "UPDATE ToDoTbl SET IsCompleted = @isDone WHERE Id = @Id";
                using (var db = DataAccess.DbAccess())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@isDone", isDone, DbType.Byte);
                    parameters.Add("@Id", id, DbType.Int32);
                    db.Execute(updateQuery, parameters);
                }
            }

        //delete function
            public void Delete(int id)
            {
                var query = "DELETE FROM ToDoTbl WHERE Id = @Id";
                using (var db = DataAccess.DbAccess())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id, DbType.Int32);
                    db.Execute(query, parameters);
                }
            }

            public List<ToDoModel> items { get; set; }
        }
    }






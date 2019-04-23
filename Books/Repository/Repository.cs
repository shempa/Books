using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;

namespace Books.Repository
{
    public class Repository:IRepository  //класс Repository
    {
        string cs = ConfigurationManager.ConnectionStrings["BDConnection"].ConnectionString;

        public List<Models.Book> Get_Books()   //метод вывод списка книг
        {
            string sqlExpression = "Get_Books";
            using (SqlConnection connection = new SqlConnection(cs)) 
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    List<Models.Book> Books = new List<Models.Book>() { };
                    var reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Models.Book book = new Models.Book();
                            book.Id =Convert.ToInt32( reader["Id"]);
                            book.Title = reader["Title"].ToString();
                            book.Author = reader["Author"].ToString();
                            book.Genre = reader["Genre"].ToString();
                            book.Language = reader["Language"].ToString();
                            book.ToString();
                            Books.Add(book);
                        }
                    }
                    reader.Close();
                    return Books;
                }
            };
        }

        public void Add_Book(Models.Book book)   //метод добавления книги
        {           
            string sqlExpression = "Add_Book";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                       
                    SqlParameter TitleParam = new SqlParameter
                    {
                        ParameterName = "@Title",
                        Value = book.Title
                    };
                    command.Parameters.Add(TitleParam);
                    SqlParameter AuthorParam = new SqlParameter
                    {
                        ParameterName="@Author",
                        Value=book.Author
                    };
                    command.Parameters.Add(AuthorParam);
                    SqlParameter GenreParam = new SqlParameter
                    {
                        ParameterName="@Genre",
                        Value=book.Genre
                    };
                    command.Parameters.Add(GenreParam);
                    SqlParameter LanguageParam = new SqlParameter
                    {
                        ParameterName="@Language",
                        Value=book.Language
                    };
                    command.Parameters.Add(LanguageParam);
                    int number = command.ExecuteNonQuery();
                }
            }
        }

        public void Book_Removal(Models.Book book)  //метод удаления книги
        {
            string sqlExpression = "Book_Removal";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParam = new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = book.Id
                    };
                    command.Parameters.Add(IdParam);
                    int number = command.ExecuteNonQuery();
                }
            }
        }

        public void Edit_Book(Models.Book book)  //метод редактирования данных книги
        {
            string sqlExpression = "Edit_Book";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlExpression, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter IdParam = new SqlParameter
                    {
                        ParameterName = "@Id",
                        Value = book.Id
                    };
                    command.Parameters.Add(IdParam);
                    
                    SqlParameter TitleParam = new SqlParameter
                    {
                        ParameterName = "@Title",
                        Value = book.Title
                    };
                    command.Parameters.Add(TitleParam);
                    SqlParameter AuthorParam = new SqlParameter
                    {
                        ParameterName = "@Author",
                        Value = book.Author
                    };
                    command.Parameters.Add(AuthorParam);
                    SqlParameter GenreParam = new SqlParameter
                    {
                        ParameterName = "@Genre",
                        Value = book.Genre
                    };
                    command.Parameters.Add(GenreParam);
                    SqlParameter LanguageParam = new SqlParameter
                    {
                        ParameterName = "@Language",
                        Value = book.Language
                    };
                    command.Parameters.Add(LanguageParam);
                    int number = command.ExecuteNonQuery();                   
                }
            }
        }
    }
}
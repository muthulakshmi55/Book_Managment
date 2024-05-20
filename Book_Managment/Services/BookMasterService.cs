using Book_Managment.API.Models;
using Book_Managment.API.Providers.Infrastructure;
using Book_Managment.API.Services.Interface;
using Book_Managment.API.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Pipelines;
using static Book_Managment.API.Utilities.Constant;

namespace Book_Managment.API.Services
{
    public class BookMasterService : IBookMasterService
    {

        private readonly DatabaseContext _databaseContext;
        public static IConfiguration _configuration;

        public BookMasterService(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        public JsonResponse GetAllBookSortedList()
        {
            JsonResponse response = new();
            try
            {
                var BookDetails = _databaseContext.Book.AsNoTracking().Where(e => e.IsActive).Select(e => new Book()
                {
                    Id = e.Id,
                    Publisher = e.Publisher,
                    Title = e.Title,
                    AuthorLastName = e.AuthorLastName,
                    AuthorFirstName = e.AuthorFirstName,
                    Price = e.Price,
                    PublicationYear = e.PublicationYear,
                    PageNumbers = e.PageNumbers,
                    JournalTitle = e.JournalTitle,
                    IssueNo = e.IssueNo,
                    VolumeNo = e.VolumeNo,
                    UrlOrDoi = e.UrlOrDoi
                })
                .OrderBy(e => e.Publisher)
                .ThenBy(e => e.AuthorLastName)
                .ThenBy(e => e.AuthorFirstName)
                .ThenBy(e => e.Title)
                .ToList();
                response.Status = ResponseStatus.Success;
                response.Message = ResponseMessage.Success;
                response.Data = BookDetails;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = Constant.ResponseStatus.Success;
                response.Message = ex.Message;
                return response;
            }
        }

        public JsonResponse GetBookSortedByAuthorTitle()
        {
            JsonResponse response = new();
            try
            {
                var BookDetails = _databaseContext.Book.AsNoTracking().Where(e => e.IsActive).Select(e => new Book()
                {
                    Id = e.Id,
                    Publisher = e.Publisher,
                    Title = e.Title,
                    AuthorLastName = e.AuthorLastName,
                    AuthorFirstName = e.AuthorFirstName,
                    Price = e.Price,
                    PublicationYear = e.PublicationYear,
                    PageNumbers = e.PageNumbers,
                    JournalTitle = e.JournalTitle,
                    IssueNo = e.IssueNo,
                    VolumeNo = e.VolumeNo,
                    UrlOrDoi = e.UrlOrDoi
                })
                .OrderBy(e => e.AuthorLastName)
                .ThenBy(e => e.AuthorFirstName)
                .ThenBy(e => e.Title)
                .ToList();
                response.Status = ResponseStatus.Success;
                response.Message = ResponseMessage.Success;
                response.Data = BookDetails;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = Constant.ResponseStatus.Success;
                response.Message = ex.Message;
                return response;
            }
        }

        public JsonResponse GetAllBookSortedListUsingProc()
        {
            JsonResponse response = new();
            try
            {
                DataSet data = new ADODataFunction().ExecuteDataset(Constant.Procedure.GetAllBookSortedList, null);


                if (data != null && data.Tables.Count > 0)
                {
                    if (data.Tables[0].Rows.Count > 0 && data.Tables[0] != null)
                    {

                        response.Status = ResponseStatus.Success;
                        response.Message = ResponseMessage.Success;
                        response.Data = data.Tables[0].AsEnumerable().Select(a => new
                        {
                            Id = a.Field<long>("Id"),
                            Publisher = a.Field<string>("Publisher"),
                            Title = a.Field<string>("Title"),
                            AuthorLastName = a.Field<string>("AuthorLastName"),
                            AuthorFirstName = a.Field<string>("AuthorFirstName"),
                            Price = a.Field<decimal>("Price")
                        }).ToList();
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failed;
                        response.Message = ResponseMessage.Failed;

                    }
                }
                else
                {
                    response.Status = ResponseStatus.Failed;
                    response.Message = ResponseMessage.Failed;
                }
            }
            catch (Exception ex)
            {
                response.Status = Constant.ResponseStatus.Success;
                response.Message = ex.Message;
                return response;
            }

            return response;

        }

        public JsonResponse GetBookSortedByAuthorTitleUsingProc()
        {
            JsonResponse response = new();
            try
            {
                DataSet data = new ADODataFunction().ExecuteDataset(Constant.Procedure.GetBookSortedByAuthorTitle, null);


                if (data != null && data.Tables.Count > 0)
                {
                    if (data.Tables[0].Rows.Count > 0 && data.Tables[0] != null)
                    {

                        response.Status = ResponseStatus.Success;
                        response.Message = ResponseMessage.Success;
                        response.Data = data.Tables[0].AsEnumerable().Select(a => new
                        {
                            Id = a.Field<long>("Id"),
                            Publisher = a.Field<string>("Publisher"),
                            Title = a.Field<string>("Title"),
                            AuthorLastName = a.Field<string>("AuthorLastName"),
                            AuthorFirstName = a.Field<string>("AuthorFirstName"),
                            Price = a.Field<decimal>("Price")
                        }).ToList();
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failed;
                        response.Message = ResponseMessage.Failed;

                    }
                }
                else
                {
                    response.Status = ResponseStatus.Failed;
                    response.Message = ResponseMessage.Failed;
                }
            }
            catch (Exception ex)
            {
                response.Status = Constant.ResponseStatus.Success;
                response.Message = ex.Message;
                return response;
            }

            return response;
        }

        public JsonResponse GetTotalPrice()
        {
            JsonResponse response = new();
            try
            {
                DataSet data = new ADODataFunction().ExecuteDataset(Constant.Procedure.GetTotalPrice, null);


                if (data != null && data.Tables.Count > 0)
                {
                    if (data.Tables[0].Rows.Count > 0 && data.Tables[0] != null)
                    {

                        response.Status = ResponseStatus.Success;
                        response.Message = ResponseMessage.Success;
                        response.Data = data.Tables[0].AsEnumerable().Select(a => new
                        {
                            TotalPrice = a.Field<decimal>("TotalPrice")
                        }).ToList();
                    }
                    else
                    {
                        response.Status = ResponseStatus.Failed;
                        response.Message = ResponseMessage.Failed;

                    }
                }
                else
                {
                    response.Status = ResponseStatus.Failed;
                    response.Message = ResponseMessage.Failed;
                }
            }
            catch (Exception ex)
            {
                response.Status = Constant.ResponseStatus.Success;
                response.Message = ex.Message;
                return response;
            }

            return response;
        }

        public JsonResponse StoreBookList(List<TempBooks> BookList)
        {
            JsonResponse response = new JsonResponse();
            
            try
            {
                DataTable List = ListToDataTable(BookList);

                SqlParameter[] ObjParams = new SqlParameter[]
                {
                    new SqlParameter("@BookList", List)
                };

                DataSet data = new ADODataFunction().ExecuteDataset(Procedure.StoreBookList, ObjParams);
                response = data.Tables[0].AsEnumerable().Select(a => new JsonResponse
                {
                    Status = a.Field<string>("Status"),
                    Message = a.Field<string>("Message"),

                }).FirstOrDefault()!;

            }
            catch (Exception ex)
            {
                response.Status = Constant.ResponseStatus.Success;
                response.Message = ex.Message;
                return response;
            }
            return response;
        }

        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T)); 
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}

namespace Book_Managment.API.Utilities
{
    public class Constant
    {
        public class Procedure
        {
            public const string GetAllBookSortedList = "usp_GetAllBookSortedList";
            public const string GetBookSortedByAuthorTitle = "usp_GetBookSortedByAuthorTitle";
            public const string GetTotalPrice = "usp_GetTotalPrice";
            public const string StoreBookList = "usp_StoreBookList";
        }

        public class ResponseStatus
        {
            public const string Success = "S";
            public const string Failed = "F";
        }

        public class ResponseMessage
        {
            public const string Success = "Success";
            public const string Failed = "Failed";
        }

        public class SuccessMessage
        {
            public const string data_insert = "Record Added Successfully";
        }
        public class ErrorMessage
        {
            public const string data_insert = "Record Added Failed";
            public const string common_error = "Some Issue while updating from server, Please try again later.";
        }
    }
}

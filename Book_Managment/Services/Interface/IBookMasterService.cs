using Book_Managment.API.Models;

namespace Book_Managment.API.Services.Interface
{
    public interface IBookMasterService
    {
        public JsonResponse GetAllBookSortedList();
        public JsonResponse GetBookSortedByAuthorTitle();
        public JsonResponse GetAllBookSortedListUsingProc();
        public JsonResponse GetBookSortedByAuthorTitleUsingProc();
        public JsonResponse GetTotalPrice();
        public JsonResponse StoreBookList(List<TempBooks> books);
    }
}

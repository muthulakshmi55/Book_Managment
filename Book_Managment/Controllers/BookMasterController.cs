using Book_Managment.API.Models;
using Book_Managment.API.Providers.Infrastructure;
using Book_Managment.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Book_Managment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookMasterController : Controller
    {
        public readonly IBookMasterService _bookMasterService;
        private readonly DatabaseContext _databaseContext;

        public BookMasterController(IBookMasterService bookMasterService, DatabaseContext databaseContext)
        {
            _bookMasterService = bookMasterService;
            _databaseContext = databaseContext;

        }

        [HttpGet]
        [Route("GetAllBookSortedList")]
        public IActionResult GetAllBookSortedList()
        {
            return Json(_bookMasterService.GetAllBookSortedList());
        }

        [HttpGet]
        [Route("GetBookSortedByAuthorTitle")]
        public IActionResult GetBookSortedByAuthorTitle()
        {
            return Json(_bookMasterService.GetBookSortedByAuthorTitle());
        }

        [HttpGet]
        [Route("GetAllBookSortedListUsingProc")]
        public IActionResult GetAllBookSortedListUsingProc()
        {
            return Json(_bookMasterService.GetAllBookSortedListUsingProc());
        }

        [HttpGet]
        [Route("GetBookSortedByAuthorTitleUsingProc")]
        public IActionResult GetBookSortedByAuthorTitleUsingProc()
        {
            return Json(_bookMasterService.GetBookSortedByAuthorTitleUsingProc());
        }

        [HttpGet]
        [Route("GetTotalPrice")]
        public IActionResult GetTotalPrice()
        {
            return Json(_bookMasterService.GetTotalPrice());
        }

        [HttpPost]
        [Route("StoreBookList")]
        public IActionResult StoreBookList(List<TempBooks> BookList)
        {
            return Json(_bookMasterService.StoreBookList(BookList));
        }

        [HttpGet]
        [Route("GetMlaCitation")]
        public async Task<ActionResult<string>> GetMlaCitation(long id)
        {
            var book = await _databaseContext.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return book.MLACitation;
        }

        [HttpGet]
        [Route("GetChicagoCitation")]
        public async Task<ActionResult<string>> GetChicagoCitation(long id)
        {
            var book = await _databaseContext.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return book.ChicagoCitation;
        }
    }
}

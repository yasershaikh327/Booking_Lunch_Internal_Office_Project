using FoodInventoryManagement.DataAccess;
using FoodManagement_UI.Models.Dtos.Mappers;
using FoodManagement_UI.Models.UIModels;
using FoodManagement_UI.Services;


namespace FoodManagement_UI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly FoodManagementDB _db;
        private readonly IbookDtoMapper _IbookDtoMapper;
        private readonly IEmailService _emailService;
        public BookRepository(FoodManagementDB foodManagementDB, IbookDtoMapper ibookDtoMapper, IEmailService emailService)
        {
            _db = foodManagementDB;
            _IbookDtoMapper = ibookDtoMapper;
            _emailService = emailService;
        }

        public void BookLunch(Book book)
        {
            var bookDto = _IbookDtoMapper.Map(book);
            bookDto.Employee = book.Employee;
            bookDto.VegNonVegSelection = book.VegNonVegSelection;

            //Fetch Name of Employee
            var employee = _db.RegistrationDto.FirstOrDefault(e => e.Id.ToString() == bookDto.Employee);
            if (employee == null)
                return;
            bookDto.Name = employee.Name;
            _db.BookLunchDto.Add(bookDto);
            _db.SaveChanges();
            _emailService.BookingComfirmEmail(employee.Email, book.VegNonVegSelection == "Veg",employee.Name,employee.Id,bookDto.Date);
        }

        public bool CheckifLunchisAlreadyBooked(Book book)
        {
            var BookDto = _IbookDtoMapper.Map(book);
            {
                var result = _db.BookLunchDto.Any(b => b.Employee == BookDto.Employee);
                if (result)
                    return true;
                return false;
            }
        }
    }
}

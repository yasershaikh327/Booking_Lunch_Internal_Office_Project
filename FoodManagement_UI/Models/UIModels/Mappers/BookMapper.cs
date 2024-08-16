using FoodManagement_UI.Models.Dtos;

namespace FoodManagement_UI.Models.UIModels.Mappers
{
    public interface IBookmapper
    {
        Book Map(BookDto bookDto);
        List<Book> Map(List<BookDto> bookDto);
    }
    public class BookMapper : IBookmapper
    {
        public Book Map(BookDto bookDto)
        {
            var book = new Book();  
            book.VegNonVegSelection = bookDto.VegNonVegSelection;
            book.Employee = bookDto.Employee;   
            return book;
        }

        public List<Book> Map(List<BookDto> bookDto)
        {
            var bookDtos = new List<Book>();
            foreach (var dto in bookDto)
            {
                var bookItem = new Book
                {
                  Employee = dto.Employee,
                  VegNonVegSelection = dto.VegNonVegSelection,
                };

                bookDtos.Add(bookItem);
            }
            return bookDtos;
        }
    }
}

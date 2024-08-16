using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Models.Dtos.Mappers
{
    public interface IbookDtoMapper
    {
        BookDto Map(Book book);  
    }
    public class BookDtoMapper : IbookDtoMapper
    {
        public BookDto Map(Book book)
        {
            var BookDto = new BookDto();
            BookDto.VegNonVegSelection = book.VegNonVegSelection;   
            BookDto.Employee = book.Employee;   
            return BookDto;
        }
    }
}

namespace FoodManagement_UI.Models.Dtos
{
    public class BookDto
    {
        public BookDto()
        {
            Date = DateTime.Now.Date.ToString();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VegNonVegSelection { get; set; }
        public string Employee { get; set; }
        public string Date { get; private set; }

    }
    public class BookDtos
    {
        BookDto dtos { get; set; }
        public BookDtos()
        {
            dtos = new BookDto();
        }
    }
}

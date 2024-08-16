using FoodManagement_UI.Models.UIModels;

namespace FoodManagement_UI.Repository
{
    public interface IBookRepository
    {
        public bool CheckifLunchisAlreadyBooked(Book book);
        public void BookLunch(Book book);
    }
}

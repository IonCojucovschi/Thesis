using Int.Core.Application.Menu.Contract;

namespace Core.Models.DAL
{
    public class MenuItem : IItemMenu
    {
        public string Name { get; set; }
        public string ClickArgument { get; set; }
    }
}
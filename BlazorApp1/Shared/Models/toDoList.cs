using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Shared.Models
{
    public class toDoList :DbContext
    {
        public int ıd { get; set; }
        public string text { get; set; } 
        public bool ısEnabled { get; set; } 
        public int listId { get; set; } 

    }
}

namespace BlazorApp1.Data
{
      
    public class ToDoList
    {
        
        public int Id { get; set; }
        public int ListId { get; set; }
        public string? Text { get; set; }
        public bool IsEnabled { get; set; }
    }
}

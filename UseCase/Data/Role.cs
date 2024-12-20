namespace UseCase.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string? desc {  get; set; }
        public int? UserID {  get; set; }//fk to user class
        public User? User { get; set; }
    }
}

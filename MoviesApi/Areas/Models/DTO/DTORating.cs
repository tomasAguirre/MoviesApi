namespace MoviesApi.Areas.Models.DTO
{
    public class DTORating 
    {
        public Rate rate { get; set; }
        public int idUser { get; set; }
        public int idMovie { get; set; }
    }
}

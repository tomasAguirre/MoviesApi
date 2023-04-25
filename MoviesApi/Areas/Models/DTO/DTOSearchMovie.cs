namespace MoviesApi.Areas.Models.DTO
{
    public class DTOSearchMovie
    {
        public string MovieName { get; set; }
        public string sypnosis { get; set; }
        public Category Category { get; set; }
        public DateTime YearOfRealese{ get; set; }

        #region ordenable
        public Rating rating { get; set; }
        #endregion
    }
}

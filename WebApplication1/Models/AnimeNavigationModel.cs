namespace WebApplication1.Models
{
    public class AnimeNavigationModel
    {
        public List<string> Seasons { get; set; }  = new(){ "Fall", "Summer", "Spring", "Winter" };

        public int currentYear { get; set; } = 2024;

        public List<string> newSeasons { get; set; } = new() { "Winter","Spring","Summer","Fall"};

        public int newCurrentYear { get; set; } = 2024; /// <summary>
        /// 
        /// </summary>

        public string currentSeason = "Spring";
    }
}

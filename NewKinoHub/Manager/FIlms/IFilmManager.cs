using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public interface IFilmManager
    {
        Task<ICollection<Media>> GetAllFilms();
        Task<Media> GetFilmforId(int filmId,Users User);
        MediaType TypeFilm(string i);
        Task<ICollection<Media>> AllSorting(string sort, Users User);
        Task<ICollection<Media>> Filtration(int filtr, Users User);
        string GetNameFiltr(int idFiltr);
        ICollection<Media> SortingFromFiltr(string sort, ICollection<Media> media);
        Task<ICollection<Media>> GetFilms(Users User);
        ICollection<Media> GetFavoriteFilmsForUser(Users User);
        Task<Users> GetUser(string UserEmail);
        Task DeleteFilm(int IdFIlm);
        Task AddReviews(int idFilm, string Email, string text);
        ICollection<Media> GetViewedFilmsForUser(Users User);
        Task AddFilm(string mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Day, string month, int NumOfEpisodes, int NumOfSeason, int type, string[] Images);
        Task EditFilm(string mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Id, int Day, string month, int NumOfEpisodes, int NumOfSeason, int type, string[] Images);
        bool UserReview(string Email, int IdFilm);
        Task DeleteReviews(int IdFilm, int IdUser);
        Task EditReviews(int idFilm, int IdUser, string text);

    }
}

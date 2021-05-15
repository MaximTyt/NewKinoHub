using NewKinoHub.Storage.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public interface IFilmManager
    {
        Task<ICollection<Media>> GetAllFilms();
        Task<Media> GetFilmforId(int filmId,Users User);
        RoleInFilm Cast(int i);
        MediaType TypeFilm(string i);
        Task<ICollection<Media>> AllSorting(string sort, Users User);
        Task<ICollection<Media>> Filtration(int filtr, Users User);
        string GetNameFiltr(int idFiltr);
        Task<ICollection<Media>> SortingFromFiltr(string sort, ICollection<Media> media);
        Task<ICollection<Media>> GetFilms(Users User);
        Task<ICollection<Media>> GetFavoriteFilmsForUser(Users User);
        Task<Users> GetUser(string UserEmail);
        Task DeleteFilm(int IdFIlm);
        Task AddReviews(int idFilm, string Email, string text);
        Task<ICollection<Media>> GetViewedFilmsForUser(Users User);
        Task AddFilm(string mainPhoto, string Name, int Year, string Contry, string Release_Date, int Age, string RunTime, string Description, string shortDescription, double Score, string ScoreKP, string Music, string Video);
        Task EditFilm(string mainPhoto, string Name, int Year, string Contry, string Release_Date, int Age, string RunTime, string Description, string shortDescription, double Score, string ScoreKP, string Music, string Video, int id);
        bool UserReview(string Email, int IdFilm);
    }
}

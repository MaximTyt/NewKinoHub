using Microsoft.AspNetCore.Http;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinoHab.Manager
{
    public interface IFilmManager
    {
        void ChangeRaiting(int IdFilm);
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
        Task AddReviews(int idFilm, string Email, string text, double rating);
        ICollection<Media> GetViewedFilmsForUser(Users User);
        Task AddFilm(IFormFile mainPhoto, string Name, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int NumOfEpisodes, int NumOfSeason, int type, IFormFile Images1, IFormFile Images2, IFormFile Images3, IFormFile Images4, string[] genres, DateTime Release_Date);
        Task EditFilm(IFormFile mainPhoto, string Name, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Id, int NumOfEpisodes, int NumOfSeason, int type, IFormFile Images1, IFormFile Images2, IFormFile Images3, IFormFile Images4, string[] genres, DateTime Release_Date);
        bool UserReview(string Email, int IdFilm);
        Task DeleteReviews(int IdFilm, int IdUser);
        Task EditReviews(int idFilm, int IdUser, string text, double rating);
        Task<(List<Media>, List<Media>)> GetFilmsForPerson(string Person, int IdPerson, Users User);
        Task<(List<Media>, List<Media>)> SearchFilmsForActors(string Role1, string Name1, string Role2, string Name2, Users User);

    }
}

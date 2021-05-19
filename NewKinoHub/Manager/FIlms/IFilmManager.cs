﻿using NewKinoHub.Storage.Entity;
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
        Task AddFilm(string mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDescription, string Score, string ScoreKP, string Music, string Video, int Day, string month, int NumOfEpisodes, int NumOfSeason, int type);
        Task EditFilm(string mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDescription, string Score, string ScoreKP, string Music, string Video, int id, int Day,string month, int NumOfEpisodes, int NumOfSeason, int type);
        bool UserReview(string Email, int IdFilm);
        Task DeleteReviews(int IdFilm, string Email);
        Task EditReviews(int idFilm, int IdUser, string text);

    }
}

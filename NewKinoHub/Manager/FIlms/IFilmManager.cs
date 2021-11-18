﻿using Microsoft.AspNetCore.Http;
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
        Task AddFilm(IFormFile mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int NumOfEpisodes, int NumOfSeason, int type, string[] Images, string[] genres, DateTime Release_Date);
        Task EditFilm(IFormFile mainPhoto, string Name, int Year, string Contry, int Age, string RunTime, string Description, string shortDiscription, string Score, string ScoreKP, string Music, string Video, int Id, int NumOfEpisodes, int NumOfSeason, int type, string[] Images, string[] genres, DateTime Release_Date);
        bool UserReview(string Email, int IdFilm);
        Task DeleteReviews(int IdFilm, int IdUser);
        Task EditReviews(int idFilm, int IdUser, string text, double rating);

    }
}

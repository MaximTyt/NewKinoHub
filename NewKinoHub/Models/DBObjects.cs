using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NewKinoHub.Storage;
using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Models
{
    public class DBObjects
    {

        public static void Initial(MvcFilmContext content)
        {                            

            if (!content.Genres.Any())
                content.Genres.AddRange(Genres.Select(c => c.Value));

            if (!content.Media.Any())
            {
                content.AddRange(
                    new Media
                    {
                        MediaType = MediaType.Film,
                        Name = "Лига справедливости Зака Снайдера",
                        Img = "https://imageup.ru/img168/3732118/zacksnydersjusticeleague.jpg",
                        Video = "https://www.youtube.com/embed/KQwKRTtJU-A",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#album/14462174",
                        Year = 2021,
                        Country = "США, Великобритания",
                        Age = 18,
                        Score = 8.024,
                        Release_Date = "18 марта 2021",
                        Runtime = "04:02",
                        ShortDescription = "Бэтмен собирает команду супергероев," +
                        " чтобы спасти Землю. Самый ожидаемый блокбастер весны",
                        Description = "Вдохновившись самопожертвованием Супермена," +
                        " Брюс Уэйн вновь обретает веру в человечество.Он заручается" +
                        " поддержкой новой союзницы Дианы Принс, чтобы сразиться с ещё" +
                        " более могущественным противником.Бэтмен и Чудо - женщина набирают" +
                        " команду сверхлюдей для борьбы с пробудившейся угрозой.",
                        ScoreKP = "https://rating.kinopoisk.ru/1387021.gif",
                        Genres = new List<Genre>() {Genres["Фантастика"], Genres["Боевик"], Genres["Боевик"], Genres["Фэнтези"] }
                    },
                    new Media
                    {
                        MediaType = MediaType.Serial,
                        Name = "Засланец из космоса",
                        Img = "https://imageup.ru/img234/3731988/residentalien.jpg",
                        Video = "https://www.youtube.com/embed/tP1A_dgKEd8",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#playlist/MaximTyta/1000",
                        Year = 2021,
                        Country = "США",
                        Age = 18,
                        Score = 8.115,
                        Release_Date = "27 января 2021",
                        Runtime = "46 мин. серия",
                        ShortDescription = "Инопланетянин в теле доктора пытается" +
                        " оправдать человечество. Алан Тьюдик в экранизации комиксов Dark Horse",
                        Description = "Доктор Гарри Вендершпигль — отшельник в небольшом городке" +
                        " в Колорадо. Ещё он — пришелец, который на самом деле упал на Землю и занял" +
                        " тело врача. Когда же доктора убивают, пришелец вынужден отложить миссию по" +
                        " возвращению домой и занять место убитого. Живя в новом теле, он постепенно" +
                        " начинает задаваться вопросами, стоят люди спасения или нет.",
                        ScoreKP = "https://rating.kinopoisk.ru/1200189.gif",
                        Genres = new List<Genre>() { Genres["Фантастика"], Genres["Драма"], Genres["Комедия"], Genres["Детектив"] }
                    },
                    new Media
                    {
                        MediaType = MediaType.Film,
                        Name = "Истребитель демонов: Поезд «Бесконечный»",
                        Img = "https://imageup.ru/img260/3733456/demonslayer.jpg",
                        Video = "https://www.youtube.com/embed/__Nwefty3Y4",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#playlist/MaximTyta/1026",
                        Year = 2020,
                        Country = "Япония",
                        Age = 18,
                        Score = 8.149,
                        Release_Date = "16 октября 2020",
                        Runtime = "01:57",
                        ShortDescription = "Самый посещаемый японский фильм всех времен",
                        Description = "Тандзиро с друзьями из отряда уничтожителей демонов" +
                        " расследует серию загадочных исчезновений внутри мчащегося поезда." +
                        " Но компания ещё не знает, что в составе находится один из двенадцати" +
                        " Лунных демонов, и он приготовил для них ловушку.",
                        ScoreKP = "https://rating.kinopoisk.ru/1347949.gif",
                        Genres = new List<Genre>() { Genres["Аниме"], Genres["Боевик"], Genres["Фэнтези"] }
                    }
                    );
            }
            content.SaveChanges();
        }

            private static Dictionary<string, Genre> genres;
            public static Dictionary<string,Genre> Genres
        {
            get
            {
                if(genres == null)
                {
                    var list = new Genre[]
                    {
                        new Genre { Genre_Name = "Аниме" },
                        new Genre { Genre_Name = "Боевик" },
                        new Genre { Genre_Name = "Вестерн" },
                        new Genre { Genre_Name = "Детектив" },
                        new Genre { Genre_Name = "Драма" },
                        new Genre { Genre_Name = "Комедия" },
                        new Genre { Genre_Name = "Мелодрама" },
                        new Genre { Genre_Name = "Мультфильм" },
                        new Genre { Genre_Name = "Мюзикл" },
                        new Genre { Genre_Name = "Криминал" },
                        new Genre { Genre_Name = "Приключения" },
                        new Genre { Genre_Name = "Семейный" },                        
                        new Genre { Genre_Name = "Ужасы" },
                        new Genre { Genre_Name = "Фантастика" },
                        new Genre { Genre_Name = "Фэнтези" }
                    };
                    genres = new Dictionary<string, Genre>();
                    foreach (Genre el in list)
                        genres.Add(el.Genre_Name, el);                    
            }
                return genres;
            }
        }

    }
}



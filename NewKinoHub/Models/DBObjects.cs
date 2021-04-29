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
        public static void Initial(IApplicationBuilder app)
        {
            MvcFilmContext content = app.ApplicationServices.GetRequiredService<MvcFilmContext>();

            if (!content.Genres.Any())
            {
                content.AddRange(
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
                                   new Genre { Genre_Name = "Мюзикл" },
                                   new Genre { Genre_Name = "Ужасы" },
                                   new Genre { Genre_Name = "Фантастика" },
                                   new Genre { Genre_Name = "Фэнтези" }
                                   );
            }
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
                        Genres = new List<Genre>() {}
                    }
                    ) ;
            }

        }

    }
}



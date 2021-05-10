﻿using Microsoft.AspNetCore.Builder;
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

            if (!content.Persons.Any())
                content.Persons.AddRange(Persons.Select(c => c.Value));

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
                        Genres = new List<Genre>() { Genres["Фантастика"], Genres["Боевик"], Genres["Фэнтези"] },
                        Casts = new List<Cast>()
                        {
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Режиссёр,
                            Person = Persons["Зак Снайдер"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Крис Террио"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Бен Аффлек"],
                            Character = "Batman / Bruce Wayne"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Галь Гадот"],
                            Character = "Wonder Woman / Diana Prince"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Генри Кавилл"],
                            Character = "Superman / Clark Kent"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Джейсон Момоа"],
                                Character = "Aquaman / Arthur Curry"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Эзра Миллер"],
                                Character = "The Flash / Barry Allen"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Рэй Фишер"],
                                Character = "Cyborg / Victor Stone"
                            }
                        },
                        Images = new List<MediaImages>()
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img128/3736799/liga-1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img191/3736801/liga-2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img156/3736802/liga-3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img13/3736803/liga-4.jpg"
                            }
                        }

                    },
                    new Media
                    {
                        MediaType = MediaType.Serial,
                        Name = "Засланец из космоса",
                        NumOfSeason = 1,
                        NumOfEpisodes = 10,
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
                        Genres = new List<Genre>() { Genres["Фантастика"], Genres["Драма"], Genres["Комедия"], Genres["Детектив"] },
                        Images = new List<MediaImages>
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img178/3736813/zsl1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img188/3736816/zsl2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img178/3736817/zsl3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img155/3736819/zsl4.jpg"
                            }
                        }
                    }, //доделать каст
                    new Media
                    {
                        MediaType = MediaType.Film,
                        Name = "Истребитель демонов: Поезд «Бесконечный»",
                        Img = "https://imageup.ru/img260/3733456/demonslayer.jpg",
                        Video = "https://www.youtube.com/embed/wtE-SW8YDHM",
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
                        Genres = new List<Genre>() { Genres["Аниме"], Genres["Мультфильм"], Genres["Боевик"], Genres["Фэнтези"] },
                        Casts = new List<Cast>()
                        {
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Режиссёр,
                            Person = Persons["Харуо Сотодзаки"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Сценарист,
                            Person = Persons["Коёхару Готогэ"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Нацуки Ханаэ"],
                            Character="Kamado Tanjiro, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Ёсицугу Мацуока"],
                            Character="Hashibira Inosuke, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Хиро Симоно"],
                            Character="Agatsuma Zenitsu, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Сатоси Хино"],
                            Character="Rengoku Kyôjurô, озвучка"
                            },
                        },
                        Images = new List<MediaImages>()
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img13/3736804/kl1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img144/3736805/kl2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img286/3736806/kl3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img184/3736807/kl4.jpg"
                            }
                        }
                    },
                    new Media
                    {
                        MediaType = MediaType.Film,
                        Name = "Твоё имя",
                        Img = "https://imageup.ru/img161/3733340/yourname.jpg",
                        Video = "https://www.youtube.com/embed/tT7b5wR0IOM",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#album/3929305",
                        Year = 2016,
                        Country = "Япония",
                        Age = 16,
                        Score = 8.327,
                        Release_Date = "3 июля 2016",
                        Runtime = "01:50",
                        ShortDescription = "«Я ищу тебя, хотя не знаю, кто ты». " +
                            "Нежная сказка о первой любви, которая преодолевает пространство и время. Аниме – рекордсмен бокс-офиса.",
                        Description = "Парень из Токио Таки и девушка из провинции Мицуха обнаруживают," +
                            " что между ними существует странная связь. Во сне они меняются телами и проживают" +
                            " жизни друг друга. Но однажды эта способность исчезает так же внезапно, как появилась." +
                            " Таки решает во что бы то ни стало отыскать Мицуху.",
                        ScoreKP = "https://rating.kinopoisk.ru/958722.gif",
                        Genres = new List<Genre>() { Genres["Аниме"], Genres["Мультфильм"], Genres["Фэнтези"], Genres["Драма"], Genres["Мелодрама"], },
                        Casts = new List<Cast>()
                            {
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Режиссёр,
                            Person = Persons["Макото Синкай"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Сценарист,
                            Person = Persons["Макото Синкай"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Рюносукэ Камики"],
                            Character="Taki Tachibana, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Монэ Камисираиси"],
                            Character="Mitsuha Miyamizu, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Рё Нарита"],
                            Character="Katsuhiko Teshigawara, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Аой Юки"],
                            Character="Sayaka Natori, озвучка"
                            }
                            },
                        Images = new List<MediaImages>()
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img187/3736954/tvoeimia1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img37/3736955/tvoeimia2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img300/3736956/tvoeimia3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img75/3736957/tvoeimia4.jpg"
                            }
                        }
                    },
                    new Media
                    {
                        MediaType = MediaType.Film,
                        Name = "Майор Гром: Чумной Доктор",
                        Img = "https://imageup.ru/img227/3732084/mayorgromchumnoydoktor.jpg",
                        Video = "https://www.youtube.com/embed/aUi6fQRUP1o",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#playlist/music-blog/2524",
                        Year = 2021,
                        Country = "Россия",
                        Age = 12,
                        Score = 7.391,
                        Release_Date = "1 апреля 2021",
                        Runtime = "02:16",
                        ShortDescription = "Честный полицейский ловит мстителя в маске, убивающего" +
                            " коррупционеров. Супергеройское кино по комиксу Bubble",
                        Description = "Майор полиции Игорь Гром известен всему Санкт-Петербургу пробивным" +
                            " характером и непримиримой позицией по отношению к преступникам всех мастей." +
                            " Неимоверная сила, аналитический склад ума и неподкупность — всё это делает майора" +
                            " Грома идеальным полицейским. Но всё резко меняется с появлением человека в маске" +
                            " Чумного Доктора. Заявив, что его город «болен чумой беззакония», он принимается" +
                            " за «лечение», убивая людей, которые в своё время избежали наказания при помощи" +
                            " денег и влияния. Общество взбудоражено. Полиция бессильна. Игорь впервые" +
                            " сталкивается с трудностями в расследовании, от итогов которого может зависеть" +
                            " судьба всего города.",
                        ScoreKP = "https://rating.kinopoisk.ru/1109271.gif",
                        Genres = new List<Genre>() { Genres["Боевик"], Genres["Криминал"], Genres["Комедия"], Genres["Детектив"] },
                        Casts = new List<Cast>()
                        {
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Режиссёр,
                            Person = Persons["Олег Трофим"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Артем Габрелянов"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Роман Котков"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Тихон Жизневский"],
                            Character = "Игорь Гром, майор полиции"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Любовь Аксенова"],
                            Character = "Юлия Пчёлкина, журналистка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Алексей Маклаков"],
                            Character = "Фёдор Прокопенко, полковник, начальник Игоря Грома"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Сергей Горошко"],
                            Character = "Сергей Разумовский, основатель соцсети «Вместе»"
                            },
                        },
                        Images = new List<MediaImages>
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img174/3739201/mg1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img161/3739202/mg2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img291/3739203/mg3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img198/3739204/mg4.jpg"
                            }
                        }
                    },
                    new Media
                    {
                        MediaType = MediaType.Film,
                        Name = "Душа",
                        Img = "https://imageup.ru/img214/3732232/soul.jpg",
                        Video = "https://www.youtube.com/embed/vsb8762mE6Q",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#album/13521150",
                        Year = 2020,
                        Country = "США",
                        Age = 6,
                        Score = 8.311,
                        Release_Date = "11 октября 2020",
                        Runtime = "01:46",
                        ShortDescription = "Джазмен хочет сбежать с того света на концерт. Фантазия" +
                        " о призвании и важных мелочах жизни от автора «Вверх»",
                        Description = "Уже немолодой школьный учитель музыки Джо Гарднер всю жизнь" +
                        " мечтал выступать на сцене в составе джазового ансамбля. Однажды он успешно" +
                        " проходит прослушивание у легендарной саксофонистки и, возвращаясь домой вне" +
                        " себя от счастья, падает в люк и умирает. Теперь у Джо одна дорога — в Великое" +
                        " После, но он сбегает с идущего в вечность эскалатора и случайно попадает в Великое" +
                        " До. Тут новенькие души обретают себя, и у будущих людей зарождаются увлечения," +
                        " мечты и интересы. Джо становится наставником упрямой души 22, которая уже много" +
                        " веков не может найти свою искру и отправиться на Землю.",
                        ScoreKP = "https://rating.kinopoisk.ru/775273.gif",
                        Genres = new List<Genre>() { Genres["Мультфильм"], Genres["Фэнтези"], Genres["Комедия"], Genres["Приключения"], Genres["Семейный"], Genres["Мюзикл"] },
                        Casts = new List<Cast>()
                        {
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Режиссёр,
                            Person = Persons["Пит Доктер"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Пит Доктер"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Майк Джонс"]
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Джейми Фокс"],
                            Character = "Joe, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Тина Фей"],
                            Character = "22, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Грэм Нортон"],
                            Character = "Moonwind, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Анджела Бассетт"],
                            Character = "Dorothea, озвучка"
                            },
                        },
                        Images = new List<MediaImages>
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img243/3739789/soul1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img31/3739793/soul2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img184/3739794/soul3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img130/3739795/soul4.jpg"
                            }
                        }
                    },
                    new Media
                    {
                        MediaType = MediaType.Serial,
                        Name = "Внешние отмели",
                        NumOfSeason = 1,
                        NumOfEpisodes = 11,
                        Img = "https://imageup.ru/img111/3731964/outerbanks.jpg",
                        Video = "https://www.youtube.com/embed/o0xdAiYsX18",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#playlist/gromsserg/1011",
                        Year = 2020,
                        Country = "США",
                        Age = 16,
                        Score = 7.282,
                        Release_Date = "15 апреля 2020",
                        Runtime = "54 мин. серия",
                        ShortDescription = "Будьте Осторожны В Том, Что Вы Ищете",
                        Description = "Внешние отмели — 320-километровая полоса узких песчаных барьерных" +
                        " островов побережья Северной Каролины, начинающихся у юго-восточного края Вирджиния-Бич" +
                        " восточного побережья США. Именно здесь в разгар летнего сезона, который накрылся медным" +
                        " тазом из-за бушующего урагана, четверо подростков с помощью случайно добытой карты отправляются" +
                        " на поиски огромной партии золота, стоимость которой оценивается в четыреста миллионов долларов.",
                        ScoreKP = "https://rating.kinopoisk.ru/1264562.gif",
                        Genres = new List<Genre>() { Genres["Драма"], Genres["Детектив"], Genres["Приключения"], },
                        Images = new List<MediaImages>
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img206/3739991/ob1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img253/3739993/ob2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img154/3739994/ob3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img16/3739995/ob4.jpg"
                            }
                        }
                    }
                    );
            }

            if (!content.Users.Any())
            {
                content.AddRange(
                    new Users
                    {
                        Nickname = "admin",
                        Email = "admin@gmail.com",
                        Password = "123",
                        Role = Role.Admin,
                        DateOfBirthday = "10/08/2001",
                        Image = "https://imageup.ru/img161/3736570/pirate.jpg",
                    }
                    );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Genre> genres;
        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genres == null)
                {
                    var list = new Genre[]
                    {
                        new Genre { Genre_Name = "Аниме", NumOfGenre=1 },
                        new Genre { Genre_Name = "Боевик", NumOfGenre=2},
                        new Genre { Genre_Name = "Вестерн", NumOfGenre=3},
                        new Genre { Genre_Name = "Детектив", NumOfGenre=4},
                        new Genre { Genre_Name = "Драма", NumOfGenre=5},
                        new Genre { Genre_Name = "Комедия", NumOfGenre=6},
                        new Genre { Genre_Name = "Криминал", NumOfGenre=7},
                        new Genre { Genre_Name = "Мелодрама", NumOfGenre=8},
                        new Genre { Genre_Name = "Мультфильм", NumOfGenre=9},
                        new Genre { Genre_Name = "Мюзикл", NumOfGenre=10},
                        new Genre { Genre_Name = "Приключения", NumOfGenre=11},
                        new Genre { Genre_Name = "Семейный", NumOfGenre=12},
                        new Genre { Genre_Name = "Ужасы", NumOfGenre=13},
                        new Genre { Genre_Name = "Фантастика", NumOfGenre=14},
                        new Genre { Genre_Name = "Фэнтези", NumOfGenre=15}
                    };
                    genres = new Dictionary<string, Genre>();
                    foreach (Genre el in list)
                        genres.Add(el.Genre_Name, el);
                }
                return genres;
            }
        }


        private static Dictionary<string, Person> persons;
        public static Dictionary<string, Person> Persons
        {
            get
            {
                if (persons == null)
                {
                    var list = new Person[]
                    {
                        new Person{
                            Name="Зак Снайдер",
                            OriginalName="Zachary Edward Snyder",
                            Height="1.7 м",
                            DateOfBirthday="1/03/1966",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("1/03/1966")).TotalDays/365.2425)),
                            PlaceOfBirthday="Грин Бэй, Висконсин, США",
                            Spouse="Дебора Снайдер",
                            Awards="Сатурн, 2008 - Лучший режиссер («300 спартанцев»)",
                            RolesInMedia = new RoleInFilm[3]{RoleInFilm.Режиссёр, RoleInFilm.Сценарист, RoleInFilm.Актёр},
                            Image="https://imageup.ru/img214/3736505/zack_snyder.jpg",
                            Description="В марте 2017 года дочь Снайдера Отем покончила с собой.\n" +
                            "Зак с Деборой воспитывают семерых детей, двое из которых являются приемными."
                        },
                        new Person{
                            Name="Бен Аффлек",
                            OriginalName="Benjamin Geza Affleck-Boldt",
                            Height="1.92 м",
                            DateOfBirthday="15/08/1972",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("15/08/1972")).TotalDays/365.2425)),
                            PlaceOfBirthday="Беркли, Калифорния, США",
                            Spouse="Дженнифер Гарнер (развод)",
                            Awards="Золотая малина, 2017 - Худший экранный ансамбль («Бэтмен против Супермена: На заре справедливости»);" +
                            " Золотая малина, 2015 - Премия за восстановление репутации;" +
                            " Оскар, 2013 - Лучший фильм («Операция «Арго»»);"+
                            " Золотой глобус, 2013 - Лучший режиссер («Операция «Арго»»);"+
                            " Британская академия, 2013 - Лучший фильм («Операция «Арго»»);"+
                             " Лучший режиссер («Операция «Арго»»);"+
                            " Сезар, 2013 - Лучший фильм на иностранном языке («Операция «Арго»»);"+
                            " Премия Гильдии актеров, 2013 - Лучший актерский состав («Операция «Арго»»);"+
                            " Сатурн, 2007 - Лучший актер второго плана («Смерть супермена»);"+
                            " Венецианский кинофестиваль, 2006 - Кубок Вольпи за лучшую мужскую роль («Смерть супермена»);"+
                            " Золотая малина, 2004 - Худшая мужская роль («Сорвиголова»);"+
                            " Премия Гильдии актеров, 1999 - Лучший актерский состав («Влюбленный Шекспир»);"+
                            " Оскар, 1998 - Лучший сценарий («Умница Уилл Хантинг»);"+
                            " Золотой глобус, 1998 - Лучший сценарий («Умница Уилл Хантинг»)",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Актёр,RoleInFilm.Режиссёр, RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img208/3736572/benafflec.jpg",
                            Description= "Актёр Кейси Аффлек — младший брат Бена.\n" +
                            "Недолгое время учился в Вермонтском университете и Оксидентал-колледже."
                        },
                        new Person
                        {
                            Name="Галь Гадот",
                            OriginalName="Gal Gadot",
                            Height="1.78 м",
                            DateOfBirthday="30/04/1985",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("30/04/1985")).TotalDays/365.2425)),
                            PlaceOfBirthday = "Петах-Тиква, Израиль",
                            Spouse="Ярон Версано",
                            Awards="Премия канала «MTV», 2018 - Лучшая драка («Чудо-женщина»);" +
                            "Сатурн, 2018 - Лучшая актриса («Чудо-женщина»)",
                            RolesInMedia = new RoleInFilm[2]{RoleInFilm.Актёр, RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img152/3736581/galgadot.jpg",
                            Description= "Актриса и модель. Является победительницей конкурса" +
                            " «Мисс Израиль 2004» и участницей конкурса «Мисс Вселенная 2004».\n" +
                            "В начале ноября 2011 года родила дочь от супруга Ярона Версано, которую назвали Альмой.\n" +
                            "Два года прослужила в качестве спортивного тренера в армии Израиля."
                        },
                        new Person
                        {
                            Name="Генри Кавилл",
                            OriginalName="Henry William Dalgliesh Cavill",
                            Height="1.85 м",
                            DateOfBirthday="5/05/1983",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("5/05/1983")).TotalDays/365.2425)),
                            PlaceOfBirthday="Сент-Сейвьер, Джерси, Нормандские острова",
                            Awards="Золотая малина, 2017 - Худший экранный ансамбль («Бэтмен против Супермена: На заре справедливости»);" +
                            "Премия канала «MTV», 2014 - Лучший герой («Человек из стали»)",
                            RolesInMedia = new RoleInFilm[1]{RoleInFilm.Актёр},
                            Image="https://imageup.ru/img10/3736585/henrycavill.jpg",
                            Description="У актера есть четыре брата.\n" +
                            "Генри Кавилл является представителем Фонда охраны дикой природы имени Даррелла.\n" +
                            "Свободно говорит по-французски, владеет итальянским и немецким языками.\n" +
                            "Кавилл является заядлым геймером с самого детства. Однажды он пропустил" +
                            " важный звонок с предложением играть Супермена из-за World of Warcraft." +
                            " Любовь к игре Ведьмак побудила его сыграть Геральта в ее экранизации." +
                            " Он также назвал серию стратегических игр Total War одной из своих любимых.\n" +
                            "Он заядлый фанат клуба Канзас-Сити Чифс."
                        },
                        new Person
                        {
                            Name="Джейсон Момоа",
                            OriginalName="Joseph Jason Namakaeha Momoa",
                            Height="1.93 м",
                            DateOfBirthday="1/08/1979",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("1/08/1979")).TotalDays/365.2425)),
                            PlaceOfBirthday="Гонолулу, Гавайи, США",
                            Spouse="Лиза Боне",
                            Awards="CinemaCon, 2011 - Восходящая звезда",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Актёр,RoleInFilm.Режиссёр, RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img226/3736588/jasonmamoa.jpg",
                            Description="У него есть двое детей от Лизы Боне — Лола Иолани (Lola Iolani) и Накоа Вульф Манакауапо Намакеаха Момоа.\n" +
                            "Лицевой шрам - 15 ноября 2008 года мужчина ударил Момоа по лицу разбитым пивным стаканом во время ссоры" +
                            " в кафе Birds Cafe, таверне в Голливуде, штат Калифорния."
                        },
                        new Person
                        {
                            Name="Эзра Миллер",
                            OriginalName="Ezra Matthew Miller",
                            Height="1.8 м",
                            DateOfBirthday="30/09/1992",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("30/09/1992")).TotalDays/365.2425)),
                            PlaceOfBirthday="Хобокен, Нью-Джерси, США",
                            Awards="Каннский кинофестиваль, 2012 - Приз компании «Шопар» лучшему молодому актеру",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Актёр,RoleInFilm.Режиссёр, RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img148/3736601/ezramiller.jpg",
                            Description="Миллер описывает себя как квира, не идентифицируя свою личность с конкретным гендером и сексуальной ориентацией.\n" +
                            "С 2016 года играет роли Криденса Бэрбоуна в серии фильмов «Фантастические твари»" +
                            " по романам Джоан Роулинг и Барри Аллена в лентах супергеройской вселенной DC.\n" +
                            "Помимо кино Миллер занимается музыкой — он барабанщик и вокалист в группе «Sons of an Illustrious Father»."
                        },
                        new Person
                        {
                            Name="Рэй Фишер",
                            OriginalName="Ray Fisher",
                            Height="1.91 м",
                            DateOfBirthday="8/09/1987",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("8/09/1987")).TotalDays/365.2425)),
                            PlaceOfBirthday="Балтимор, Мэрилэнд, США",
                            RolesInMedia = new RoleInFilm[1]{RoleInFilm.Актёр},
                            Image="https://imageup.ru/img65/3736608/rayfisher.jpg",
                            Description="После средней школы Фишер учился в Американской музыкально-драматической академии в Нью-Йорке.\n" +
                            "Получив роль Киборга, Фишер сказал: «Я не знал, в какой степени DC и WB планировали использовать" +
                            " моего персонажа. Когда я подписал контракт, я просто хотел быть частью этого мира. Но эту конкретную" +
                            " информацию я узнал только тогда и только там. Я не думал, что я получу свой собственный фильм." +
                            " Я человек долгоиграющих перспектив и не думал, что подобное произойдет раньше, чем мне исполнится 40." +
                            " Это огромная честь, но с ним приходит немного давления. Мой разум просто ошеломлён прямо сейчас»."
                        },
                        new Person
                        {
                            Name="Крис Террио",
                            OriginalName="Chris Terrio",
                            DateOfBirthday="31/12/1976",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("31/12/1976")).TotalDays/365.2425)),
                            PlaceOfBirthday="Нью-Йорк, США",
                            Awards="Золотая малина, 2017 - Худший сценарий («Бэтмен против Супермена: На заре справедливости»);" +
                            "Оскар, 2013 - Лучший адаптированный сценарий («Операция «Арго»»)",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Сценарист,RoleInFilm.Режиссёр,RoleInFilm.Актёр},
                            Image="https://imageup.ru/img11/3736631/christerrio.jpg",
                            Description="Крис Террио вырос на Статен-Айленде (Нью-Йорк), в католической" +
                            " семье итальянского и ирландского происхождения. В 1997 году окончил" +
                            " Гарвардский университет, где он изучал английскую и американскую литературу."
                        },
                        new Person
                        {
                            Name="Макото Синкай",
                            OriginalName="Makoto Niitsu",
                            DateOfBirthday="9/02/1973",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("9/02/1973")).TotalDays/365.2425)),
                            PlaceOfBirthday="Коуми, Нагано (префектура), Япония",
                            Spouse="Мисака Тиэко",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Режиссёр,RoleInFilm.Сценарист,RoleInFilm.Актёр},
                            Image="https://imageup.ru/img111/3736947/makotoshinkai.jpg",
                            Description="Настоящее имя — Макото Ниицу. Фильм Синкая «Твоё имя», вышедший в 2016 году," +
                            " некоторое время был самым кассовым аниме в мире за всю историю.\n" +
                            "Синкая называли «новым Миядзаки» в нескольких обзорах, хотя сам он" +
                            " не согласен с таким сравнением, заявляя, что его переоценивают." +
                            " Также он сказал, что хочет создавать произведения, которые имеют" +
                            " другие точки соприкосновения с аудиторией, иные, чем у работ Хаяо Миядзаки.\n" +
                            "Отличительным признаком Синкая является отвлечённость от штампов и требований" +
                            " аниме-индустрии. Он тщательнейшим образом прорисовывает пейзажи и дальние планы.\n" +
                            "В честь режиссёра был назван астероид.\n"
                        },
                        new Person
                        {
                            Name="Рюносукэ Камики",
                            OriginalName="Ryunosuke Kamiki",
                            Height="1.68 м",
                            DateOfBirthday="19/05/1993",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("19/05/1993")).TotalDays/365.2425)),
                            PlaceOfBirthday="Сайтама, Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="11-я премия Seiyu Awards, 2017 - Лучшая мужская роль («Твоё имя»)",
                            Image="https://imageup.ru/img21/3739101/ryunosuke_kamiki.jpg",
                            Description="Его отец любил поезда, и его назвали Рюносукэ" +
                            " в честь поезда. Его хобби - фотография. Он любил поезда с" +
                            " юных лет, а фотографирование поездов превратилось в хобби." +
                            " Его фотокнига «Рынок выходного дня» получила награду. " +
                            "Он близок со многими знаменитостями. Сато Такеру сказал," +
                            " что Камики - это тот, кого все любят. Несмотря на то, что" +
                            " он был более активен как актер, а не как актер озвучивания," +
                            " он довольно много участвовал в работах режиссеров, которых" +
                            " можно было бы назвать мастерами анимации. Унесенные призраками" +
                            " , Ходячий замок Хаяо Миядзаки и т.д., Летние войны Хосоды Мамору," +
                            " а также работы Синкая Макото."
                        },
                        new Person
                        {
                            Name="Монэ Камисираиси",
                            OriginalName="Mone Kamishiraishi",
                            Height="1.52 м",
                            DateOfBirthday="27/01/1998",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("27/01/1998")).TotalDays/365.2425)),
                            PlaceOfBirthday="Кагосима, Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="11-я премия Seiyu Awards, 2017 - Лучшая женская роль («Твоё имя»)",
                            Image="https://imageup.ru/img225/3739102/mone_kamishiraishi.jpg",
                            Description="Родилась в артистической семье, ее сестра Мока Камисираиси" +
                            " играет в кино и на телевидении. Работу над озвучиванием мультфильмов" +
                            " актриса начала еще в 12 лет, став «голосом» одной из второстепенных" +
                            " ролей в картине «Волчьи дети Амэ и Юки». В 2016 году она озвучила" +
                            " роль Мицухи в полнометражном мультфильме «Твое имя» режиссера Макото Синкай."
                        },
                        new Person
                        {
                            Name="Рё Нарита",
                            OriginalName="Ryo Narita",
                            Height="1.82 м",
                            DateOfBirthday="22/11/1993",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("22/11/1993")).TotalDays/365.2425)),
                            PlaceOfBirthday="Сайтама (префектура), Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="74-ю Mainichi Film Awards, 2020 - Лучшая мужская роль («Говорящие картинки»)",
                            Image="https://imageup.ru/img248/3739110/ryo_narita.jpg",
                            Description="В индустрию развлечений пришел в 2013 году" +
                            " в качестве эксклюзивной модели модного торгового бренда" +
                            " мужской одежды MEN'S NON-NO. Дебютировал как актер в 2014 году в фантастической детективной драме 'Флешбек'. " +
                            "Работа в школьном сериале 'Лестницы школы' (2015) привлекла к нему внимание зрителей. " +
                            "Имеет лицензию косметолога."
                        },
                        new Person
                        {
                            Name="Аой Юки",
                            OriginalName="Aoi Yuki",
                            Height="1.45 м",
                            DateOfBirthday="27/03/1992",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("27/03/1992")).TotalDays/365.2425)),
                            PlaceOfBirthday="Тиба (префектура), Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="Newtype Anime Awards, 2011 - Лучшая женская роль;"+
                            "6-я премия Seiyu Awards, 2012 - Лучшая женская роль («Пуэлла Маги Мадока Магика»), («Госик»), («A-Channel»)"                            ,
                            Image="https://imageup.ru/img220/3739117/aoi_yuki.jpg",
                            Description="Она пришла в индустрию развлечений в четыре года." +
                            " В детстве она снималась в фильмах и драмах. С 1999 по 2002 год" +
                            " она регулярно появлялась в развлекательных шоу Appare Sanma Dai-sensei" +
                            " и Yappari Sanma Dai-sensei, которые транслировались на Fuji TV." +
                            " В пятом классе она дебютировала как актриса озвучивания." +
                            " У нее было две роли в 2008 году, восемь в 2009 году и двенадцать в 2010 году." +
                            " В 2013 году Юки и Аяна Такетацу создали певческую группу Petit Milady."
                        },
                        new Person
                        {
                            Name="Харуо Сотодзаки",
                            OriginalName="Haruo Sotozaki",
                            DateOfBirthday="-",
                            PlaceOfBirthday="Хоккайдо, Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Режиссёр},
                            Awards="Tokyo Anime Award, 2021 - Режиссёр («Клинок, рассекающий демонов»)",
                            Image="https://imageup.ru/img109/3739209/haruo-sotozaki.jpg",
                            Description="Полнометражное аниме 'Клинок, рассекающий демонов. Бесконечный поезд'" +
                            " стало самым кассовым японским фильмом в мировом прокате, опередив «Унесённых призраками»" +
                            " Хаяо Миядзаки и собрав более 400 миллионов долларов — и это в условиях пандемии Covid-19."
                        },
                        new Person
                        {
                            Name="Коёхару Готогэ",
                            OriginalName="Koyoharu Gotouge",
                            DateOfBirthday="5/05/1989",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("5/05/1989")).TotalDays/365.2425)),
                            PlaceOfBirthday="-",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img71/3739216/koyoharu_gotouge.jpg",
                            Description="Автор и мангака 'Клинка, рассекающего демонов'." +
                            " В ноябре 2016 года Готоге начала выпускать свою первую продолжительную" +
                            " мангу Kimetsu no Yaiba('Клинок, рассекающий демонов')."
                        },
                        new Person
                        {
                            Name="Нацуки Ханаэ",
                            OriginalName="Natsuki Hanae",
                            Height="1.73 м",
                            DateOfBirthday="26/06/1991",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("26/06/1991")).TotalDays/365.2425)),
                            PlaceOfBirthday="Канагава, Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="Seiyu Awards, 2015 - Лучший начинающий актёр;" +
                            "Seiyu Awards, 2017 - «Лучшая индивидуальная работа»;" +
                            "Seiyu Awards, 2020 - Лучшая мужская роль",
                            Image="https://imageup.ru/img42/3739368/natsuki_hanae.jpg",
                            Description="Свою дебютную роль в качестве сэйю Ханаэ исполнил в 2011 году." +
                            " Первую главную роль он исполнил в аниме Tari Tari, озвучив Ацухиро Маэду, при" +
                            " этом его имя как композитора фигурировало в титрах пятой и двенадцатой серий." +
                            " В 2014 году Ханаэ исполнил множество главных ролей, среди них Инахо Кайдзука в" +
                            " Aldnoah.Zero, Кэн Канэки в Tokyo Ghoul и Косэй Арима в Shigatsu wa Kimi no Uso." +
                            " 27 августа 2016 года Ханаэ официально заявил о том, что женился."
                        },
                        new Person
                        {
                            Name="Ёсицугу Мацуока",
                            OriginalName="Yoshitsugu Matsuoka",
                            DateOfBirthday="17/09/1986",
                            Height="1.65 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("17/09/1986")).TotalDays/365.2425)),
                            PlaceOfBirthday="Хоккайдо, Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="Seiyu Awards, 2012 - Лучший начинающий актёр;" +
                            "Seiyu Awards, 2016 - «Лучший актёр в главной роли»;",
                            Image="https://imageup.ru/img192/3739467/yoshitsugu_matsuoka.jpg",
                            Description="Наиболее известен тем, что озвучивал Кирито из Sword Art Online," +
                            " Сората Канда из Домашнее животное Сакурасо, Сора из Нет игры - нет жизни, Арата Касуга" +
                            " / Астральная троица из Тринити Семь, Сома Юкихира из Food Wars !: Сёкугэки но Сома" +
                            " и Масамунэ Идзуми из Эроманга Сенсей. По состоянию на 17 июня 2019 года он является действующим" +
                            " официальным обладателем Мирового рекорда Гиннеса за самые уникальные звуковые фрагменты, предоставленные" +
                            " актером озвучивания на более чем 10 000 слов в Неправильно ли пытаться подбирать девушек в темнице?"
                        },
                        new Person
                        {
                            Name="Хиро Симоно",
                            OriginalName="Hiro Shimono",
                            DateOfBirthday="21/04/1980",
                            Height="1.68 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("21/04/1980")).TotalDays/365.2425)),
                            PlaceOfBirthday="Хоккайдо, Япония",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="Seiyu Awards, 2012 - «Лучшее исполнение песни» («Поющий принц»)",
                            Image="https://imageup.ru/img219/3739474/hiro_shimono.jpg",
                            Description="Его известные роли включают Кейма Кацураги в Мир, который знает только Бог," +
                            " Конни Спрингер в Атака Титана , Най в Карневал , Аято Камина в Рахксефон, Акихиса Ёсии" +
                            " в Бака и испытание: Призыв зверей, Норифуми Каваками в Бриллиантовом тузе, Сатоши Мотида" +
                            " в серии Corpse Party , Сё Курусу в Ута но принц-сама сериал и Зеницу Агацума в Demon Slayer:" +
                            " Kimetsu no Yaiba."
                        },
                        new Person
                        {
                            Name="Сатоси Хино",
                            OriginalName="Satoshi Hino",
                            DateOfBirthday="4/08/1978",
                            Height="1.7 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("4/08/1978")).TotalDays/365.2425)),
                            PlaceOfBirthday="Сан-Франциско, Калифорния, США",
                            Spouse="Саки Накадзима",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="Seiyu Awards, 2012 - «Лучшее исполнение песни» («Поющий принц»)",
                            Image="https://imageup.ru/img226/3739477/satoshi_hino.jpg",
                            Description="Хино родился в США и вырос в Токио . Он жил в Сан-Франциско до пяти лет." +
                            " В подростковом возрасте он был участником Детской театральной труппы. Изначально Хино" +
                            " стремился стать театральным актером, но после его участия в дубляже американского" +
                            " драматического телесериала « Скорая помощь» он изменил свои цели, чтобы всерьез" +
                            " стать актером озвучивания . В 2001 году он сыграл свою первую главную роль в роли" +
                            " Эдди в зарубежной драме « Ванда Эдди», которую транслировали на канале NHK Educational" +
                            " TV . Хотя изначально он не знал о связи дубляжа с аниме, он был приглашен на прослушивание," +
                            " и в конечном итоге получил роль в Икки Тоусене , работе, в которой принимал участие режиссер" +
                            " дубляжа. Хино выступал в качестве актера озвучивания в различных областях, таких как дубляж," +
                            " анимация, игры и повествование. До июня 2011 года он был связан с Production Baobab . С июля" +
                            " 2011 года Hino присоединилась к Axl-One."
                        },
                        new Person
                        {
                            Name="Олег Трофим",
                            OriginalName="Трофим Олег Борисович",
                            DateOfBirthday="12/10/1989",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("12/10/1989")).TotalDays/365.2425)),
                            PlaceOfBirthday="Нарьян-Мар, СССР (Россия)",
                            Spouse="Виктория",
                            RolesInMedia = new RoleInFilm[2]{ RoleInFilm.Режиссёр,RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img50/3739738/oleg-trofim.jpg",
                            Description="Стал автором и продюсером самого первого клипа группы «DownCast»" +
                            " под названием «Немое кино». С февраля 2007 года музыкальное семейство ежегодно" +
                            " устраивало концерты в клубе авторской песни «Арктика» в Ненецком Автономном Округе." +
                            " В 2012 году Олег окончил Санкт-Петербургский государственный университет кино и телевидения" +
                            " по специальности «Режиссура кино и телевидения», мастерскую Владимира Смирнова и Олега Рябоконя." +
                            " К тому времени молодой человек уже снял около полусотни музыкальных клипов для петербургских" +
                            " музыкантов. В 2017 году дебютировал в большом кино - фильм «Лёд». Режиссировал фильм «Майор Гром:" +
                            " Чумной доктор» после ухода Владимира Беседина с поста режиссёра картины и главы Bubble Studios."
                        },
                        new Person
                        {
                            Name="Артем Габрелянов",
                            OriginalName="Габрелянов Артем Арамович",
                            DateOfBirthday="9/02/1987",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("9/02/1987")).TotalDays/365.2425)),
                            PlaceOfBirthday="Москва, СССР (Россия)",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img195/3739750/artem_gabrelianov.jpg",
                            Description="Основал в 2011 году Bubble Comics как подразделение медиакомпании «News Media Holdings»." +
                            " Со временем Артём Габрелянов решил, что издательству стоит отказаться от юмористических комиксов" +
                            " в пользу приключенческих и супергеройских. Является автором комиксов и графических романов Бесобой," +
                            " Майор Гром, Красная Фурия, Время ворона, Инок и Метеора."
                        },
                        new Person
                        {
                            Name="Роман Котков",
                            OriginalName="Котков Роман Игоревич",
                            DateOfBirthday="28/04/1987",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("28/04/1987")).TotalDays/365.2425)),
                            PlaceOfBirthday="Москва, СССР (Россия)",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img137/3739752/roman-kotkov.jpg",
                            Description="Главный редактор издательства Bubble, ранее выпускающий редактор." +
                            " Креативный продюссер и сценарист ожидаемого фильма «Майор Гром: Чумной доктор»." +
                            " Работает в издательстве с 2014 года. Сперва выпускающим редактором, с 1 октября 2015" +
                            " — главным редактором. Обсуждает варианты развития серий и в живую прорабатывает с авторами" +
                            " диалоги. Является администратором сайта spidermedia.ru. Иногда пишет статьи о комиксах."
                        },
                        new Person
                        {
                            Name="Тихон Жизневский",
                            OriginalName="Жизневский Тихон Игоревич",
                            DateOfBirthday="30/08/1988",
                            Height="1.91 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("30/08/1988")).TotalDays/365.2425)),
                            PlaceOfBirthday="Зеленоградск, Калининградская область, СССР (Россия)",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Image="https://imageup.ru/img100/3739753/tikhon-zhiznevskii.jpg",
                            Description="В 2009 году окончил ВТУ им. Щукина, курс Марии Пантелеевой и Валерия Фокина." +
                            " С 2009 года работал актёром Александринского театра. Дебютом в Александринском театре" +
                            " стал ввод на роль участника хора фиванцев в спектакль «Эдип-царь» Софокла (реж. Т. Терзопулос)."
                        },
                        new Person
                        {
                            Name="Любовь Аксенова",
                            OriginalName="Аксенова Любовь Павловна",
                            DateOfBirthday="15/03/1990",
                            Height="1.75 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("15/03/1990")).TotalDays/365.2425)),
                            PlaceOfBirthday="Москва, СССР (Россия)",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Spouse="Павел Аксенов",
                            Image="https://imageup.ru/img194/3739757/liubov-aksenova.jpg",
                            Description="В 2010 году окончила РАТИ-ГИТИС, мастерская А.И. Шейнина. В 2019 году стала" +
                            " самой популярной актрисой года по версии сайта Кино-театр.ру. В 2019 году заняла второе место в ежегодном" +
                            " рейтинге самых сексуальных женщин России, публикуемом журналом «Maxim»."
                        },
                        new Person
                        {
                            Name="Алексей Маклаков",
                            OriginalName="Маклаков Алексей Константинович",
                            DateOfBirthday="6/01/1961",
                            Height="1.75 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("6/01/1961")).TotalDays/365.2425)),
                            PlaceOfBirthday="Тамбов, СССР (Россия)",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Spouse="Анна Романцева",
                            Awards="«Заслуженный артист Российской Федерации»",
                            Image="https://imageup.ru/img109/3739765/aleksei-maklakov.jpg",
                            Description="Окончил Новосибирское театральное училище. Известность приобрёл благодаря роли прапорщика Шматко в телесериале «Солдаты»." +
                            " Болельщик футбольного клуба «Спартак» (Москва)."
                        },
                        new Person
                        {
                            Name="Сергей Горошко",
                            OriginalName="Горoшко Сергей Дмитриевич",
                            DateOfBirthday="7/07/1997",
                            Height="1.83 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("7/07/1997")).TotalDays/365.2425)),
                            PlaceOfBirthday="Дзержинск, Нижегородская область, Россия",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Актёр},
                            Awards="Лауреат высшей театральной премии Санкт-Петербурга «Золотой софит»",
                            Image="https://imageup.ru/img171/3739768/sergei-goroshko.jpg",
                            Description="В период с 2016 по 2020 год обучался в Российском государственном институте сценических" +
                            " искусств в мастерской В. Фильштинского. Является соавтором театрального проекта FULCRO, состоящего" +
                            " из команды актеров, выпускников петербургской театральной мастерской В. М. Фильштинского."
                        },
                        new Person
                        {
                            Name="Пит Доктер",
                            OriginalName="Pete Docter",
                            DateOfBirthday="10/08/1968",
                            Height="1.94 м",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("10/08/1968")).TotalDays/365.2425)),
                            PlaceOfBirthday="Блумингтон, Миннесота, США",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Сценарист, RoleInFilm.Режиссёр, RoleInFilm.Актёр},
                            Spouse="Аманда Доктер",
                            Awards="Оскар, 2021 год - Лучший анимационный фильм («Душа»); " +
                            "Британская академия, 2021 год - Лучший анимационный фильм («Душа»); " +
                            "Оскар, 2016 год - Лучший анимационный фильм («Головоломка»); " +
                            "Сатурн, 2016 год - Лучший анимационный фильм («Головоломка»); " +
                            "Оскар, 2010 год - Лучший анимационный фильм («Вверх»); " +
                            "Британская академия, 2010 год - Лучший анимационный фильм («Вверх»); " +
                            "Венецианский кинофестиваль, 2009 год - Премия Future Film Festival Digital Award - особое упоминание («Вверх»)",
                            Image="https://imageup.ru/img114/3739806/pit-dokter.jpg",
                            Description="Самые известные фильмы, над которыми он работал — «Корпорация монстров», «Вверх»," +
                            " «Головоломка», «Душа». Также он ключевая фигура и сотрудник студии Pixar. Был шесть раз номинирован" +
                            " на соискание премии «Оскара», трижды — на Annie Awards, из них выиграл две, и по разу на BAFTA Children’s" +
                            " Film Award (выиграл) и Hochi Film Award (выиграл). Пит Доктер — фанат аниме, и одно время работал с Хаяо Миядзаки." +
                            " Сам себя он называет «малыш из Миннесоты, который любит рисовать мультфильмы». Начал работать в Pixar с 21 года. Он также" +
                            " является поклонником работы, проделанной его конкурентами из DreamWorks . Говоря о конкурентной среде, он сказал:" +
                            " «Я думаю, что это гораздо более здоровая среда, когда больше разнообразия»."
                        },
                        new Person
                        {
                            Name="Майк Джонс",
                            OriginalName="Mike Jones",
                            DateOfBirthday="1/06/1971",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("1/06/1971")).TotalDays/365.2425)),
                            PlaceOfBirthday="Сан-Антонио, Техас, США",
                            RolesInMedia = new RoleInFilm[1]{ RoleInFilm.Сценарист},
                            Image="https://imageup.ru/img25/3739826/mike-jones.jpg",
                            Description="Он начал свою карьеру в качестве журналиста-развлекателя, работая" +
                            " управляющим редактором Filmmaker Magazine и исполнительным редактором IndieWire. Его первый сценарий, EvenHand," +
                            " был снят в 2001 г. и показанный на AFI Film Festival, Tribeca Film Festival и South by Southwest." +
                            " Джонс сделал некредитованный переписанный фильм City of Ghosts, режиссер Мэтт Диллон, и с тех пор" +
                            " написал сценарии для Columbia Pictures, United Artists, HBO, Warner Bros. Pictures, Sony Pictures Animation," +
                            " Fox Searchlight и Metro-Goldwyn-Mayer."
                        },
                        new Person
                        {
                            Name="Джейми Фокс",
                            OriginalName="Eric Marlon Bishop",
                            Height="1.75 м",
                            DateOfBirthday="13/12/1967",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("13/12/1967")).TotalDays/365.2425)),
                            PlaceOfBirthday="Террелл, Техас, США",
                            RolesInMedia = new RoleInFilm[3]{ RoleInFilm.Актёр, RoleInFilm.Сценарист,RoleInFilm.Режиссёр },
                            Awards="Премия канала «MTV», 2013 год - Самый безумный эпизод («Джанго освобожденный»); " +
                            "Оскар, 2005 год - Лучшая мужская роль («Рэй»); " +
                            "Золотой глобус, 2005 год - Лучшая мужская роль (комедия или мюзикл) («Рэй»); " +
                            "Британская академия, 2005 год - Лучшая мужская роль («Рэй»); " +
                            "Премия Гильдии актеров, 2005 год - Лучшая мужская роль («Рэй»)",
                            Image="https://imageup.ru/img208/3739831/dzheimi-foks.jpg",
                            Description="В 1994 году он записал свой первый альбом (на студии FOX) Peep This," +
                            " а в 2001 году получил престижную премию MTV Video Music Awards. Фокс сменил имя во" +
                            " время участия в stand-up comedy, после того как узнал, что женщин-комедиантов" +
                            " приглашали выступать первыми. Он выбрал себе имя в честь другого известного комика — Реда Фокса." +
                            " В сентябре 2007 года была заложена звезда Джейми Фокса на Голливудской «Аллее славы»." +
                            " После церемонии Джейми сказал: «Это был один из самых замечательных дней в моей жизни!»"
                        },
                        new Person
                        {
                            Name="Тина Фей",
                            OriginalName="Elizabeth Stamatina Fey",
                            Height="1.64 м",
                            DateOfBirthday="18/05/1970",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("18/05/1970")).TotalDays/365.2425)),
                            PlaceOfBirthday="Аппер Дерби, Пенсильвания, США",
                            Spouse="Джефф Ричмонд",
                            RolesInMedia = new RoleInFilm[2]{ RoleInFilm.Актёр, RoleInFilm.Сценарист},
                            Awards="Эмми, 2016 год - Лучшая приглашенная актриса в комедийном сериале («Saturday Night Live»); " +
                            "Премия Гильдии актеров, 2013 год - Лучшая актриса комедийного сериала («Студия 30»); " +
                            "Золотой глобус, 2009 год - Лучшая женская роль на ТВ (комедия или мюзикл) («Студия 30»); " +
                            "Эмми, 2009 год - Лучший комедийный сериал («Студия 30»), Лучшая приглашенная актриса в комедийном сериале («Saturday Night Live»); " +
                            "Премия Гильдии актеров, 2009 год - Лучший актерский состав комедийного сериала («Студия 30»), Лучшая актриса комедийного сериала («Студия 30»); " +
                            "Золотой глобус, 2008 год - Лучшая женская роль на ТВ (комедия или мюзикл) («Студия 30»); " +
                            "Эмми, 2008 год - Лучший комедийный сериал («Студия 30»), Лучшая женская роль в комедийном сериале («Студия 30»); " +
                            "Премия Гильдии актеров, 2008 год - Лучшая актриса комедийного сериала («Студия 30»); " +
                            "Эмми, 2007 год - Лучший комедийный сериал («Студия 30»)",
                            Image="https://imageup.ru/img144/3739834/tina-fei.jpg",
                            Description="В 1992 году Фей с отличием окончила Виргинский университет, получив степень бакалавра в области театрального искусства. " +
                            "У неё греческие, немецкие и шотландские корни. " +
                            "В 2006 году, по окончании контракта, Тина покинула шоу «Субботним вечером в прямом эфире» ради своего собственного детища" +
                            " — ситкома «Студия 30», в котором она является автором сценария и исполнительницей главной роли. Композитором проекта стал" +
                            " её супруг — Джефф Ричмонд. Шоу было восторженно принято зрителями и критиками и шло на NBC семь сезонов."
                        },
                        new Person
                        {
                            Name="Грэм Нортон",
                            OriginalName="Graham William Walker",
                            Height="1.73 м",
                            DateOfBirthday="4/04/1963",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("4/04/1963")).TotalDays/365.2425)),
                            PlaceOfBirthday="Дублин, Ирландия",
                            RolesInMedia = new RoleInFilm[2]{ RoleInFilm.Актёр, RoleInFilm.Сценарист },
                            Awards="British Academy Television Awards, 2000-2002 - Лучшее развлекательное выступление («Итак, Грэм Нортон»); " +
                            "Royal Television Society, 2001 - 	Лучший ведущий («Итак, Грэм Нортон»); " +
                            "British Academy Television Awards, 2011,2012,2018 - Лучшее развлекательное выступление («Шоу Грэма Нортона»); " +
                            "British Academy Television Awards, 2013 - Премия Lew Grade Award за развлекательную программу («Шоу Грэма Нортона»); " +
                            "British Academy Television Awards, 2015 - Лучшая комедийная программа или Серия («Шоу Грэма Нортона»); " +
                            "Национальная телевизионная премия, 2017 - Специальная награда («Шоу Грэма Нортона»)",
                            Image="https://imageup.ru/img242/3739839/graham-walker.jpg",
                            Description="В июне 2013 он получил почётную докторскую степень от Ирландского национального университета. " +
                            "Первое появление Нортона в радиовещании произошло в Великобритании, где он получил" +
                            " место постоянного комика на BBC Radio 4 в шоу Loose Ends, которое выходило утром по субботам. Нортон — открытый гей."
                        },
                        new Person
                        {
                            Name="Анджела Бассетт",
                            OriginalName="Angela Bassett",
                            Height="1.63 м",
                            DateOfBirthday="16/08/1958",
                            Age=Convert.ToInt32(Math.Truncate((DateTime.Now.Date-Convert.ToDateTime("16/08/1958")).TotalDays/365.2425)),
                            PlaceOfBirthday="Гарлем, Нью-Йорк, США",
                            RolesInMedia = new RoleInFilm[2]{ RoleInFilm.Актёр, RoleInFilm.Режиссёр },
                            Spouse="Кортни Б. Вэнс",
                            Awards="Премия Гильдии актеров, 2019 год - Лучший актерский состав («Чёрная Пантера»); " +
                            "Сатурн, 1996 год - Лучшая актриса («Странные дни»); " +
                            "Золотой глобус, 1994 год - Лучшая женская роль (комедия или мюзикл) («На что способна любовь»)",
                            Image="https://imageup.ru/img289/3739940/andzhela-bassett.jpg",
                            Description="В 1980 году Анджела Бассетт закончила Йельский университет и получила" +
                            " степень бакалавра по специальности «афро-американские исследования». В 1983 году" +
                            " она также получила степень магистра изобразительных искусств в Йельской драматической" +
                            " школе, несмотря на протесты со стороны отца, который не хотел чтобы она тратила своё" +
                            " образование на театр. Анджела стала первой в своей семье, кто учился в колледже и аспирантуре" +
                            ". В Йеле Бассетт встретила своего будущего мужа, актёра Кортни Б. Вэнса. В 1986 году она окончила" +
                            " театральное училище, одноклассником Анджелы был актёр Чарльз Стэнли Даттон. В 1986 году Анджела Бассетт" +
                            " впервые появилась на киноэкране, в роли репортёра в фильме «Иллюзия убийства» (1986), после этой роли" +
                            " она присоединилась к гильдии киноактёров." +
                            " Обладательница именной звезды на Голливудской «Аллее Славы» за вклад в мировой кинематограф. "
                        },
                    };
                    persons = new Dictionary<string, Person>();
                    foreach (Person el in list)
                        persons.Add(el.Name, el);
                }
                return persons;
            }
        }


    }
}



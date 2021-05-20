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
                        },
                        Casts=new List<Cast>()
                        {
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Режиссёр,
                                Person=Persons["Роберт Данкан МакНил"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Режиссёр,
                                Person=Persons["Джей Чандрашекхар"]
                            },
                             new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Крис Шеридан"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Алан Тьюдик"],
                                Character="Harry Vanderspeigle"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Сара Томко"],
                                Character="Asta Twelvetrees"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Кори Рейнольдс"],
                                Character="Sheriff Mike Thompson"
                            }
                        }
                    },
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
                            Character="Kyojuro Rengoku, озвучка"
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
                        Genres = new List<Genre>() { Genres["Мультфильм"], Genres["Фэнтези"], Genres["Комедия"],
                            Genres["Приключения"], Genres["Семейный"], Genres["Музыка"] },
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
                        },
                        Casts = new List<Cast>()
                        {
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Режиссёр,
                                Person=Persons["Джонас Пейт"]
                            },                           
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Шеннон Берк"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Чейз Стоукс"],
                                Character="John B"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Мэдлин Клайн"],
                                 Character="Sarah Cameron"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Руди Панкоу"],
                                Character="JJ"
                            }
                        }
                    }, 
                    new Media
                    {
                        MediaType = MediaType.Serial,
                        Name = "Клинок, рассекающий демонов",
                        NumOfSeason = 1,
                        NumOfEpisodes = 26,
                        Img = "https://imageup.ru/img234/3733520/demonslayer.jpg",
                        Video = "https://www.youtube.com/embed/uz_Wg-0ulpk",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#playlist/laferacis/1022",
                        Year = 2019,
                        Country = "Япония",
                        Age = 18,
                        Score = 8.073,
                        Release_Date = "6 апреля 2019",
                        Runtime = "25 мин. серия",
                        ShortDescription = "Тем, кто не выдержал и сдался, остается лишь смотреть на успехи других!",
                        Description = "Эпоха Тайсё. Ещё с древних времён ходят слухи, что в лесу обитают человекоподобные" +
                        " демоны, которые питаются людьми и выискивают по ночам новых жертв. Тандзиро Камадо — старший" +
                        " сын в семье, потерявший отца и взявший на себя заботу о родных. Однажды он уходит в соседний город," +
                        " чтобы продать древесный уголь. Вернувшись утром, парень обнаруживает перед собой страшную картину:" +
                        " вся родня зверски убита, а единственная выжившая - младшая сестра Нэдзуко, обращённая в демона," +
                        " но пока не потерявшая человечность. С этого момента начинается долгое и опасное путешествие Тандзиро" +
                        " и Нэдзуко, в котором мальчик намерен разыскать убийцу и узнать способ исцеления сестры.",
                        ScoreKP = "https://rating.kinopoisk.ru/1220920.gif",
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
                            Person = Persons["Кайл Маккарли"]
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
                            Person = Persons["Такахиро Сакурай"],
                            Character="Giyu Tomioka, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Сатоси Хино"],
                            Character="Kyojuro Rengoku, озвучка"
                            },
                            new Cast
                            {
                            RoleInFilm = RoleInFilm.Актёр,
                            Person = Persons["Аой Юки"],
                            Character="Kiriya Ubuyashiki, озвучка"
                            }
                        },
                        Images = new List<MediaImages>()
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img93/3740187/kl1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img117/3740189/kl2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img37/3740190/kl3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img72/3740192/kl4.jpg"
                            }
                        }
                    },
                    new Media
                    {
                        MediaType = MediaType.Serial,
                        Name = "Неуязвимый",
                        NumOfSeason = 1,
                        NumOfEpisodes = 8,
                        Img = "https://imageup.ru/img112/3732606/invingible.jpg",
                        Video = "https://www.youtube.com/embed/oBD-7njwAsQ",
                        SoundTrackUrl = "https://music.yandex.ru/iframe/#playlist/gromsserg/1011",
                        Year = 2021,
                        Country = "США",
                        Age = 18,
                        Score = 8.368,
                        Release_Date = "26 марта 2021",
                        Runtime = "45 мин. серия",
                        ShortDescription = "Основано на комиксах Роберта Киркмана",
                        Description = "Сюжет посвящен обычному старшекласснику Марку Грэйсону," +
                        " подрабатывающему после школы и ведущему вполне нормальную жизнь. За и сключением" +
                        " одного момента: отец Марка, Норман, является самым могущественным супергероем на планете" +
                        " по прозвищу Омни-мэн. В возрасте 17 лет Марк обнаруживает, что способности отца передались" +
                        " ему по наследству, поскольку Норман принадлежит к расе Вильтрумитов — первооткрывателей галактики," +
                        " прибывших с благожелательной и просветительской миссией.",
                        ScoreKP = "https://rating.kinopoisk.ru/1171895.gif",
                        Genres = new List<Genre>() { Genres["Мультфильм"], Genres["Ужасы"], Genres["Фантастика"], Genres["Фэнтези"],
                            Genres["Боевик"], Genres["Триллер"], Genres["Драма"], Genres["Приключения"], },
                        Images = new List<MediaImages>
                        {
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img162/3740236/inv1.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img165/3740237/inv2.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img140/3740239/inv3.jpg"
                            },
                            new MediaImages
                            {
                                ImagesUrl ="https://imageup.ru/img237/3740240/inv4.jpg"
                            }
                        },
                        Casts = new List<Cast>()
                        {
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Режиссёр,
                                Person=Persons["Джефф Аллен"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Сценарист,
                                Person=Persons["Роберт Киркман"]
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Стивен Ён"],
                                Character="Mark Grayson / Invincible"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Сандра О"],
                                Character="Debbie Grayson"
                            },
                            new Cast
                            {
                                RoleInFilm=RoleInFilm.Актёр,
                                Person=Persons["Дж.К. Симмонс"],
                                Character="Nolan Grayson / Omni-Man"
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
                        new Genre { Genre_Name = "Биография", NumOfGenre=2},
                        new Genre { Genre_Name = "Боевик", NumOfGenre=3},
                        new Genre { Genre_Name = "Вестерн", NumOfGenre=4},
                        new Genre { Genre_Name = "Военный", NumOfGenre=5},
                        new Genre { Genre_Name = "Детектив", NumOfGenre=6},
                        new Genre { Genre_Name = "Документальный", NumOfGenre=7},
                        new Genre { Genre_Name = "Драма", NumOfGenre=8},
                        new Genre { Genre_Name = "Комедия", NumOfGenre=9},
                        new Genre { Genre_Name = "Криминал", NumOfGenre=10},
                        new Genre { Genre_Name = "Мелодрама", NumOfGenre=11},
                        new Genre { Genre_Name = "Музыка", NumOfGenre=12},
                        new Genre { Genre_Name = "Мультфильм", NumOfGenre=13},
                        new Genre { Genre_Name = "Мюзикл", NumOfGenre=14},
                        new Genre { Genre_Name = "Приключения", NumOfGenre=15},
                        new Genre { Genre_Name = "Семейный", NumOfGenre=16},
                        new Genre { Genre_Name = "Триллер", NumOfGenre=17},
                        new Genre { Genre_Name = "Ужасы", NumOfGenre=18},
                        new Genre { Genre_Name = "Фантастика", NumOfGenre=19},
                        new Genre { Genre_Name = "Фэнтези", NumOfGenre=20}
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
                            PlaceOfBirthday="Грин Бэй, Висконсин, США",
                            Spouse="Дебора Снайдер",
                            Awards="Сатурн, 2008 - Лучший режиссер («300 спартанцев»)",
                            RolesInMedia = "Режиссёр, Сценарист, Актёр",
                            Image="https://imageup.ru/img214/3736505/zack_snyder.jpg",
                            Description="В марте 2017 года дочь Снайдера Отем покончила с собой.\n" +
                            "Зак с Деборой воспитывают семерых детей, двое из которых являются приемными."
                        },
                        new Person{
                            Name="Бен Аффлек",
                            OriginalName="Benjamin Geza Affleck-Boldt",
                            Height="1.92 м",
                            DateOfBirthday="15/08/1972",                            
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
                            RolesInMedia = "Актёр, Режиссёр, Сценарист",
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
                            PlaceOfBirthday = "Петах-Тиква, Израиль",
                            Spouse="Ярон Версано",
                            Awards="Премия канала «MTV», 2018 - Лучшая драка («Чудо-женщина»);" +
                            "Сатурн, 2018 - Лучшая актриса («Чудо-женщина»)",
                            RolesInMedia = "Актриса, Сценарист",
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
                            PlaceOfBirthday="Сент-Сейвьер, Джерси, Нормандские острова",
                            Awards="Золотая малина, 2017 - Худший экранный ансамбль («Бэтмен против Супермена: На заре справедливости»);" +
                            "Премия канала «MTV», 2014 - Лучший герой («Человек из стали»)",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Гонолулу, Гавайи, США",
                            Spouse="Лиза Боне",
                            Awards="CinemaCon, 2011 - Восходящая звезда",
                            RolesInMedia = "Актёр, Режиссёр, Сценарист",
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
                            PlaceOfBirthday="Хобокен, Нью-Джерси, США",
                            Awards="Каннский кинофестиваль, 2012 - Приз компании «Шопар» лучшему молодому актеру",
                            RolesInMedia = "Актёр, Режиссёр,Сценарист",
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
                            PlaceOfBirthday="Балтимор, Мэрилэнд, США",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Нью-Йорк, США",
                            Awards="Золотая малина, 2017 - Худший сценарий («Бэтмен против Супермена: На заре справедливости»);" +
                            "Оскар, 2013 - Лучший адаптированный сценарий («Операция «Арго»»)",
                            RolesInMedia = "Сценарист, Режиссёр, Актёр",
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
                            PlaceOfBirthday="Коуми, Нагано (префектура), Япония",
                            Spouse="Мисака Тиэко",
                            RolesInMedia = "Режиссёр, Сценарист, Актёр",
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
                            PlaceOfBirthday="Сайтама, Япония",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Кагосима, Япония",
                            RolesInMedia = "Актриса",
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
                            PlaceOfBirthday="Сайтама (префектура), Япония",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Тиба (префектура), Япония",
                            RolesInMedia = "Актриса",
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
                            RolesInMedia = "Режиссёр",
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
                            PlaceOfBirthday="-",
                            RolesInMedia = "Сценарист",
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
                            PlaceOfBirthday="Канагава, Япония",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Хоккайдо, Япония",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Хоккайдо, Япония",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Сан-Франциско, Калифорния, США",
                            Spouse="Саки Накадзима",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Нарьян-Мар, СССР (Россия)",
                            Spouse="Виктория",
                            RolesInMedia = "Режиссёр, Сценарист",
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
                            PlaceOfBirthday="Москва, СССР (Россия)",
                            RolesInMedia = "Сценарист",
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
                            PlaceOfBirthday="Москва, СССР (Россия)",
                            RolesInMedia = "Сценарист",
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
                            PlaceOfBirthday="Зеленоградск, Калининградская область, СССР (Россия)",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Москва, СССР (Россия)",
                            RolesInMedia = "Актриса",
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
                            PlaceOfBirthday="Тамбов, СССР (Россия)",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Дзержинск, Нижегородская область, Россия",
                            RolesInMedia = "Актёр",
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
                            PlaceOfBirthday="Блумингтон, Миннесота, США",
                            RolesInMedia = "Сценарист, Режиссёр, Актёр",
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
                            PlaceOfBirthday="Сан-Антонио, Техас, США",
                            RolesInMedia = "Сценарист",
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
                            PlaceOfBirthday="Террелл, Техас, США",
                            RolesInMedia = "Актёр, Сценарист, Режиссёр",
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
                            PlaceOfBirthday="Аппер Дерби, Пенсильвания, США",
                            Spouse="Джефф Ричмонд",
                            RolesInMedia = "Актриса, Сценарист",
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
                            PlaceOfBirthday="Дублин, Ирландия",
                            RolesInMedia = "Актёр, Сценарист",
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
                            PlaceOfBirthday="Гарлем, Нью-Йорк, США",
                            RolesInMedia = "Актриса, Режиссёр",
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
                        new Person
                        {
                            Name="Кайл Маккарли",
                            OriginalName="Kyle McCarley",
                            DateOfBirthday="5/12/1985",
                            Height="1.83 м",                            
                            PlaceOfBirthday="Иллинойс, США",
                            Spouse="Кэтлин Голт",
                            RolesInMedia = "Актёр, Сценарист",
                            Awards="BTVA Video Game Voice Acting Award - Лучший вокальный ансамбль в видеоигре («NieR: Automata (2017)»)," +
                            " Лучшее мужское вокальное исполнение в видеоигре («NieR: Automata (2017)»); " +
                            "BTVA People's Choice Voice Acting Award, 2018 - Лучший вокальный ансамбль в видеоигре («NieR: Automata (2017)»); " +
                            "BTVA People's Choice Voice Acting Award, 2016 - Лучший вокальный ансамбль в Аниме-телесериале/OVA («Durarara!!x2»)",                            
                            Image="https://imageup.ru/img242/3740208/kail-makkarli.jpg",
                            Description="В аниме он известен как голос Сигео Кагеямы из Mob Psycho 100," +
                            " Микадзуки Августа из Mobile Suit Gundam: Iron-Blooded Orphans, Синдзи Мато из Fate / stay ночь:" +
                            " Unlimited Blade Works, Риота Ватари из Your Lie in April, Килли из Blame, Наранча Гирга из Причудливое" +
                            " приключение Джоджо: Vento Aureo, Джо Шимамура из Киборг 009: Зов правосудия и Хельбрам из Семь" +
                            " смертных грехов. В видеоиграх он известен своими выступлениями в роли главных персонажей" +
                            " 9S из Nier: Automata, Зерокена из Disgaea 5, Альма в Fire Emblem Echoes: Shadows of Valentia," +
                            " Привратник в Fire Emblem: Three Houses и Гарри Поттер в Harry Potter: Wizards Unite."
                        },
                        new Person
                        {
                            Name="Такахиро Сакурай",
                            OriginalName="Takahiro Sakurai",
                            Height="1.76 м",
                            DateOfBirthday="13/06/1974",                            
                            PlaceOfBirthday="Окадзаки, Айти (префектура), Япония",
                            RolesInMedia = "Актёр",
                            Awards="Seiyu Awards, 2012 - «Премия зарубежных поклонников»",
                            Image="https://imageup.ru/img89/3740211/takakhiro-sakurai.jpg",
                            Description="Известные роли, которые сыграл Сакурай, включают Тентомона из серии Digimon Adventure," +
                            " Зомби из One Punch Man, Стинга Эвклифа из Fairy Tail, Сасори из Наруто Шиппуден, Клауд Страйф в" +
                            " Сборник Final Fantasy VII, Томиока Гиюу из Клинок, рассекающий демонов и Осомацу Мацуно" +
                            " из Mr. Osomatsu. Сотрудничал с агентством развлечений 81 Produce," +
                            " с 20 июля 2014 года состоит в агентстве INTENTION, учреждённом одним" +
                            " из его хороших друзей, сэйю Кэнъити Судзумурой."
                        },
                        new Person
                        {
                            Name="Роберт Данкан МакНил",
                            OriginalName="Robert Duncan McNeill",
                            DateOfBirthday="9/11/1964",
                            Height="1.85 м",
                            PlaceOfBirthday="Роли, Северная Каролина, США",
                            RolesInMedia="Режиссер, Актер, Продюсер, Сценарист",                            
                            Image="https://imageup.ru/img232/3743274/robert-dankan-maknil.jpg",
                            Awards="New York International Independent Film & Video Festival, 1999 - Лучший короткометражный фильм («Батарея»)",
                            Description="Макнил начал свою режиссерскую карьеру с нескольких эпизодов «Вояджера»." +
                            " Затем он написал, продюсировал и снял два отмеченных наградами короткометражных фильма," +
                            " «Батарея» и « 9 мм любви», а также стал режиссером других эпизодических телешоу." +
                            " С тех пор он выступал в качестве приглашенной звезды в телевизионных шоу, таких как The Outer Limits и Crossing Jordan." +
                            " Макнил сосредоточился на своей режиссерской карьере, руководя эпизодами «Бухта Доусона», «Эвервуд»," +
                            " «Звездный путь: Энтерпрайз», «Мертвый, как я», «Одинокие сердца», «Холм одного дерева», «Лас-Вегас»," +
                            " «Саммерленд» и «Сверхъестественное». Его режиссерские работы в 2006–2007 годах включают эпизоды «Отчаянных домохозяек»," +
                            " « Средний» , «Противостояние» , «Девять» , «Рыцари процветания», « В случае чрезвычайной ситуации»," +
                            " « Что насчет Брайана» и « Мои мальчики»."
                        },
                        new Person
                        {
                            Name="Джей Чандрашекхар",
                            OriginalName="Jayanth Jambulingam Chandrasekhar",
                            DateOfBirthday="9/04/1968",
                            Height="1.84 м",
                            PlaceOfBirthday="Чикаго, Иллинойс, США",
                            RolesInMedia="Режиссер, Актер, Сценарист, Продюсер, Монтажер",
                            Spouse="Сьюзэн Кларк",
                            Image="https://imageup.ru/img99/3743671/dzhei-chandrashekkhar.jpg",
                            Awards="CinEuphoria Awards, 2020 - Merit - Honorary Award («Голдберги»); " +
                            "OFTA Television Award, 2012 - Лучшая режиссура в комедийном сериале («Сообщество»); " +
                            "SXSW Film Festival, 2001 - Полночные фильмы («Суперполицейские»)" +
                            "Hamptons International Film Festival, 1996 - Лучший американский независимый фильм («Puddle Cruiser»);",
                            Description="Известен по сериалам «Сообщество» (2009 – 2015) и «Реальные пацаны» (2010 – 2011)," +
                            " «Чак» (2007 – 2012), «Задержка в развитии» (2003) и «Новенькая» (2011 – 2018), а также по фильмам «Суперполицейские» (2001)," +
                            " «Клуб страха» (2004), «Детородные» (2012) и «Суперполицейские 2» (2018). В 2005 году Чандрасекхар поставил Герцогов Хаззарда. Комедийный боевик" +
                            " по мотивам одноименного американского телесериала 1970-х стал дебютом поп-певицы Джессики Симпсон как актрисы. Несмотря на финансовый успех," +
                            " фильм получил негативные отзывы критиков. Он стал признанным режиссером телевизионных комедий, снимая эпизоды Undeclared," +
                            " Happy Endings, Chuck, Community, Psych и Задержка развития. Он говорит, что чем раньше режиссер" +
                            " присоединяется к шоу, тем большее влияние он или она окажет на его внешний вид."
                        },
                        new Person
                        {
                            Name="Алан Тьюдик",
                            OriginalName="Alan Wray Tudyk",
                            DateOfBirthday="16/03/1971",
                            Height="1.8 м",
                            PlaceOfBirthday="Эль-Пасо, Техас, США",
                            RolesInMedia="Актер, Режиссер, Сценарист, Продюсер",
                            Spouse="Чарисса Бартон",
                            Image="https://imageup.ru/img52/3743689/alan-tiudik.jpg",
                            Awards="BTVA People's Choice Voice Acting Award, 2017 - Лучший вокальный ансамбль в телесериале («Звёздная принцесса и силы зла»); " +
                            "BTVA People's Choice Voice Acting Award, 2017 - Лучший вокальный ансамбль в художественном фильме («Моана»); " +
                            "BTVA People's Choice Voice Acting Award, 2017 - Лучшее мужское вокальное исполнение в художественном фильме («Изгой-один: Звёздные войны. Истории»); " +
                            "BTVA People's Choice Voice Acting Award, 2014 - Лучший вокальный ансамбль в художественном фильме («Холодное сердце»); " +
                            "BTVA Feature Film Voice Acting Award, 2014 - Лучший вокальный ансамбль в художественном фильме («Холодное сердце»); " +
                            "BTVA Feature Film Voice Acting Award, 2013 - Лучший вокальный ансамбль в художественном фильме («Ральф»); " +
                            "BTVA People's Choice Voice Acting Award, 2013 - Лучший вокальный ансамбль в художественном фильме («Ральф»)",
                            Description=" В колледже с 1990 по 1991 год он изучал драматургию, а также участвовал в театральных постановках." +
                            " В 1993 году поступил в Джульярдскую школу, но в 1996 году бросил обучение, так и не получив диплома. В 1997 году" +
                            " он дебютировал в кино, снявшись в фильме «35 миль от нормального». В начале своей карьеры он также часто появлялся в пьесах Бродвея. " +
                            "Известен по ролям Саймона в чёрной комедии «Смерть на похоронах»" +
                            " и Стива в «Вышибалах», а также роли Хобана Уошбурна («Уоша») в научно-фантастическом сериале «Светлячок» и фильме «Миссия „Серенити“»," +
                            " снятом как продолжение сериала."
                        },
                        new Person
                        {
                            Name="Сара Томко",
                            OriginalName="Sara Tomko",
                            DateOfBirthday="19/10/1983",
                            Height="1.65 м",                            
                            RolesInMedia="Актриса, Продюсер",                            
                            Image="https://imageup.ru/img211/3743704/sara-tomko.jpg",                            
                            Description="Известна по ролям в Засланец из космоса (2021), Девочки! Девочки! Девочки! Или: Когда Тэмми Увядает (2018) и Подлый Пит (2015)."
                        },
                        new Person
                        {
                            Name="Кори Рейнольдс",
                            OriginalName="Corey Reynolds",
                            DateOfBirthday="3/07/1974",
                            PlaceOfBirthday="Ричмонд, Вирджиния, США",
                            Spouse="Тара Рене Шемански",                            
                            RolesInMedia="Актер, Продюсер",
                            Image="https://imageup.ru/img73/3743716/kori-reinolds.jpg",
                            Description="Первый актёрский опыт Кори Рейнольдс получил ещё в школе. В 16 лет переехал в Калифорнию в надежде на успех." +
                            " Играл в различных эстрадных постановках. Впоследствии перебрался в Нью-Йорк, где после многочисленных проб получил роль Сиуида" +
                            " Стаббса в бродвейском мюзикле «Лак для волос», за которую в 2003 году номинировался на премию «Тони» в категории «Лучшая мужская роль второго" +
                            " плана в мюзикле». На волне театральных успехов Рейнольдс попробовал себя в кино и на телевидении. В России наиболее известен своей ролью сержанта Дэвида Гэбриэла" +
                            " в телевизионном сериале «Ищейка»."
                        },                        
                        new Person{
                            Name="Джонас Пейт",
                            OriginalName="Jonas James Pate",                            
                            DateOfBirthday="15/01/1970",
                            PlaceOfBirthday="Рейфорд, Северная Каролина, США",
                            Spouse="Дебора Снайдер",
                            Awards="Cognac Festival du Film Policier,1998 - Специальный приз Жюри («Детектор лжи»); " +
                            "Stockholm Film Festival, 1997 - Лучший сценарий («Детектор лжи»)",                            
                            RolesInMedia = "Режиссер, Продюсер, Сценарист",
                            Image="https://imageup.ru/img84/3743733/dzhonas-peit.jpg",
                            Description="В 1996 году Пейт начал свою карьеру, написав и направив триллер фильм под названием Могила с братом Джошем." +
                            " После показа на кинофестивале Sundance фильм получил множество положительных отзывов. В следующем году они вместе работали над фильмом Обманщик." +
                            " Впоследствии он вместе со своим братом стал соавтором фэнтезибоевик телешоу Добро против Зла (1999)." +
                            " С 2003 по 2004 год он был со-исполнительным продюсером на телеканале L.A. Драгнет, для которого он также написал серию." +
                            " В 2005 году он стал соавтором научно-фантастического сериала Поверхность, который транслировался до 2006 года." +
                            " В 2020 году губернатор Рой Купер назначил его" +
                            " в Консультативный совет губернатора по вопросам кино, телевидения и цифрового потокового вещания."
                        },
                        new Person
                        {
                            Name="Шеннон Берк",
                            OriginalName="Shannon Burke",
                            DateOfBirthday="11/09/1966",
                            PlaceOfBirthday="Уилметт, Иллинойс, США",                            
                            RolesInMedia="Сценарист, Продюсер, Писатель",
                            Image="https://imageup.ru/img202/3743824/shannon-burke.jpg",
                            Description="Учился в Университет Северной Каролины-Чапел-Хилл. После окончания он стал фельдшером" +
                            " Пожарная служба Нью-Йорка. Берк использовал этот опыт в своих романах. Safelight (2004) и Черные мухи (2008)." +
                            " К 2015 году Берк опубликовал три романа: Safelight (2004), Черные мухи (2008) и В дикую страну (2015). Также он" +
                            " принимал участие в различных кино- и телепроектах, в том числе работал над сценарием к фильму Сириана (2005), и он является" +
                            " соавтором и исполнительным продюсером сериала Netflix Внешние отмели."
                        },
                        new Person
                        {
                            Name="Чейз Стоукс",
                            OriginalName="Chase Stokes",
                            Height="1.85 м",
                            DateOfBirthday="16/09/1992",
                            PlaceOfBirthday="Аннаполис, Мэриленд, США",
                            RolesInMedia="Актер",
                            Image="https://imageup.ru/img222/3743827/chase-stokes.jpg",
                            Awards="Премия канала «MTV», 2021 - Лучший поцелуй («Внешние отмели»)",
                            Description="В начале своей актерской карьеры у Стокса были небольшие роли, в том числе Очень странные дела, Дневные дивы и Расскажи мне свои секреты." +
                            " Он проходил прослушивание во Внешних отмелях в 2019 году и первоначально отклонил предложение, но передумал после прочтения сценария. Он также первоначально" +
                            " прослушивался на роль Топпера, прежде чем читать для Джона Б. Первый сезон был выпущен 15 апреля 2020 года и получил положительные отзывы, а второй" +
                            " сезон был подтвержден в июле. В том же месяце было объявлено, что он будет играть TJ в Один и нас лжёт. В сентябре 2020 года Стоукс и Мэделин Клайн снялись" +
                            " в видеоклипе на сингл Kygo и Донны Саммер 'Hot Stuff'."
                        },
                        new Person
                        {
                            Name="Мэдлин Клайн",
                            OriginalName="Madelyn Cline",
                            Height="1.68 м",
                            DateOfBirthday="21/12/1997",
                            PlaceOfBirthday="Чарльстон, Южная Каролина, США",
                            RolesInMedia="Актриса",
                            Image="https://imageup.ru/img281/3743932/medlin-klain.jpg",
                            Awards="Премия канала «MTV», 2021 - Лучший поцелуй («Внешние отмели»)",
                            Description="Она начала с небольших ролей, таких как Хлоя в Стертая личность и Тейлор Уоттс в Вице-директора. У нее также были небольшие повторяющиеся роли" +
                            " в Древние и Очень странные дела. В 2018 году она сыграла Сару Кэмерон в оригинальном сериале Netflix Внешние отмели, первый сезон которого был выпущен 15 апреля 2020 года." +
                            " Шоу получило положительные отзывы, и второй сезон был подтвержден в июле 2020 года. В сентябре 2020 года Клайн и Чейз Стоукс снялись в видеоклипе на сингл Kygo" +
                            " и Донны Саммер 'Hot Stuff'."
                        },
                         new Person
                        {
                            Name="Руди Панкоу",
                            OriginalName="Rudy Pankow",                            
                            DateOfBirthday="12/08/1998",
                            PlaceOfBirthday="Кетчикан, Аляска, США",
                            RolesInMedia="Актёр",
                            Image="https://imageup.ru/img181/3743970/rudi-pankou.jpg",
                            Awards="Humboldt International Film Festival, 2019 - Почетное упоминание («Девиант» (2018))",
                            Description="Панков изначально собирался пойти в кулинарную школу, но решил стать актером и поступил в актерский институт в 2016–17 годах. " +
                            "После этого Панков поступил в студию Майкла Вулсона, чтобы улучшить свои актерские способности. После окончания актерского курса он начал играть в театре," +
                            " чтобы набраться опыта. Панков наиболее известен своей ролью Джей-Джея Мейбанка во Внешних отмелях. Другие шоу, в которых он выступал: Политик, Девиант и Космические волны."
                        },
                         new Person
                        {
                            Name="Джефф Аллен",
                            OriginalName="Jeff Allen",
                            DateOfBirthday="-",
                            PlaceOfBirthday="-",
                            RolesInMedia="Режиссёр",
                            Image="https://imageup.ru/img70/3743969/dzheff-allen.jpg",                            
                            Description="Известен как режиссёр по таким работам Неуязвимый (2021), Команда 'Мстители'(2012-2019), Великий Человек-паук (2012-2017), Шэгги и Скуби-Ду ключ найдут! (2006-2008)."
                        },
                          new Person
                        {
                            Name="Роберт Киркман",
                            OriginalName="Robert Kirkman",
                            DateOfBirthday="30/11/1978",
                            PlaceOfBirthday="Ричмонд, Кентукки, США",
                            RolesInMedia="Продюсер, Сценарист, Актёр",
                            Height="1.85 м",
                            Image="https://imageup.ru/img23/3743975/robert-kirkman.jpg",
                            Awards="CinEuphoria Awards, 2020 - Почетная Награда («Ходячие мертвецы»)",
                            Description="Наиболее известен своей работой над серией комиксов Ходячие мертвецы и Неуязвимый для Image Comics и Marvel Team-Up и Marvel Zombies для Marvel Comics." +
                            " Вместе с Тоддом Макфарлейном работал над созданием серии Haunt, и с ним же входит в число пяти владельцев Image Comics и единственным из них, кто не был" +
                            " соучредителем издательства. Киркман участвует в создании телесериала «Ходячие мертвецы», снятого по мотивам комикса его авторства и написал сценарий к четвёртому эпизоду, «Vatos»."
                        },
                          new Person
                        {
                            Name="Стивен Ён",
                            OriginalName="Yeon Sang-yeop",
                            Height="1.75 м",
                            Spouse="Джоана Пак",
                            DateOfBirthday="21/12/1983",
                            PlaceOfBirthday="Сеул, Южная Корея",
                            RolesInMedia="Актёр, Продюсер",
                            Image="https://imageup.ru/img156/3743979/stiven-ian.jpg",
                            Awards="NMFC Award, 2021 - Лучший ансамбль («Минари»); " +
                            "NCFCA Award, 2021 - Лучший актер («Минари»); " +
                            "NTFCA Award, 2021 - Лучший актер («Минари»); " +                           
                            "CinEuphoria Awards, 2020 - Почетная Награда («Ходячие мертвецы»); " +
                            "Denver International Film Festival, 2020 - Премия за выдающиеся актерские достижения («Минари»); " +
                            "Middleburg Film Festival, 2020 - Ансамбль в ролях Премия Spotlight («Минари»); " +                            
                            "Chunsa Film Art Awards, 2019 - Лучший актер второго плана («Пылающий» (2018))", 
                            Description="Получил высшее образование в Kalamazoo College в Каламазу, где изучал психологию. По окончании колледжа получил степень бакалавра. " +
                            "Известнен по роли Гленна Ри в телесериале «Ходячие мертвецы». За главную роль Джейкоба Ли в картине «Минари» Ён получил номинации на премии" +
                            " Американской киноакадемии «Оскар» и Американской Гильдии киноактёров в категории «Лучший актёр»," +
                            " став первым американским актёром корейского происхождения, номинированным на эти награды. Помимо съёмок в фильмах и телесериалах сериалах" +
                            " Ён занимается озвучиванием персонажей компьютерных игр и мультфильмов. Ещё до своего переезда в Лос-Анджелес он озвучивал корейских солдат" +
                            " в играх Crysis и Crysis Warhead. В 2013 году Ён озвучивал персонажа по имени Ван в мультсериале «Аватар: Легенда о Корре». Он также озвучил" +
                            " главного героя анимационного фильма Chew, созданного по одноимённому комиксу, и персонажа Кита в мультсериале «Вольтрон: Легендарный Защитник»."
                        },
                           new Person
                        {
                            Name="Сандра О",
                            OriginalName="Sandra Miju Oh",
                            DateOfBirthday="20/07/1971",
                            PlaceOfBirthday="Непиан, Онтарио, Канада",
                            RolesInMedia="Актриса, Продюсер, Сценарист",
                            Height="1.65 м",
                            Image="https://imageup.ru/img169/3743982/sandra-o.jpg",
                            Awards="Золотой глобус, 2019 - Лучшая женская роль на ТВ (драма) («Убивая Еву»); " +
                            "Премия Гильдии актеров, 2019 - Лучшая актриса драматического сериала («Убивая Еву»); " +
                            "Премия Гильдии актеров, 2007 - Лучший актерский состав драматического сериала («Анатомия страсти»); " +
                            "Золотой глобус, 2006 - Лучшая актриса второго плана мини-сериала или фильма на ТВ («Анатомия страсти»); " +
                            "Премия Гильдии актеров, 2006 - Лучшая актриса драматического сериала («Анатомия страсти»); " +
                            "Премия Гильдии актеров, 2005 - Лучший актерский состав («На обочине»)",
                            Description="В 1993 году Сандра О сыграла главную роль в канадском телефильме «Дневник Эвелин Ло»," +
                            " обойдя при этом более 1000 претендентов. Эта роль принесла ей похвалу от критиков и номинацию на премию «Джемини»" +
                            " за лучшую женскую роль на телевидении. В следующем году она выиграла канадский «Оскар» за исполнение главной роли в фильме «Двойная радость»." +
                            "Наиболее известна по своей роли доктора Кристины Янг в сериале канала ABC «Анатомия страсти», которая принесла ей премии «Золотой глобус»" +
                            " и Гильдии актёров США за лучшую женскую роль в драматическом сериале. 12 июля 2018 года вошла в историю, став первой актрисой азиатского происхождения," +
                            " получившей номинацию на телевизионную премию «Эмми» в категории «Лучшая женская роль в драматическом телесериале» за роль в «Убивая Еву». За эту же роль получила" +
                            " премию «Золотой глобус» за лучшую женскую роль в телевизионном сериале — драма."
                        },
                            new Person
                        {
                            Name="Дж.К. Симмонс",
                            OriginalName="Jonathan Kimble Simmons",
                            DateOfBirthday="9/01/1955",
                            PlaceOfBirthday="Детройт, Мичиган, США",
                            RolesInMedia="Актёр",
                            Spouse="Мишель Шумахер",
                            Height="1.8 м",
                            Image="https://imageup.ru/img272/3743989/dzhk-simmons.jpg",
                            Awards="Оскар, 2015 - Лучшая мужская роль второго плана («Одержимость»); " +
                            "Золотой глобус, 2015 - Лучшая мужская роль второго плана («Одержимость»); " +
                            "Британская академия, 2015 - Лучшая мужская роль второго плана («Одержимость»); " +
                            "Премия Гильдии актеров, 2015 - Лучшая мужская роль второго плана («Одержимость»)",                            
                            Description="Больше всего известен по ролям доктора Шкоды в сериале «Закон и порядок», неонациста Шиллингера" +
                            " в тюремной драме HBO «Тюрьма Оз», Дж. Джоны Джеймсона в серии фильмов «Человек-паук» и подрывника Газа Панкейка в фильме братьев" +
                            " Коэнов «Игры джентльменов». Был удостоен множества наград, в том числе «Золотого глобуса», BAFTA и «Оскар» за роль дирижёра-тирана в психологической драме «Одержимость» (2014). " +
                            "Симмонс снимался во всей серии фильмов о Человеке-Пауке, где исполнил роль Дж. Джоны Джеймсона. голосом Симмонса заговорил жёлтый M&M’s из" +
                            " известной серии реклам о двух драже. Джон исполнял роль президента-антикоммуниста Говарда Акермана в видеоигре Command & Conquer: Red Alert 3," +
                            " основателя и президента Aperture Science Кэйва Джонсона в видеоигре Portal 2 и нескольких персонажей мультсериала «Симпсоны»."
                        },
                        new Person
                        {
                            Name="Крис Шеридан",
                            OriginalName="Christopher Sheridan",
                            DateOfBirthday="19/09/1967",
                            PlaceOfBirthday="Филиппины",
                            RolesInMedia="Актёр, Продюсер, Сценарист",
                            Height="1.91 м",
                            Image="https://imageup.ru/img102/3743993/kris-sheridan.jpeg",
                            Awards="Austin Film Festival, 2006 - Премия за документальный фильм («Похищение: История Мегуми Йокоты»); " +
                            "DVD Exclusive Awards, 2006 - Лучший сценарий (для премьерного фильма на DVD) («Стьюи Гриффин: Нерассказанная история»); " +
                            "Omaha Film Festival, 2006 - Лучший документальный фильм («Похищение: История Мегуми Йокоты»); " +
                            "Slamdance Film Festival, 2006 - Лучший документальный фильм («Похищение: История Мегуми Йокоты»); " +
                            "Heartland International Film Festival, 1997 - Награда 'Хрустальное сердце' («Walk This Way»)",
                            Description="Его первая работа появилась в 1992 году, когда его наняли помощником сценариста в ситкоме Fox Shaky Ground." +
                            " После этого он был нанят ассистентом в ситкоме Fox Living Single, где в конечном итоге стал сценаристом. Он оставался в" +
                            " сериале до его отмены в 1998 году. После того, как шоу было отменено и Шеридан стал безработным, он начал писать для мультсериала Гриффины." +
                            " Хотя поначалу он был настроен скептически, он согласился на эту работу, поскольку у него не было других вариантов. Шеридан был одним" +
                            " из первых нанятых сценаристов и продолжал писать для сериала на протяжении его одиннадцатого сезона. За свою работу" +
                            " над Family Guy он был номинирован на пять Primetime Emmy Awards, British Academy Television Award и выиграл DVD Exclusive Award." +
                            " Шеридан также написал эпизоды Тита и Да, дорогой."
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



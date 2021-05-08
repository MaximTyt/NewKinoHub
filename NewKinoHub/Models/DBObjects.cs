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
                        }
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
                        Genres = new List<Genre>() { Genres["Аниме"], Genres["Мультфильм"], Genres["Боевик"], Genres["Фэнтези"] },
                        Casts=new List<Cast>()
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


                        }
                    ) ;
            }

            if (!content.Users.Any())
            {
                content.AddRange(
                    new Users
                    {
                        Login = "admin",
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
                        new Genre { Genre_Name = "Аниме" },
                        new Genre { Genre_Name = "Боевик" },
                        new Genre { Genre_Name = "Детектив" },
                        new Genre { Genre_Name = "Драма" },
                        new Genre { Genre_Name = "Комедия" },
                        new Genre { Genre_Name = "Мелодрама"},
                        new Genre { Genre_Name = "Мультфильм" },
                        new Genre { Genre_Name = "Мюзикл"},
                        new Genre { Genre_Name = "Криминал" },
                        new Genre { Genre_Name = "Приключения"},
                        new Genre { Genre_Name = "Семейный"},
                        new Genre { Genre_Name = "Ужасы"},
                        new Genre { Genre_Name = "Фантастика"},
                        new Genre { Genre_Name = "Фэнтези"}
                    };
                    genres = new Dictionary<string, Genre>();
                    foreach (Genre el in list)
                        genres.Add(el.Genre_Name, el);
                }
                return genres;
            }
        }

        private static int Age;
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



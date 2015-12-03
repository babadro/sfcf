using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using sfcf.Domain.Entities;

namespace sfcf.Domain.Concrete
{
    public class EFDbInitializer : /* System.Data.Entity.DropCreateDatabaseAlways<EFDbContext> */ System.Data.Entity.DropCreateDatabaseIfModelChanges<EFDbContext> 
    {
        protected override void Seed(EFDbContext context)
        {
            var users = new List<User>
            {
                new User{FirstName="Carson",LastName="Alexander", Capital=25},
                new User{FirstName="Meredith",LastName="Alonso", Capital=25},
                new User{FirstName="Arturo",LastName="Anand", Capital=25},
                new User{FirstName="Gytis",LastName="Barzdukas", Capital=25},
                new User{FirstName="Yan",LastName="Li", Capital=25},
                new User{FirstName="Peggy",LastName="Justice", Capital=25},
                new User{FirstName="Laura",LastName="Norman", Capital=25},
                new User{FirstName="Nino",LastName="Olivetto", Capital=25},
                new User{FirstName="Andrey",LastName="Petrovich", Capital=100}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{ID=1, Name="Политика"},
                new Category{ID=2, Name="Культура"},
                new Category{ID=3, Name="Бизнес"},
                new Category{ID=4, Name="Техника"},
                new Category{ID=5, Name="Окружающая среда"},
                new Category{ID=6, Name="Наука"},
                new Category{ID=7, Name="Экономика"}
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var votings = new List<Voting>
            {
                new Voting
                {
                    ID = 1,
                    Title="Кто победит на президентских выборах в России в 2018 году?",
                    CategoryID=1,
                    Description="Название говорит само за себя",
                    DeadLine=DateTime.Parse("2018-12-31")                        
                },
                
                new Voting
                {
                    ID = 2,
                    Title="Выпустят ли Надежду Савченко из Российской тюрьмы в 2015-ом году?",
                    CategoryID=1,
                    Description="Савченко будет считаться освобожденной, если она выйдет из-под любых форм лишения свободы со стороны России",
                    DeadLine=DateTime.Parse("2015-12-31")                        
                },
                new Voting
                {
                    ID = 3,
                    Title="Введут ли выездные визы для граждан России не позже 2016 года?",
                    CategoryID=1,
                    Description="Выездные визы любой формы",
                    DeadLine=DateTime.Parse("2016-12-31")                        
                },
                new Voting
                {
                    ID = 4,
                    Title="Будет ли ослабление санкций запада по отношению к России в 2016 году?",
                    CategoryID=1,
                    Description="Имеются ввиду как политические, так и экономические санкции",
                    DeadLine=DateTime.Parse("2016-12-31")                        
                },
                new Voting
                {
                    ID =5,
                    Title="Будет ли зафиксирован экономический рост в России в 2015-году?",
                    CategoryID=7,
                    Description="Экономический рост фиксируется, если он наблюдается не менее трех кварталов подряд",
                    DeadLine=DateTime.Parse("2016-12-31")
                }
                 
                 
            };
            votings.ForEach(s => context.Votings.Add(s));
            context.SaveChanges();

            var options = new List<Option>
            {
                new Option{ID=1, VotingID=1, Title="Путин", Description="Побеждает Путин"},
                new Option{ID=2, VotingID=1, Title="Зюганов", Description="Побеждает Зюганов"},
                new Option{ID=3, VotingID=1, Title="Жириновский", Description="Побеждает Жириновский"},
                new Option{ID=4, VotingID=1, Title="Явлинский", Description="Побеждает Явлинский"},
                new Option{ID=5, VotingID=1, Title="Другой кандидат", Description="Побеждает любой другой кандидат"},

                
                new Option{ID=6, VotingID=2, Title="Да", Description=""},
                new Option{ID=7, VotingID=2, Title="Нет", Description=""},

                new Option{ID=8, VotingID=3, Title="Да", Description=""},
                new Option{ID=9, VotingID=3, Title="Нет", Description=""},

                new Option{ID=10, VotingID=4, Title="Да", Description=""},
                new Option{ID=11, VotingID=4, Title="Нет", Description=""},

                new Option{ID=12, VotingID=5, Title="Да", Description=""},
                new Option{ID=13, VotingID=5, Title="Нет", Description=""}
                
            };
            options.ForEach(s => context.Options.Add(s));
            context.SaveChanges();

            var bets = new List<Bet>
            {
                new Bet{UserID=1, OptionID=3, Size=5},
                new Bet{UserID=1, OptionID=7, Size=10},
                new Bet{UserID=1, OptionID=8, Size=3},
                new Bet{UserID=1, OptionID=11, Size=2},
                new Bet{UserID=1, OptionID=12, Size=2},

                new Bet{UserID=2, OptionID=5, Size=1},
                new Bet{UserID=2, OptionID=6, Size=2},
                new Bet{UserID=2, OptionID=9, Size=10},
                new Bet{UserID=2, OptionID=10, Size=8},
                new Bet{UserID=2, OptionID=13, Size=2},

                new Bet{UserID=3, OptionID=1, Size=5},
                new Bet{UserID=3, OptionID=7, Size=3},
                new Bet{UserID=3, OptionID=8, Size=2},
                new Bet{UserID=3, OptionID=11, Size=7},
                new Bet{UserID=3, OptionID=12, Size=2},

                new Bet{UserID=4, OptionID=1, Size=4},
                new Bet{UserID=4, OptionID=6, Size=4},
                new Bet{UserID=4, OptionID=9, Size=4},
                new Bet{UserID=4, OptionID=10, Size=4},
                new Bet{UserID=4, OptionID=13, Size=5},

                new Bet{UserID=5, OptionID=2, Size=3},
                new Bet{UserID=5, OptionID=7, Size=5},
                new Bet{UserID=5, OptionID=8, Size=10},
                new Bet{UserID=5, OptionID=10, Size=5},
                new Bet{UserID=5, OptionID=12, Size=2},

                new Bet{UserID=6, OptionID=3, Size=6},
                new Bet{UserID=6, OptionID=6, Size=4},
                new Bet{UserID=6, OptionID=9, Size=5},
                new Bet{UserID=6, OptionID=11, Size=5},
                new Bet{UserID=6, OptionID=12, Size=3},

                new Bet{UserID=7, OptionID=4, Size=10},
                new Bet{UserID=7, OptionID=6, Size=5},
                new Bet{UserID=7, OptionID=9, Size=2},
                new Bet{UserID=7, OptionID=10, Size=3},
                new Bet{UserID=7, OptionID=12, Size=3},

                new Bet{UserID=8, OptionID=1, Size=1},
                new Bet{UserID=8, OptionID=7, Size=3},
                new Bet{UserID=8, OptionID=8, Size=1},
                new Bet{UserID=8, OptionID=11, Size=10},
                new Bet{UserID=8, OptionID=13, Size=4},
                
            };
            bets.ForEach(s => context.Bets.Add(s));
            context.SaveChanges();
        }
    }
}

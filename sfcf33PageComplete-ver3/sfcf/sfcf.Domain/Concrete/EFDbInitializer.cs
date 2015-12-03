using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using sfcf.Domain.Entities;

namespace sfcf.Domain.Concrete
{
    public class EFDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var users = new List<User>
            {
                new User{FirstName="Carson",LastName="Alexander"},
                new User{FirstName="Meredith",LastName="Alonso"},
                new User{FirstName="Arturo",LastName="Anand"},
                new User{FirstName="Gytis",LastName="Barzdukas"},
                new User{FirstName="Yan",LastName="Li"},
                new User{FirstName="Peggy",LastName="Justice"},
                new User{FirstName="Laura",LastName="Norman"},
                new User{FirstName="Nino",LastName="Olivetto"}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
           
            var votings = new List<Voting>
            {
                new Voting
                {
                    ID = 1,
                    Title="Кто победит на президентских выборах в России в 2018 году?",
                    Category="Внутренняя политика РФ",
                    Description="Название говорит само за себя",
                    DeadLine=DateTime.Parse("2018-12-31")                        
                },
                
                new Voting
                {
                    ID = 2,
                    Title="Выпустят ли Надежду Савченко из Российской тюрьмы в 2015-ом году?",
                    Category="Внутренняя политика РФ",
                    Description="Савченко будет считаться освобожденной, если она выйдет из-под любых форм лишения свободы со стороны России",
                    DeadLine=DateTime.Parse("2015-12-31")                        
                },
                new Voting
                {
                    ID = 3,
                    Title="Введут ли выездные визы для граждан России не позже 2016 года?",
                    Category="Внутренняя политика РФ",
                    Description="Выездные визы любой формы",
                    DeadLine=DateTime.Parse("2016-12-31")                        
                },
                new Voting
                {
                    ID = 4,
                    Title="Будет ли ослабление санкций запада по отношению к России в 2016 году?",
                    Category="Международная политика",
                    Description="Имеются ввиду как политические, так и экономические санкции",
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
                new Option{ID=11, VotingID=4, Title="Нет", Description=""}
                
            };
            options.ForEach(s => context.Options.Add(s));
            context.SaveChanges();

            var bets = new List<Bet>
            {
                new Bet{UserID=1, OptionID=3, Size=5},
                new Bet{UserID=1, OptionID=7, Size=10},
                new Bet{UserID=1, OptionID=8, Size=3},
                new Bet{UserID=1, OptionID=11, Size=2},

                new Bet{UserID=2, OptionID=5, Size=1},
                new Bet{UserID=2, OptionID=6, Size=2},
                new Bet{UserID=2, OptionID=9, Size=10},
                new Bet{UserID=2, OptionID=10, Size=8},

                new Bet{UserID=3, OptionID=1, Size=5},
                new Bet{UserID=3, OptionID=7, Size=3},
                new Bet{UserID=3, OptionID=8, Size=2},
                new Bet{UserID=3, OptionID=11, Size=7},

                new Bet{UserID=4, OptionID=1, Size=4},
                new Bet{UserID=4, OptionID=6, Size=4},
                new Bet{UserID=4, OptionID=9, Size=4},
                new Bet{UserID=4, OptionID=10, Size=4},

                new Bet{UserID=5, OptionID=2, Size=3},
                new Bet{UserID=5, OptionID=7, Size=5},
                new Bet{UserID=5, OptionID=8, Size=10},
                new Bet{UserID=5, OptionID=10, Size=5},

                new Bet{UserID=6, OptionID=3, Size=11},
                new Bet{UserID=6, OptionID=6, Size=4},
                new Bet{UserID=6, OptionID=9, Size=5},
                new Bet{UserID=6, OptionID=11, Size=5},

                new Bet{UserID=7, OptionID=4, Size=15},
                new Bet{UserID=7, OptionID=6, Size=5},
                new Bet{UserID=7, OptionID=9, Size=2},
                new Bet{UserID=7, OptionID=10, Size=3},

                new Bet{UserID=8, OptionID=1, Size=1},
                new Bet{UserID=8, OptionID=7, Size=3},
                new Bet{UserID=8, OptionID=8, Size=1},
                new Bet{UserID=8, OptionID=11, Size=20}
                
            };
            bets.ForEach(s => context.Bets.Add(s));
            context.SaveChanges();
        }
    }
}

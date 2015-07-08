using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SportSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUsers(context);
                CreateTeams(context);
                CreateMatches(context);
                CreatePlayers(context);
            }
        }

        private void CreateUsers(ApplicationDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var firstUserEmail = "alex@usa.net";
            var firstUserPassword = "12qw!@QW";

            var firstUser = new User
            {
                UserName = firstUserEmail,
                Email = firstUserEmail
            };

            var firstUserCreateResult = userManager.Create(firstUser, firstUserPassword);
            if (!firstUserCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", firstUserCreateResult.Errors));
            }

            var secondUserEmail = "tanya@gmail.com";
            var secondUserPassword = "P@ssW0RD!123";

            var secondUser = new User
            {
                UserName = secondUserEmail,
                Email = secondUserEmail
            };

            var secondUserCreateResult = userManager.Create(secondUser, secondUserPassword);
            if (!secondUserCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", firstUserCreateResult.Errors));
            }
        }

        private void CreateTeams(ApplicationDbContext context)
        {
            context.Teams.Add(new Team()
            {
                Name = "Manchester United F.C.",
                WebSite = "http://www.manutd.com",
                DateFounded = new DateTime(1878, 6, 1),
                NickName = "The Red Devils"
            });

            context.Teams.Add(new Team()
            {
                Name = "Real Madrid",
                WebSite = "http://www.realmadrid.com",
                DateFounded = new DateTime(1902, 3, 6),
                NickName = "The Whites",
                Votes = new HashSet<Vote>()
                {
                    new Vote() { VoteUser = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com") }
                }
            });

            context.Teams.Add(new Team()
            {
                Name = "FC Barcelona",
                WebSite = "http://www.fcbarcelona.com",
                DateFounded = new DateTime(1899, 11, 12),
                NickName = "Barca"
            });

            context.Teams.Add(new Team()
            {
                Name = "Bayern Munich",
                WebSite = "http://www.fcbayern.de",
                DateFounded = new DateTime(1900, 2, 13),
                NickName = "The Bavarians",
                Votes = new HashSet<Vote>()
                {
                    new Vote() { VoteUser = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com") },
                    new Vote() { VoteUser = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net") }
                }
            });

            context.Teams.Add(new Team()
            {
                Name = "Manchester City",
                WebSite = "http://www.mcfc.com",
                DateFounded = new DateTime(1880, 5, 1),
                NickName = "The Citizens"
            });

            context.Teams.Add(new Team()
            {
                Name = "Chelsea",
                WebSite = "https://www.chelseafc.com",
                DateFounded = new DateTime(1905, 3, 10),
                NickName = "The Pensioners"
            });

            context.Teams.Add(new Team()
            {
                Name = "Arsenal",
                WebSite = "http://www.arsenal.com",
                DateFounded = new DateTime(1886, 9, 1),
                NickName = "The Gunners"
            });

            context.SaveChanges();
        }

        private void CreateMatches(ApplicationDbContext context)
        {
            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C."),
                MatchDate = new DateTime(2015, 6, 13)
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Bayern Munich"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C."),
                MatchDate = new DateTime(2015, 6, 14),
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "The best match this summer!",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Comment()
                    {
                        Content = "The good football this evening.",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                    }
                },
                Bets = new HashSet<Bet>()
                {
                    new Bet()
                    {
                        HomeBet = 500.00m,
                        AwayBet = 0.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Bet()
                    {
                        HomeBet = 50.00m,
                        AwayBet = 0.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                    },

                    new Bet()
                    {
                        HomeBet = 0.00m,
                        AwayBet = 20.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                    }
                }
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester City"),
                MatchDate = new DateTime(2015, 6, 15),
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "Barca!",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                    }
                },
                Bets = new HashSet<Bet>()
                {
                    new Bet()
                    {
                        HomeBet = 120.00m,
                        AwayBet = 0.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    }
                }
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona"),
                MatchDate = new DateTime(2015, 6, 16),
                Bets = new HashSet<Bet>()
                {
                    new Bet()
                    {
                        HomeBet = 30.00m,
                        AwayBet = 0.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Bet()
                    {
                        HomeBet = 0.00m,
                        AwayBet = 50.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Bet()
                    {
                        HomeBet = 0.00m,
                        AwayBet = 120.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Bet()
                    {
                        HomeBet = 0.00m,
                        AwayBet = 220.00m,
                        User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                    }
                }
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester City"),
                MatchDate = new DateTime(2015, 6, 17),
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "Real forever!",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Comment()
                    {
                        Content = "Real, real, real",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    },

                    new Comment()
                    {
                        Content = "Real again :)",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                    }
                }
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C."),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                MatchDate = new DateTime(2015, 6, 18)
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Arsenal"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Bayern Munich"),
                MatchDate = new DateTime(2015, 6, 12)
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                MatchDate = new DateTime(2015, 6, 11),
                Comments = new HashSet<Comment>()
                {
                    new Comment()
                    {
                        Content = "Chelsea champion!",
                        Author = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                    }
                }
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester City"),
                MatchDate = new DateTime(2015, 6, 10)
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Arsenal"),
                MatchDate = new DateTime(2015, 6, 19)
            });

            context.Matches.Add(new Match()
            {
                HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Arsenal"),
                AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona"),
                MatchDate = new DateTime(2015, 6, 20)
            });

            context.SaveChanges();
        }

        private void CreatePlayers(ApplicationDbContext context)
        {
            context.Players.Add(new Player()
            {
                Name = "Alexis Sanchez",
                BirthDate = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona")
            });

            context.Players.Add(new Player()
            {
                Name = "Arjen Robben",
                BirthDate = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid")
            });

            context.Players.Add(new Player()
            {
                Name = "Franck Ribery",
                BirthDate = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C.")
            });

            context.Players.Add(new Player()
            {
                Name = "Wayne Rooney",
                BirthDate = new DateTime(1982, 1, 3),
                Height = 1.65,
                Team = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona")
            });

            context.Players.Add(new Player()
            {
                Name = "Lionel Messi",
                BirthDate = new DateTime(1982, 1, 13),
                Height = 1.65
            });

            context.Players.Add(new Player()
            {
                Name = "Theo Walcott",
                BirthDate = new DateTime(1983, 2, 17),
                Height = 1.75
            });

            context.Players.Add(new Player()
            {
                Name = "Cristiano Ronaldo",
                BirthDate = new DateTime(1984, 3, 16),
                Height = 1.85
            });

            context.Players.Add(new Player()
            {
                Name = "Aaron Lennon",
                BirthDate = new DateTime(1985, 4, 15),
                Height = 1.95
            });

            context.Players.Add(new Player()
            {
                Name = "Gareth Bale",
                BirthDate = new DateTime(1986, 5, 14),
                Height = 1.90
            });

            context.Players.Add(new Player()
            {
                Name = "Antonio Valencia",
                BirthDate = new DateTime(1987, 5, 23),
                Height = 1.82
            });

            context.Players.Add(new Player()
            {
                Name = "Robin van Persie",
                BirthDate = new DateTime(1988, 6, 13),
                Height = 1.84
            });

            context.Players.Add(new Player()
            {
                Name = "Ronaldinho",
                BirthDate = new DateTime(1989, 7, 30),
                Height = 1.87
            });

            context.SaveChanges();
        }
    }
}
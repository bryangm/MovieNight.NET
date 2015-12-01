using System.Collections.Generic;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Enums;

namespace MovieNight.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration :
        DbMigrationsConfiguration<MovieNight.Domain.Repositories.EntityFramework.EntityFrameworkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieNight.Domain.Repositories.EntityFramework.EntityFrameworkDbContext context)
        {
            context.Movies.AddOrUpdate(x => x.MovieId,
                new Movie()
                {
                    MovieId = 1,
                    Title = "Terminator 2: Judgement Day",
                    Year = 1991,
                    Rating = "R",
                    Length = 137,
                    ReleaseDate = new DateTime(1991, 7, 3),
                    Genres = new List<Genre>()
                    {
                        new Genre()
                        {
                            Category = GenreCategory.Action
                        },
                        new Genre()
                        {
                            Category = GenreCategory.SciFi
                        }
                    },
                    Directors = new List<Director>()
                    {
                        new Director()
                        {
                            FirstName = "James",
                            LastName = "Cameron"
                        }
                    },
                    Writers = new List<Writer>()
                    {
                        new Writer()
                        {
                            FirstName = "James",
                            LastName = "Cameron"
                        },
                        new Writer()
                        {
                            FirstName = "William",
                            LastName = "Wisher"
                        },
                    },
                    CastMembers = new List<CastMember>()
                    {
                        new CastMember()
                        {
                            FirstName = "Arnold",
                            LastName = "Schwarzenegger"
                        },
                        new CastMember()
                        {
                            FirstName = "Linda",
                            LastName = "Hamilton"
                        },
                        new CastMember()
                        {
                            FirstName = "Edward",
                            LastName = "Furlong"
                        }
                    }
                },
                new Movie()
                {
                    MovieId = 2,
                    Title = "Bad Boys",
                    Year = 1995,
                    Rating = "R",
                    Length = 118,
                    ReleaseDate = new DateTime(1995, 4, 7),
                    Genres = new List<Genre>()
                    {
                        new Genre()
                        {
                            Category = GenreCategory.Action
                        },
                        new Genre()
                        {
                            Category = GenreCategory.Comedy
                        },
                        new Genre()
                        {
                            Category = GenreCategory.Crime
                        },
                    },
                    Directors = new List<Director>()
                    {
                        new Director()
                        {
                            FirstName = "Michael",
                            LastName = "Bay"
                        }
                    },
                    Writers = new List<Writer>()
                    {
                        new Writer()
                        {
                            FirstName = "George",
                            LastName = "Gallo"
                        },
                        new Writer()
                        {
                            FirstName = "Michael",
                            LastName = "Barrie"
                        },
                        new Writer()
                        {
                            FirstName = "Jim",
                            LastName = "Mulholland"
                        },
                        new Writer()
                        {
                            FirstName = "Doug",
                            LastName = "Richardson"
                        }
                    },
                    CastMembers = new List<CastMember>()
                    {
                        new CastMember()
                        {
                            FirstName = "Will",
                            LastName = "Smith"
                        },
                        new CastMember()
                        {
                            FirstName = "Martin",
                            LastName = "Lawrence"
                        }
                    }
                }
            );
        }
    }
}
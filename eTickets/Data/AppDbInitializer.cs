﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using eTickets.Models;
using eTickets.Data;
using eTickets.Data.Enums;


namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {



            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Define admin role
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    var adminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(adminRole);
                }

                // Define user role
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    var userRole = new IdentityRole("User");
                    await roleManager.CreateAsync(userRole);
                }

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the third cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the forth cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "https://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the fifth cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-1.jpeg",

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-2.jpeg",

                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the third actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-3.jpeg",

                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the forth actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-4.jpeg",

                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the fifth actor",
                            ProfilePictureURL = "https://dotnethow.net/images/actors/actor-5.jpeg",

                        },

                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first Producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-1.jpeg",

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second Producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-2.jpeg",

                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the third actor",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-3.jpeg",

                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the forth Producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-4.jpeg",

                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the fifth Producer",
                            ProfilePictureURL = "https://dotnethow.net/images/producers/producer-5.jpeg",

                        },

                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the The Shawshank Redemption movie's description",
                            Price = 59,
                            ImageURL = "https://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "No Country For Old Men",
                            Description = "This is the The No Country For Old Men movie's description",
                            Price = 79,
                            ImageURL = "https://dotnethow.net/images/movies/movie-2.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(23),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie's description",
                            Price = 59,
                            ImageURL = "https://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-3),
                            EndDate = DateTime.Now.AddDays(15),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Horror

                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie's description",
                            Price = 59,
                            ImageURL = "https://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror

                        },
                        new Movie()
                        {
                            Name = "Old Boy",
                            Description = "This is the Old Boy movie's description",
                            Price = 59,
                            ImageURL = "https://dotnethow.net/images/movies/movie-5.jpeg",
                            StartDate = DateTime.Now.AddDays(-7),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 5,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Action
                        },
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },
                    });
                    context.SaveChanges();

                }

            }
        }
    }
}

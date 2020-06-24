using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieAccess
{
    public class DbInitializer
    {
        //public static void Seed(IApplicationBuilder applicationBuilder)
        public static void Seed(ApplicationDbContext context)
        {
            //ApplicationDbContext context =
            //    applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Directors.Any())
            {
                context.Directors.AddRange(Directors.Select(s => s.Value));
            }
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(Genres.Select(d => d.Value));
            }
            if (!context.Movies.Any())
            {
                context.AddRange
                (
                     new Movie
                     {
                         Title = "Interstellar",
                         Description = "In Earth's future, a global crop blight and second Dust Bowl are slowly rendering the planet uninhabitable. " +
                         "Professor Brand (Michael Caine), a brilliant NASA physicist, is working on plans to save mankind by transporting Earth's population" +
                         " to a new home via a wormhole. But first, Brand must send former NASA pilot Cooper (Matthew McConaughey) and a team of researchers through" +
                         " the wormhole and across the galaxy to find out which of three planets could be mankind's new home.",
                         Image = "https://m.media-amazon.com/images/M/MV5BZjdkOTU3MDktN2IxOS00OGEyLWFmMjktY2FiMmZkNWIyODZiXkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_SX675_AL_.jpg",
                         Director = Directors["Nolan"],
                         Genre = Genres["Drama"]
                     },
                                          new Movie
                                          {
                                              Title = "John Wick",
                                              Description = "John Wick is an American neo-noir action-thriller media franchise created by producer Basil Iwanyk, " +
                                              "screenwriter Derek Kolstad and owned by Summit Entertainment. Keanu Reeves plays John Wick, a retired hitman seeking vengeance for " +
                                              "the killing of the dog given to him by his recently-deceased wife.",
                                              Image = "https://m.media-amazon.com/images/M/MV5BMTU2NjA1ODgzMF5BMl5BanBnXkFtZTgwMTM2MTI4MjE@._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                                              Director = Directors["Stahelski"],
                                              Genre = Genres["Action"]
                                          },
                                                               new Movie
                                                               {
                                                                   Title = "Sonic The Hedgehog",
                                                                   Description = "The world needed a hero -- it got a hedgehog. Powered with incredible speed, " +
                                                                   "Sonic embraces his new home on Earth -- until he accidentally knocks out the power grid, sparking " +
                                                                   "the attention of uncool evil genius Dr. Robotnik. Now, it's supervillain vs. supersonic in an all-out race " +
                                                                   "across the globe to stop Robotnik from using Sonic's unique power to achieve world domination.",
                                                                   Image = "https://m.media-amazon.com/images/M/MV5BMDk5Yzc4NzMtODUwOS00NTdhLTg2MjEtZTkzZjc0ZWE2MzAwXkEyXkFqcGdeQXVyMTA3MTA4Mzgw._V1_SY1000_CR0,0,666,1000_AL_.jpg",
                                                                   Director = Directors["Fowler"],
                                                                   Genre = Genres["Comedy"]
                                                               },
                                                                                                                              new Movie
                                                                                                                              {
                                                                                                                                  Title = "Venom",
                                                                                                                                  Description = "While trying to take down Carlton, the CEO of Life Foundation, Eddie, a journalist, investigates experiments of human trials. Unwittingly, he gets merged with a symbiotic alien with lethal abilities.",
                                                                                                                                  Image = "https://m.media-amazon.com/images/M/MV5BNzAwNzUzNjY4MV5BMl5BanBnXkFtZTgwMTQ5MzM0NjM@._V1_.jpg",
                                                                                                                                  Director = Directors["Fleischer"],
                                                                                                                                  Genre = Genres["Action"]
                                                                                                                              }


                );
            }

            context.SaveChanges();
        }

      
        private static Dictionary<string, Director> directors;
        public static Dictionary<string, Director> Directors
        {
            get
            {
                if (directors == null)
                {
                    var directorList = new Director[]
                    {
                        new Director {FirstName="Christopher",LastName="Nolan"},
                        new Director {FirstName="Chad",LastName= "Stahelski" },
                        new Director {FirstName="Jeff",LastName="Fowler"},
                        new Director {FirstName="Ruben",LastName="Fleischer"},
                        

                    };

                    directors = new Dictionary<string, Director>();

                    foreach (Director director in directorList)
                    {
                        directors.Add(director.LastName, director);
                    }
                }

                return directors;
            }
        }
        private static Dictionary<string, Genre> genres;
        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genres == null)
                {
                    var genreList = new Genre[]
                    {
                        new Genre {Name="Action",Icon="https://img.icons8.com/ios-filled/50/000000/action.png"},
                        new Genre {Name="Drama",Icon="https://img.icons8.com/pastel-glyph/64/000000/theatre-mask.png"},
                        new Genre {Name="Comedy",Icon="https://img.icons8.com/pastel-glyph/64/000000/charlie-chaplin.png"},
                    };

                    genres = new Dictionary<string, Genre>();

                    foreach (Genre genre in genreList)
                    {
                        genres.Add(genre.Name, genre);
                    }
                }

                return genres;
            }
        }
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            //if (userManager.FindByEmailAsync("spidera951@abv.bg").Result == null)
            //{
            //    IdentityUser user = new IdentityUser
            //    {
            //        UserName = "spidera951",
            //        Email = "spidera951@abv.bg"
            //    };

            //    IdentityResult result = userManager.CreateAsync(user, "spidera951").Result;

            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Administrator").Wait();
            //    }
            //}
        }
    }

}

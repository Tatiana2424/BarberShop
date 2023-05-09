using BarberShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BarberShop.DAL.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>().HasData(
            new Image
            {
                Id = 1,
                Title = "classic haircut",
                Url = "./images/classic_haircut.jpg"
            },
            new Image
            {
                Id = 2,
                Title = "mustache and beard trim",
                Url = "./images/beard_mustache.jpg"
            },
            new Image
            {
                Id = 3,
                Title = "hair washing and styling",
                Url = "./images/styling.jpg"
            },
            new Image
            {
                Id = 4,
                Title = "children's haircut",
                Url = "../images/child_haircut.jpg"
            },
            new Image
            {
                Id = 5,
                Title = "camouflage hair",
                Url = "./images/camouflage.jpg"
            },
            new Image
            {
                Id = 6,
                Title = "french crop",
                Url = "../images/french_crop.jpg"
            },
            new Image
            {
                Id = 7,
                Title = "slick back",
                Url = "../images/slick_back.jpg"
            },
            new Image
            {
                Id = 8,
                Title = "side part",
                Url = "../images/side_part.jpg"
            },
            new Image
            {
                Id = 9,
                Title = "circle beard",
                Url = "../images/circle_beard.jpg"
            },
            new Image
            {
                Id = 10,
                Title = "royale beard",
                Url = "../images/royale_beard.jpg"
            },
            new Image
            {
                Id = 11,
                Title = "styling hair",
                Url = "../images/styling_hair.jpg"
            },
            new Image
            {
                Id = 12,
                Title = "hair washing",
                Url = "../images/hair_washing.jpg"
            },
            new Image
            {
                Id = 13,
                Title = "tapered sides with side swept fringe",
                Url = "../images/Tapered-Sides-with-Side-Swept-Fringe.jpg"
            },
            new Image
            {
                Id = 14,
                Title = "high fade with hard side part",
                Url = "../images/High-Fade-with-Hard-Side-Part.jpg"
            },
            new Image
            {
                Id = 15,
                Title = "camouflage hair",
                Url = "../images/Camouflage-Hair-men.jpg"
            },
            new Image
            {
                Id = 16,
                Title = "camouflage beard",
                Url = "../images/men-hair-styles-beard-styles.jpg"
            },
            new Image
            {
                Id = 17,
                Title = "camouflage beard",
                Url = "./images/camouflage.jpg"
            },
            new Image
            {
                Id = 18,
                Title = "barber tom",
                Url = "./images/barber_tom.jpg"
            },
            new Image
            {
                Id = 19,
                Title = "barber bob",
                Url = "./images/barber_bob.jpg"
            },
            new Image
            {
                Id = 20,
                Title = "barber david",
                Url = "./images/barber_david.jpg"
            }
        ) ;

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "classic haircut",
                Description = "haircut using hair clipper and scissors",
                ImageId = 1
            },
            new Category
            {
                Id = 2,
                Name = "mustache and beard trim",
                Description = "combing, cutting mustaches and beards",
                ImageId = 2
            },
            new Category
            {
                Id = 3,
                Name = "hair washing and styling",
                Description = "washing and styling your hair, mostache or beard",
                ImageId = 3
            },
            new Category
            {
                Id = 4,
                Name = "children's haircut",
                Description = "classic haircut using hair clipper and scissors for children",
                ImageId = 4
            },
            new Category
            {
                Id = 5,
                Name = "camouflage hair, beard and mustache",
                Description = "painting the beard, hair or mustache borders",
                ImageId = 5
            }
        );

        modelBuilder.Entity<Status>().HasData(
            new Status 
            { 
                Id = 1,
                StatusName = "average user"
            }
       
        );
        modelBuilder.Entity<Service>().HasData(
           new Service
           {
               Id = 1,
               Name = "french crop",
               Description = "The French Crop is classically famous because it is so simple. ",
               ImageId = 6,
               Price = 100,
               TimeToMake = new TimeSpan(1, 0, 0),
               CategoryId = 1,
           },
           new Service
           {
               Id = 2,
               Name = "slick back",
               Description = "The slick back is a stylish hairstyle for men who want a cool and sleek look.",
               ImageId = 7,
               Price = 90,
               TimeToMake = new TimeSpan(0, 50, 0),
               CategoryId = 1,

           },
           new Service
           {
               Id = 3,
               Name = "side part",
               Description = "Whether it is the side parts of the Twenties, Forties, Sixties.",
               ImageId = 8,
               Price = 110,
               TimeToMake = new TimeSpan(1, 10, 0),
               CategoryId = 1,
           },
           new Service
           {
               Id = 4,
               Name = "circle beard",
               Description = "A chin patch and a mustache that forms a circle.",
               ImageId = 9,
               Price = 60,
               TimeToMake = new TimeSpan(0, 30, 0),
               CategoryId = 2,
           },
           new Service
           {
               Id = 5,
               Name = "royale beard",
               Description = "A mustache anchored by a chin strip.",
               ImageId = 10,
               Price = 65,
               TimeToMake = new TimeSpan(0, 35, 0),
               CategoryId = 2,
           },
           new Service
           {
               Id = 6,
               Name = "styling hair",
               Description = "Use any style with your hair.",
               ImageId = 11,
               Price = 6,
               TimeToMake = new TimeSpan(0, 5, 0),
               CategoryId = 3,
           },
           new Service
           {
               Id = 7,
               Name = "hair washing",
               Description = "Usual hair washing.",
               ImageId = 12,
               Price = 5,
               TimeToMake = new TimeSpan(0, 5, 0),
               CategoryId = 3,
           },
           new Service
           {
               Id = 8,
               Name = "tapered sides",
               Description = "Tapered sides are great for kids haircuts if you don’t want a very short fade. ",
               ImageId = 13,
               Price = 75,
               TimeToMake = new TimeSpan(0, 55, 0),
               CategoryId = 4,
           },
           new Service
           {
               Id = 9,
               Name = "high fade with hard side part",
               Description = "Boys fade haircuts keep the sides clean, short and simple, " +
                   "while a hard side part adds a classy yet cool hairstyle on top.",
               ImageId = 14,
               Price = 85,
               TimeToMake = new TimeSpan(1, 0, 0),
               CategoryId = 4,
           },
           new Service
           {
               Id = 10,
               Name = "camouflage hair",
               Description = "Hide your bald.",
               ImageId = 15,
               Price = 90,
               TimeToMake = new TimeSpan(0, 20, 0),
               CategoryId = 5,
           },
           new Service
           {
               Id = 11,
               Name = "camouflage beard",
               Description = "Make a great boards for your beard.",
               ImageId = 16,
               Price = 60,
               TimeToMake = new TimeSpan(0, 10, 0),
               CategoryId = 5,
           }
       );

        modelBuilder.Entity<Barber>().HasData(
            new Barber
            {
                Id = 1,
                Name = "Bob",
                Description = "I like to communicate with customers",
                Position = "Barber",
                Experience = 1,
                ImageId = 19,
                Rate = 4.5,
            }, 
            new Barber
            {
                Id = 2,
                Name = "David",
                Description = "I like to communicate with customers",
                Position = "Barber",
                Experience = 3,
                ImageId = 20,
                Rate = 3.5,
            },
            new Barber
            {
                Id = 3,
                Name = "Tom",
                Description = "I like to communicate with customers",
                Position = "Barber",
                Experience = 5,
                ImageId = 18,
                Rate = 5,
            }

        );
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = 1,
                BarberId = 1,
                UserId = 1,
                ServiceId = 9,
                date = new DateTime(2023, 5, 1),
                time = new TimeSpan(10, 30, 0),
            },
            new Order
            {
                Id = 2,
                BarberId = 1,
                UserId = 1,
                ServiceId = 4,
                date = new DateTime(2023, 5, 1),
                time = new TimeSpan(11, 30, 0),
            },
            new Order
            {
                Id = 3,
                BarberId = 1,
                UserId = 1,
                ServiceId = 1,
                date = new DateTime(2023, 5, 1),
                time = new TimeSpan(12, 00, 0),
            }

        );
        modelBuilder.Entity<User>().HasData(
           new User
           {
               Id = 1,
               Username = "Bob",
               Password = "bob",
               Email = "bob@gmail.com",
               Name = "Bob",
               Surname = "Bob",
               statusId = 1
           }

       );
    }
}

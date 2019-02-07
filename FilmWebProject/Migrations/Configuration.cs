using FilmWebProject.Core.Models;
using FilmWebProject.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace FilmWebProject.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var cinematographers = new List<Director>
            {
                new Director
                {
                    Id = 1,
                    FirstName = "Martin",
                    LastName = "Scorsese",
                    PlaceOfBirth = "New York City",
                    Height = 163,
                    Biography = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ut vestibulum lacus. Phasellus hendrerit a felis ac dapibus. Maecenas a nisi porttitor, consectetur massa non, porttitor elit. Etiam id tellus in magna tristique condimentum. Nam quis feugiat sem. Duis hendrerit cursus mi vel ullamcorper. Nam aliquam viverra ipsum, sit amet placerat leo ullamcorper et. Quisque iaculis venenatis tristique.",
                    DateOfBirth = DateTime.Parse("1942-11-17")
                },
                new Director
                {
                    Id = 2,
                    FirstName = "David",
                    LastName = "Fincher",
                    PlaceOfBirth = "Denver, Colorado, USA",
                    Height = 184,
                    Biography = "Donec vitae tellus nisi. Integer vitae justo aliquam, viverra eros id, tincidunt justo. Pellentesque gravida, turpis vitae faucibus feugiat, lorem ligula convallis arcu, sed sollicitudin neque risus non nibh. Aliquam ullamcorper maximus nisl in aliquet. In quam ante, ornare non rutrum a, mattis a dui. Maecenas finibus bibendum urna. Integer venenatis tempus varius.",
                    DateOfBirth = DateTime.Parse("1962-08-28")
                },
                new Director
                {
                    Id = 3,
                    FirstName = "Ridley",
                    LastName = "Scott",
                    PlaceOfBirth = " South Shields, Tyne and Wear, England, UK",
                    Height = 174,
                    Biography = "Nulla ex nibh, elementum nec felis at, ultrices interdum nulla. Donec fringilla molestie quam nec rhoncus. Vivamus a hendrerit diam. Quisque et tincidunt erat. Donec at consequat nisi. Nulla facilisi. Nam sed lobortis lectus. Proin id libero blandit dui semper ultrices. Nam tempor leo sapien, a tincidunt leo bibendum eu. Pellentesque sed metus ut tortor tincidunt sodales et eu mauris. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut eros justo, dignissim in nibh vel, aliquet tincidunt sapien. Duis ante dolor, blandit ac mauris iaculis, pharetra tincidunt sem. Integer vel auctor augue, a pretium velit. Integer condimentum aliquam libero quis imperdiet. Sed nec placerat metus.",
                    DateOfBirth = DateTime.Parse("1937-11-30")
                },
                new Director
                {
                    Id = 4,
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    PlaceOfBirth = "Knoxville, Tennessee, USA",
                    Height = 185,
                    Biography = "Suspendisse pharetra lobortis mi, ut sodales nibh ultricies in. Sed tincidunt molestie rutrum. Sed id odio lectus. Phasellus malesuada volutpat hendrerit. Sed viverra massa eget est interdum laoreet. Fusce tincidunt odio id nulla tempus sagittis. Donec non leo vel dolor accumsan euismod. Morbi magna ex, tincidunt at magna vitae, rhoncus accumsan tortor. Donec aliquet, quam a suscipit sollicitudin, lectus dolor mattis enim, eget varius magna ante vitae sem. Aliquam erat volutpat. Suspendisse pellentesque lacus vitae fermentum ornare. Proin laoreet ipsum eu viverra ornare. Morbi maximus id risus suscipit dignissim.",
                    DateOfBirth = DateTime.Parse("1963-03-27")
                },
                new Director
                {
                    Id = 5,
                    FirstName = "Peter",
                    LastName = "Jackson",
                    PlaceOfBirth = "Pukerua Bay, North Island, New Zealand",
                    Height = 169,
                    Biography = "Praesent gravida ullamcorper posuere. Nulla nec felis tortor. Integer iaculis ultrices urna in imperdiet. Sed accumsan sodales ligula aliquet fermentum. Sed a felis sem. Sed vel leo fermentum, consectetur augue nec, viverra nisi. Nam in purus ante.",
                    DateOfBirth = DateTime.Parse("1961-10-31")
                },
                new Director
                {
                    Id = 6,
                    FirstName = "Jon",
                    LastName = "Favreau",
                    PlaceOfBirth = "Queens, New York City, New York, USA",
                    Height = 185,
                    Biography = "Nunc eros tellus, scelerisque et molestie eu, consequat sed eros. Mauris finibus quam eros, quis aliquet magna dictum nec. Morbi id magna faucibus, ultricies metus at, porttitor mauris. Nunc condimentum in ex nec aliquet. Vivamus vitae neque at velit gravida laoreet. Etiam a massa et est porta vehicula vel id mi. Nam ultricies sapien et gravida laoreet.",
                    DateOfBirth = DateTime.Parse("1942-11-17")
                },
                new Director
                {
                    Id = 7,
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    PlaceOfBirth = "London, England, UK",
                    Height = 180,
                    Biography = "Proin vitae est arcu. Nullam odio nulla, egestas ac turpis id, euismod tempor elit. Aenean metus felis, vehicula a dolor eu, tempor condimentum leo. Aliquam vitae nunc quam. Ut porta rutrum augue id posuere. Mauris dictum, est vel tincidunt gravida, nisi tortor cursus purus, nec feugiat velit nisi id velit. Nulla sed commodo eros. Fusce gravida nisi sed mollis ornare. Integer in ex nisl. Cras quis purus dignissim nibh commodo cursus et elementum massa. Ut eget porta enim. Quisque a sem sem. Ut vel est neque. Nam eros urna, malesuada eget purus ac, pulvinar iaculis magna. Nulla vel efficitur metus. Cras ornare pretium metus, eget laoreet ex sodales et.",
                    DateOfBirth = DateTime.Parse("1970-07-30")
                },
                new Director
                {
                    Id = 8,
                    FirstName = "Zack",
                    LastName = "Snyder",
                    PlaceOfBirth = "New York City",
                    Height = 163,
                    Biography = "Nunc vestibulum libero pretium massa luctus aliquet. Cras dignissim ullamcorper nulla, id efficitur turpis ullamcorper in. Aliquam vehicula arcu vel sollicitudin eleifend. Maecenas rutrum pretium lacus nec cursus. Phasellus eu dignissim ex. Fusce erat est, efficitur sed vehicula a, blandit id metus. Sed ac mauris aliquet, posuere ex ac, venenatis lacus. Praesent eget nunc consequat, volutpat metus non, malesuada lorem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec in ante a ex eleifend rhoncus. Nulla purus nisi, tempus at consectetur feugiat, feugiat pellentesque odio. Nulla consequat, neque sed congue vulputate, orci ipsum egestas erat, a dignissim lacus ex nec magna.",
                    DateOfBirth = DateTime.Parse("1942-11-17")
                },
                new Director
                {
                    Id = 9,
                    FirstName = "Steven",
                    LastName = "Spielberg",
                    PlaceOfBirth = " Cincinnati, Ohio, USA",
                    Height = 171,
                    Biography = "In maximus velit leo, sit amet iaculis ligula interdum nec. Nulla quam nibh, hendrerit vitae augue sit amet, scelerisque vestibulum magna. Sed consectetur venenatis odio vel consequat. Etiam egestas nulla et hendrerit suscipit. Phasellus cursus pulvinar mi, non fermentum tellus finibus sed. Mauris accumsan dui massa, mollis elementum ligula tristique nec. Donec nisl lacus, efficitur eu turpis non, tincidunt faucibus nisl. Pellentesque sit amet odio finibus, vestibulum felis eget, fermentum enim. Curabitur fermentum lectus semper, blandit turpis nec, ultrices diam. Curabitur sollicitudin commodo ante, vel lobortis massa convallis quis.",
                    DateOfBirth = DateTime.Parse("1946-12-18")
                },
                new Director
                {
                    Id = 10,
                    FirstName = "Anthony",
                    LastName = "Russo",
                    PlaceOfBirth = "Cleveland, Ohio, USA",
                    Height = 165,
                    Biography = "Nunc eros tellus, scelerisque et molestie eu, consequat sed eros. Mauris finibus quam eros, quis aliquet magna dictum nec. Morbi id magna faucibus, ultricies metus at, porttitor mauris. Nunc condimentum in ex nec aliquet. Vivamus vitae neque at velit gravida laoreet. Etiam a massa et est porta vehicula vel id mi. Nam ultricies sapien et gravida laoreet.",
                    DateOfBirth = DateTime.Parse("1942-02-03")
                }
            };

            cinematographers.ForEach(c => context.Directors.AddOrUpdate(p => p.LastName, c));
            context.SaveChanges();

        }
    }
}
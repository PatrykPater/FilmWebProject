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

            cinematographers.ForEach(c => context.Directors.AddOrUpdate(p => p.Id, c));
            context.SaveChanges();

            var films = new List<Film>()
            {
                new Film()
                {
                    Id = 1,
                    Title = "The Green Mile",
                    Duration = new TimeSpan(0,3,8,0),
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vitae vestibulum erat. Phasellus interdum maximus molestie. Proin fringilla risus quis hendrerit consequat. Pellentesque tristique sodales mattis.",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent vitae vestibulum erat. Phasellus interdum maximus molestie. Proin fringilla risus quis hendrerit consequat. Pellentesque tristique sodales mattis. Ut commodo quis diam ac rutrum. Nullam rutrum justo sit amet mauris laoreet, auctor mollis ex commodo. Suspendisse ac felis dui. Nam posuere nibh eleifend gravida bibendum. Curabitur lobortis sem sed efficitur aliquam. Maecenas fermentum libero a leo dictum, non imperdiet nibh suscipit.",
                    Production = "USA",
                    Release = DateTime.Parse("1999-03-24"),
                    Budget = 60000000,
                    Score = 8.6,
                    Studio = "Castle Rock Entertainment ",
                    BoxOffice = 286801374,
                },
                new Film()
                {
                    Id = 2,
                    Title = "The Shawshank Redemption",
                    Duration = new TimeSpan(0,2,22,0),
                    ShortDescription = "Nam convallis elit posuere, convallis erat vitae, porttitor tortor. Mauris ultrices pharetra ultricies.",
                    LongDescription = "Nam convallis elit posuere, convallis erat vitae, porttitor tortor. Mauris ultrices pharetra ultricies. Ut volutpat volutpat urna vitae sollicitudin. Vestibulum ornare leo orci, sit amet interdum sem dapibus id. Etiam ac justo mauris. Vestibulum vel venenatis elit. Maecenas a tellus et tortor imperdiet ornare. Sed elementum justo eget sem euismod, ut suscipit neque consectetur. Etiam ut viverra ex. Etiam accumsan molestie bibendum.",
                    Production = "USA",
                    Release = DateTime.Parse("1995-09-10"),
                    Budget = 25000000,
                    Score = 8.8,
                    Studio = "Castle Rock Entertainment",
                    BoxOffice = 59841469,
                },
                new Film()
                {
                    Id = 3,
                    Title = "Forrest Gump",
                    Duration = new TimeSpan(0,2,22,0),
                    ShortDescription = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.",
                    LongDescription = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Cras et vestibulum augue, at pharetra tortor. Suspendisse facilisis ipsum metus, vitae consequat turpis tempor vitae. Curabitur in imperdiet nisi, at aliquam eros. Maecenas et orci mauris.",
                    Production = "USA",
                    Release = DateTime.Parse("1994-06-23"),
                    Budget = 55000000,
                    Score = 8.5,
                    Studio = "Paramount Pictures",
                    BoxOffice = 677387716,
                },
                new Film()
                {
                    Id = 4,
                    Title = "Requiem for a Dream",
                    Duration = new TimeSpan(0,1,42,0),
                    ShortDescription = " Etiam posuere metus arcu, elementum bibendum sapien venenatis eget. Nulla massa nibh, efficitur id ex ut, tempus eleifend lorem.",
                    LongDescription = "Etiam posuere metus arcu, elementum bibendum sapien venenatis eget. Nulla massa nibh, efficitur id ex ut, tempus eleifend lorem. Nam dapibus lacinia nunc vel pulvinar. Pellentesque egestas, dui id vestibulum sollicitudin, sapien libero sollicitudin lorem, ut suscipit enim felis tristique velit. Nullam id nulla quam. Morbi fringilla, nisi sit amet tempus pulvinar, nibh nulla iaculis erat, at pharetra dolor risus vitae ante. Vivamus sagittis nunc at felis faucibus sollicitudin. Quisque aliquet pulvinar lacus ac elementum.",
                    Production = "USA",
                    Release = DateTime.Parse("2001-03-01"),
                    Budget = 4500000,
                    Score = 0,
                    Studio = "",
                    BoxOffice = 7390108,
                },
                new Film()
                {
                    Id = 5,
                    Title = "Léon",
                    Duration = new TimeSpan(0,1,50,0),
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent at finibus mauris. Morbi sollicitudin risus a dui blandit, eget suscipit lacus faucibus. Praesent imperdiet neque ut pellentesque fringilla.",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent at finibus mauris. Morbi sollicitudin risus a dui blandit, eget suscipit lacus faucibus. Praesent imperdiet neque ut pellentesque fringilla. Aenean nulla orci, commodo at nibh eget, dignissim varius ex. Nunc sollicitudin ipsum eget ligula pulvinar porta. Nunc efficitur lectus imperdiet velit consequat accumsan. Curabitur a ligula molestie, eleifend quam eu, luctus risus.",
                    Production = "France",
                    Release = DateTime.Parse("1994-09-14"),
                    Budget = 0,
                    Score = 8.1,
                    Studio = "Gaumont",
                    BoxOffice = 19501238,
                },
                new Film()
                {
                    Id = 6,
                    Title = "The Matrix",
                    Duration = new TimeSpan(0,2,16,0),
                    ShortDescription = "Quisque pulvinar elit quis mauris sollicitudin, ac porta mi convallis. Donec sit amet cursus metus, at iaculis lorem. Vestibulum sem nibh, interdum sit amet pellentesque vitae, pulvinar vel eros.",
                    LongDescription = "Quisque pulvinar elit quis mauris sollicitudin, ac porta mi convallis. Donec sit amet cursus metus, at iaculis lorem. Vestibulum sem nibh, interdum sit amet pellentesque vitae, pulvinar vel eros. Proin fermentum ex id urna tincidunt, ut commodo erat vestibulum. Nam sed orci nulla. Proin faucibus augue congue lorem scelerisque, vitae iaculis enim sagittis. Proin diam orci, convallis vel lobortis sit amet, finibus pharetra lorem. Nam volutpat, ligula sed aliquam blandit, lectus ex dignissim neque, ut pretium est turpis ut tellus. Donec eget orci eleifend, facilisis neque id, pharetra felis.",
                    Production = "Australia, USA",
                    Release = DateTime.Parse("1999-03-24"),
                    Budget = 63000000,
                    Score = 7.5,
                    Studio = "Warner Bros.",
                    BoxOffice = 463517383,
                },
                new Film()
                {
                    Id = 7,
                    Title = "The Silence of the Lambs",
                    Duration = new TimeSpan(0,1,58,0),
                    ShortDescription = "Vestibulum posuere eget purus non malesuada. Sed interdum dolor sit amet faucibus rutrum. Praesent nisi arcu, euismod et vehicula a, porta eget neque.",
                    LongDescription = "Cras laoreet urna ac libero dictum vestibulum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras ut semper augue, ac dictum diam. Suspendisse mattis felis ut tincidunt congue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean volutpat aliquam mauris ut dignissim. Fusce cursus, magna ac laoreet tempus, felis odio consequat dui, eget congue felis elit vitae ipsum. Phasellus iaculis orci in quam semper, at tempor augue vulputate.",
                    Production = "USA",
                    Release = DateTime.Parse("1991-01-30"),
                    Budget = 19000000,
                    Score = 8.2,
                    Studio = "Orion Pictures Corporation",
                    BoxOffice = 272742922,
                },
                new Film()
                {
                    Id = 8,
                    Title = "Avatar",
                    Duration = new TimeSpan(0,2,42,0),
                    ShortDescription = "Quisque auctor semper sem ut tempor. Morbi quis tellus fringilla, lobortis mauris ut, pharetra lacus. Phasellus dictum ex vitae leo vulputate, vel vehicula sapien ornare. In dictum quam vitae lacus congue convallis.",
                    LongDescription = "Quisque auctor semper sem ut tempor. Morbi quis tellus fringilla, lobortis mauris ut, pharetra lacus. Phasellus dictum ex vitae leo vulputate, vel vehicula sapien ornare. In dictum quam vitae lacus congue convallis. Nulla vulputate, augue in placerat pulvinar, nisl nunc scelerisque orci, non dignissim sem felis rhoncus turpis. Morbi suscipit lorem tellus, vel feugiat eros eleifend eu. Etiam ullamcorper nisi elit, ac tempor purus dictum ac. Curabitur gravida quam tempus dolor sollicitudin, sed consectetur diam porta.",
                    Production = "The United Kingdom, USA",
                    Release = DateTime.Parse("2009-12-10"),
                    Budget = 237000000,
                    Score = 7.4,
                    Studio = "Dune Entertainment",
                    BoxOffice = 2782275172,
                },
                new Film()
                {
                    Id = 9,
                    Title = "Titanic",
                    Duration = new TimeSpan(0,3,14,0),
                    ShortDescription = "Quisque viverra tempus sapien, ac scelerisque metus vehicula at. Curabitur tristique tristique turpis at suscipit.",
                    LongDescription = "Aenean cursus augue quis leo luctus porta. Sed dignissim lacus vitae tempor pulvinar. Nam ut accumsan enim, vel molestie nisl. Cras eget ipsum egestas, elementum sem eu, blandit tortor. Integer accumsan ex et felis aliquet, id tristique sapien euismod. Proin nec risus nec ex congue euismod id id orci. In hac habitasse platea dictumst.",
                    Production = "USA",
                    Release = DateTime.Parse("1997-11-01"),
                    Budget = 200000000,
                    Score = 7.3,
                    Studio = "Paramount Pictures",
                    BoxOffice = 2187463944,
                },
                new Film()
                {
                    Id = 10,
                    Title = "Gladiator",
                    Duration = new TimeSpan(0,2,35,0),
                    ShortDescription = "Nam ut dolor ultrices, porta lacus sit amet, euismod neque. Donec maximus rhoncus elit, dapibus molestie neque ullamcorper ac. Suspendisse maximus dui nec eros porta tincidunt.",
                    LongDescription = "Nam ut dolor ultrices, porta lacus sit amet, euismod neque. Donec maximus rhoncus elit, dapibus molestie neque ullamcorper ac. Suspendisse maximus dui nec eros porta tincidunt. Integer in ullamcorper risus, a eleifend mauris. Curabitur rutrum mi eget eros rhoncus, a mattis diam condimentum. Sed blandit a orci vitae molestie. Maecenas ut efficitur eros, efficitur elementum arcu. Praesent turpis lectus.",
                    Production = "The United Kingdom, USA",
                    Release = DateTime.Parse("2000-03-01"),
                    Budget = 103000000,
                    Score = 8.1,
                    Studio = "DreamWorks SKG",
                    BoxOffice = 457640427,
                },
            };

            films.ForEach(c => context.Films.AddOrUpdate(p => p.Id, c));
            context.SaveChanges();

            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Action"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Animated"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Documentary"
                },
                new Genre()
                {
                    Name = "Drama"
                },
                new Genre()
                {
                    Id = 4,
                    Name = "Family"
                },
                new Genre()
                {
                    Id = 5,
                    Name = "Fantasy"
                },
                new Genre()
                {
                    Id = 6,
                    Name = "Horror"
                },
                new Genre()
                {
                    Id = 7,
                    Name = "Comedy"
                },
                new Genre()
                {
                    Id = 8,
                    Name = "Crime"
                },
                new Genre()
                {
                    Id = 9,
                    Name = "Silent"
                },
                new Genre()
                {
                    Id = 10,
                    Name = "Adventure"
                },
                new Genre()
                {
                    Id = 11,
                    Name = "Romance"
                },
                new Genre()
                {
                    Id = 12,
                    Name = "Sci-fi"
                },
                new Genre()
                {
                    Id = 13,
                    Name = "Thriller"
                },

            };

            genres.ForEach(c => context.Genres.AddOrUpdate(p => p.Id, c));
            context.SaveChanges();

        }
    }
}
# FilmWebProject
The project's features are based on popular polish website Filmweb. The goal is to practise the use of technologies i already know, as well as learning and implementing new ones. The focus of the project is back-end code as im trying to be primarily a back-end developer, though if i have the time, i will try and learn more about front-end technologies and improve this aspect of the app in the future.

The app is made in .NET Framework. The current architecture is based on the concept of layering. There are Data, Model, Repository, Service and Presentation layers, decoupled from each other thanks to Unit Of Work, Repository design patterns and Dependency Injection performed with Autofac. Database has been built with Code First approach using Fluent Api. Some of the features are done in API, though they are not fully following REST guidelines yet. I'm also trying to follow the guidelines of SOLID, it's work in progress and something i intend to improve on over time.

The technologies used to write the app:

- Asp.Net MVC 5 & Asp.Net Web API 2
- Entity Framework
- Bootstrap
- Automapper
- Autofac
- JavaScript/jQuery
- Html/CSS
- LINQ

Currently working features:

- Working relational Database
- CRUD operations for film and partially for other entities 
- Displaying list
- Looking up all of film's details at it's own page.
- Searching by title for a specific film in databse through searchbox.
- Rating a film
- Displaying film's overall Score
- Searching for other users/friends by last and first name.
- Working notification system, at the moment it supports friend requests only, you get the number of new notifications upon login into your account. You can check those notifications at separate page where they are displayed in a table with appriopriate actions available to them (like accepting/declining a friend request).
- You can add another user as a friend if they accept your friend request.
- Working news system - The top 4 (newest) news are displayed in carousel, the rest is displayed below in a column (picture+title+short description). Only news no older than 24 hours are displayed on the main page.
- You can click on the Read More buton or the short descritpion to see the full article.
- Admins Panel with an option to promote chosen users to Moderators. Moderators will have exclusive rights to write articles/new and add new movies/tv shows/celebrities to the database (in the future).
- Pagination - currently works on List of Films page only.
- Filetring the list of movies by multiple paramters - for now works with genres and queries

On todo list:
- Paging, sorting, filtering for films, news etc.
- Client side validation with Fluent Validation
- Strongly typed helpers with T4MVC
- Reviews system
- Add notification if your friend has rated a film.
- Polish/Improve existing features

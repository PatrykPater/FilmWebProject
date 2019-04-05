# FilmWebProject
The project's features are based on popular polish website Filmweb. The goal is to practise the use of technologies i already know, as well as learning and implementing new ones. The focus of the project is backend code as im trying to be primarily a backend developer, though if i have the time, i will try and learn more about frontend technologies and improve this aspect of the app in the future. As it is right now, it consists mainly of copy & paste bootstrap templates just to give me some tangible interface i can work with.

The app is made in .NET Framework. I'm currently learning about clean architecture and slowly trying to improve the app according its concepts. The current architecture is based on the concept of layering. There are Data, Model, Repository, Service and Presentation layers, decoupled from each other thanks to Unit Of Work design pattern and Dependency Injection performed with Autofac. Soem of the features are also done in API, though they are not done according to REST guidelines yet. I'm also trying to follow the guidelines of SOLID, the concept is relatively difficult to implement properly for someone new like myself, it's a work in progress and something i'm trying to improve on.

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
- Creating a film
- Updating film's details
- Deleting a film (done in API)
- Displaying list of films and some of their details in a table
- Looking up all of film's details at it's own page.
- Searching by title for a specific film in databse through searchbox.
- Option to bookmark the search
- Rating a Film and displaying its overall Score (done in API)
- Searching for other users/friends by last and first name, an option to bookmark the search.
- Working notification system, should be easy to expand, at the moment it supports friend requests only, you get the number of new notifications upon login into your account. You can check those notifications at separate page where they are displayed in a table with appriopriate actions available to them (like accepting/declinging a friend request). (done mainly in API)
- You can add another user as a friend if they accept your friend request. (done in API)

On todo list:

- Refactor Data layer to get rid of duplicate and redundant code
- Implement API controllers according to REST guidelines.
- Notification if your friend has rated a film.
- Abilit to comment on the notification.
- Ability to write a review about a movie.
- Ability to lookup film's reviews and comment on them.

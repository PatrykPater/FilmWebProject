# FilmWebProject
The project's features are based on popular polish website Filmweb. The goal is to practise the use of technologies i already know, as well as learning and implementing new ones. The focus of the project is backend code as im trying to be primarily a backend developer, though if i have the time, i will try and learn more about frontend technologies and improve this aspect of the app in the future. As it is right now, it consists mainly of copy & paste bootstrap templates just to give me some tangible interface i can work with.

The current architecture is based on the concept of layering. There are Data, Model, Repository, Service and Presentation layers, decoupled from each other thanks to Unit Of Work design pattern and Dependency Injection performed with Ninject. I also have small API, though its not done according to REST guidelines yet. I'm also trying to follow the guidelines of SOLID, the concept is relatively difficult for someone new like me to implement properly, it's a work in progress and something i'm trying to improve on.

The technologies used to write the app so far:

- Entity Framework
- Bootstrap
- Automapper
- Ninject

Current working features:

- Working relational Database
- Creating a film
- Updating film's details
- Deleting a film (done with API)
- Displaying list of films and some of their details in a table
- Looking up all of film's details at separate page.
- Searching for a specific film in databse through searchbox and displaying it without reloading the page.
- Ability to save the search for later use (the result of the search url consits of attached query string)
- Rating a Film and displaying its overall Score. (done with API)

On todo list so far:

- Ability for a user to add another user as a friend
- Notification if your friend has rated a film
- Abilit to comment on the notification
- Ability to write a review about a movie.
- Ability to lookup film's reviews and comment on them.

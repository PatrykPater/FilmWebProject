# FilmWebProject
The project's features are based on popular polish website Filmweb. The goal is to practise the use of technologies i already know, as well as implementing and learning new ones. The focus of the project is backend code as im trying to be primarily a backend developer, though if i have the time i will try and learn more about frontent technologies and improve this aspect of the app in the future. As it is right now, it consists mainly of copy & paste bootstrap templates just to give me some tangible interface i can work with.

The current architecture is based on the concept of layering. There are Data, Models, Repositories, Services and Presentations layers, decoupled from each other thanks to Unit Of Work design pattern and Dependency Injection performed with Ninject. I also have small API, though its not done according to REST yet.

The technologies used to write the app so far:

- Entity Framework
- Bootstrap
- Automapper
- Ninject

Current working features:

- Creating a film
- Updating film's details
- Deleting a film
- Displaying list of films and some of their details in a table
- Searching for a specific film in databse through searchbox and displaying it
- Ability to save the search for later use (the result of the search url consits of query attached query string)
- Rating a Film

On todo list so far:

- An ability for a user to add another user as a friend
- Notification if your friend has rated a film
- Abilit to comment on the notification
- Ability to write a review about a movie.
- Ability to lookup film's reviews and comment on them.

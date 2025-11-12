# Models Relationship Diagram

```mermaid
classDiagram
    class Category {
        int Id
        string Name
        List<Movie> Movies
    }
    class Movie {
        int Id
        string Title
        int CategoryId
        Category Category
        List<MovieUser> MovieUsers
        List<Favorites> Favorites
    }
    class MovieUser {
        int Id
        string FullName
        string Email
        List<Movie> Movies
        List<Favorites> Favorites
    }
    class Favorites {
        int Id
        string Name
        List<Movie> Movies
        int MovieUserId
        MovieUser Owner
    }

    Category "1" --o "*" Movie : contains
    Movie "*" --o "*" MovieUser : watched by
    Movie "*" --o "*" Favorites : in lists
    MovieUser "1" --o "*" Favorites : owns lists
```

// Checklist (x for done, - for not done):
// - [x] Create diagram folder if needed
// - [x] Create mermaid diagram for relationships
// - [x] Show one-to-many and many-to-many relationships
// - [x] Add Favorites model and update diagram
// - [x] Show one-to-many and many-to-many relationships

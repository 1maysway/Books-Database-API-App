using TranslatedBooks.Model;
using Microsoft.EntityFrameworkCore;
using TranslatedBooks.Model.Entity;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "https://1maysway.github.io"));

app.MapGet("/", async (HttpContext context, ApplicationDbContext db) =>
{
    var responseData = new { Time = DateTime.Now, Message = "Server is running" };
    await context.Response.WriteAsJsonAsync(responseData);
});

app.MapGet("/books/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Books.ToListAsync();
});

app.MapPost("/books/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Book? book = await context.Request.ReadFromJsonAsync<Book>();
    if(book != null)
    {
        db.Books.Add(book);
        db.SaveChanges();
    }
    else
    {
        context.Response.StatusCode = 404;
    }
    return book;
});

app.MapGet("/books/{id}", async (int id,HttpContext context, ApplicationDbContext db) =>
{
    //Book? book = await context.Request.ReadFromJsonAsync<Book>();
    Book? book = await db.Books.FindAsync(id);
    if (book==null)
    {
        context.Response.StatusCode = 404;
    }
    return book;
});

app.MapPost("/books/delete/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    db.Books.Remove(book);

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

app.MapPost("/books/update/{id}", async (int id, Book updatedBook, HttpContext context, ApplicationDbContext db) =>
{
    var book = await db.Books.FindAsync(id);
    Console.WriteLine(updatedBook);

    if (book == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    book.OriginalTitle = updatedBook.OriginalTitle;
    book.AuthorsIds = updatedBook.AuthorsIds;
    book.PublishedCountry = updatedBook.PublishedCountry;
    book.PublishedDate = updatedBook.PublishedDate;
    book.PublisherId = updatedBook.PublisherId;
    book.PagesCount = updatedBook.PagesCount;
    book.Description = updatedBook.Description;
    book.GenresIds = updatedBook.GenresIds;

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

///////////////

app.MapGet("/publishers/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Publishers.ToListAsync();
});

app.MapPost("/publishers/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Publisher? publisher = await context.Request.ReadFromJsonAsync<Publisher>();
    if (publisher != null)
    {
        db.Publishers.Add(publisher);
        db.SaveChanges();
    }
    else
    {
        context.Response.StatusCode = 404;
    }
    return publisher;
});

app.MapGet("/publishers/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    Publisher? publisher = await db.Publishers.FindAsync(id);
    if (publisher == null)
    {
        context.Response.StatusCode = 404;
    }
    return publisher;
});

app.MapPost("/publishers/delete/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    var publisher = await db.Publishers.FindAsync(id);

    if (publisher == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    db.Publishers.Remove(publisher);

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

app.MapPost("/publishers/update/{id}", async (int id, Publisher updatedPublisher, HttpContext context, ApplicationDbContext db) =>
{
    var publisher = await db.Publishers.FindAsync(id);

    if (publisher == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    publisher.Name = updatedPublisher.Name;
    publisher.Country = updatedPublisher.Country;
    publisher.BooksIds = updatedPublisher.BooksIds;

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

/////////////////

app.MapGet("/genres/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Genres.ToListAsync();
});

app.MapPost("/genres/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Genre? genre = await context.Request.ReadFromJsonAsync<Genre>();
    if (genre != null)
    {
        db.Genres.Add(genre);
        db.SaveChanges();
    }
    else
    {
        context.Response.StatusCode = 404;
    }
    return genre;
});

app.MapGet("/genres/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    Genre? genre = await db.Genres.FindAsync(id);
    if (genre == null)
    {
        context.Response.StatusCode = 404;
    }
    return genre;
});

app.MapPost("/genres/delete/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    var genre = await db.Genres.FindAsync(id);

    if (genre == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    db.Genres.Remove(genre);

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

app.MapPost("/genres/update/{id}", async (int id, Genre updatedGenre, HttpContext context, ApplicationDbContext db) =>
{
    var genre = await db.Genres.FindAsync(id);

    if (genre == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    genre.Name = updatedGenre.Name;
    genre.Description = updatedGenre.Description;

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

///////////////


app.MapGet("/authors/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Authors.ToListAsync();
});

app.MapPost("/authors/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Author? author = await context.Request.ReadFromJsonAsync<Author>();
    if (author != null)
    {
        db.Authors.Add(author);
        db.SaveChanges();
    }
    else
    {
        context.Response.StatusCode = 404;
    }
    return author;
});

app.MapGet("/authors/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    Author? author = await db.Authors.FindAsync(id);
    if (author == null)
    {
        context.Response.StatusCode = 404;
    }
    return author;
});

app.MapPost("/authors/delete/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    var author = await db.Authors.FindAsync(id);

    if (author == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    db.Authors.Remove(author);

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;
});

app.MapPost("/authors/update/{id}", async (int id, Author updatedAuthor, HttpContext context, ApplicationDbContext db) =>
{
    var author = await db.Authors.FindAsync(id);

    if (author == null)
    {
        context.Response.StatusCode = 404;
        return;
    }

    author.Birthday = updatedAuthor.Birthday;
    author.BooksIds = updatedAuthor.BooksIds;
    author.Country = updatedAuthor.Country;
    author.FullName = updatedAuthor.FullName;

    await db.SaveChangesAsync();

    context.Response.StatusCode = 200;

});


app.Run();

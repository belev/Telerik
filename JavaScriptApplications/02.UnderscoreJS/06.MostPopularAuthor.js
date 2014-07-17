var books = data.getBooks();

var grouptedBooksByAuthor = _.groupBy(books, '_author');

var mostBooksCount = 0;
var mostPopularAuthor = '';

console.log(grouptedBooksByAuthor);

_.each(grouptedBooksByAuthor, function (booksByAuthor, author) {
    if (mostBooksCount < booksByAuthor.length) {
        mostBooksCount = booksByAuthor.length;
        mostPopularAuthor = author;
    }
});

console.log(mostPopularAuthor + ' has ' + mostBooksCount + ' books.');
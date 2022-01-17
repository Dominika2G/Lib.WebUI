import './book.scss';

window.book = (() => {
    const init = () => { };
    const addComment = (id) => {
        var comment = $("#CommentForm").val();
        var rating = $("#RatingId").val();
        var model = {
            description: comment,
            rating: rating,
            bookId: id
        }

        httpClient
            .post({
                url: addCommentUrl,
                data: model
            })
            .then(
                () => {
                    location.reload();
                }
            )
    }

    const back = () => {
        window.location.href = returnUrl;
    }

    const searchBooks = () => {
        var currentValue = $("#SearchValue").val();

        var model = {
            data: currentValue
        }

        httpClient
            .get({
                url: searchBookUrl,
                data: model
            })
            .then(
                (result) => {
                    window.location.href = searchResultUrl.replace("DATA", result);
                }
            )

    }
    const bookReservation = (id) => {
        var model = {
            UserId: 0,
            BookId: id
        }

        httpClient
            .post({
                url: reservationUrl,
                data: model
            })
            .then(
                () => {
                    window.location.href = returnUrl;
                }
            )
    }

    const returnBook = (id) => {
        var model = {
            BookId: id
        }

        httpClient
            .post({
                url: returnBookUrl,
                data: model
            })
            .then(
                () => {
                    window.location.href = returnUrl;
                }
            )
    }

    const changeStateReservation = (id) => {
        var model = {
            UserId: 2,
            BookId: id
        }

        httpClient
            .post({
                url: changeStateReservationUrl,
                data: model
            })
            .then(
                () => {
                    window.location.href = returnUrl;
                }
            )
    }


    return {
        init,
        addComment,
        back,
        searchBooks,
        bookReservation,
        returnBook,
        changeStateReservation
    }

})();

$(function () {
    book.init();
});
import './user.scss';

window.user = (() => {
    const init = () => { };

    const back = () => {
        window.location.href = returnUrl;
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
                    location.reload();
                }
            )
    }

    const backUser = () => {
        window.location.href = returnUserUrl;
    }

    const changeStateReservation = (id) => {
        var model = {
            BookId: id
        }

        httpClient
            .post({
                url: changeStateReservUrl,
                data: model
            })
            .then(
                () => {
                    location.reload();
                }
            )
    }

    return {
        init,
        back,
        returnBook,
        backUser,
        changeStateReservation
    }

})();

$(function () {
    user.init();
});
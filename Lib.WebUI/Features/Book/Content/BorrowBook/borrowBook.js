window.borrowBook = (() => {
    const init = () => { };

    const back = () => {
        console.log("back");
        window.location.href = '/Book';
    }

    return {
        init,
        back
    }
})();

$(function () {
    borrowBook.init();
});
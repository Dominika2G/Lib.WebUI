
window.addBook = (() => {
    const init = () => { };
    const generateCode = () => {
        let r = Math.floor(Math.random() * 1000000000 + 1);
        $("#barCode").val(r);
    }

    return {
        init,
        generateCode
    }
})();

$(function () {
    addBook.init();
});
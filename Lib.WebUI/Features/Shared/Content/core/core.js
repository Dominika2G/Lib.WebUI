import './core.scss';

window.extensionCore = (() => {
    const init = () => {
        removeConstScript();
        removePartialScript();
    };

    const removeConstScript = () => {
        $("#ConstScriptElements").remove();
        $("#SharedConstScriptElements").remove();
    };

    const removePartialScript = () => {
        $(".lib-partial-script-elements").remove();
    };


    const getHash = (str) => {
        let hash = 0, i = 0, len = str.length;
        while (i < len) {
            hash = ((hash << 5) - hash + str.charCodeAt(i++)) << 0;
        }
        return hash;
    };

    return {
        init,
        removePartialScript,
        getHash
    };
})();

$(function () {
    extensionCore.init();
});

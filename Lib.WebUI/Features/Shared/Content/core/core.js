import './core.scss';
import '../http-client/http-client.js';

window.extensionCore = (() => {
    const init = () => {
        removeConstScript();
        removePartialScript();
    };

    const redirectToLink = (link) => {
        window.location.href = link;
    }

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
        getHash,
        redirectToLink
    };
})();

$(function () {
    extensionCore.init();
});

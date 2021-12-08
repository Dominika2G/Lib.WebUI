window.httpClient = {
    get: function (params) {
        return $.ajax({
            url: params.url,
            data: params.data,
            type: 'get'
        });
    },
    post: function (params) {
        return $.ajax({
            url: params.url,
            data: params.data,
            type: 'post'
        });
    }
};
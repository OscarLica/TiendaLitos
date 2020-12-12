var HttpClient = (function () {

    function Get(url) {
        return new Promise((resolve, reject) => {

            resolve(
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    data: null,
                    dataType: "json",
                    success: function (response) {
                        return response;
                    },
                    error: function (req, status, error) {

                    }
                })
            );
        });
    }

    function GetBy(url, data) {
        return new Promise((resolve, reject) => {

            resolve(
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    data: data,
                    dataType: "json",
                    success: function (response) {
                        return response;
                    },
                    error: function (req, status, error) {

                    }
                })
            );
        });
    }

    function Post(url, data) {
        return new Promise((resolve, reject) => {

            resolve(
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    data: data,
                    dataType: "json",
                    success: function (response) {
                        return response;
                    },
                    error: function (req, status, error) {

                    }
                })
            );
        });
    }

    return {
        Get: function (url) {
            return Get(url);
        },
        GetBy: function (url, params) {
            return GetBy(url, params);
        },
        Post: function (url, params) {
            return Post(url, params);
        }
    };

})();
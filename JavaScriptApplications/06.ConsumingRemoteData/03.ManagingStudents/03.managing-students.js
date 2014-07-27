var HttpRequester = (function () {
    var RESOURCE_URL = 'http://localhost:3000/students/';

    function ajaxRequest(url, type, data) {
        var deffered = Q.defer();

        if (data) {
            data = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            data: data,
            contentType: 'application/json',
            success: function (responseData) {
                deffered.resolve(responseData);
            },
            error: function (err) {
                deffered.reject(err);
            }
        });

        return deffered.promise;
    }

    function getRequest() {
        return ajaxRequest(RESOURCE_URL, 'GET');
    }

    function postRequest(data) {
        return ajaxRequest(RESOURCE_URL, 'POST', data);
    }

    function deleteRequest(id) {
        return ajaxRequest(RESOURCE_URL + id, 'DELETE');
    }

    return {
        getStudents: getRequest,
        addStudent: postRequest,
        deleteStudent: deleteRequest
    }
}());
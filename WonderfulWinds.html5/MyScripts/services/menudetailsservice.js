myApp.service('menuDetailsService', function ($http, $q)
{


    this.getMenuDetails = function (index) {
        var currentUrl = 'http://wonderfulwinds.azurewebsites.net/api/v1/mi?index=' + index;
        var request = $http(
            {
                method: 'get',
                url: currentUrl
            }
        );

        return (request.then(handleSuccess, handleError));
    }

    function handleError(response)
    {
        if (!angular.isObject(response.data) || !response.data.message)
        {
            if (response.status == 500)
            {
                return ($q.reject(response.data.ExceptionMessage));

            }
            return ($q.reject("Could not access " + currentUrl + "."));
        }
        return ($q.reject(response.data.message));
    }


    function handleSuccess(response)
    {
        return (response.data);
    }
});
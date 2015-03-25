myApp.service('menuService', function ($http, $q)
{


    this.getMenu = function ()
    {
        var currentUrl = 'http://wonderfulwinds.azurewebsites.net/api/v1/me';
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
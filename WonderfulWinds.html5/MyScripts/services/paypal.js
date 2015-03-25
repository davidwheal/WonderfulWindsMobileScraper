myApp.service('payPalService', function ($http, $q)
{


    this.getOauthToken = function ()
    {
        var currentUrl = 'https://api.sandbox.paypal.com/v1/oauth2/token';
        var request = $http(
            {

                method: 'get',
                url: currentUrl,
                headers: {
                    'Accept': 'application/json', 'Accept-Language': 'en_US',
                    'EOJ2S-Z6OoN_le_KS1d75wsZ6y0SFdVsY9183IvxFyZp': 'EClusMEUk8e9ihI7ZdVLF5cZ6y0SFdVsY9183IvxFyZp',
                    'grant_type': 'client_credentials'
                }
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
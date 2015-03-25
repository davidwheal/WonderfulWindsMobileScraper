

myApp.controller('MenuController', ['$scope', 'menuService',
    function ($scope, menuService)
    {

        $scope.error = "";
        $scope.displayerror = false;
        $scope.menu = {};
        getMenu();

        function getMenu()
         {
   
            // The Service returns a promise.
            menuService.getMenu().then(
                function (data)
                {
                    $scope.menu = data;
                },
                function (reason)
                {
                    $scope.error = reason;
                    $scope.displayerror = true;
                    console.log("Menu failed load", reason);
                }
                );


        }



    }

]
);

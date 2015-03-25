myApp.controller('SynopsisController', ['$scope', '$http', '$sce', function synopsisController($scope, $http, $sce)
{
    $scope.wwmenu;
    $scope.wwcontent;
    $scope.synopsis;
    getMenu();
    console.log($scope.wwmenu);



    $scope.getContent = function (index)
    {

        $http({ method: 'GET', url: 'http://wonderfulwinds.azurewebsites.net/api/v1/mi?index=' + index }).
            success(function (data, status, headers, config)
            {
                // this callback will be called asynchronously
                // when the response is available
                $scope.wwcontent = data;
                $scope.synopsis = $sce.trustAsHtml(data.Item.SynopsisHtml);
                console.log(data.Item.SynopsisHtml);
            }).
            error(function (data, status, headers, config)
            {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                console.log(status);
            });


    };

    function getMenu()
    {

        $http({ method: 'GET', url: 'http://wonderfulwinds.azurewebsites.net/api/v1/me' }).
            success(function (data, status, headers, config)
            {
                // this callback will be called asynchronously
                // when the response is available
                $scope.wwmenu = data;
                $scope.getContent(0);
                console.log(data);
            }).
            error(function (data, status, headers, config)
            {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                console.log(status);
            });


    }



}]
);


myApp.controller('CheckoutController', ['$scope', '$location', 'basketService',
    function ($scope, $location, basketService)
    {
        $scope.basket;
        $scope.baskettotal = 0;

        $scope.basket = basketService.getBasket();
        $scope.baskettotal = basketService.getTotal();




    }]
    );
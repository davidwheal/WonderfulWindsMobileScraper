var myApp = angular.module('WonderfulWindsMobileApp', ['ui.router', 'ngAudio','ngTable']);

//myApp.controller('ctrl', function ($scope, $state)
//{
//    $scope.changeState = function ()
//    {
//        $state.transitionTo('menu');
//    };
//});


myApp.config(function ($stateProvider, $urlRouterProvider)
{

    $urlRouterProvider.otherwise('/menu/' + new Date().getTime() / 1000);

    $stateProvider
        .state('checkout', {
            url: '/checkout/' + new Date().getTime() / 1000,
            templateUrl: '../MyPartialPages/checkout.html',
            controller: 'CheckoutController'})
        .state('menu', {
            url: '/menu/' + new Date().getTime() / 1000,
            templateUrl: '../MyPartialPages/menu.html',
            controller: 'MenuController'
        })
         .state('about', {
             url: '/about/' + new Date().getTime() / 1000,
             templateUrl: '../MyPartialPages/about.html',
             controller: 'WWController'
         })
        .state('menudetails', {
            url: '/menudetails/{index}/' + new Date().getTime() / 1000,
            templateUrl: '../MyPartialPages/menudetails.html',
            controller: 'MenuDetailsController'
        });

});
 
// Start up state
myApp.run(function ($state)
{
    $state.transitionTo('menu');
});


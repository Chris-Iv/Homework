'use strict';

var app = angular.module('app', ['ngRoute', 'ngResource']);

app.constant('headers', {
    'X-Parse-Application-Id': 'N88gT2xkmjtwqTMHY7TMVtF35vN2rMsUvaOh0bVw',
    'X-Parse-REST-API-Key': 'PyqrZ5W8uzC3fKDG7R564JQaAotc2NfclgXemzo4'
});
app.constant('baseServiceUrl', 'https://api.parse.com/1/');

app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'templates/home.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/login', {
        templateUrl: 'templates/login.html',
        controller: 'LoginController'
    });

    $routeProvider.when('/register', {
        templateUrl: 'templates/register.html',
        controller: 'RegisterController'
    });

    $routeProvider.when('/estates', {
        templateUrl: 'templates/estates.html',
        controller: 'EstatesController'
    });

    $routeProvider.when('/estates/add', {
        templateUrl: 'templates/estate/add-estate.html',
        controller: 'EstateAddController'
    });

    $routeProvider.when('/estates/edit', {
        templateUrl: 'templates/estate/edit-estate.html',
        controller: 'EstateEditController'
    });

    $routeProvider.when('/estates/delete', {
        templateUrl: 'templates/estate/delete-estate.html',
        controller: 'EstateDeleteController'
    });
});

app.run(function ($rootScope, $location, authService) {
    $rootScope.$on('$locationChangeStart', function (event) {
        //if ($location.path().indexOf('/estates') != 1 && !authService.isLoggedIn()) {
        //    $location.path('/');
        //}
    })
});
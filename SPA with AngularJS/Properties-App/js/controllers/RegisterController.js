'use strict';

app.controller('RegisterController',
    function ($scope, $location, authService, notifyService) {
        $scope.register = function (userData) {
            authService.register(
                userData,
                function success() {
                    notifyService.showInfo('Registration successful');
                    $location.path('/');
                },

                function error(err) {
                    notifyService.showError('Registration failed', err);
                }
            )
        }
});
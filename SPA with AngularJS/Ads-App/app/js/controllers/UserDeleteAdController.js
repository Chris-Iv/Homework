'use strict';

app.controller('UserDeleteAdController',
    function ($scope, $location, $routeParams, userService, categoriesService, townsService, notifyService) {
        window.scrollTo(0,0);

        $scope.adData = {};
        function getUserAd(id) {
            userService.getUserAdById(
                id,
                function success(data) {
                    $scope.adData = data;
                },

                function error(err) {
                    notifyService.showError('Cannot load user ad', err);
                }
            );
        }

        getUserAd($routeParams.id);

        $scope.deleteAd = function (adData) {
            userService.deleteAd(
                adData.id,
                function (success) {
                    notifyService.showInfo('Ad deleted successfully');
                    $location.path('/user/ads');
                },

                function (err) {
                    notifyService.showError('Ad delete failed', err);
                }
            );
        }
});
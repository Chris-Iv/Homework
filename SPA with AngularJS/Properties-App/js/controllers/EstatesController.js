'use strict';

app.controller('EstatesController',
    function ($scope, estatesService, notifyService) {
        $scope.loadEstates = function () {
            estatesService.getEstates(
                function success(data) {
                    $scope.estates = data;
                },

                function error(err) {
                    notifyService.showError('Cannot load estates', err);
                }
            )
        };

        $scope.loadEstates();
});
'use strict';

app.controller('EstateAddController',
    function ($scope, $location, estatesService, notifyService) {
        $scope.addEstate = function (estateData) {
            estatesService.addEstate(
                estateData,
                function success() {
                    notifyService.showInfo("New estate added successfully");
                    $location.path('/estates');
                },

                function error(err) {
                    notifyService.showError('New estate add failed');
                }
            )
        }
});
'use strict';

app.controller('EstateEditController',
    function ($scope, $location, estatesService, notifyService) {
        window.scrollTo(0,0);

        $scope.editEstate = function (estateData) {
            estatesService.editEstate(
                estateData,
                function success() {
                    notifyService.showInfo("Estate edited successfully");
                    $location.path('/estates');
                },

                function error(err) {
                    notifyService.showError('Estate edited failed');
                }
            )
        }
    });
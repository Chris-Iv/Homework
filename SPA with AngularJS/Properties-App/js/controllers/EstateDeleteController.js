'use strict';

app.controller('EstateDeleteController', function ($scope, $location, estatesService, notifyService) {
    window.scrollTo(0,0);

    $scope.deleteEstate = function (estateData) {
        estatesService.deleteEstate(
            estateData,
            function success() {
                notifyService.showInfo('Estate deleted successfully');
                $location.path('/estates');
            },

            function error(err) {
                notifyService.showError('Estate delete failed', err);
            }
        )
    }
});
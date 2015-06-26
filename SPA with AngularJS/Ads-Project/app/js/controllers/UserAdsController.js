'use strict';

app.controller('UserAdsController',
    function ($scope, $rootScope, userService, notifyService, pageSize) {
        $rootScope.pageTitle = 'My Ads';

        $scope.adsParams = {
            'startPage': 1,
            'pageSize': pageSize
        };

        $scope.reloadUserAds = function () {
            userService.getUserAds(
                $scope.adsParams,
                function success(data) {
                    $scope.userAds = data;
                },

                function error(err) {
                    notifyService.showError('Cannot load user ads', err);
                }
            );
        };

        $scope.deactivateAd = function (ad) {
            userService.deactivateAd(
                ad.id,
                function success(data) {
                    ad.status = 'Inactive';
                    notifyService.showInfo('Ad deactivated successfully');
                },

                function error(err) {
                    notifyService.showError('Cannot deactivate ad', err);
                }
            );
        };

        $scope.publishAgainAd = function (ad) {
            userService.publishAgainAd(
                ad.id,
                function success(data) {
                    ad.status = 'WaitingApproval';
                    notifyService.showInfo('Ad republished successfully');
                },

                function error(err) {
                    notifyService.showError('Cannot republish ad', err);
                }
            );
        };

        $scope.reloadUserAds();

        $scope.$on("statusSelectionChanged", function (event, selectedStatus) {
            $scope.adsParams.status = selectedStatus;
            $scope.adsParams.startPage = 1;
            $scope.reloadUserAds();
        });
});
'use strict';

app.controller('UserEditProfileController',
    function ($scope, $rootScope, $location, authService, townsService, notifyService) {
        $rootScope.pageTitle = 'Edit Profile';

        $scope.towns = townsService.getTowns();

        $scope.getUserProfile = function () {
            authService.getUserProfile(
                function success(data) {
                    $scope.userData = data;
                },

                function error(err) {
                    notifyService.showError('Cannot load user profile', err);
                }
            );
        };

        $scope.getUserProfile();
        
        $scope.editUser = function (userData) {
            authService.editUser(
                userData,
                function success() {
                    notifyService.showInfo('User edited successfully');
                    $location.path('/');
                },

                function error(err) {
                    notifyService.showError('User edit failed', err);
                }
            );
        };

        $scope.changePassword  = function (passData) {
            authService.changePassword(
                passData,
                function success() {
                    notifyService.showInfo('Changed password successfully');
                    $location.path('/');
                },

                function error(err) {
                    notifyService.showError('Change password failed', err);
                }
            )
        }
});
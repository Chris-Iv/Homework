'use strict';

app.factory('authService',
    function ($http, headers, baseServiceUrl) {
        return {
            login: function (userData, success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + 'login',
                    headers: headers,
                    data: userData
                };
                $http(request).success(function (data) {
                    sessionStorage['currentUser'] = JSON.stringify(data);
                    success(data);
                }).error(error);
            },

            register: function (userData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + 'users',
                    headers: headers,
                    data: userData
                };
                $http(request).success(function (data) {
                    sessionStorage['currentUser'] = JSON.stringify(data);
                    success(data);
                }).error(error);
            },

            logout: function () {
                delete sessionStorage['currentUser'];
            },

            isLoggedIn: function () {
                return sessionStorage['currentUser'] != undefined;
            },

            isAnonymous: function () {
                return sessionStorage['currentUser'] == undefined;
            },

            getCurrentUser: function () {
                var userObject = sessionStorage['currentUser'];
                if (userObject) {
                    return JSON.parse(userObject);
                }
            }
        }
});
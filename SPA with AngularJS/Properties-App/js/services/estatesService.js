'use strict';

app.factory('estatesService',
    function ($http, headers, baseServiceUrl) {
        return {
            getEstates: function (success, error) {
                var request = {
                    method: 'GET',
                    url: baseServiceUrl + 'classes/Estate',
                    headers: headers
                };
                $http(request).success(success).error(error);
            },

            addEstate: function (estateData, success, error) {
                var request = {
                    method: 'POST',
                    url: baseServiceUrl + 'classes/Estate',
                    headers: headers,
                    data: estateData

                };
                $http(request).success(success).error(error);
            },

            editEstate: function (estateData, success, error) {
                var request = {
                    method: 'PUT',
                    url: baseServiceUrl + 'classes/Estate/estate ' + estateData.id,
                    headers: headers,
                    data: estateData

                };
                $http(request).success(success).error(error);
            },

            deleteEstate: function (estateData, success, error) {
                var request = {
                    method: 'DELETE',
                    url: baseServiceUrl + 'classes/Estate/estate ' + estateData.id,
                    headers: headers,
                    data: estateData
                };
                $http(request).success(success).error(error);
            }
        }
});
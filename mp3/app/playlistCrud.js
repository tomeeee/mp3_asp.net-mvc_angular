angular.module('playlist.controller')
    .factory('plCRUD', ['$http', function ($http) {
        var plCRUD = {};

        plCRUD.Getall = function () {
            var p = $http({
                method: 'GET',
                url: '/api/playlist/all'
            })
                .then(function (response) {
                    return response.data;
                },
                function (response) {
                    return response.statusText;
                });
            return p;
        };

        plCRUD.ById = function (id) {
            var p = $http({
                method: 'GET',
                url: '/api/playlist/byId/' + id
            })
                .then(function (response) {
                    return response.data;
                },
                function (response) {
                    return response.statusText;
                });
            return p;
        };

        plCRUD.Update = function (playlist) {
            var p = $http({
                method: 'POST',
                url: '/api/playlist/update',
                data: playlist,
            })
            .then(function (response) {
                return response.statusText;
            },
            function (response) {
                return response.statusText;
            });
            return p;
        };

        plCRUD.Add = function (playlist) {
            var p = $http({
                method: 'POST',
                url: '/api/playlist/add',
                data: playlist
            })
            .then(function (response) {
                return response.data;
            });
            return p;
        };

        plCRUD.Delete = function (id) {
            var p = $http({
                method: 'POST',
                url: '/api/playlist/delete/' + id,
            })
            .then(function (response) {
                return response.statusText;
            });
            return p;
        };

        return plCRUD;
    }]);
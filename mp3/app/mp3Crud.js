angular.module('mp3.controller')
    .factory('mp3CRUD', ['$http', function ($http) {
        var mp3CRUD = {};

        mp3CRUD.Getall = function () {
            var p = $http({
                method: 'GET',
                url: '/api/mp3/all'
            })
                .then(function (response) {
                    return response.data; //uspilo
                },
                function (response) {
                    return response.statusText; //greska
                });
            return p;
        };

        mp3CRUD.ById = function (id) {
            var p = $http({
                method: 'GET',
                url: '/api/mp3/byId/' + id
            })
                .then(function (response) {
                    return response.data;
                },
                function (response) {
                    return response.statusText;
                });
            return p;
        };

        mp3CRUD.Add = function (mp3) {
            var p = $http({
                method: 'POST',
                url: '/api/mp3/add',
                data: mp3
            })
            .then(function (response) {
                return response.data;
            });
            return p;
        };

        mp3CRUD.Delete = function (id) {
            var p = $http({
                method: 'POST',
                url: '/api/mp3/delete/' + id,
            })
            .then(function (response) {
                return response.statusText;
            });
            return p;
        };

        mp3CRUD.Update = function (mp3) {
            var p = $http({
                method: 'POST',
                url: '/api/mp3/update',
                data: mp3,
            })
            .then(function (response) {
                return response.data;
            },
            function (response) {
                return response.statusText;
            });
            return p;
        };

        return mp3CRUD;
    }]);
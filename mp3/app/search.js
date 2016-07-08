angular.module('search', [])

angular.module('search')
    .controller('search.controller', ['$scope', 'searchHttp', '$routeParams', function ($scope, searchHttp, $routeParams) {
        $scope.mp3 = {};
        $scope.playlist;

        searchHttp.Search($routeParams.key).then(function (data) {
            $scope.mp3.byName = data.resultsByName;
            $scope.mp3.byArtist = data.resultsByArtist;
            $scope.playlist = data.resultsPlaylist;
        });

        // $scope.$parent.search = {};
    }]);

angular.module('search')
    .factory('searchHttp', ['$http', function ($http) {
        var searchHttp = {};

        searchHttp.Search = function (param) {
            var p = $http({
                method: 'GET',
                url: '/api/search/all/values?key=' + param,
            })
            .then(function (response) {
                return response.data;
            },
            function (response) {
                return response.statusText;
            });
            return p;
        };

        return searchHttp;
    }]);
angular.module('playlist.controller', [])

angular.module('playlist.controller')
    .controller('playlist.controller.index', ['$scope', 'plCRUD', function ($scope, plCRUD) {
        $scope.playlist = [];

        plCRUD.Getall().then(function (data) {
            $scope.playlist = data;
        });

    }]);

angular.module('playlist.controller')
    .controller('playlist.controller.edit', ['$scope', 'plCRUD', '$routeParams', function ($scope, plCRUD, $routeParams) {
        $scope.playlist = {};
        $scope.status;
        plCRUD.ById($routeParams.id).then(function (data) {
            $scope.playlist = data;
        });

        $scope.Add = function (notInMp3) {
            $scope.playlist.mp3s.push(notInMp3);
            $scope.playlist.notInPlaylist.splice($scope.playlist.notInPlaylist.indexOf(notInMp3), 1);
        };
        $scope.Remove = function (mp3) {
            $scope.playlist.notInPlaylist.push(mp3);
            $scope.playlist.mp3s.splice($scope.playlist.mp3s.indexOf(mp3), 1);
        };
        $scope.Update = function (playlist) {
            plCRUD.Update(playlist).then(function (data) {
                $scope.status = data;
            });
        };
    }]);


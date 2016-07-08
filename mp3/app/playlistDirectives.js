angular.module('playlist.controller')
    .directive('playlistAdd', ['plCRUD', function (plCRUD) {
        return {
            templateUrl: 'app/template/playlistAdd.html',
            restrict: 'E',
            scope: {
                playlist: '=',
            },
            link: function (scope) {
                scope.Add = function () {
                    plCRUD.Add(scope.newPlaylist).then(function (data) {
                        scope.newPlaylist = data;
                        scope.playlist.push(scope.newPlaylist);
                        scope.newPlaylist = {};
                        scope.addform = false;
                    }, function (data) {
                        scope.status =data.statusText + ", try again";
                    });
                };
            }
        }
    }]);

angular.module('playlist.controller')
    .directive('playlistRepeat', ['plCRUD', function (plCRUD) {
        return {
            templateUrl: 'app/template/playlistDirRepeat.html',
            restrict: 'E',
            scope: {
                playlist: '=',
            },
            link: function (scope) {
                scope.Delete = function (id, $index) {
                    plCRUD.Delete(id).then(function (data) {
                        scope.playlist.splice($index, 1);
                    }, function () {
                        alert("error, try again");
                    });
                };
            }
        }
    }]);
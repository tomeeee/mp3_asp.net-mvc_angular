angular.module('mp3.controller')
    .directive('mp3Repeat', ['mp3CRUD', function (mp3CRUD) {
        return {
            templateUrl: 'app/template/mp3DirRepeat.html',
            restrict: 'E',
            scope: {
                mp3: '=',
            },
            link: function (scope) {
                scope.Delete = function (mp3) {
                    mp3CRUD.Delete(mp3.id).then(function (data) {
                        scope.mp3.splice(scope.mp3.indexOf(mp3), 1);
                    }, function (data) {
                        alert("error, try again");
                    });
                };
            }

        }
    }]);
angular.module('mp3.controller', [])

angular.module('mp3.controller')
    .controller('mp3.controller.index', ['$scope', 'mp3CRUD', function ($scope, mp3CRUD) {
        $scope.mp3 = [];

        mp3CRUD.Getall().then(function (data) {
            $scope.mp3 = data;
        });

    }]);

angular.module('mp3.controller')
    .controller('mp3.controller.add', ['$scope', 'mp3CRUD', function ($scope, mp3CRUD) {
        $scope.newMp3 = {};
        $scope.status;

        $scope.Add = function (newMp3) {
            $scope.stutus = "";
            mp3CRUD.Add(newMp3).then(function (data) {
                    newMp3.id = data.id;
                    $scope.status = "Saved";
            }, function (data) {
                $scope.addMp3Form.$submitted = false;
                $scope.status = data.data.message;
            });
        };

    }]);

angular.module('mp3.controller')
    .controller('mp3.controller.edit', ['$scope', 'mp3CRUD', '$routeParams', function ($scope, mp3CRUD, $routeParams) {
        $scope.mp3 = {};
        $scope.stutus;

        mp3CRUD.ById($routeParams.id).then(function (data) {
            $scope.mp3 = data;
        });

        $scope.Update = function (mp3) {
            $scope.status = "";
            mp3CRUD.Update(mp3).then(function (data) {
                $scope.status = data;
            })
        }

    }]);
angular.module("game").controller('GameCtrl', ['$scope', 'GamesFactory', function ($scope, GamesFactory) {
    $scope.title = "Moving...";

    $scope.init = function init() {
        GamesFactory.GetAll.go().$promise.then(function (dataGames) {
            $scope.games = dataGames;
        });
    }

    $scope.add = function add() {
        GamesFactory.Insert.go($scope.DataGame).$promise.then(function (result) {
            $scope.DataGame.Id = result.id;
            //$scope.dataCargos.push($scope.DataCargo);
        });

    }

}]);
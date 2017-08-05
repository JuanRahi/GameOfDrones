angular.module("game").controller('GameCtrl', ['$scope', '$location', '$routeParams', 'GamesFactory', 'RoundsFactory',
                        function ($scope, $location, $routeParams, GamesFactory, RoundsFactory) {

    $scope.turn = 1;
    
    $scope.init = function init() {
        GamesFactory.GetAll.go().$promise.then(function (dataGames) {
            $scope.games = dataGames;
        });
    }

    $scope.add = function add() {
        GamesFactory.Insert.go($scope.DataGame).$promise.then(function (result) {    
            $location.path("/Play/" + result.game);                    
        });
    }

    $scope.round = function round() {
        var game = $routeParams.id;
        GamesFactory.Get.go({ id: game }).$promise.then(function (dataGame) {
            $scope.game = dataGame.game;
        });
    }

    $scope.play = function play() {
        $scope.turn = 2;
    }

    $scope.nextRound = function nextRound() {
        if ($scope.game.Player1.Play != $scope.game.Player2.Play) {            
            RoundsFactory.Insert.go($scope.game).$promise.then(function (result) {
                if (result.keepPlaying)
                    $location.path("/Play/" + $scope.game.ID);
                else
                    $location.path("/Winner");
            });        
        }
        else {
            alert("tie");
            $scope.turn = 1;
        }

        
    }
    

}]);
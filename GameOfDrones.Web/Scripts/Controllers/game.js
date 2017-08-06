angular.module("game").controller('GameCtrl', ['$scope', '$location', '$routeParams', 'toastr', 'GamesFactory', 'RoundsFactory',
    function ($scope, $location, $routeParams, toastr, GamesFactory, RoundsFactory) {

        $scope.winnerId = $routeParams.winnerId;
        $scope.winnerName = $routeParams.winnerName;
        
        $scope.init = function init() {
            GamesFactory.GetAll.go().$promise.then(function (dataGames) {
                $scope.games = dataGames;
            });
        };

        $scope.add = function add() {
            GamesFactory.Insert.go($scope.DataGame).$promise.then(function (result) {
                $location.path("/Play/" + result.game);
            });
        };

        $scope.round = function round() {
            $scope.turn = 1;
            var game = $routeParams.id;
            GamesFactory.Get.go({ id: game }).$promise.then(function (dataGame) {
                $scope.game = dataGame.game;
            });
        };

        $scope.play = function play(turn) {
            $scope.turn = turn;
        };

        $scope.nextRound = function nextRound() {
            if ($scope.game.Player1.Play != $scope.game.Player2.Play) {
                RoundsFactory.Insert.go($scope.game).$promise.then(function (result) {
                    if (result.KeepPlaying) {
                        $scope.turn = 1;
                        var game = $routeParams.id;
                        GamesFactory.Get.go({ id: game }).$promise.then(function (dataGame) {
                            $scope.game = dataGame.game;
                        });
                    }
                    else
                        $location.path("/Winner/" + result.WinnerId + "/" + result.Winner);
                });            
            }
            else {
                toastr.warning("Tie!");
                $scope.turn = 1;
            }
        };        
}]);
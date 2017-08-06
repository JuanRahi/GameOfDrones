angular.module("game").controller('PlayerCtrl', ['$scope', '$location', '$routeParams', 'toastr', 'PlayersFactory',
    function ($scope, $location, $routeParams, toastr, PlayersFactory) {

        $scope.init = function init() {            
            var player = $routeParams.player;
            PlayersFactory.GetAll.go({ id: player}).$promise.then(function (dataPlayer) {
                $scope.player = dataPlayer;
            });
        };

    }]);
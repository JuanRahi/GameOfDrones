var app = angular.module("game", ['ngRoute', 'ngResource', 'toastr', 'gameFactory', 'angularUtils.directives.dirPagination', 'roundFactory', 'playerFactory']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider',
      function ($routeProvider, $locationProvider, $httpProvider) {
        
        $httpProvider.defaults.useXDomain = true;

        $routeProvider
            .when('/Player/:player', {
                templateUrl: 'Views/Player/Statistics.html',
                controller: 'PlayerCtrl'
            })
            .when('/Games', {
                templateUrl: 'Views/Game/Index.html',
                controller: 'GameCtrl'
            })
            .when('/Play/:id', {
                templateUrl: 'Views/Game/Play.html',
                controller: 'GameCtrl'
            })
            .when('/Winner/:winnerId/:winnerName', {
                templateUrl: 'Views/Game/Winner.html',
                controller: 'GameCtrl'
            })
            .otherwise({
                templateUrl: 'Views/Game/Start.html',
                controller: 'GameCtrl'
            });

        $locationProvider.html5Mode(true);

      }]);





var app = angular.module("game", ['ngRoute', 'ngResource', 'gameService', 'roundFactory']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider',
      function ($routeProvider, $locationProvider, $httpProvider) {
        
        $httpProvider.defaults.useXDomain = true;

        $routeProvider
            .when('/Move', {
                templateUrl: 'Views/Game/Move.html',
                controller: 'GameCtrl'
            })
            .when('/Games', {
                templateUrl: 'Views/Game/Index.html',
                controller: 'GameCtrl'
            })
            .when('/Play/:id', {
                templateUrl: 'Views/Game/Play.html',
                controller: 'GameCtrl'
            })
            .when('/Winner', {
                templateUrl: 'Views/Game/Winner.html',
                controller: 'GameCtrl'
            })
            .otherwise({
                templateUrl: 'Views/Game/Start.html',
                controller: 'GameCtrl'
            });

        $locationProvider.html5Mode(true);

      }]);





(function () {
    'use strict';

    var base_url = 'http://localhost:57464/api/Games';
    var GameService = angular.module('gameService', ['ngResource']);
    GameService.factory('GamesFactory', function ($resource) {
        return {
            Insert: $resource(base_url, null, { go: { method: 'POST', params: { game: '@DataGame' } } }),
            Delete: $resource(base_url, null, { go: { method: 'DELETE', params: { id: '@id' } } }),
            Modify: $resource(base_url, null, { go: { method: 'PUT', params: { game: '@DataGame' } } }),
            GetAll: $resource(base_url, null, { go: { method: 'GET', isArray: true } }),
            Get:    $resource(base_url, null, { go: { method: 'GET', params: { id: '@id' } } })
        };
    });
})();
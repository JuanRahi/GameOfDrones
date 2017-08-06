(function () {
    'use strict';

    var base_url = 'http://localhost:57464/api/Players';
    var PlayersFactory = angular.module('playerFactory', ['ngResource']);
    PlayersFactory.factory('PlayersFactory', function ($resource) {
        return {
            Insert: $resource(base_url, null, { go: { method: 'POST', params: { game: '@DataPlayer' } } }),
            Delete: $resource(base_url, null, { go: { method: 'DELETE', params: { id: '@id' } } }),
            Modify: $resource(base_url, null, { go: { method: 'PUT', params: { game: '@DataPlayer' } } }),
            GetAll: $resource(base_url, null, { go: { method: 'GET',  params: { id: '@id'} } }),
            Get: $resource(base_url, null, { go: { method: 'GET', params: { id: '@id' } } })
        };
    });
})();
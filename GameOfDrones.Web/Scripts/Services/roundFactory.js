(function () {
    'use strict';

    var base_url = 'http://localhost:57464/api/Rounds/';
    var RoundFactory = angular.module('roundFactory', ['ngResource']);
    RoundFactory.factory('RoundsFactory', function ($resource) {
        return {
            Insert: $resource(base_url, null, { go: { method: 'POST', params: { game: '@DataRound' } } }),
            Delete: $resource(base_url, null, { go: { method: 'DELETE', params: { id: '@id' } } }),
            Modify: $resource(base_url, null, { go: { method: 'PUT', params: { game: '@DataRound' } } }),
            GetAll: $resource(base_url, null, { go: { method: 'GET', isArray: true } }),
            Get: $resource(base_url, null, { go: { method: 'GET', params: { id: '@id' } } })
        };
    });
})();
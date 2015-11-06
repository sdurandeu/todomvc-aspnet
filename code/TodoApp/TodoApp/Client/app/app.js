/*global angular */

/**
 * The main TodoMVC app module
 *
 * @type {angular.Module}
 */
angular.module('todomvc', ['ngRoute', 'ngResource'])
	.config(['$routeProvider', function ($routeProvider) {
		'use strict';

		var routeConfig = {
		    controller: 'TodoController',
			templateUrl: 'todomvc-index.html'
		};

		$routeProvider
			.when('/', routeConfig)
			.when('/:status', routeConfig)
			.otherwise({
				redirectTo: '/'
			});
	}]);

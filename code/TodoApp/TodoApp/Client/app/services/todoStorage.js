/*global angular */

/**
 * Services that persists and retrieves todos from  a backend API.
 *
 */
angular.module('todomvc')
	.factory('todoStorage', ["$resource", function ($resource) {
	    'use strict';

	    var store = {
	        todos: [],

	        api: $resource('/api/todo/:id', null,
				{
				    update: { method: 'PUT' }
				}
			),

	        clearCompleted: function () {
	            var originalTodos = store.todos.slice(0);

	            var completeTodos = [];
	            var incompleteTodos = [];
	            store.todos.forEach(function (todo) {
	                if (todo.completed) {
	                    completeTodos.push(todo);
	                } else {
	                    incompleteTodos.push(todo);
	                }
	            });

	            angular.copy(incompleteTodos, store.todos);
                
                // delete all operation was not implemented, so falling back to single delete opps
	            completeTodos.forEach(function (todo) {
	                // TODO: need to wait all here?
	                store.api.delete({ id: todo.id },
                                        function () { },
                                        function error() {
                                            store.todos.push(todo);
                                        }); 
	            });
	        },

	        delete: function (todo) {
	            var originalTodos = store.todos.slice(0);

	            store.todos.splice(store.todos.indexOf(todo), 1);
	            return store.api.delete({ id: todo.id },
					function () {
					}, function error() {
					    angular.copy(originalTodos, store.todos);
					});
	        },

	        get: function () {
	            return store.api.query(function (resp) {
	                angular.copy(resp, store.todos);
	            });
	        },

	        insert: function (todo) {
	            var originalTodos = store.todos.slice(0);

	            return store.api.save(todo,
					function success(resp) {
					    todo.id = resp.id;
					    store.todos.push(todo);
					}, function error() {
					    angular.copy(originalTodos, store.todos);
					})
					.$promise;
	        },

	        put: function (todo) {
	            return store.api.update({ id: todo.id }, todo)
					.$promise;
	        }
	    };

	    return store;
	}]);

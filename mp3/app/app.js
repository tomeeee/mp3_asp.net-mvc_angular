app = angular.module('app', ['ngRoute', 'mp3.controller', 'playlist.controller', 'search']);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/',
        {
            redirectTo: '/playlist'
        })
        .when('/mp3',
        {
            templateUrl: '/app/template/mp3.html',
            controller: 'mp3.controller.index'
        })
        .when('/mp3/add',
        {
            templateUrl: '/app/template/mp3Add.html',
            controller: 'mp3.controller.add'
        })
        .when('/mp3/edit/:id',
        {
            templateUrl: '/app/template/mp3Edit.html',
            controller: 'mp3.controller.edit'
        })
        .when('/playlist',
        {
            templateUrl: '/app/template/playlist.html',
            controller: 'playlist.controller.index'
        })
        .when('/playlist/edit/:id',
        {
            templateUrl: '/app/template/playlistEdit.html',
            controller: 'playlist.controller.edit'
        })
        .when('/search/:key',
        {
            templateUrl: '/app/template/searchResults.html',
            controller: 'search.controller'
        })
});
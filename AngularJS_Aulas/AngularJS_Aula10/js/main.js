/// <reference path="../lib/angular.js" />

var app = angular.module('blog', ['ngRoute']);

// definir a rota
app.config(function ($routeProvider) {

    $routeProvider.when('/', { templateUrl: '/views/home.html' })
        .when('/artigos', { templateUrl: '/views/artigos.html', controller: 'ArtigosController' })
        .when('/sobre', { templateUrl: '/views/sobre.html', controller: 'SobreController' })
        .otherwise({redirectTo: "/"})
});

app.controller('ArtigosController', function ($scope) {
    $scope.artigos = [
        "C#",
        "Angular",
        "SQL"
    ]; 
});

app.controller('SobreController', function ($scope) {
    $scope.titulo = "Sobre";
    $scope.nome = "Leo";
    $scope.sobre = "Artigos sobre Tecnologia!";
});
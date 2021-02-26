/// <reference path="../scripts/angular.js" />

// define a aplicação angular e o controlador
var app = angular.module("livrosApp", []);

// registrar o controller
app.controller("livrosCtrl", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/home/GetTodosLivros/'
    }).then(function successCallback(response) {
        $scope.livros = response.data;
    }, function errorCallback(response) {
        console.log(response);
    });

    $scope.livro = $scope.livros;
    $scope.SelecionaLivro = function (livro) {
        $scope.livro = livro;
    }

    // chama o método AdicionaLivro do controlador
    $scope.IncluiLivro = function (livro) {
        $http.post('/home/AdicionarLivro', livro)
            .then(function successCallback(response) {
                $scope.livros = response;
                delete $scope.livro;
                $scope.TodosLivros();
            }, function errorCallback(response) {
                console.log(response);
            });
    }

    // chama o método AtualizarLivro do controlador
    $scope.AlteraLivro = function (livro) {
        $http.post('/home/AtualizarLivro', { livro })
            .then(function successCallback(response) {
                $scope.livros = response;
                delete $scope.livro;
                $scope.TodosLivros();
            }, function errorCallback(response) {
                console.log(response);
            });
    }

    // chama o método DeletarLivro do controlador
    $scope.DeletaLivro = function (livro) {
        $http.post('/home/DeletarLivro', { livro })
            .then(function successCallback(response) {
                $scope.livros = response;
                delete $scope.livro;
                $scope.TodosLivros();
            }, function errorCallback(response) {
                console.log(response);
            });
    }

    // retorna todos os livros
    $scope.TodosLivros = function () {
        $http.get('/home/GetTodosLivros')
            .then(function successCallback(response) {
                $scope.livros = response.data;
            }, function errorCallback(response) {
                console.log(response);
            });
    }
});
/// <reference path="../lib/angular.min.js" />

// criar o module
var app = angular.module("leoModule", []);

// criar e registrar o controller
app.controller("leoController", function ($scope) {
    $scope.mensagem = "AngularJS Conceitos Básicos";
});
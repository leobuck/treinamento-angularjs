var app = angular
    .module("leoModule", [])
    .controller("leoController", function ($scope, stringService) {
        $scope.transformarTexto = function (input) {

            $scope.output = stringService.processarTexto(input);
        };
    });
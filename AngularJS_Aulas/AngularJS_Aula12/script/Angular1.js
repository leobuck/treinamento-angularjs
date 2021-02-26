// criar o module
var app = angular.module("ProdutosApp", []);

// criar e registrar o controller
app.controller("produtosCtrl", function ($scope, $http) {
    $http.get('ProdutosService.asmx/getProdutos')
        .then(function (response) {
            $scope.produtos = response.data;
        });
});
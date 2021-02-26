angular

    .module('app', ['ngResource'])

    .service('CommonService', ["$http", "$resource", function ($http, $resource) {
        return {
            tarefa: $resource('api/tarefa/:id', {}, {
                todas: { method: 'GET', url: 'api/tarefa', isArray: true },
                salvar: { method: 'POST', url: 'api/tarefa' },
                atualizar: { method: 'PUT', url: 'api/tarefa/:id', params: { id: '@id' } },
                excluir: { method: 'DELETE', url: 'api/tarefa/:id', params: { id: '@id' } }
            })
        };
    }])

    .controller('TarefasController', ['$scope', 'CommonService',function ($scope, CommonService) {
        $scope.Rotulos = "";
        $scope.CarregarTarefas = function () {
            CommonService.tarefa.todas().$promise.then(function (d) {
                $scope.Tarefas = d;
            });
        };

        $scope.Init = function () {
            $scope.CarregarTarefas();
        };

        $scope.Editar = function (tarefa) {
            $scope.Tarefa = tarefa;
            $scope.Rotulos = tarefa.Rotulos.map(x => x.Descricao).join(' ');
        };

        $scope.$watch(function () { return $scope.Rotulos; }, function () {
            if ($scope.Tarefa) {
                var tags = $scope.Rotulos.match(/([^\s]+)/g);
                $scope.Tarefa.Rotulos = tags.map(x => { return { Descricao: x };});
            }
        });

        $scope.Salvar = function () {
            if ($scope.Tarefa && $scope.Tarefa.Id) {
                CommonService.tarefa.atualizar({ id: $scope.Tarefa.Id }, $scope.Tarefa).$promise.then(function (d) {
                    if (d) {
                        $scope.CarregarTarefas();
                    }
                });
            }
            else {
                CommonService.tarefa.salvar(null, $scope.Tarefa).$promise.then(function (d) {
                    if (d) {
                        $scope.Tarefa.Id = d.id;
                        $scope.CarregarTarefas();
                    }
                });
            }
        };


        $scope.Excluir = function (ev, tarefa) {
            ev.stopPropagation();
            CommonService.tarefa.excluir({ id: tarefa.Id }).$promise.then(function (d) {
                if (d) {
                    $scope.CarregarTarefas();
                }
            });
        };
    }]);
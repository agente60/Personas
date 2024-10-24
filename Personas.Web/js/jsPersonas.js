var angularPersonas = angular.module('Personas', ['ngRoute'])

angularPersonas.controller('PersonasController', ['$scope', '$http', '$window', function ($scope, $http, $window) {
    $scope.Nombre = 'Manuel';
    $scope.Edad = 25;
    $scope.Email = 'mmanuel@outlook.com';
    $scope.btnDisabled = false;
    $scope.IdPersona = 0;
    $scope.btnDisabledCnsultar = false;

    $scope.init = function () {

    }

    $scope.AgregaPersona = function () {
        $scope.btnDisabled = true;

        $http({
            method: 'POST',
            url: 'https://localhost:44317/api/persona/agregar',
            dataType: 'json',
            data: {
                Nombre: $scope.Nombre,
                Edad: $scope.Edad,
                Email: $scope.Email
            },
        }).then(function successCallback(data) {
            console.log('OK');
            console.log(JSON.stringify(data));
            
            $scope.Nombre = '';
            $scope.Edad = 0;
            $scope.Email = '';
            $scope.btnDisabled = false;
        }, function errorCallback(response) {
            console.log('Error');

            console.log(JSON.stringify(response));

            $scope.btnDisabled = false;
        });
    }

    $scope.ConsultaPersonas = function () {
        $scope.btnDisabledCnsultar = true; 
        var id = '';

        if ($scope.IdPersona > 0) {
            id = $scope.IdPersona;
        }
        else
        {
            id = '';
        }

        $http({
            method: 'GET',
            url: 'https://localhost:44317/api/persona/consultar?id=' + id,
        }).then(function successCallback(data) {
            console.log('OK');
            console.log(JSON.stringify(data));

            $scope.Nombre = '';
            $scope.Edad = 0;
            $scope.Email = '';
            $scope.btnDisabledCnsultar = false; 
        }, function errorCallback(response) {
            console.log('Error');

            console.log(JSON.stringify(response));

            $scope.btnDisabledCnsultar = false; 
        });
    }

}]);
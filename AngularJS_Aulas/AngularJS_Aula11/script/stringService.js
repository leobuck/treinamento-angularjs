/// <reference path="../lib/angular.js" />

app.factory('stringService', function () {
    return {
        processarTexto: function (input) {
            if (!input)
                return input;

            var output = input.toUpperCase();

            return output;
        }
    }
});
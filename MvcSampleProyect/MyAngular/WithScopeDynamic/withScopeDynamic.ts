/// <reference path="../angular.d.ts" />
/// <reference path="../../scripts/jqueryui.d.ts" />
var app = angular.module('myHelloWorld',[]);

app.controller('ModalDemoCtrl', ($scope) => {
    alert($scope.myCosa);
});



$(document).ready(() => {
    // No estamos seguros si con esto nos cargamos la herencia
    // de todos modos de momento no los heredamos
    var injector = angular.injector(['ng','myHelloWorld']);
    injector.invoke(($rootScope, $compile) => {
        var scopeModel = $rootScope.$new();
        $.extend(true, scopeModel, {myCosa:"myCosa" });
        var jElement = $('html');
        $compile(jElement)(scopeModel);
        scopeModel.$apply();
        jElement.on('remove', () => {
            scopeModel.$destroy();
        });
    });
})
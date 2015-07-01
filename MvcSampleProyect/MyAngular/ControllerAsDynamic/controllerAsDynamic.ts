/// <reference path="../angular.d.ts" />
/// <reference path="../../scripts/jqueryui.d.ts" />


var app = angular.module('myHelloWorld',[]);


class MyControllerAsDynamic {
    private myCosa: string;
    private holatarola: string;
    private $scope;

    constructor($scope) {
        // En este caso particular inyectamos el scope porque lo necesitamos
        // no tiene porque ser la norma
        alert($scope.myCosa);
        this.holatarola = "holatarola";
        this.$scope = $scope;
    }

    public elclick() {
        alert(this.myCosa);
    }

    public otroclick() {
        alert(this.holatarola);
        this.holatarola = "josesito";
    }
}

app.controller('ModalDemoCtrl2', MyControllerAsDynamic);

$(document).ready(() => {
    // No estamos seguros si con esto nos cargamos la herencia
    // de todos modos de momento no los heredamos
    var injector = angular.injector(['ng', 'myHelloWorld']);
    injector.invoke(($rootScope, $compile) => {
        var scopeModel = $rootScope.$new();
        $.extend(true, scopeModel, { myCosa: "ValorDeMyCosa" });
        var jElement = $('html');

        $compile(jElement)(scopeModel);
        scopeModel.$apply();
        jElement.on('remove', () => {
            scopeModel.$destroy();
        });
    });
})
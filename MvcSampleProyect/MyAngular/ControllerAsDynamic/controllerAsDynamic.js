/// <reference path="../angular.d.ts" />
/// <reference path="../../scripts/jqueryui.d.ts" />
var app = angular.module('myHelloWorld', []);
var MyControllerAsDynamic = (function () {
    function MyControllerAsDynamic($scope) {
        // En este caso particular inyectamos el scope porque lo necesitamos
        // no tiene porque ser la norma
        alert($scope.myCosa);
        this.holatarola = "holatarola";
        this.$scope = $scope;
    }
    MyControllerAsDynamic.prototype.elclick = function () {
        alert(this.myCosa);
    };
    MyControllerAsDynamic.prototype.otroclick = function () {
        alert(this.holatarola);
        this.holatarola = "josesito";
    };
    return MyControllerAsDynamic;
})();
app.controller('ModalDemoCtrl2', MyControllerAsDynamic);
$(document).ready(function () {
    // No estamos seguros si con esto nos cargamos la herencia
    // de todos modos de momento no los heredamos
    var injector = angular.injector(['ng', 'myHelloWorld']);
    injector.invoke(function ($rootScope, $compile) {
        var scopeModel = $rootScope.$new();
        $.extend(true, scopeModel, { myCosa: "ValorDeMyCosa" });
        var jElement = $('html');
        $compile(jElement)(scopeModel);
        scopeModel.$apply();
        jElement.on('remove', function () {
            scopeModel.$destroy();
        });
    });
});
//# sourceMappingURL=controllerAsDynamic.js.map
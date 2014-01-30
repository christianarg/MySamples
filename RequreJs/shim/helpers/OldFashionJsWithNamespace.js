/* NO BORRAR: Esta clase está hecha A PROPOSITO, para que crear clases nuevas sea copy & paste de ella*/

var Pb = Pb || {};
Pb.Eip = Pb.Eip || {};


(function ($) {
    'use strict';

    var tHelloWorld = function () {

        //#region private functions
        function privateFunction() {
            alert('hola mundo');
        }
        function anotherPrivateFunction() {
            alert('hola mundo');
        }
        //#endregion
        
        function helloWorld() {
        }
                
        helloWorld.prototype = {
            /**
            * Los métodos y propiedades en js van en minúsculas.
            */
            hola: function () {
                privateFunction();
            }
        };
        
        //if (typeOf(QUnit) !== 'undefined') {
        //    // Para los tests de QUnit que necesiten acceder a privadas las publicamos para los tests de QUnit
        //    $.extend(true, helloWorld.prototype, {
        //        anotherPrivateFunctionThatCanBeCalledInQUnitTests: function () {
        //            anotherPrivateFunction();
        //        }
        //    });
        //}

        return {
            // Para hacer singleton hacemos new
            // Para hacer tipo instanciable publicamos el tipo sin new ni nada
            HelloWorld: new helloWorld()
        };
    }();
    // MSM: Proteger ante posible machaque de Pb.Eip.HelloWorld.xxx
    $.extend(true, tHelloWorld.HelloWorld, Pb.Eip.HelloWorld || {});
    $.extend(true, Pb.Eip, tHelloWorld);

})(window.jQuery);
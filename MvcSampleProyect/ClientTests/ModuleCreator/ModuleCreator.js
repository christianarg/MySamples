var Pb = {};

function createModule(namespace, moduleDeclaration) {
    var nameSpaceObject = createNameSpace(namespace);
    
    $.extend(true, nameSpaceObject, moduleDeclaration);
    
    for (var item in moduleDeclaration) {
        $.extend(true, moduleDeclaration[item], nameSpaceObject[item] || {});
    }
}

function createNameSpace(namespace,root) {
    var chunks = namespace.split('.');
    if (!root)
        root = window;
    var current = root;
    for (var i = 0; i < chunks.length; i++) {
        if (!current.hasOwnProperty(chunks[i]))
            current[chunks[i]] = {};
        current = current[chunks[i]];
    }
    return current;
}

test('create Namespace', function () {

    var newNamespace = createNameSpace('Pb.Eip.Pepo');
    ok(Pb.Eip.Pepo);
    ok(Pb.Eip.Pepo = newNamespace);
});



test('create class in Namespace', function () {
    (function ($) {
        'use strict';

        createModule('Pb.Eip.Pepo', function () {

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

            return {
                // Para hacer singleton hacemos new
                // Para hacer tipo instanciable publicamos el tipo sin new ni nada
                HelloWorld: new helloWorld()
            };
        }());
    })(window.jQuery);


    ok(Pb.Eip.Pepo.HelloWorld);
});


test('create instance class in Namespace', function () {
    (function ($) {
        'use strict';

        createModule('Pb.Eip.Pepo', function () {

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

            return {
                // Para hacer singleton hacemos new
                // Para hacer tipo instanciable publicamos el tipo sin new ni nada
                HelloWorld: helloWorld
            };
        }());
    })(window.jQuery);

    var pepoHelloWorld = new Pb.Eip.Pepo.HelloWorld();
    ok(pepoHelloWorld);
});



test('create instance class ARR in Namespace', function () {
    (function ($) {
        'use strict';

        createModule('Pb.Eip.Pepo.HelloWorld', function () {

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

            return helloWorld;
        }());
    })(window.jQuery);

    var pepoHelloWorld = new Pb.Eip.Pepo.HelloWorld();
    ok(!!Pb.Eip.Pepo.HelloWorld.prototype.hola);
    ok(!!pepoHelloWorld.hola);
    ok(Pb.Eip.Pepo.HelloWorld.prototype.hola === pepoHelloWorld.hola);
});

test('create class in Namespace, check no class override', function () {
    (function ($) {
        'use strict';

        createModule('Pb.Eip.Pepo', function () {

            //#region private functions
            function privateFunction() {
                alert('hola mundo');
            }
            function anotherPrivateFunction() {
                alert('hola mundo');
            }
            //#endregion

            function constants() {
            }

            constants.prototype = {
                /**
                * Los métodos y propiedades en js van en minúsculas.
                */
                quePasaTio: function () {
                    privateFunction();
                }
            };

            return {
                // Para hacer singleton hacemos new
                // Para hacer tipo instanciable publicamos el tipo sin new ni nada
                Constants: new constants()
            };
        }());

        createModule('Pb.Eip.Pepo.Constants', function () {

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

            return {
                // Para hacer singleton hacemos new
                // Para hacer tipo instanciable publicamos el tipo sin new ni nada
                HelloWorld: new helloWorld()
            };
        }());

    })(window.jQuery);
    

    ok(Pb.Eip.Pepo.Constants);
    ok(Pb.Eip.Pepo.Constants.quePasaTio);
    ok(Pb.Eip.Pepo.Constants.HelloWorld);
    ok(Pb.Eip.Pepo.Constants.quePasaTio);
});


test('Porongo', function () {

    function myNewClass() {
        
    }
    
    myNewClass.prototype = {
        
    };
    
    var My = {};
    My.NameSpace = {};
    My.NameSpace.myNewClass = {};
    
    My.NameSpace.myNewClass = myNewClass;

    var myClass = new My.NameSpace.myNewClass();
    ok(myClass);
});
/// <reference path="Framework/qunit.js" />
/// <reference path="Framework/sinon.js" />

// Modulo / Clase de pruebas
var MyModule = (function () {
    function myClass() {

    }
    myClass.prototype = {
        isExecuted: false,
        execute: function () {
            this.isExecuted = true;
        }
    };
    return {
        MyClass: myClass, //instancia
        MyClassSingleton: new myClass() // singleton
    };
})();

test('executed', function () {
    // ARRANGE
    var myInstance = new MyModule.MyClass();
    // ACT
    myInstance.execute();
    // ASSERT
    ok(myInstance.isExecuted);
});

test('spy: "Espiar" un objet SIN reemplazar su funcionalidad original', function () {
    // ARRANGE
    var myInstance = new MyModule.MyClass();
    // ACT
    sinon.spy(myInstance, 'execute'); // como estamos probando sinon, es parte del act
    myInstance.execute();
    // ASSERT
    ok(myInstance.isExecuted);
    ok(myInstance.execute.calledOnce);
});

test('stub1: Reemplazar objeto', function () {
    // ARRANGE
    var myInstance = new MyModule.MyClass();
    // ACT
    sinon.stub(myInstance, 'execute'); // como estamos probando sinon, es parte del act
    myInstance.execute();

    // ASSERT
    // GRAN DIFERENCIA CON SPY! El método original no se ejecutará
    ok(!myInstance.isExecuted);
    ok(myInstance.execute.calledOnce);
});

test('stub2: Reemplazar objeto con funcionalidad', function () {
    // ARRANGE
    var myInstance = new MyModule.MyClass();
    var stubExecuted = false;

    // ACT
    sinon.stub(myInstance, 'execute', function () {
        stubExecuted = true;
    });

    myInstance.execute();

    // ASSERT

    ok(stubExecuted);
    ok(myInstance.execute.calledOnce);
});


test("mock: ", 0, function () {
    // ARRANGE
    var myInstance = new MyModule.MyClass();

    // ACT
    var mock = sinon.mock(myInstance, 'execute');
    mock.expects('execute').once();

    myInstance.execute();

    // ASSERT
    mock.verify();
    //ok(myInstance.execute.calledOnce);
});


asyncTest('ajax', function () {
    expect(1);
    $.getJSON('/ajax/index').then(function (data) {
        equal(data.MyProperty, 'Hola Tarola');
        start();
    });
});

module('ajax', {
    teardown: function(){
        sinon.sandbox.restore();
    }
});


asyncTest('Reemplazar ajax', function () {
    expect(1);
    // sinon sandbox permite hacer sinon.sandbox.restore()
    // al final del test, con lo que restauramos todos sos stubs / mocks que hemos guarreado
    sinon.sandbox.stub(jQuery, "ajax", function () {
        var dfd = $.Deferred();
        dfd.resolve({ MyProperty: 'Que onda papa' });
        return dfd;
    });
    //var fakeServer = sinon.fakeServer.create();
    //fakeServer.respondWith("get", "/ajax/index", "{'MyProperty':'Que onda papa'}");

    $.getJSON('/ajax/index').then(function (data) {
        equal(data.MyProperty, 'Que onda papa');
        start();
    });
});
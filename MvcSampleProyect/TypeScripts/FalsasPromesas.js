var falsasPromsas;
(function (falsasPromsas) {
    function ajax(input) {
        return $.get('/ajax/returninput?input=' + input);
    }
    function log(data) {
        if (console) {
            console.log(data);
        }
        $('#output').append('<li>' + data + '</li>');
    }
    function clearLog() {
        if (console) {
            console.clear();
        }
        $('#output').empty();
    }
    function simple() {
        clearLog();
        ajax('a').done(log);
    }
    falsasPromsas.simple = simple;
    function noseEspera() {
        clearLog();
        dobleAjaxDevolviendoElPrimero().then(function () { return log('c'); });
    }
    falsasPromsas.noseEspera = noseEspera;
    function seEspera() {
        clearLog();
        dobleAjaxDevolviendoElSegundo().then(function () { return log('c'); });
    }
    falsasPromsas.seEspera = seEspera;
    function dobleAjaxDevolviendoElPrimero() {
        var promise = ajax('a').then(log);
        promise.then(function () { return ajax('b'); }).then(log);
        return promise;
    }
    function dobleAjaxDevolviendoElSegundo() {
        return ajax('a').then(log).then(function () { return ajax('b'); }).then(log);
    }
})(falsasPromsas || (falsasPromsas = {}));
//# sourceMappingURL=FalsasPromesas.js.map
module falsasPromsas {

    function ajax(input: string): JQueryPromise<any> {
        return $.get('/ajax/returninput?input=' + input);
    }
    function log(data: string) {
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

    export function simple() {
        clearLog();
        ajax('a').done(log);
    }

    export function noseEspera() {
        clearLog();
        dobleAjaxDevolviendoElPrimero().then(() => log('c'));
    }

    export function seEspera() {
        clearLog();
        dobleAjaxDevolviendoElSegundo().then(() => log('c'));
    }

    function dobleAjaxDevolviendoElPrimero(): JQueryPromise<any> {
        var promise = ajax('a').then(log);
        promise.then(() => ajax('b')).then(log);
        return promise;
    }

    function dobleAjaxDevolviendoElSegundo(): JQueryPromise<any> {
        return ajax('a').then(log).then(() => ajax('b')).then(log);
    }
}
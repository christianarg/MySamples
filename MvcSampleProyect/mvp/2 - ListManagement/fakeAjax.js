/*
CLASE ULTRA MEGA HIPER GUARRA QUE SIMULA EL SEVIDOR NO HACER CASO JODER NO ES EL MOTIVO DEL EJEMPLO
HIJOS DE PUTA!
*/
var lastcontentId = 2;

function fakeAjax(action, params) {
    var dfd = $.Deferred();
    
    if (action == 'createElement') {
        var newContent = {
            contentId: ++lastcontentId,
            title: 'Nuevo contenido',
            body: 'Cuerpo del nuevo contenido'
        };
        dfd.resolve(newContent);
    }
    else {
        dfd.resolve();
    }
    $('#elservidor').html('Enviada petición joya: Action: ' + action + " Params: " + params);
    return dfd.promise();
}
// Spaguetti: Dom, acciones, llamadas ajax, datos, to junto

var ListManagement = (function () {
    
    function createElement(newContent) {
        
        fakeAjax('createElement', 'newContent').then(function () {
            var html = $('<div class="contenido"><h2></h2><div></div>');

            html.find('h2').text(newContent.title);
            html.find('div').text(newContent.body);
            html.attr('data-contentId', newContent.contentId);

            $('#listacontenidos').append(html);
        });
    }
    
    function elementReordered (event, ui) {
        var contentId = $(ui.item).attr('data-contentId');
        fakeAjax('reorderElement', contentId);
    }
    
    function ListManager() {
        
    }
    
    ListManager.prototype = {
        
        initialize: function () {
            // Activamos el plug in de sortable
            var jListContenidos = $('#listacontenidos');
            jListContenidos.sortable({
                update: elementReordered
            });
            jListContenidos.disableSelection();
            // Añadir el botón de crear
            var jcreateButton = $('<a id="nuevocontenido" href="javascript:void(0)">Añadir contenido</a>');
            jListContenidos.after(jcreateButton);
            jcreateButton.click(createElement);
        }
    };
    
    return {
        ListManager: new ListManager() // singleton
    };
})();


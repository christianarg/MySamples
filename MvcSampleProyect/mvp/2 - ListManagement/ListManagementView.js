/// <reference path="../../Scripts/jquery-2.0.3.js" />
function ListManagementView(theSelector) {
    this.selector = theSelector;
    this.jcreateButton = $('<a id="nuevocontenido" href="javascript:void(0)">Añadir contenido</a>');
    this.reorderPresenterAction = null;
}
ListManagementView.prototype = {
    elementReordered: function (event, ui) {
        var contentId = $(ui.item).attr('data-contentId');
        this.reorderPresenterAction(contentId);
    },
    
    addReorderHandler: function (reorderPresenterAction) {
        this.reorderPresenterAction = reorderPresenterAction;
    },
    
    addCreateHandler: function(createElementPresenterAction) {
        $(this.jcreateButton).click(function () {
            createElementPresenterAction();
        });
    },
    
    createElement: function(newContent) {
        var html = $('<div class="contenido"><h2></h2><div></div>');
        
        html.find('h2').text(newContent.title);
        html.find('div').text(newContent.body);
        html.attr('data-contentId', newContent.contentId);
        
        $(this.selector).append(html);
    },
    
    initialize: function () {
        var self = this;
        // Activamos el plug in de sortable
        $(this.selector).sortable({
            update: $.proxy(self.elementReordered,self)
        });
        $(this.selector).disableSelection();
        
        // Añadir el botón de crear
        $(this.selector).after(this.jcreateButton);
    }
}
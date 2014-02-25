/// <reference path="../../Scripts/jquery-2.0.3.js" />
/// <reference path="ListManagementView.js" />
function ListManagementPresenter(theView) {
    this.view = theView;
    this.view.addReorderHandler($.proxy(this.reorderelement, this));
    this.view.addCreateHandler($.proxy(this.createElement, this));
}

ListManagementPresenter.prototype = {
    initialize: function() {
        this.view.initialize();
    },
    
    reorderelement: function (contentId) {
        fakeAjax('reorderElement', contentId);
    },
    
    createElement: function () {
        var self = this;
        fakeAjax('createElement').then($.proxy(self.view.createElement, self.view));
    }
}
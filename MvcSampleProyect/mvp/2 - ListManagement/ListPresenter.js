/// <reference path="../../Scripts/jquery-2.0.3.js" />

function ListPresenter(theView) {
    this.view = theView;
}

ListPresenter.prototype = {
    bind: function() {
        this.view.bind();
    }
    
}
/// <reference path="../../Scripts/jquery-2.0.3.js" />

function ListView(theSelector) {
    this.selector = theSelector;
}
ListView.prototype = {

    bind: function () {
        $(this.selector).sortable();
        $(this.selector).disableSelection();
    }
}
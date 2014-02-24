function TaskView(){
    this.html = $("<div><input type='checkbox'/><label></label></li></div>");
}

TaskView.prototype = {
    getHtml: function () {
        return this.html;
    },
    setModel: function (model) {
        this.html.find("input").attr("id", model.getID());
        this.html.find("label").attr("for", model.getID());
        this.html.find("label").html(model.getText());
    },
    addCheckedHandler: function (handler) {
        this.html.find("input").click(handler);
    },
    remove: function () {
        this.html.remove();
    }
}
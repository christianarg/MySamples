/// <reference path="../../Scripts/jquery-2.0.3.js" />


function TaskListView() {

    this.html =  $("<div>" +
                "<h1>Awesome MVP task list</h1>" +
                    "<fieldset><legend>Don't forget!</legend>" +
                        "<ul id='tasklist'></ul>" +
                    "</fieldset>" +
                "<h2>Add a new task:</h2>" +
                "What do you need to do? <input id='taskinput' placeholder='I need to do…'/> <input id='submittask' type='submit' value='Add'/>" +
                "</div>");
}

TaskListView.prototype = {
    getHtml: function () {
        return this.html;
    },
    
    addCreateTaskHandler: function (presenterAction) {
        var clickFunction = $.proxy(function () {
            
            var newTaskTitle = this.html.find("#taskinput").val();
            this.html.find("#taskinput").val("");
            presenterAction(newTaskTitle);
            
        }, this);
        
        this.html.find("#submittask").click(clickFunction);
    },
    
    addTask: function (taskView) {
        this.html.find("#tasklist").append(taskView.getHtml());
    },
    
    show: function() {
        $("body").append(this.getHtml());
    }
}